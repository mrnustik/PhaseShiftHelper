using System;
using PhaseShift.Library.Locations;

namespace PhaseShift.Library.Models
{
    public class Track
    {
        public Song Song { get; }
        public IChildLocation Location { get; }
        public Difficulty GuitarDifficulty { get; }
        public Difficulty RealGuitarDifficulty { get; }
        public Difficulty DrumDifficulty { get; }
        public Difficulty RealDrumDifficulty { get; }
        public Difficulty BassDifficulty { get; }
        public Difficulty RealBassDifficulty { get; }

        public Track(Song song, Difficulty guitarDifficulty, Difficulty realGuitarDifficulty, Difficulty drumDifficulty, Difficulty realDrumDifficulty, Difficulty bassDifficulty, Difficulty realBassDifficulty)
        {
            Song = song;
            GuitarDifficulty = guitarDifficulty;
            RealGuitarDifficulty = realGuitarDifficulty;
            DrumDifficulty = drumDifficulty;
            RealDrumDifficulty = realDrumDifficulty;
            BassDifficulty = bassDifficulty;
            RealBassDifficulty = realBassDifficulty;
        }
    }
}
