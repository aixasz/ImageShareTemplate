using ImageShareTemplate.ImageProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageShareTemplate
{
    public class ImageShareOption
    {
        /// <summary>
        /// The proportion horizontal ratio. 
        /// </summary>
        public double RatioX { get; set; }
        /// <summary>
        /// The proportion vertical ratio. 
        /// </summary>
        public double RatioY { get; set; }

        public IBlock Block1 { get; set; }
        public IBlock Block2 { get; set; }
        public IBlock Block3 { get; set; }
        public IBlock Block4 { get; set; }

        public string MainImagePath { get; set; }
        public IImageProvider ImageProvider { get; set; }

    }
}
