using PhaseShift.Library.Parsing.Search;
using PhaseShift.Library.Parsing.Track;
using System;
using System.IO;

namespace PhaseShift.Library.Parsing
{
    public class LibraryLoader : ILibraryLoader
    {
        private readonly ITrackConfigurationSearcher trackConfigurationSearcher;
        private readonly ITrackParser trackParser;

        public LibraryLoader(ITrackConfigurationSearcher trackConfigurationSearcher, ITrackParser trackParser)
        {
            this.trackConfigurationSearcher = trackConfigurationSearcher ?? throw new ArgumentNullException(nameof(trackConfigurationSearcher));
            this.trackParser = trackParser ?? throw new ArgumentNullException(nameof(trackParser));
        }

        public Models.Library LoadLibrary(string path)
        {
            var trackFiles = trackConfigurationSearcher.FindSongConfigurationFiles(path);
            var library = new Models.Library(new DirectoryInfo(path));
            foreach (var file in trackFiles)
            {
                var text = File.ReadAllText(file.FullName);
                Models.Track item = trackParser.Parse(text);
                item.Location = file;
                library.AddSong(item);
            }
            return library;
        }
    }
}
