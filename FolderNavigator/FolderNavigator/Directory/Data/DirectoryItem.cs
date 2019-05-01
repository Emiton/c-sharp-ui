using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderNavigator.Directory.Data
{
    /// <summary>
    ///     Informtion about a directory item (drive, file, folder)
    /// </summary>
    public class DirectoryItem
    {
        // The file type of the item
        public DirectoryItemType Type { get; set; }
        // Absolute path to item
        public string FullPath { get; set; }

        public string Name
        {
            get
            {
                return this.Type == DirectoryItemType.Drive
                    ? this.FullPath
                    : DirectoryStructure.GetFileFolderName(this.FullPath);
            }
        }
    }
}
