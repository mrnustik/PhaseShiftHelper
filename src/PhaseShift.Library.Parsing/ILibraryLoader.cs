using PhaseShift.Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhaseShift.Library.Parsing
{
    public interface ILibraryLoader
    {
        Models.Library LoadLibrary(string path);
    }
}
