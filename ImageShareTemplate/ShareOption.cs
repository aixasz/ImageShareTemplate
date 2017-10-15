using ImageShareTemplate.ImageProvider;

namespace ImageShareTemplate
{
    public class ShareOption
    {
        /// <summary>
        /// The proportion horizontal ratio. 
        /// </summary>
        public double RatioX { get; set; }

        /// <summary>
        /// The proportion vertical ratio. 
        /// </summary>
        public double RatioY { get; set; }

        /// <summary>
        /// We have separate area to render item on main image to four quadrant.
        /// 
        ///  +---------+---------+
        ///  |         |         |
        ///  | Block 1 | Block 2 |
        ///  |         |         |
        ///  +---------+---------+
        ///  |         |         |
        ///  | Block 3 | Block 4 |
        ///  |         |         |
        ///  +---------+---------+
        ///
        /// </summary>
        public IBlock Block1 { get; set; }
        public IBlock Block2 { get; set; }
        public IBlock Block3 { get; set; }
        public IBlock Block4 { get; set; }

        /// <summary>
        /// Main image this will be background.
        /// </summary>
        public byte[] ImageSource { get; set; }

        /// <summary>
        /// Target image result follow provider specification.
        /// </summary>
        public IImageProvider ImageProvider { get; set; }

    }
}
