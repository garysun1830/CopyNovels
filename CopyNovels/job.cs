using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ShareLib17;

namespace CopyNovel
{

    public interface INovelJob
    {
        string DoneMessage { get; }
        void execute(List<string> SourceDirs);
        void execute(string SourceDir);
    }

    public class NovelJob
    {

        public void execute(List<string> SourceDirs)
        {
            doExecute(SourceDirs);
        }

        protected virtual void doExecute(List<string> SourceDirs)
        {
        }

        public void execute(string SourceDir)
        {
            doExecute(SourceDir);
        }

        protected virtual void doExecute(string SourceDir)
        {
        }

    }

    public class CopyNovelJob : NovelJob, INovelJob
    {

        private readonly string destDir;
        public string DoneMessage { get { return "Novels copied."; } }

        public CopyNovelJob(string DestDir)
        {
            destDir = DestDir;
        }

        protected override void doExecute(List<string> SourceDirs)
        {
            SourceDirs.ForEach(dir => copyDir(dir));
        }

        private void copyDir(string SourceDir)
        {
            string toDir = Path.Combine(destDir, Path.GetFileName(SourceDir));
            Directory.CreateDirectory(toDir);
            List<string> files = Directory.GetFiles(SourceDir).ToList();
            files = files.Select(s => Path.GetFileName(s)).ToList();
            files.Sort();
            files.ForEach(delegate (string file)
            {
                copyFile(Path.Combine(SourceDir, file), toDir);
            });
        }

        private void copyFile(string SourceFile, string ToFolder)
        {
            string fn = Path.GetFileName(SourceFile);
            fn = Path.Combine(ToFolder, fn);
            File.Copy(SourceFile, fn);
        }

    }

    public class RenameNovelJob : NovelJob, INovelJob
    {
        public RenameNovelJob() { }
        public string DoneMessage { get { return "Novel names fixed."; } }

        protected override void doExecute(List<string> SourceDirs)
        {
            SourceDirs.ForEach(delegate (string dir)
            {
                doExecute(Directory.GetDirectories(dir).ToList());
                renameDir(dir);
            });
        }

        private void renameDir(string dir)
        {
            string fn = Path.GetFileName(dir);
            if (!Regex.IsMatch(fn, "^f-", RegexOptions.IgnoreCase))
                return;
            fn = Regex.Replace(fn, "^f-", "", RegexOptions.IgnoreCase);
            fn = Path.Combine(Path.GetDirectoryName(dir), fn);
            Directory.Move(dir, fn);
        }

    }

    public class AlbumNovelJob : NovelJob, INovelJob
    {
        public string DoneMessage { get { return "Novel album changed."; } }

        protected override void doExecute(List<string> SourceDirs)
        {
            SourceDirs.ForEach(delegate (string dir)
            {
                RenameAlbumDir(dir);
                doExecute(Directory.GetDirectories(dir).ToList());
            });
        }

        private void RenameAlbumDir(string dir)
        {
            string dirName = Path.GetFileName(dir);
            string album = Regex.Replace(dirName, "-\\d+$", "");
            List<string> files = Directory.EnumerateFiles(dir).ToList();
            files.ForEach(delegate (string fn)
            {
                MP3 mp3 = new MP3(fn);
                mp3.Album = album;
                string fnint = Path.GetFileNameWithoutExtension(fn);
                int title;
                if (int.TryParse(fnint, out title))
                    mp3.Title = fnint;
                mp3.Save();
            });
        }

    }

    public class DelNullFolderNovelJob : NovelJob, INovelJob
    {
        public string DoneMessage { get { return "Empty folders removed."; } }

        protected override void doExecute(List<string> SourceDirs)
        {
            SourceDirs.ForEach(delegate (string dir)
            {
                doExecute(Directory.GetDirectories(dir).ToList());
                DelNullFolder(dir);
            });
        }

        private void DelNullFolder(string dir)
        {
            if (Directory.GetDirectories(dir).Count() > 0)
                return;
            if (Directory.GetFiles(dir).Count() > 0)
                return;
            Directory.Delete(dir);
        }

    }
    public class MoveZippedNovelJob : NovelJob, INovelJob
    {
        public string DoneMessage { get { return "Zipped folders moved."; } }

        protected override void doExecute(List<string> SourceDirs)
        {
            SourceDirs.ForEach(delegate (string dir)
            {
                doExecute(Directory.GetDirectories(dir).ToList());
                MoveZipped(dir);
            });
        }

        private void MoveZipped(string dir)
        {
            if (Directory.GetFiles(dir).Count() > 0)
                return;
            List<string> subs = Directory.GetDirectories(dir).ToList();
            if (subs.Count != 1)
                return;
            string src = subs[0];
            string dn = Path.GetFileName(src);
            string dest = Path.GetDirectoryName(dir);
            dest = Path.Combine(dest, dn);
            if (Directory.Exists(dest))
                return;
            Directory.Move(src, dest);
        }

    }
    public class MergeZippedNovelJob : NovelJob, INovelJob
    {
        private string keyName;
        private string keyDir;
        public string DoneMessage { get { return "Zipped folders merged."; } }

        private bool isKeyName(string text)
        {
            string[] filter = new string[] { "²¥Òô" };
            bool result = true;
            filter.ToList().ForEach(s => result &= !text.ToLower().Contains(s.ToLower()));
            if (!result)
                return false;
            result = !Regex.IsMatch(text, "\\d+»Ø");
            return result;
        }
        private string getKeyName(string dir)
        {
            string[] filter = new string[] { "¼¯", "£¨", "£©", "¡¶", "¡·", "£¨", "£©" };
            char[] deli = new char[] { '[', ']', '{', '}', '(', ')', '-' };
            string result = Path.GetFileName(dir);
            result = Regex.Replace(result, "\\d+-\\d+", "");
            filter.ToList().ForEach(s => result = result.Replace(s, "["));
            result = Regex.Replace(result, "^\\d+", "");
            result = Regex.Replace(result, "\\d+$", "");
            result = result.Split(new char[] { '[', ']', '{', '}', '(', ')', '-' })
                        .Where(s => !string.IsNullOrWhiteSpace(s) && !Regex.IsMatch(s, "^\\d+$"))
                        .Select(s => s.Trim())
                        .FirstOrDefault();
            return result;
        }
        protected override void doExecute(string SourceDir)
        {
            keyName = getKeyName(Path.GetFileName(SourceDir));
            if (string.IsNullOrWhiteSpace(keyName))
                return;
            keyDir = SourceDir;
            string pdir = Path.GetDirectoryName(SourceDir);
            Directory.GetDirectories(pdir, "*" + keyName + "*", SearchOption.TopDirectoryOnly).ToList().ForEach(dir =>
            {
                MergeZipped(dir);
            });
        }

        private void MergeZipped(string dir)
        {
            if (dir == keyDir)
                return;
            string keyn = getKeyName(dir);
            if (string.Compare(keyn, keyName, true) != 0)
                return;
            Directory.GetFiles(dir).ToList().ForEach(s =>
            {
                string fn = Path.GetFileName(s);
                string dest = Path.Combine(keyDir, fn);
                try
                {
                    if (!File.Exists(dest))
                        Directory.Move(s, dest);
                }
                catch { }
            });
        }

    }
    public class RootZipNovelJob : NovelJob, INovelJob
    {
        private string rootDir;
        public string DoneMessage { get { return "Zip files moved."; } }

        protected override void doExecute(List<string> SourceDirs)
        {
            if (rootDir == null)
                rootDir = SourceDirs.FirstOrDefault();
            SourceDirs.ForEach(delegate (string dir)
            {
                doExecute(Directory.GetDirectories(dir).ToList());
                RootZip(dir);
            });
        }

        private void RootZip(string dir)
        {
            if (dir == rootDir)
                return;
            Directory.GetFiles(dir).ToList().ForEach(s =>
            {
                if (Path.GetExtension(s).ToLower() != ".zip")
                    return;
                string fn = Path.GetFileName(s);
                string dest = Path.Combine(rootDir, fn);
                if (File.Exists(dest))
                    throw new Exception(string.Format("{0} already exists.\nSource: {1}", dest, s));
                Directory.Move(s, dest);
            });
        }

    }

}