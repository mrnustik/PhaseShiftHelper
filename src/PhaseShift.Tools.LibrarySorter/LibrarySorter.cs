using System;
using PhaseShift.Library.Models;
using PhaseShift.Tools.LibrarySorter.Options;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhaseShift.Tools.LibrarySorter
{
    public class LibrarySorter : ILibrarySorter
    {
        private readonly IDirectoryCleaner directoryCleaner;
        private readonly IDirectoryCapitalizer dierctoryCapitalizer;
        public LibrarySorter(IDirectoryCleaner directoryCleaner, IDirectoryCapitalizer dierctoryCapitalizer)
        {
            this.directoryCleaner = directoryCleaner;
            this.dierctoryCapitalizer = dierctoryCapitalizer;
        }

        public void Sort(Library.Models.Library library, params SortingOption[] options)
        {
            foreach (var track in library.Items)
            {
                MoveTrackToLocation(library, options, track);
            }
            directoryCleaner.ClearEmptyDirectories(library.Location);
            dierctoryCapitalizer.CapitalizeDirectories(library.Location);
        }

        private void MoveTrackToLocation(Library.Models.Library library, SortingOption[] options, Track track)
        {
            var destinationPath = CreateNewPath(library.Location.FullName, track, options);
            var trackFiles = track.Location.Directory.GetFiles();
            foreach (var file in trackFiles)
            {
                file.MoveTo(destinationPath);
            }
        }

        private string CreateNewPath(string libraryRoot, Track track, SortingOption[] options)
        {
            var newPath = libraryRoot;
            foreach (var option in options)
            {
                newPath = Path.Combine(newPath, option.SortDelegate.Invoke(track));
            }
            return newPath;
        }
    }
}
