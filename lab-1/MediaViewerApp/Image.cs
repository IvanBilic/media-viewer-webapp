using System;

namespace MediaViewerApp
{
    /// <summary>
    /// Klasa koja predstavlja slikovnu datoteku
    /// </summary>
    public class Image : Media
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int DpiResolution { get; set; }
        public string CameraModel { get; set; }
        public bool IsHdr { get; set; }

        public Image()
            : base()
        {
            CameraModel = string.Empty;
        }

        public override string ToString()
        {
            return base.ToString() + $" | {Width}x{Height} px | DPI: {DpiResolution}";
        }
    }
}
