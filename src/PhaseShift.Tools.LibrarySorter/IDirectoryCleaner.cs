using System.IO;

namespace PhaseShift.Tools.LibrarySorter
{
    public interface IDirectoryCleaner
    {
        void ClearEmptyDirectories(DirectoryInfo directoryInfo);
    }
}