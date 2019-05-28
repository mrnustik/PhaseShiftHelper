using System.Collections.Generic;
using System.Linq;
using PhaseShift.Library.Locations;

namespace PhaseShift.Library.Models
{
    public class Library
    {
        public ICollection<Track> Items { get; } = new List<Track>();
        public IContainerLocation Location { get; }

        public void AddSong(Track item)
        {
            Items.Add(item);
        }
    }
}