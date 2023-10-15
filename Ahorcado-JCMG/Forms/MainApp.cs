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

        private void button_storymode_MouseEnter(object sender, EventArgs e)
        {
            button_storymode.Height = 65;
            button_storymode.Width = 53;
        }

        private void button_storymode_MouseLeave(object sender, EventArgs e)
        {
            button_storymode.Height = 60;
            button_storymode.Width = 47;
        }

        private void button_1pmode_Click(object sender, EventArgs e)
        {
            // Crear una instancia de 1PlayerMode
            Forms._1PlayerMode form1PlayerMode = new Forms._1PlayerMode();

            // Configurar las mismas medidas y posición que MainApp
            form1PlayerMode.Size = this.Size;
            form1PlayerMode.Location = this.Location;

            // Mostrar 1PlayerMode y ocultar MainApp
            form1PlayerMode.Show();
            this.Hide();

            form1PlayerMode.FormClosed += (s, args) => this.Show();
        }

        private void button_2pmode_Click(object sender, EventArgs e)
        {
            // Crear una instancia de 2PlayerMode
            Forms._2PlayerMode form2PlayerMode = new Forms._2PlayerMode();

            // Configurar las mismas medidas y posición que MainApp
            form2PlayerMode.Size = this.Size;
            form2PlayerMode.Location = this.Location;

            // Mostrar 2PlayerMode y ocultar MainApp
            form2PlayerMode.Show();
            this.Hide();

            form2PlayerMode.FormClosed += (s, args) => this.Show();
        }

        private void button_storymode_Click(object sender, EventArgs e)
        {
            // Crear una instancia de StoryMode
            Forms.StoryMode formStoryMode = new Forms.StoryMode();

            // Configurar las mismas medidas y posición que MainApp
            formStoryMode.Size = this.Size;
            formStoryMode.Location = this.Location;

            // Mostrar StoryMode y ocultar MainApp
            formStoryMode.Show();
            this.Hide();

            formStoryMode.FormClosed += (s, args) => this.Show();
        }
    }
}