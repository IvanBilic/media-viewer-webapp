using System;
using System.Collections.Generic;

namespace MediaViewerApp
{
    /// <summary>
    /// Klasa koja predstavља korisnika aplikacije
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public List<MediaLibrary> MediaLibraries { get; set; }
        public List<Playlist> Playlists { get; set; }

        public User()
        {
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            MediaLibraries = new List<MediaLibrary>();
            Playlists = new List<Playlist>();
            RegisteredDate = DateTime.UtcNow;
            LastLoginDate = DateTime.UtcNow;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            return $"User: {GetFullName()} ({Email})";
        }
    }
}
