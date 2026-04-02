using System;
using System.Collections.Generic;

namespace MediaViewerApp
{
    /// <summary>
    /// Klasa koja predstavlja korisnički playlist - 1-N relacija s Media
    /// </summary>
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int UserId { get; set; }
        public List<Media> MediaItems { get; set; }

        public Playlist()
        {
            Name = string.Empty;
            Description = string.Empty;
            MediaItems = new List<Media>();
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"Playlist: {Name} ({MediaItems.Count} items)";
        }
    }
}
