namespace Ahorcado_JCMG
{
    partial class MainApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button_1pmode = new Button();
            button_2pmode = new Button();
            button_storymode = new Button();
            label_1p = new Label();
            label_2p = new Label();
            label_story = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Leelawadee", 72F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Purple;
            label1.Location = new Point(202, 9);
            label1.Name = "label1";
            label1.Size = new Size(541, 115);
            label1.TabIndex = 0;
            label1.Text = "Ahorcadox";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button_1pmode
            // 
            button_1pmode.BackColor = Color.Transparent;
            button_1pmode.BackgroundImage = Properties.Resources._1playermode_icon;
            button_1pmode.BackgroundImageLayout = ImageLayout.Stretch;
            button_1pmode.Cursor = Cursors.Hand;
            button_1pmode.FlatAppearance.BorderSize = 0;
            button_1pmode.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_1pmode.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_1pmode.FlatStyle = FlatStyle.Flat;
            button_1pmode.ForeColor = Color.Transparent;
            button_1pmode.Location = new Point(421, 139);
            button_1pmode.Name = "button_1pmode";
            button_1pmode.Size = new Size(47, 60);
            button_1pmode.TabIndex = 1;
            button_1pmode.UseVisualStyleBackColor = false;
            button_1pmode.Click += button_1pmode_Click;
            button_1pmode.MouseEnter += button_1pmode_MouseEnter;
            button_1pmode.MouseLeave += button_1pmode_MouseLeave;
            // 
            // button_2pmode
            // 
            button_2pmode.BackColor = Color.Transparent;
            button_2pmode.BackgroundImage = Properties.Resources._2playermode_icon;
            button_2pmode.BackgroundImageLayout = ImageLayout.Stretch;
            button_2pmode.Cursor = Cursors.Hand;
            button_2pmode.FlatAppearance.BorderSize = 0;
            button_2pmode.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_2pmode.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_2pmode.FlatStyle = FlatStyle.Flat;
            button_2pmode.ForeColor = Color.Transparent;
            button_2pmode.Location = new Point(421, 215);
            button_2pmode.Name = "button_2pmode";
            button_2pmode.Size = new Size(47, 60);
            button_2pmode.TabIndex = 2;
            button_2pmode.UseVisualStyleBackColor = false;
            button_2pmode.Click += button_2pmode_Click;
            button_2pmode.MouseEnter += button_2pmode_MouseEnter;
            button_2pmode.MouseLeave += button_2pmode_MouseLeave;
            // 
            // button_storymode
            // 
            button_storymode.BackColor = Color.Transparent;
            button_storymode.BackgroundImage = Properties.Resources.storymode_icon2;
            button_storymode.BackgroundImageLayout = ImageLayout.Stretch;
            button_storymode.Cursor = Cursors.Hand;
            button_storymode.FlatAppearance.BorderSize = 0;
            button_storymode.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_storymode.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_storymode.FlatStyle = FlatStyle.Flat;
            button_storymode.ForeColor = Color.Transparent;
            button_storymode.Location = new Point(421, 290);
            button_storymode.Name = "button_storymode";
            button_storymode.Size = new Size(47, 60);
            button_storymode.TabIndex = 3;
            button_storymode.UseVisualStyleBackColor = false;
            button_storymode.Click += button_storymode_Click;
            button_storymode.MouseEnter += button_storymode_MouseEnter;
            button_storymode.MouseLeave += button_storymode_MouseLeave;
            // 
            // label_1p
            // 
            label_1p.AutoSize = true;
            label_1p.BackColor = Color.Transparent;
            label_1p.Font = new Font("Franklin Gothic Medium", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label_1p.Location = new Point(483, 154);
            label_1p.Name = "label_1p";
            label_1p.Size = new Size(108, 26);
            label_1p.TabIndex = 4;
            label_1p.Text = "1 Jugador";
            // 
            // label_2p
            // 
            label_2p.AutoSize = true;
            label_2p.BackColor = Color.Transparent;
            label_2p.Font = new Font("Franklin Gothic Medium", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label_2p.Location = new Point(483, 230);
            label_2p.Name = "label_2p";
            label_2p.Size = new Size(131, 26);
            label_2p.TabIndex = 5;
            label_2p.Text = "2 Jugadores";
            // 
            // label_story
            // 
            label_story.AutoSize = true;
            label_story.BackColor = Color.Transparent;
            label_story.Font = new Font("Franklin Gothic Medium", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label_story.Location = new Point(483, 305);
            label_story.Name = "label_story";
            label_story.Size = new Size(90, 26);
            label_story.TabIndex = 6;
            label_story.Text = "Historia";
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.mainApp_background_ajusted;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1008, 729);
            Controls.Add(label_story);
            Controls.Add(label_2p);
            Controls.Add(label_1p);
            Controls.Add(button_storymode);
            Controls.Add(button_2pmode);
            Controls.Add(button_1pmode);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainApp";
            Text = "Ahorcadox - Menú principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button_1pmode;
        private Button button_2pmode;
        private Button button_storymode;
        private Label label_1p;
        private Label label_2p;
        private Label label_story;
    }
}