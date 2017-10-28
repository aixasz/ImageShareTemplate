using ImageShareTemplate.ImageProvider;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace ImageShareTemplate.Tests
{
    /// <summary>
    /// Tests that inherit from this class can test against the "VerificationImages"
    /// </summary>
    public abstract class ImageRenderTests
    {
        // all black bitmap
        protected static readonly byte[] MinimalBitmap = {
            0x42, 0x4d, 0x1e, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1a, 0x00, 0x00, 0x00, 0x0c, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00
        };

        protected static byte[] CreateImageFromOptions(ShareOption options)
        {
            return Convert.FromBase64String(
                ShareTemplate.CreateAsBase64String(options).Split(',')[1]
            );
        }

        /// <summary>
        /// Assert that the provided byte array, which represents an image, is the same
        /// as an image file on disk. By default, the image file has the same name as the
        /// test case.
        /// </summary>
        /// <param name="actualResults">the actual byte array from the system under test.</param>
        /// <param name="expectedFile">the expected filename, this is automatically the unit test name</param>
        /// <param name="writeActualResult">whether or not to write the actual file to disk</param>
        protected static void AssertImage(byte[] actualResults, [CallerMemberName] string expectedFile = "", bool writeActualResult = false)
        {
            string root = "VerificationImages" + Path.DirectorySeparatorChar;

            byte[] actualBytes;
            using (var image = Image.Load(actualResults))
            using (MemoryStream ms = new MemoryStream())
            {
                image.SaveAsBmp(ms);
                actualBytes = ms.ToArray();
            }

            if(writeActualResult)
            {
                File.WriteAllBytes($"{root}{expectedFile}-actual.bmp", actualBytes);
            }

            byte[] expectedBytes = File.ReadAllBytes($"{root}{expectedFile}.bmp");

            Assert.Equal(expectedBytes, actualBytes);
        }
    }
}
