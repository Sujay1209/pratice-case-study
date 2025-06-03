using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyPlayList : IPlaylist
    {
        public static List<Song> myPlayList = new List<Song>();
        private readonly int capacity = 20;

        public MyPlayList() { }

        public void Add(Song song)
        {
            if (myPlayList.Count >= capacity)
            {
                Console.WriteLine("Cannot add more than 20 songs.");
                return;
            }
            myPlayList.Add(song);
            Console.WriteLine("Song added successfully.");
        }

        public void Remove(int songId)
        {
            Song song = myPlayList.FirstOrDefault(s => s.SongId == songId);
            if (song != null)
            {
                myPlayList.Remove(song);
                Console.WriteLine("Song removed.");
            }
            else
            {
                Console.WriteLine("Song not found.");
            }
        }

        public Song GetSongById(int songId)
        {
            return myPlayList.FirstOrDefault(s => s.SongId == songId);
        }

        public Song GetSongByName(string songName)
        {
            return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Song> GetAllSongs()
        {
            return myPlayList;
        }
    }

}
