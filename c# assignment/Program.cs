using System;
using SongApp;

class Program
{
    static void Main(string[] args)
    {
        MyPlayList playlist = new MyPlayList();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nEnter:\n1. Add Song\n2. Remove Song by Id\n3. Get Song by Id\n4. Get Song by Name\n5. Get All Songs\n6. Exit");
            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Song newSong = new Song();
                    Console.Write("Enter Song ID: ");
                    newSong.SongId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Song Name: ");
                    newSong.SongName = Console.ReadLine();
                    Console.Write("Enter Song Genre (Pop, HipHop, Jazz, etc.): ");
                    newSong.SongGenre = Console.ReadLine();
                    playlist.Add(newSong);
                    break;

                case 2:
                    Console.Write("Enter Song ID to remove: ");
                    int removeId = Convert.ToInt32(Console.ReadLine());
                    playlist.Remove(removeId);
                    break;

                case 3:
                    Console.Write("Enter Song ID to search: ");
                    int searchId = Convert.ToInt32(Console.ReadLine());
                    var songById = playlist.GetSongById(searchId);
                    if (songById != null)
                        Console.WriteLine($"ID: {songById.SongId}, Name: {songById.SongName}, Genre: {songById.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case 4:
                    Console.Write("Enter Song Name to search: ");
                    string name = Console.ReadLine();
                    var songByName = playlist.GetSongByName(name);
                    if (songByName != null)
                        Console.WriteLine($"ID: {songByName.SongId}, Name: {songByName.SongName}, Genre: {songByName.SongGenre}");
                    else
                        Console.WriteLine("Song not found.");
                    break;

                case 5:
                    var allSongs = playlist.GetAllSongs();
                    Console.WriteLine("All Songs in Playlist:");
                    foreach (var s in allSongs)
                    {
                        Console.WriteLine($"ID: {s.SongId}, Name: {s.SongName}, Genre: {s.SongGenre}");
                    }
                    break;

                case 6:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}

