namespace PhaseShift.Tools.LibrarySorter.Options
{
    public static class DefaultSortingOptions
    {
        public static SortingOption ByAuthor => new SortingOption(t => t.Song.Author);
        public static SortingOption ByAlbum => new SortingOption(t => t.Song.Album);
        public static SortingOption ByName => new SortingOption(t => t.Song.Name);
    }
}
