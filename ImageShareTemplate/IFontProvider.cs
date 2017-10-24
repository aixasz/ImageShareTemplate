using SixLabors.Fonts;

namespace ImageShareTemplate
{
    public interface IFontProvider
    {
        Font GetFont(string family, int size);
    }
}