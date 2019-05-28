using PhaseShift.Library.Models;
using PhaseShift.Library.Parsing.Ini;
using PhaseShift.Library.Parsing.Track;
using Xunit;

namespace PhaseShift.Library.Parsing.Tests
{
    public class TrackParserTests
    {
        [Fact]
        public void Parse_WithValidSong_InsertsValidValues()
        {
            //Arrange
            var input = @"[song]
name = Thunderstruck (Live)
artist = AC/DC
album = Live
diff_guitar = 4
diff_vocals = 2
diff_drums = 3
diff_bass = 1
diff_guitar_real = -1
diff_drums_real = 3
diff_bass_real = -1";
            var sut = CreateSut();

            //Act
            var track = sut.Parse(input);

            //Assert
            Assert.Equal("Thunderstruck (Live)", track.Song.Name);
            Assert.Equal("AC/DC", track.Song.Author);
            Assert.Equal("Live", track.Song.Album);
            Assert.Equal(Difficulty.Expert, track.GuitarDifficulty);
            Assert.Equal(Difficulty.Unavailable, track.RealGuitarDifficulty);
            Assert.Equal(Difficulty.Hard, track.DrumDifficulty);
            Assert.Equal(Difficulty.Hard, track.RealDrumDifficulty);
            Assert.Equal(Difficulty.Easy, track.BassDifficulty);
            Assert.Equal(Difficulty.Unavailable, track.RealBassDifficulty);
        } 


        public ITrackParser CreateSut()
        {
            return new TrackParser(new IniFormatParser());
        }
    }
}
