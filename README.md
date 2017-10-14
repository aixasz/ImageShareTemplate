# ImageShareTemplate
ImageShareTemplate is image template library to share an image to social like facebook, twitter, etc. This library can add other image or some text to main image as background.

# Dependencies
- .net core 2.0
- [ImageSharp] (https://github.com/SixLabors/ImageSharp) 

# Coding Style
We following [C# Coding style](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md) from dotnet core coding guideline.


# Example
This will be result image after combine text and other like like logo and bring the main image as background.

                                   X : 65%
+-------------------------------------+-----------------+
|                                     |                 |
|                                     |   +----------+  |
|                                     |   |          |  |
|                                     |   |  Logo 1  |  |
|    This is example for              |   |          |  |
|    ImageShareTemplate               |   +----------+  |
|    to facebook ...                  |                 |
|                                     |                 |
|                                     |                 |
|                                     |                 |
|                                     |                 |
|                                     |                 |
+-------------------------------------------------------+ Y : 75%
|                                     |                 |
|    By : FirstName Lastname          |                 |
|                                     |                 |
+-------------------------------------+-----------------+
