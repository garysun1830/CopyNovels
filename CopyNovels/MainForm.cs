using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace CopyNovel
{
    public partial class formMain : Form
    {

        private string sourceDir;
        private string destDir;
        private Stack<string> sourceStack;
        private bool clickStack;

        public formMain()
        {
            InitializeComponent();
            sourceStack = new Stack<string>();
        }

        private void initFolderList()
        {
            createView(fldSource, sourceDir);
            createView(fldDest);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initFolderList();
        }

        private void createView(TreeView view)
        {
            createView(view, null);
        }

        private void createView(TreeView view, string root)
        {
            view.Nodes.Clear();
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                TreeNode tn = new TreeNode();
                string nodeText = string.Empty;
                if (di.IsReady)
                {
                    nodeText = string.Format(@"{0} ({1}:)", di.Name, di.VolumeLabel);
                }
                else
                {
                    nodeText = string.Format(@"({0}:)", di.Name);
                }
                tn.Text = nodeText;
                tn.Name = di.Name;
                view.Nodes.Add(AddChildNodes(tn, false));
            }
            if (view.Nodes.Count > 0)
                view.SelectedNode = view.Nodes[0];
        }

        private void tvFolders_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                AddChildNodes(node, false);
            }
        }

        private TreeNode AddChildNodes(TreeNode node, bool final)
        {
            if (final)
            {
                return node;
            }
            DirectoryInfo parentDI = new DirectoryInfo(node.Name);

            if (parentDI.FullName.Length == 3)
            {
                DriveInfo di = new DriveInfo(parentDI.FullName);
                if (!di.IsReady)
                {
                    return node;
                }
            }

            DirectoryInfo[] arrDI = null;
            try
            {
                arrDI = parentDI.GetDirectories();
            }
            catch
            {
            }
            if (arrDI != null)
            {
                foreach (DirectoryInfo di in arrDI)
                {
                    TreeNode tn = new TreeNode();
                    string nodeText = string.Empty;

                    tn.Text = di.Name;
                    tn.Name = di.FullName;
                    node.Nodes.Add(AddChildNodes(tn, true));
                }
            }
            return node;
        }

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (sender == fldSource)
            {
                sourceDir = e.Node.Name;
                lblSrc.Text = sourceDir;
                listSub(sourceDir, lstSubSource);
                if (!clickStack)
                {
                    sourceStack.Push(sourceDir);
                }
                btnSrcBack.Enabled = sourceStack.Count > 1;
                btnSourceUp.Enabled = !string.IsNullOrWhiteSpace(Path.GetDirectoryName(sourceDir));
                clickStack = false;
            }
            else
            {
                destDir = e.Node.Name;
                lblDest.Text = destDir;
                listSub(destDir, lstSubDest);
            }
        }

        private void listSub(string root, ListView SubFolder)
        {
            SubFolder.Items.Clear();
            try
            {
                List<string> folders = Directory.GetDirectories(root).ToList();
                folders.ForEach(delegate (string fld)
                {
                    SubFolder.Items.Add(fld.Replace(root, "").Trim(new char[] { '\\' }));
                });
            }
            catch (Exception ex)
            {
                SubFolder.Items.Add(ex.Message);
            }
        }

        private void lstSubSource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstSubSource.FocusedItem == null)
                return;
            string text = lstSubSource.FocusedItem.Text;
            foreach (TreeNode node in fldSource.SelectedNode.Nodes)
            {
                if (node.Text == text)
                    fldSource.SelectedNode = node;
            }
        }

        private void doJob(INovelJob job)
        {
            doJob(job, true);
        }

        private void doJob(INovelJob job, bool Loop)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (Loop)
                {
                    if (lstSubSource.SelectedItems.Count == 0)
                        return;
                    List<string> dirs = new List<string>();
                    foreach (ListViewItem item in lstSubSource.SelectedItems)
                        dirs.Add(Path.Combine(sourceDir, item.Text));
                    job.execute(dirs);
                }
                else
                {
                    job.execute(Path.Combine(sourceDir, ((ListViewItem)lstSubSource.SelectedItems[0]).Text));
                }
                MessageBox.Show(job.DoneMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(destDir))
                return;
            INovelJob job = new CopyNovelJob(destDir);
            doJob(job);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initFolderList();
        }

        private void btnNoF_Click(object sender, EventArgs e)
        {
            INovelJob job = new RenameNovelJob();
            doJob(job);
        }

        private void setSourceDir(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return;
            TreeNode node = fldSource.Nodes.Find(source, true).FirstOrDefault();
            if (node == null)
                return;
            fldSource.SelectedNode = node;
        }


        private void btnSrcBack_Click(object sender, EventArgs e)
        {
            clickStack = true;
            sourceStack.Pop();
            string src = sourceStack.FirstOrDefault();
            setSourceDir(src);
        }

        private void btnSourceUp_Click(object sender, EventArgs e)
        {
            setSourceDir(Path.GetDirectoryName(sourceDir));
        }

        private void btnAlbum_Click(object sender, EventArgs e)
        {
            INovelJob job = new AlbumNovelJob();
            doJob(job);
        }

        private void lstSubSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSubDest.SelectedItems.Count == 0)
                return;
            string dest = Path.Combine(destDir, lstSubDest.SelectedItems[0].Text);

        }

        private void btnDelNullFolder_Click(object sender, EventArgs e)
        {
            INovelJob job = new DelNullFolderNovelJob();
            doJob(job);
        }

        private void btnMoveZip_Click(object sender, EventArgs e)
        {
            INovelJob job = new MoveZippedNovelJob();
            doJob(job);
        }

        private void btnMergeZip_Click(object sender, EventArgs e)
        {
            INovelJob job = new MergeZippedNovelJob();
            doJob(job, false);
        }

        private void btnRootZip_Click(object sender, EventArgs e)
        {
            INovelJob job = new RootZipNovelJob();
            doJob(job);
        }
    }
}

