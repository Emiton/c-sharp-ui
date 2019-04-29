using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderNavigator.Directory.Data
{
    public enum DirectoryItemType
    {
        // Logical Drive
        Drive,
        // Physical File
        File,
        // Folder within file explorer
        Folder
    }
}
