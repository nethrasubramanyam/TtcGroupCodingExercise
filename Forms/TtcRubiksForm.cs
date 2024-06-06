using TtcGroupRubiksCubeSimulator.Rubiks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TtcGroupRubiksCubeSimulator.Forms
{
    public partial class TtcRubiksForm : Form
    {
        private RubiksCube rubiksCube;

        /// <summary>
        /// Gets all of the cube displays on the form.
        /// </summary>
        private IEnumerable<CubeFaceDisplay> CubeDisplays =>
            tableLayoutPanel.Controls.OfType<CubeFaceDisplay>();

        public TtcRubiksForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
            SetRubiksCube();
        }

        private void SetRubiksCube()
        {
            // Create a solved cube with the developers color scheme
            rubiksCube = RubiksCube.Create(CubeColors.TtcsScheme);

            UpdateDisplayedCube();
        }


        private void UpdateDisplayedCube()
        {
            foreach (var display in CubeDisplays)
                display.RubiksCube = rubiksCube;
        }

        private static DialogResult ShowQuestionPrompt(string message)
        {
            return MessageBox.Show(message, Application.ProductName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (ShowQuestionPrompt("Are you sure you want to undo changes?") == DialogResult.Yes)
            {
                rubiksCube.Reset();
                tableLayoutPanel.Invalidate(true);
            }
        }

        private void textBoxCommand_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxCommand.BackColor = Color.FromKnownColor(KnownColor.Window);
            if (e.KeyCode != Keys.Enter) return;
            string[] splitted = textBoxCommand.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var moveList = new List<CubeMove>();

            foreach (string str in splitted)
            {
                try
                {
                    moveList.Add(new CubeMove(str));
                }
                catch (ArgumentException)
                {
                    textBoxCommand.BackColor = Color.LightPink;
                    return; // Invalid input
                }
            }

            foreach (var move in moveList)
            {
                rubiksCube.MakeMove(move);
            }

            e.SuppressKeyPress = true;
            textBoxCommand.Clear();
            tableLayoutPanel.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
