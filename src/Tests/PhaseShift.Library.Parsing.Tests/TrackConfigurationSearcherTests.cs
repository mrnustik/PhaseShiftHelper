using PhaseShift.Library.Parsing.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PhaseShift.Library.Parsing.Tests
{
    public class TrackConfigurationSearcherTests : TestBase
    {
        [Fact] 
        public void Find_InParentDirectory_HasValidValues()
        {
            var sut = new TrackConfigurationSearcher();

            var configurationFiles = sut.FindSongConfigurationFiles(TestLibraryPath);

            Assert.Equal(2, configurationFiles.Count());
        }

    }
}
