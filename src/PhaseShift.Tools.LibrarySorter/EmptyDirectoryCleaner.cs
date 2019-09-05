using System.IO;
using System.Linq;

namespace PhaseShift.Tools.LibrarySorter
{
    public class EmptyDirectoryCleaner : IDirectoryCleaner
    {
        public void ClearEmptyDirectories(DirectoryInfo directoryInfo)
        {
            CleanEmptyFoldersInDirectory(directoryInfo);
        }

        private void CleanEmptyFoldersInDirectory(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.EnumerateFiles().Any()) return;
            foreach (var childDirectory in directoryInfo.EnumerateDirectories())
            {
                CleanEmptyFoldersInDirectory(childDirectory);
            }

            if (!directoryInfo.EnumerateFileSystemInfos().Any())
            {
                directoryInfo.Delete();
            }
        }
    }
}