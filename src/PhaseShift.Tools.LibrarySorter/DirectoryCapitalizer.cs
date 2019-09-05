using System.IO;

namespace PhaseShift.Tools.LibrarySorter
{
    public interface IDirectoryCapitalizer
    {
        void CapitalizeDirectories(DirectoryInfo directoryInfo);
    }

    public class DirectoryCapitalizer : IDirectoryCapitalizer
    {
        public void CapitalizeDirectories(DirectoryInfo directoryInfo)
        {
            foreach (var directory in directoryInfo.EnumerateDirectories())
            {
                if (char.IsLower(directory.Name[0]))
                {
                    string newName = directory.Name[0] + directory.Name.Substring(1);
                    directory.MoveTo(Path.Combine(directory.Parent.FullName, newName));
                }
            }
        }
    }
}