using PhaseShift.Library.Models;
using PhaseShift.Library.Parsing.Ini;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhaseShift.Library.Parsing.Track
{
    public class TrackParser : ITrackParser
    {
        private readonly IIniFormatParser iniFormatParser;

        public TrackParser(IIniFormatParser iniFormatParser)
        {
            this.iniFormatParser = iniFormatParser ?? throw new ArgumentNullException(nameof(iniFormatParser));
        }

        public Models.Track Parse(string text)
        {
            var content = iniFormatParser.Parse(text);
            var song = ParseSongInfo(content);
            return new Models.Track(song,
                ParseDifficulty(content["diff_guitar"]),
                ParseDifficulty(content["diff_guitar_real"]),
                ParseDifficulty(content["diff_drums"]),
                ParseDifficulty(content["diff_drums_real"]),
                ParseDifficulty(content["diff_bass"]),
                ParseDifficulty(content["diff_bass_real"]));
        }

        private Song ParseSongInfo(Dictionary<string, string> content)
        {
            return new Song(content["name"], content["artist"], content["album"]);
        }

        private Difficulty ParseDifficulty(string value)
        {
            return (Difficulty)int.Parse(value);
        }
    }
}
