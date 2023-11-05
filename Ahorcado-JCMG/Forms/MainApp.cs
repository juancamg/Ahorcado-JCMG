using Ahorcado_JCMG.Forms;

namespace Ahorcado_JCMG
{
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }

        private void button_1pmode_MouseEnter(object sender, EventArgs e)
        {
            button_1pmode.Height = 65;
            button_1pmode.Width = 53;
        }

        private void button_1pmode_MouseLeave(object sender, EventArgs e)
        {
            button_1pmode.Height = 60;
            button_1pmode.Width = 47;
        }

        private void button_2pmode_MouseEnter(object sender, EventArgs e)
        {
            button_2pmode.Height = 65;
            button_2pmode.Width = 53;
        }

        private void button_2pmode_MouseLeave(object sender, EventArgs e)
        {
            button_2pmode.Height = 60;
            button_2pmode.Width = 47;
        }

        private void button_1pmode_Click(object sender, EventArgs e)
        {
            // Abre el formulario de configuración de partida
            ConfigurationForm configForm = new ConfigurationForm();
            configForm.AceptarConfiguracion += (sender2, e2) =>
            {
                // Evento que se dispara cuando se acepta la configuración
                configForm.Close();

                // Abre el formulario de selección de avatares
                AvatarSelectionForm avatarForm = new AvatarSelectionForm();
                avatarForm.AceptarAvatares += (sender3, e3) =>
                {
                    // Evento que se desencadena cuando se acepta la selección de avatares
                    avatarForm.Close();

                    // Abre el formulario de juego 1P
                    string categoriaSeleccionada = configForm.comboBoxCategoria.Text; // Obtén la categoría seleccionada
                    _1PlayerMode gameForm = new _1PlayerMode(categoriaSeleccionada);
                    gameForm.InicializarAvatar(avatarForm.SelectedAvatar);
                    gameForm.Show();
                    gameForm.FormClosed += (s, args) => this.Show(); // Muestra MainApp cuando gameForm se cierre
                    this.Hide();
                };
                avatarForm.ShowDialog();
            };
            configForm.ShowDialog();
        }


        private void button_2pmode_Click(object sender, EventArgs e)
        {
            // Abre el formulario de configuración de partida
            ConfigurationForm configForm = new ConfigurationForm();
            configForm.AceptarConfiguracion += (sender2, e2) =>
            {
                // Evento que se dispara cuando se acepta la configuración
                configForm.Close();

                // Variables para almacenar avatares seleccionados
                int selectedAvatar1 = 0;
                int selectedAvatar2 = 0;

                // Abre el formulario de selección de avatares para el jugador 1
                AvatarSelectionForm avatarForm1 = new AvatarSelectionForm();
                avatarForm1.AceptarAvatares += (sender3, e3) =>
                {
                    // Evento que se desencadena cuando se acepta la selección de avatares para el jugador 1
                    avatarForm1.Close();
                    selectedAvatar1 = avatarForm1.SelectedAvatar;

                    // Abre el formulario de selección de avatares para el jugador 2
                    AvatarSelectionForm avatarForm2 = new AvatarSelectionForm();
                    avatarForm2.AceptarAvatares += (sender4, e4) =>
                    {
                        // Evento que se desencadena cuando se acepta la selección de avatares para el jugador 2
                        avatarForm2.Close();
                        selectedAvatar2 = avatarForm2.SelectedAvatar;

                        // Abre el formulario de juego 2P
                        string categoriaSeleccionada = configForm.comboBoxCategoria.Text; // Obtén la categoría seleccionada
                        _2PlayerMode gameForm = new _2PlayerMode(categoriaSeleccionada);
                        gameForm.InicializarAvatar(selectedAvatar1, 1);
                        gameForm.InicializarAvatar(selectedAvatar2, 2);
                        gameForm.Show();
                        gameForm.FormClosed += (s, args) => this.Show(); // Muestra MainApp cuando gameForm se cierre
                        this.Hide();
                    };
                    avatarForm2.ShowDialog();
                };
                avatarForm1.ShowDialog();
            };
            configForm.ShowDialog();
        }

    }
}