using System;
using System.Collections.Generic;

namespace MediaViewerApp
{
    /// <summary>
    /// Klasa koja predstavlja oznaku (tag) - N-N relacija s Media
    /// </summary>
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public List<Media> MediaItems { get; set; }

        public Tag()
        {
            Name = string.Empty;
            Color = "#000000";
            MediaItems = new List<Media>();
        }

        public override string ToString()
        {
            return $"#{Name}";
        }
    }
}
