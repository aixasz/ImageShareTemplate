using SixLabors.ImageSharp;

namespace ImageShareTemplate
{
    public interface IBlock
    {
        Rgba32 BackgroundColor { get; set; }
        int PointX { get; set; }
        int PointY { get; set; }
    }
}
