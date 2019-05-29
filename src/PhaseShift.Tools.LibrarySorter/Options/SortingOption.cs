using PhaseShift.Library.Models;
using System;

namespace PhaseShift.Tools.LibrarySorter.Options
{
    public class SortingOption
    {
        public Func<Track, string> SortDelegate { get; }

        public SortingOption(Func<Track, string> sortDelegate)
        {
            SortDelegate = sortDelegate ?? throw new ArgumentNullException(nameof(sortDelegate));
        }
    }
}
