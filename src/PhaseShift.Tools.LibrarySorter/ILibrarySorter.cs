using PhaseShift.Library.Models;
using PhaseShift.Tools.LibrarySorter.Options;

namespace PhaseShift.Tools.LibrarySorter
{
    public interface ILibrarySorter
    {
        void Sort(Library.Models.Library library, params SortingOption[] options);
    }
}