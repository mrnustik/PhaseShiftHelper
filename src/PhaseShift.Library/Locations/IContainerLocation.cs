using System;
using System.Collections.Generic;
using System.Text;

namespace PhaseShift.Library.Locations
{
    public interface IContainerLocation
    {
        void Move(IContainerLocation destination);
    }
}
