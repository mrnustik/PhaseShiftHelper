using System.Collections.Generic;
using System.IO;

namespace PhaseShift.Library.Parsing.Search
{
    public interface ITrackConfigurationSearcher
    {
        IEnumerable<FileInfo> FindSongConfigurationFiles(string libraryPath);
    }
}