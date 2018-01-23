using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase
{
    class Program
    {
        public static void Main()
        {
            var playlist = new List<Song>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var songArgs = Console.ReadLine()
                    .Split(';');

                try
                {
                    playlist.Add(new Song(songArgs[0], songArgs[1], songArgs[2]));
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException se)
                {
                    Console.WriteLine(se.Message);
                }
            }

            Console.WriteLine("Songs added: {0}", playlist.Count);

            var minutes = playlist
                .Sum(s => s.Minutes());

            var seconds = playlist
                .Sum(s => s.Seconds());

            var timespan = new TimeSpan(0, minutes, seconds);

            Console.WriteLine("Playlist length: {0}h {1}m {2}s", timespan.Hours, timespan.Minutes, timespan.Seconds);
        }
    }
}
