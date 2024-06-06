using System.Drawing;

namespace TtcGroupRubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Provides a rendering functionality to render a ColorGrid in different ways.
    /// All rendering logic works on a percentage basis (0-1).
    /// </summary>
    internal static class ColorGridRendering
    {
        /// <summary>
        /// Represents parameters as required information for the ColorGridRenderer, which
        /// describe the appearance and layout of a color grid.
        /// </summary>
        public class ColorGridStyle
        {
            /// <summary>
            /// Gets or sets the colors to be displayed on the grid.
            /// </summary>
            public Color[,] Colors { get; set; }

            /// <summary>
            /// Gets or sets the relative thickness of the border pen.
            /// </summary>
            public float CellSpacingScale { get; set; }

            /// <summary>
            /// Gets or sets the corner radius for the rounded rect used with the ColorGridRenderer.
            /// </summary>
            public int RoundedRadius { get; set; }


            public ColorGridStyle(Color[,] colors, float cellSpacing, int roundedRadius)
            {
                Colors = colors;
                CellSpacingScale = cellSpacing;
                RoundedRadius = roundedRadius;
            }
        }
        /// <summary>
        /// Gets the bounding rectangle for each of the cells in the grid.
        /// </summary>
        public static RectangleF[,] GetAllCellBounds(ColorGridStyle style, Size drawRegion)
        {
            var rects = new RectangleF[style.Colors.GetLength(0), style.Colors.GetLength(1)];
            float cellDim = GetCellDimension(style, drawRegion);
            // They will always be centered
            float xOffset = (drawRegion.Width / 2f) - style.Colors.GetLength(0) * cellDim / 2;
            float yOffset = (drawRegion.Height / 2f) - style.Colors.GetLength(1) * cellDim / 2;

            for (int row = 0; row < style.Colors.GetLength(0); row++)
            {
                for (int clm = 0; clm < style.Colors.GetLength(1); clm++)
                {
                    float y = yOffset + cellDim * clm;
                    float x = xOffset + cellDim * row;
                    float dim = cellDim;
                    rects[row, clm] = new RectangleF(x, y, dim, dim);
                }
            }

            return rects;
        }

        /// <summary>
        /// Combimes rectangles in a way that the master rect just ecompasses the
        /// size and the locations of the child rectangles.
        /// </summary>
        private static RectangleF UniteRects(RectangleF[,] rects)
        {
            float lowestX = float.MaxValue;
            float lowestY = float.MaxValue;
            float greatestRight = 0;
            float greateastBottom = 0;

            foreach (RectangleF rect in rects)
            {
                if (rect.Right > greatestRight) greatestRight = rect.Right;
                if (rect.Bottom > greateastBottom) greateastBottom = rect.Bottom;
                if (rect.X < lowestX) lowestX = rect.X;
                if (rect.Y < lowestY) lowestY = rect.Y;
            }

            return new RectangleF(lowestX, lowestY, 
                greatestRight - lowestX, greateastBottom - lowestY);
        }

        /// <summary>
        /// Gets the dimension of all cells.
        /// </summary>
        private static float GetCellDimension(ColorGridStyle style, Size drawRegion)
        {
            int gridWidth = style.Colors.GetLength(0);
            int gridHeight = style.Colors.GetLength(1);
            double widthRatio = (double)drawRegion.Width / gridWidth;
            double heightRatio = (double)drawRegion.Height / gridHeight;

            if (widthRatio > heightRatio)
            {
                return (float)drawRegion.Height / gridHeight;
            }

            return (float)drawRegion.Width / gridWidth;
        }

        public static RectangleF GetMasterRectangle(ColorGridStyle style, Size drawRegion)
        {
            var bounds = GetAllCellBounds(style, drawRegion);
            return UniteRects(bounds);
        }
        public static Color Desaturate(this Color color)
        {
            var b = (int)(255 * color.GetBrightness());
            return Color.FromArgb(b, b, b);
        }
        /// <summary>
        /// Draws the grid center middle of the region.
        /// </summary>
        public static void Draw(ColorGridStyle style, Graphics graphics, Size drawRegion, bool enabled)
        {
            float cellDim = GetCellDimension(style, drawRegion);
            float xOffset = (drawRegion.Width / 2f) - style.Colors.GetLength(0) * cellDim / 2;
            float yOffset = (drawRegion.Height / 2f) - style.Colors.GetLength(1) * cellDim / 2;
            float spacing = style.CellSpacingScale * cellDim;
            var master = GetMasterRectangle(style, drawRegion);
            var backPath = RoundedRectangle.Create(master, style.RoundedRadius);
            graphics.FillPath(enabled ? Brushes.Black : Brushes.DimGray, backPath);

            for (int row = 0; row < style.Colors.GetLength(0); row++)
            {
                for (int clm = 0; clm < style.Colors.GetLength(1); clm++)
                {
                    float dim = cellDim - spacing*2;
                    var brush = new SolidBrush(style.Colors[clm, row]);
                    if (!enabled) brush.Color = brush.Color.Desaturate();
                    float x = (xOffset + cellDim * row) + spacing;
                    float y = (yOffset + cellDim * clm) + spacing;
                    var path = RoundedRectangle.Create(x, y, dim, dim, style.RoundedRadius);
                    graphics.FillPath(brush, path);
                    brush.Dispose();
                }
            }
        }
    }
}
