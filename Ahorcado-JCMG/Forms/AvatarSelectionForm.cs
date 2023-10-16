using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado_JCMG.Forms
{
    public partial class AvatarSelectionForm : Form
    {
        public event EventHandler AceptarAvatares;

        public AvatarSelectionForm()
        {
            InitializeComponent();
        }

    private void buttonAceptar_Click(object sender, EventArgs e)
    {
            // Realiza las configuraciones necesarias y validaciones
            // ...

            // Dispara el evento de aceptación
            AceptarAvatares?.Invoke(this, EventArgs.Empty);

            // Cierra el formulario
            this.Close();
        }
    }

}
