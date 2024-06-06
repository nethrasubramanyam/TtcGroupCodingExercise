using System.Drawing;

namespace TtcGroupRubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents a color layout for a rubiks cube.
    /// </summary>
    class CubeColors
    {
        /// <summary>
        /// The physical cube color scheme.
        /// </summary>
        public static readonly CubeColors TtcsScheme = new CubeColors
            (Color.Green, Color.Blue, Color.Red, Color.Orange, Color.White, Color.Yellow);

        #region Properties
        /// <summary>
        /// Gets the top color of the cube.
        /// </summary>
        public Color UpColor { get; }

        /// <summary>
        /// Gets the bottom color of the cube.
        /// </summary>
        public Color DownColor { get; }

        /// <summary>
        /// Gets the left color of the cube.
        /// </summary>
        public Color LeftColor { get; }

        /// <summary>
        /// Gets the right color of the cube.
        /// </summary>
        public Color RightColor { get; }

        /// <summary>
        /// Gets the front color of the cube.
        /// </summary>
        public Color FrontColor { get; }

        /// <summary>
        /// Gets the back color of the cube.
        /// </summary>
        public Color BackColor { get; }

        /// <summary>
        /// Gets all of the face colors.
        /// </summary>
        public Color[] All => 
            new[] { UpColor, DownColor, RightColor, LeftColor, FrontColor, BackColor};

        #endregion

        public CubeColors(Color frontColor, Color backColor, Color rightColor,
            Color leftColor, Color upColor, Color downColor)
        {
            FrontColor = frontColor;
            BackColor = backColor;
            RightColor = rightColor;
            LeftColor = leftColor;
            UpColor = upColor;
            DownColor = downColor;
        }

    }
}
