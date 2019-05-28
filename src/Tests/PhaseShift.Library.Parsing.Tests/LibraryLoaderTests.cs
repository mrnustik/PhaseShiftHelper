using PhaseShift.Library.Parsing.Ini;
using PhaseShift.Library.Parsing.Search;
using PhaseShift.Library.Parsing.Track;
using System.Linq;
using Xunit;

namespace PhaseShift.Library.Parsing.Tests
{
    public class LibraryLoaderTests : TestBase
    {
        [Fact]
        public void Find_InParentDirectory_HasValidValues()
        {
            var sut = new LibraryLoader(new TrackConfigurationSearcher(), new TrackParser(new IniFormatParser()));

            var library = sut.LoadLibrary(TestLibraryPath);

            Assert.Equal(2, library.Items.Count());
            Assert.All(library.Items, i => Assert.Equal("AC/DC", i.Song.Author));
        }
    }
}
