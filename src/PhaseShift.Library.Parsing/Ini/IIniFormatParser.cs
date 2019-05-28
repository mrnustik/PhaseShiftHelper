using System.Collections.Generic;

namespace PhaseShift.Library.Parsing.Ini
{
    public interface IIniFormatParser
    {
        Dictionary<string, string> Parse(string text);
    }
}