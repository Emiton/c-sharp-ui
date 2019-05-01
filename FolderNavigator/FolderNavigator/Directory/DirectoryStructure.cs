using System.Collections.Generic;
using System.Linq;
using FolderNavigator.Directory.Data;
using Path = System.IO.Path;

namespace FolderNavigator.Directory
{
    /// <summary>
    ///     A helper class to query information about directories
    /// </summary>
    class DirectoryStructure
    {
        /// <summary>
        ///     Gets all logical drives on computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem {  FullPath = drive, Type = DirectoryItemType.Drive}).ToList();
        }

        /// <summary>
        ///     Get top level content from directory
        /// </summary>
        /// <param name="fullpath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContent(string fullpath)
        {
            // Create empty list
            var items = new List<DirectoryItem>();
            #region Get Folders

            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem{ FullPath = dir, Type = DirectoryItemType.Folder}));
            }
            catch { }

     
            #endregion

            #region Get Files

            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem{FullPath = file, Type = DirectoryItemType.File}));
            }
            catch { }

            #endregion

            return items;
        }
        #region Helper Functions
        /// <summary>
        ///     Find file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var normalizedPath = path.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
