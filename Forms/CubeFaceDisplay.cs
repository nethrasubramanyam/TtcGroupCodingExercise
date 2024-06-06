using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TtcGroupRubiksCubeSimulator.Rubiks;
using static TtcGroupRubiksCubeSimulator.Rubiks.ColorGridRendering;

namespace TtcGroupRubiksCubeSimulator.Forms
{
    /// <summary>
    /// Represents a grid point mapper, to build point arrays on a grid.
    /// </summary>
    internal class CubeFaceDisplay : Control
    {

        
        #region Properties
        private ColorGridStyle Style =>
            new ColorGridStyle(GetDisplayColors(), 0.05f, RoundedRadius);


        private CubeSide face = CubeSide.None;
        [Category("Appearance"), DefaultValue(CubeSide.None)]
        [Description("The face or side of the cube to handle and display")]
        public CubeSide Face
        {
            get { return face; }
            set
            {
                face = value;
                Invalidate();
            }
        }

        private Color newColor;
        [Description("Determines the color to be set when right-clicking a cell")]
        [Category("Behavior")]
        public Color NewColor
        {
            get { return newColor; }
            set
            {
                if (newColor != value)
                {
                    newColor = value;
                    Invalidate();
                }
            }
        }

        private RubiksCube rubiksCube;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RubiksCube RubiksCube
        {
            get { return rubiksCube; }
            set
            {
                rubiksCube = value;
                Invalidate();
            }
        }

        private Color[,] FaceColors
        {
            get
            {
                if (rubiksCube == null) return null;

                switch (Face)
                {
                    case CubeSide.Front: return RubiksCube.FrontColors;
                    case CubeSide.Back: return RubiksCube.BackColors;
                    case CubeSide.Right: return RubiksCube.RightColors;
                    case CubeSide.Left: return RubiksCube.LeftColors;
                    case CubeSide.Up: return RubiksCube.UpColors;
                    case CubeSide.Down: return RubiksCube.DownColors;
                    default: return null;
                }
            }
        }

        private int roundedRadius = 1;
        [Category("Appearance"), DefaultValue(1)]
        [Description("The corner radius of the rounded rectangles used with this control")]
        public int RoundedRadius
        {
            get { return roundedRadius; }
            set
            {
                roundedRadius = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Transparent")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        #endregion

        public CubeFaceDisplay()
        {
            SetStyle(ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor, true);
            base.BackColor = Color.Transparent;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            ColorGridRendering.Draw(Style, e.Graphics, ClientSize, Enabled);

        }

        private Color[,] GetDisplayColors()
        {
            var faceColors = FaceColors;
            // If face == null then the CubeSide enum has not been set.
            if (rubiksCube == null || faceColors == null)
            {
                return RubiksCube.CreateFace(Color.White);
            }

            return faceColors;
        }

    }
}
