using PhaseShift.Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhaseShift.Library.Parsing
{
    interface ILibraryLoader
    {
        Models.Library LoadLibrary(string path);
    }
}
