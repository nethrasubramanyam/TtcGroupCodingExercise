using System;
using System.Drawing;

namespace TtcGroupRubiksCubeSimulator.Rubiks
{
    /// <summary>
    /// Represents a 3x3 rubiks cube.
    /// </summary>
    internal class RubiksCube : ICloneable
    {
        private readonly Color[][,] origColors;

        #region Properties

        /// <summary>
        /// Gets the color matrix for this cube. Face arrays are as follows:
        /// Front 0, Back 1, Right 2, left 3, Up 4, Down 5.
        /// </summary>
        public Color[][,] AllColors { get; private set; } = new Color[6][,];

        public Color[,] FrontColors
        {
            get { return AllColors[0]; }
            private set {  AllColors[0] = value; }
        }

        public Color[,] BackColors
        {
            get { return AllColors[1]; }
            private set {AllColors[1] = value; }
        }

        public Color[,] RightColors
        {
            get { return AllColors[2]; }
            private set{ AllColors[2] = value; }
        }

        public Color[,] LeftColors
        {
            get { return AllColors[3]; }
            private set  {AllColors[3] = value; }
        }

        public Color[,] UpColors
        {
            get { return AllColors[4]; }
            private set{ AllColors[4] = value;  }
        }

        public Color[,] DownColors
        {
            get { return AllColors[5]; }
            private set { AllColors[5] = value; }
        }

        
        #endregion

        /// <summary>
        /// Creates an instance of the RubiksCube.
        /// </summary>
        /// <param name="colors">Face arrays are as follows:
        /// Front 0, Back 1, Right 2, left 3, Up 4, Down 5.</param>
        public RubiksCube(Color[][,] colors)
        {
            origColors = CloneColors(colors);
            // Clone so we dont modify the original matrix.
            AllColors = colors;
        }

        /// <summary>
        /// Creates a solved cube from a specified color.
        /// </summary>
        public static RubiksCube Create(CubeColors rubiksColors)
        {
            var colors = new Color[6][,];
            colors[0] = CreateFace(rubiksColors.FrontColor);
            colors[1] = CreateFace(rubiksColors.BackColor);
            colors[2] = CreateFace(rubiksColors.RightColor);
            colors[3] = CreateFace(rubiksColors.LeftColor);
            colors[4] = CreateFace(rubiksColors.UpColor);
            colors[5] = CreateFace(rubiksColors.DownColor);
            return new RubiksCube(colors);
        }

        /// <summary>
        /// Gets the color scheme for this cube.
        /// </summary>
        public CubeColors GetColorScheme()
        {
            return new CubeColors(
                FrontColors[1, 1],
                BackColors[1, 1],
                RightColors[1, 1],
                LeftColors[1, 1],
                UpColors[1, 1],
                DownColors[1, 1]);
        }

        /// <summary>
        /// Reset the cube to its solved state.
        /// </summary>
        public void Reset()
        {
            var cube = Create(GetColorScheme());
            AllColors = cube.AllColors;
        }

        /// <summary>
        /// Creates a 3x3 face with a solid color.
        /// </summary>
        public static Color[,] CreateFace(Color faceColor)
        {
            return new[,]
            {
               {faceColor, faceColor, faceColor},
               {faceColor, faceColor, faceColor},
               {faceColor, faceColor, faceColor}
            };
        }
        /// <summary>
        /// Gets a cube face from the CubeSide specified.
        /// </summary>
        /// <returns>Null, if CubeSide.None specified.</returns>
        private Color[,] GetFaceColors(CubeSide side)
        {
            switch (side)
            {
                case CubeSide.Back: return BackColors;
                case CubeSide.Front: return FrontColors;
                case CubeSide.Left: return LeftColors;
                case CubeSide.Right: return RightColors;
                case CubeSide.Up: return UpColors;
                case CubeSide.Down: return DownColors;
                default: return null;
            }
        }

        /// <summary>
        /// Sets the colors for the cube side specified.
        /// </summary>
        private void SetSide(CubeSide side, Color[,] value)
        {
            switch (side)
            {
                case CubeSide.Back: BackColors = value; break;
                case CubeSide.Front: FrontColors = value; break;
                case CubeSide.Left: LeftColors = value; break;
                case CubeSide.Right: RightColors = value; break;
                case CubeSide.Up: UpColors = value; break;
                case CubeSide.Down: DownColors = value; break;
            }
        }

        /// <summary>
        /// Rotates the colors only on the surface of the side.
        /// </summary>
        private void RotateFace(CubeSide side, Rotation rotation)
        {
            var faceToRotate = GetFaceColors(side);
            var newFace = new Color[3, 3];

            if (rotation == Rotation.Cw)
            {
                for (int i = 2; i >= 0; i--)
                    for (int i2 = 0; i2 < 3; i2++)
                        newFace[i2, 2 - i] = faceToRotate[i, i2];
            }
            else
            {
                for (int i = 2; i >= 0; i--)
                    for (int i2 = 0; i2 < 3; i2++)
                        newFace[2 - i, i2] = faceToRotate[i2, i];
            }

            SetSide(side, newFace);
        }

        private static Color[][,] CloneColors(Color[][,] source)
        {
            var cloned = new Color[source.Length][,];

            for (int i = 0; i < source.Length; i++)
            {
                cloned[i] = new Color[3, 3];

                for (int row = 0; row < source[i].GetLength(0); row++)
                {
                    for (int clm = 0; clm < source[i].GetLength(1); clm++)
                    {
                        cloned[i][row, clm] = source[i][row, clm];
                    }
                }
            }

            return cloned;
        }

        public void MakeMove(CubeMove move)
        {
            MakeMove(move.Side, move.Rotation);
        }

        public void MakeMove(CubeSide side, Rotation rotation)
        {
            if (side == CubeSide.None) return;
            RotateFace(side, rotation);
            var newColors = CloneColors(AllColors);

            switch (side)
            {
                #region Front Shift
                case CubeSide.Front:

                    if (rotation == Rotation.Cw)
                    {
                        // Shift Left to up
                        newColors[4][2, 0] = LeftColors[2, 2];
                        newColors[4][2, 1] = LeftColors[1, 2];
                        newColors[4][2, 2] = LeftColors[0, 2];
                        // Shift up to right
                        newColors[2][0, 0] = UpColors[2, 0];
                        newColors[2][1, 0] = UpColors[2, 1];
                        newColors[2][2, 0] = UpColors[2, 2];
                        // Shift right to down
                        newColors[5][0, 2] = RightColors[0, 0];
                        newColors[5][0, 1] = RightColors[1, 0];
                        newColors[5][0, 0] = RightColors[2, 0];
                        // Shift down to left
                        newColors[3][0, 2] = DownColors[0, 0];
                        newColors[3][1, 2] = DownColors[0, 1];
                        newColors[3][2, 2] = DownColors[0, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift up to left
                        newColors[3][2, 2] = UpColors[2, 0];
                        newColors[3][1, 2] = UpColors[2, 1];
                        newColors[3][0, 2] = UpColors[2, 2];
                        // Shift right to up
                        newColors[4][2, 0] = RightColors[0, 0];
                        newColors[4][2, 1] = RightColors[1, 0];
                        newColors[4][2, 2] = RightColors[2, 0];
                        // Shift down to right
                        newColors[2][0, 0] = DownColors[0, 2];
                        newColors[2][1, 0] = DownColors[0, 1];
                        newColors[2][2, 0] = DownColors[0, 0];
                        // Shift left to down
                        newColors[5][0, 0] = LeftColors[0, 2];
                        newColors[5][0, 1] = LeftColors[1, 2];
                        newColors[5][0, 2] = LeftColors[2, 2];
                    }

                    break;
                #endregion

                #region Back Shift
                case CubeSide.Back:

                    if (rotation == Rotation.Aw)
                    {
                        // Shift Left to up
                        newColors[4][0, 0] = LeftColors[2, 0];
                        newColors[4][0, 1] = LeftColors[1, 0];
                        newColors[4][0, 2] = LeftColors[0, 0];
                        // Shift up to right
                        newColors[2][0, 2] = UpColors[0, 0];
                        newColors[2][1, 2] = UpColors[0, 1];
                        newColors[2][2, 2] = UpColors[0, 2];
                        // Shift right to down
                        newColors[5][2, 2] = RightColors[0, 2];
                        newColors[5][2, 1] = RightColors[1, 2];
                        newColors[5][2, 0] = RightColors[2, 2];
                        // Shift down to left
                        newColors[3][0, 0] = DownColors[2, 0];
                        newColors[3][1, 0] = DownColors[2, 1];
                        newColors[3][2, 0] = DownColors[2, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift up to left
                        newColors[3][2, 0] = UpColors[0, 0];
                        newColors[3][1, 0] = UpColors[0, 1];
                        newColors[3][0, 0] = UpColors[0, 2];
                        // Shift right to up
                        newColors[4][0, 0] = RightColors[0, 2];
                        newColors[4][0, 1] = RightColors[1, 2];
                        newColors[4][0, 2] = RightColors[2, 2];
                        // Shift down to right
                        newColors[2][0, 2] = DownColors[2, 2];
                        newColors[2][1, 2] = DownColors[2, 1];
                        newColors[2][2, 2] = DownColors[2, 0];
                        // Shift left to down
                        newColors[5][2, 0] = LeftColors[0, 0];
                        newColors[5][2, 1] = LeftColors[1, 0];
                        newColors[5][2, 2] = LeftColors[2, 0];
                    }

                    break;
                #endregion

                #region Right Shift
                case CubeSide.Right:

                    if (rotation == Rotation.Cw)
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift front to up
                        newColors[4][0, 2] = FrontColors[0, 2];
                        newColors[4][1, 2] = FrontColors[1, 2];
                        newColors[4][2, 2] = FrontColors[2, 2];
                        // Shift up to back
                        newColors[1][2, 0] = UpColors[0, 2];
                        newColors[1][1, 0] = UpColors[1, 2];
                        newColors[1][0, 0] = UpColors[2, 2];
                        // Shift back to down
                        newColors[5][0, 2] = BackColors[2, 0];
                        newColors[5][1, 2] = BackColors[1, 0];
                        newColors[5][2, 2] = BackColors[0, 0];
                        // Shift down to front
                        newColors[0][0, 2] = DownColors[0, 2];
                        newColors[0][1, 2] = DownColors[1, 2];
                        newColors[0][2, 2] = DownColors[2, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift up to front
                        newColors[0][0, 2] = UpColors[0, 2];
                        newColors[0][1, 2] = UpColors[1, 2];
                        newColors[0][2, 2] = UpColors[2, 2];
                        // Shift back to up
                        newColors[4][0, 2] = BackColors[2, 0];
                        newColors[4][1, 2] = BackColors[1, 0];
                        newColors[4][2, 2] = BackColors[0, 0];
                        // Shift down to back
                        newColors[1][0, 0] = DownColors[2, 2];
                        newColors[1][1, 0] = DownColors[1, 2];
                        newColors[1][2, 0] = DownColors[0, 2];
                        // Shift front to down
                        newColors[5][0, 2] = FrontColors[0, 2];
                        newColors[5][1, 2] = FrontColors[1, 2];
                        newColors[5][2, 2] = FrontColors[2, 2];
                    }

                    break;
                #endregion

                #region Left Shift
                case CubeSide.Left:

                    if (rotation == Rotation.Cw)
                    {
                        // Shift up to front
                        newColors[0][0, 0] = UpColors[0, 0];
                        newColors[0][1, 0] = UpColors[1, 0];
                        newColors[0][2, 0] = UpColors[2, 0];
                        // Shift front to down
                        newColors[5][0, 0] = FrontColors[0, 0];
                        newColors[5][1, 0] = FrontColors[1, 0];
                        newColors[5][2, 0] = FrontColors[2, 0];
                        // Shift down to back
                        newColors[1][2, 2] = DownColors[0, 0];
                        newColors[1][1, 2] = DownColors[1, 0];
                        newColors[1][0, 2] = DownColors[2, 0];
                        // Shift back to up
                        newColors[4][2, 0] = BackColors[0, 2];
                        newColors[4][1, 0] = BackColors[1, 2];
                        newColors[4][0, 0] = BackColors[2, 2];
                    }
                    else
                    {
                        // 0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift front to up
                        newColors[4][0, 0] = FrontColors[0, 0];
                        newColors[4][1, 0] = FrontColors[1, 0];
                        newColors[4][2, 0] = FrontColors[2, 0];
                        // Shift down to front
                        newColors[0][0, 0] = DownColors[0, 0];
                        newColors[0][1, 0] = DownColors[1, 0];
                        newColors[0][2, 0] = DownColors[2, 0];
                        // Shift back to down
                        newColors[5][0, 0] = BackColors[2, 2];
                        newColors[5][1, 0] = BackColors[1, 2];
                        newColors[5][2, 0] = BackColors[0, 2];
                        // Shift up to back
                        newColors[1][0, 2] = UpColors[2, 0];
                        newColors[1][1, 2] = UpColors[1, 0];
                        newColors[1][2, 2] = UpColors[0, 0];
                    }

                    break;
                #endregion

                #region Up Shift
                case CubeSide.Up:

                    // Rotate outercolors
                    if (rotation == Rotation.Cw)
                    {
                        // No need to set middle colors as newColors is a full copy
                        // Shift right to front
                        newColors[0][0, 0] = RightColors[0, 0];
                        newColors[0][0, 1] = RightColors[0, 1];
                        newColors[0][0, 2] = RightColors[0, 2];
                        // Shift front to left
                        newColors[3][0, 0] = FrontColors[0, 0];
                        newColors[3][0, 1] = FrontColors[0, 1];
                        newColors[3][0, 2] = FrontColors[0, 2];
                        // Shift left to back
                        newColors[1][0, 0] = LeftColors[0, 0];
                        newColors[1][0, 1] = LeftColors[0, 1];
                        newColors[1][0, 2] = LeftColors[0, 2];
                        // Shift back to right
                        newColors[2][0, 0] = BackColors[0, 0];
                        newColors[2][0, 1] = BackColors[0, 1];
                        newColors[2][0, 2] = BackColors[0, 2];
                    }
                    else
                    {
                        //  0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift front to right
                        newColors[2][0, 0] = FrontColors[0, 0];
                        newColors[2][0, 1] = FrontColors[0, 1];
                        newColors[2][0, 2] = FrontColors[0, 2];
                        // Shift left to front
                        newColors[0][0, 0] = LeftColors[0, 0];
                        newColors[0][0, 1] = LeftColors[0, 1];
                        newColors[0][0, 2] = LeftColors[0, 2];
                        // Shift back to left
                        newColors[3][0, 0] = BackColors[0, 0];
                        newColors[3][0, 1] = BackColors[0, 1];
                        newColors[3][0, 2] = BackColors[0, 2];
                        // Shift right to back
                        newColors[1][0, 0] = RightColors[0, 0];
                        newColors[1][0, 1] = RightColors[0, 1];
                        newColors[1][0, 2] = RightColors[0, 2];
                    }
                    break;
                #endregion

                #region Down Shift
                case CubeSide.Down:

                    // Rotate outercolors
                    if (rotation == Rotation.Aw)
                    {
                        //  0 Front, 1 back, 2 right, 3 left, 4 up, 5 down
                        // Shift right to front
                        newColors[0][2, 0] = RightColors[2, 0];
                        newColors[0][2, 1] = RightColors[2, 1];
                        newColors[0][2, 2] = RightColors[2, 2];
                        // Shift front to left
                        newColors[3][2, 0] = FrontColors[2, 0];
                        newColors[3][2, 1] = FrontColors[2, 1];
                        newColors[3][2, 2] = FrontColors[2, 2];
                        // Shift left to back
                        newColors[1][2, 0] = LeftColors[2, 0];
                        newColors[1][2, 1] = LeftColors[2, 1];
                        newColors[1][2, 2] = LeftColors[2, 2];
                        // Shift back to right
                        newColors[2][2, 0] = BackColors[2, 0];
                        newColors[2][2, 1] = BackColors[2, 1];
                        newColors[2][2, 2] = BackColors[2, 2];
                    }
                    else
                    {
                        // Shift front to right
                        newColors[2][2, 0] = FrontColors[2, 0];
                        newColors[2][2, 1] = FrontColors[2, 1];
                        newColors[2][2, 2] = FrontColors[2, 2];
                        // Shift left to front
                        newColors[0][2, 0] = LeftColors[2, 0];
                        newColors[0][2, 1] = LeftColors[2, 1];
                        newColors[0][2, 2] = LeftColors[2, 2];
                        // Shift back to left
                        newColors[3][2, 0] = BackColors[2, 0];
                        newColors[3][2, 1] = BackColors[2, 1];
                        newColors[3][2, 2] = BackColors[2, 2];
                        // Shift right to back
                        newColors[1][2, 0] = RightColors[2, 0];
                        newColors[1][2, 1] = RightColors[2, 1];
                        newColors[1][2, 2] = RightColors[2, 2];
                    }
                    break;
                #endregion
            }

            AllColors = newColors;
        }

        /// <summary>
        /// Creates a new RubiksCube from this instance.
        /// </summary>
        public object Clone()
        {
            var colors = CloneColors(AllColors);
            return new RubiksCube(colors);
        }
    }
}
