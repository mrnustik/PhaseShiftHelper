using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhaseShift.Library.Parsing.Search
{
    public class TrackConfigurationSearcher : ITrackConfigurationSearcher
    {
        public IEnumerable<FileInfo> FindSongConfigurationFiles(string libraryPath)
        {
            var libraryDirectory = new DirectoryInfo(libraryPath);
            return FindSongConfigurationsInFolder(libraryDirectory);
        }

        private IEnumerable<FileInfo> FindSongConfigurationsInFolder(DirectoryInfo directory)
        {
            var result = new List<FileInfo>();
            foreach (var entry in directory.EnumerateFileSystemInfos())
            {
                if (IsDirectory(entry))
                {
                    result.AddRange(FindSongConfigurationsInFolder(new DirectoryInfo(entry.FullName)));
                }
                else
                {
                    if (IsConfigurationFile(entry))
                    {
                        result.Add(new FileInfo(entry.FullName));
                    }
                }
            }
            return result;
        }

        private bool IsDirectory(FileSystemInfo entry)
        {
            return (entry.Attributes & FileAttributes.Directory) != 0;
        }

        private bool IsConfigurationFile(FileSystemInfo entry)
        {
            return entry.Name == "song.ini";
        }
    }
}
