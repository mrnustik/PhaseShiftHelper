using System;
using System.Collections.Generic;
using System.Text;

namespace PhaseShift.Library.Models
{
    public struct Song
    {
        public string Name { get; }
        public string Author { get; }
        public string Album { get; }

        public Song(string name, string author, string album)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Author = author ?? throw new ArgumentNullException(nameof(author));
            Album = album ?? throw new ArgumentNullException(nameof(album));
        }
    }
}
