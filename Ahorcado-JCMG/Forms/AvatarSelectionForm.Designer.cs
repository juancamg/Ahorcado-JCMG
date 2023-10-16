namespace Ahorcado_JCMG.Forms
{
    partial class AvatarSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAceptar = new Button();
            SuspendLayout();
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(295, 131);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(75, 23);
            buttonAceptar.TabIndex = 0;
            buttonAceptar.Text = "button1";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // AvatarSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(buttonAceptar);
            Name = "AvatarSelectionForm";
            Text = "Selección de Avatar";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAceptar;
    }
}