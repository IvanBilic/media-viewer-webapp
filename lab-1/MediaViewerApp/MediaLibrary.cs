using System;
using System.Collections.Generic;

namespace MediaViewerApp
{
    /// <summary>
    /// Klasa koja predstavја korisnikovu biblioteku medija - 1-N relacija s Media
    /// </summary>
    public class MediaLibrary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Media> MediaItems { get; set; }

        public MediaLibrary()
        {
            Name = string.Empty;
            MediaItems = new List<Media>();
            CreatedDate = DateTime.UtcNow;
        }

        public void AddMedia(Media media)
        {
            if (media != null)
            {
                media.MediaLibraryId = this.Id;
                MediaItems.Add(media);
            }
        }

        public override string ToString()
        {
            return $"MediaLibrary: {Name} ({MediaItems.Count} items)";
        }
    }
}
