using System;

namespace MediaViewerApp
{
    /// <summary>
    /// Klasa koja predstavlja video datoteku
    /// </summary>
    public class Video : Media
    {
        public int DurationSeconds { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double FrameRate { get; set; }
        public int Bitrate { get; set; }

        public Video()
            : base()
        {
        }

        public override string ToString()
        {
            return base.ToString() + $" | Duration: {DurationSeconds}s | {Width}x{Height} | {FrameRate}fps";
        }
    }
}
