using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PhaseShift.Library.Locations;

namespace PhaseShift.Library.Models
{
    public class Library
    {
        public ICollection<Track> Items { get; } = new List<Track>();
        public DirectoryInfo Location { get; }

        public Library(DirectoryInfo location)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        public void AddSong(Track item)
        {
            Items.Add(item);
        }
    }
}