using System;
using System.Collections.Generic;

namespace MediaViewerApp
{
    /// <summary>
    /// Bazna klasa za sve tipove medija
    /// </summary>
    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaFormat Format { get; set; }
        public long FileSizeBytes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<Tag> Tags { get; set; }
        public int MediaLibraryId { get; set; }

        public Media()
        {
            Tags = new List<Tag>();
            CreatedDate = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"[{GetType().Name}] {Title} ({Format}) - {FileSizeBytes} bytes";
        }
    }
}
