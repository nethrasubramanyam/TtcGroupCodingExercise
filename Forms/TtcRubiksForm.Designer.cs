namespace TtcGroupRubiksCubeSimulator.Forms
{
    partial class TtcRubiksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblCommand;
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonReset = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cubeUp = new TtcGroupRubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeBack = new TtcGroupRubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeFront = new TtcGroupRubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeDown = new TtcGroupRubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeRight = new TtcGroupRubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeLeft = new TtcGroupRubiksCubeSimulator.Forms.CubeFaceDisplay();
            lblCommand = new System.Windows.Forms.Label();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCommand
            // 
            lblCommand.AutoSize = true;
            lblCommand.Location = new System.Drawing.Point(79, 58);
            lblCommand.Name = "lblCommand";
            lblCommand.Size = new System.Drawing.Size(82, 20);
            lblCommand.TabIndex = 18;
            lblCommand.Text = "Command";
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.AcceptsReturn = true;
            this.textBoxCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommand.Location = new System.Drawing.Point(167, 58);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(216, 26);
            this.textBoxCommand.TabIndex = 17;
            this.toolTip.SetToolTip(this.textBoxCommand, "Space-separated algorithms.");
            this.textBoxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCommand_KeyDown);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(427, 58);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(102, 32);
            this.buttonReset.TabIndex = 23;
            this.buttonReset.Text = "Reset";
            this.toolTip.SetToolTip(this.buttonReset, "Reset to the solved position");
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.45415F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.67249F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.76419F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.10917F));
            this.tableLayoutPanel.Controls.Add(this.cubeUp, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.cubeBack, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.cubeFront, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.cubeDown, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.cubeRight, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.cubeLeft, 0, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(79, 198);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(501, 354);
            this.tableLayoutPanel.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Press enter to execute the algorithm";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "F  R  U  B  L  D";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(201, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "F\' R\' U\' B\' L\' D\'";
            // 
            // cubeUp
            // 
            this.cubeUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeUp.Face = TtcGroupRubiksCubeSimulator.Rubiks.CubeSide.Up;
            this.cubeUp.Location = new System.Drawing.Point(126, 3);
            this.cubeUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeUp.Name = "cubeUp";
            this.cubeUp.NewColor = System.Drawing.Color.Empty;
            this.cubeUp.Size = new System.Drawing.Size(116, 112);
            this.cubeUp.TabIndex = 9;
            this.cubeUp.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeUp, "Top Face");
            // 
            // cubeBack
            // 
            this.cubeBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeBack.Face = TtcGroupRubiksCubeSimulator.Rubiks.CubeSide.Back;
            this.cubeBack.Location = new System.Drawing.Point(377, 120);
            this.cubeBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeBack.Name = "cubeBack";
            this.cubeBack.NewColor = System.Drawing.Color.Empty;
            this.cubeBack.Size = new System.Drawing.Size(120, 112);
            this.cubeBack.TabIndex = 3;
            this.cubeBack.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeBack, "Back Face");
            // 
            // cubeFront
            // 
            this.cubeFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeFront.Face = TtcGroupRubiksCubeSimulator.Rubiks.CubeSide.Front;
            this.cubeFront.Location = new System.Drawing.Point(126, 120);
            this.cubeFront.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeFront.Name = "cubeFront";
            this.cubeFront.NewColor = System.Drawing.Color.Empty;
            this.cubeFront.Size = new System.Drawing.Size(116, 112);
            this.cubeFront.TabIndex = 0;
            this.cubeFront.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeFront, "Front Face");
            // 
            // cubeDown
            // 
            this.cubeDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeDown.Face = TtcGroupRubiksCubeSimulator.Rubiks.CubeSide.Down;
            this.cubeDown.Location = new System.Drawing.Point(126, 237);
            this.cubeDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeDown.Name = "cubeDown";
            this.cubeDown.NewColor = System.Drawing.Color.Empty;
            this.cubeDown.Size = new System.Drawing.Size(116, 114);
            this.cubeDown.TabIndex = 11;
            this.cubeDown.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeDown, "Bottom Face");
            // 
            // cubeRight
            // 
            this.cubeRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeRight.Face = TtcGroupRubiksCubeSimulator.Rubiks.CubeSide.Right;
            this.cubeRight.Location = new System.Drawing.Point(249, 120);
            this.cubeRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeRight.Name = "cubeRight";
            this.cubeRight.NewColor = System.Drawing.Color.Empty;
            this.cubeRight.Size = new System.Drawing.Size(121, 112);
            this.cubeRight.TabIndex = 5;
            this.cubeRight.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeRight, "Right Face");
            // 
            // cubeLeft
            // 
            this.cubeLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeLeft.Face = TtcGroupRubiksCubeSimulator.Rubiks.CubeSide.Left;
            this.cubeLeft.Location = new System.Drawing.Point(4, 120);
            this.cubeLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeLeft.Name = "cubeLeft";
            this.cubeLeft.NewColor = System.Drawing.Color.Empty;
            this.cubeLeft.Size = new System.Drawing.Size(115, 112);
            this.cubeLeft.TabIndex = 7;
            this.cubeLeft.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeLeft, "Left Face");
            // 
            // TtcRubiksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 579);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(lblCommand);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.buttonReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "TtcRubiksForm";
            this.Text = "TTC Group Rubiks Cube Simulator";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CubeFaceDisplay cubeFront;
        private CubeFaceDisplay cubeBack;
        private CubeFaceDisplay cubeLeft;
        private CubeFaceDisplay cubeRight;
        private CubeFaceDisplay cubeDown;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.ToolTip toolTip;
        private CubeFaceDisplay cubeUp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

