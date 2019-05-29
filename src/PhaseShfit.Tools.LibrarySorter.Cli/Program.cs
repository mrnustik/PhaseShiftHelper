using Microsoft.Extensions.DependencyInjection;
using PhaseShift.Library.Models;
using PhaseShift.Library.Parsing;
using PhaseShift.Library.Parsing.Ini;
using PhaseShift.Library.Parsing.Search;
using PhaseShift.Library.Parsing.Track;
using PhaseShift.Tools.LibrarySorter;
using PhaseShift.Tools.LibrarySorter.Options;
using System;
using Sorter = PhaseShift.Tools.LibrarySorter.LibrarySorter;

namespace PhaseShfit.Tools.LibrarySorter.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.Error.WriteLine("Invalid arguments count. Excepted path to library to be sorted.");
            }

            var serviceProvider = CreateServiceProvider();
            var loader = serviceProvider.GetService<ILibraryLoader>();
            var libary = loader.LoadLibrary(args[0]);
            var sorter = serviceProvider.GetService<ILibrarySorter>();
            sorter.Sort(libary, DefaultSortingOptions.ByAuthor, DefaultSortingOptions.ByName);
        }

        private static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<ILibrarySorter, Sorter>()
                .AddSingleton<IIniFormatParser, IniFormatParser>()
                .AddSingleton<ITrackConfigurationSearcher, TrackConfigurationSearcher>()
                .AddSingleton<ITrackParser, TrackParser>()
                .AddSingleton<ILibraryLoader, LibraryLoader>()
                .BuildServiceProvider();
        }
    }
}
