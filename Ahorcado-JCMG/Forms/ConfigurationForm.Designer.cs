namespace Ahorcado_JCMG.Forms
{
    partial class ConfigurationForm
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
            comboBoxCategoria = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(133, 200);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(138, 47);
            buttonAceptar.TabIndex = 0;
            buttonAceptar.Text = "Confirmar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.Cursor = Cursors.Hand;
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.FlatStyle = FlatStyle.Flat;
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Items.AddRange(new object[] { "Animales", "Ciudades", "Deportes" });
            comboBoxCategoria.Location = new Point(208, 72);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(133, 23);
            comboBoxCategoria.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 75);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 5;
            label1.Text = "Seleccione una categoría:";
            // 
            // ConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(label1);
            Controls.Add(comboBoxCategoria);
            Controls.Add(buttonAceptar);
            Name = "ConfigurationForm";
            Text = "Opciones de partida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAceptar;
        public static ComboBox comboBoxCategoria;
        private Label label1;
    }
}