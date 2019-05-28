using PhaseShift.Library.Parsing.Exceptions;
using System;
using System.Collections.Generic;

namespace PhaseShift.Library.Parsing.Ini
{
    public class IniFormatParser : IIniFormatParser
    {
        public Dictionary<string, string> Parse(string text)
        {
            var allLines = GetAllLines(text);
            var output = new Dictionary<string, string>();
            foreach (var line in allLines)
            {
                if (IsCommentLine(line)) continue;
                if (IsSectionLine(line)) continue;
                var parsedLine = ParseLine(line);
                output.Add(parsedLine.key, parsedLine.value);
            }
            return output;
        }

        private bool IsSectionLine(string line)
        {
            return line.StartsWith("[") && line.EndsWith("]");
        }

        private bool IsCommentLine(string line)
        {
            return line.StartsWith("#") || line.StartsWith("!");
        }

        private (string key, string value) ParseLine(string line)
        {
            var separator = line.IndexOf('=');
            if (separator < 0) throw new InvalidIniFileException($"Missing separator on line: {line}");
            return (line.Substring(0, separator).Trim(), line.Substring(separator + 1).Trim());
        }

        private IEnumerable<string> GetAllLines(string text)
        {
            return text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
