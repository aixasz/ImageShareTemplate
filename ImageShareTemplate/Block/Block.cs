using SixLabors.ImageSharp;

namespace ImageShareTemplate
{
    public abstract class Block : IBlock
    {
        public Rgba32 BackgroundColor { get; set; } = Rgba32.Transparent;
        public int PointX { get; set; }
        public int PointY { get; set; }
    }
}
