using SixLabors.Fonts;

namespace ImageShareTemplate
{
    public class SystemFontProvider : IFontProvider
    {
        public Font GetFont(string family, int size)
        {
            return SystemFonts.CreateFont(family, size, FontStyle.Regular);
        }
    }
}