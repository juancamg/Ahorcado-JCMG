using Ahorcado_JCMG.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Ahorcado_JCMG.Forms
{
    public partial class _2PlayerMode : Form
    {
        string palabraSecreta = "";
        Button[] letrasBotones = new Button[12];
        int intentosFallidosTot = 0;
        int intentosFallidosJ1 = 0;
        int intentosFallidosJ2 = 0;
        int puntosJ1 = 0;
        int erroresJ1 = 0;
        int puntosJ2 = 0;
        int erroresJ2 = 0;
        int turno = 0;
        string categoriaSeleccionada;
        public _2PlayerMode(String categoriaSeleccionada)
        {
            this.categoriaSeleccionada = categoriaSeleccionada;
            InitializeComponent();
            label_categoria.Text = "Categoría: " + categoriaSeleccionada;

            IniciarPartida();
        }

        private void IniciarPartida()
        {
            label_puntosJ1.Text = "Puntuación: " + puntosJ1;
            label_puntosJ2.Text = "Puntuación: " + puntosJ2;
            intentosFallidosTot = 0;
            erroresJ1 = 0;
            erroresJ2 = 0;
            label_erroresJ1.Text = "Errores: " + erroresJ1;
            label_erroresJ2.Text = "Errores: " + erroresJ2;
            label_erroresTot.Text = "Errores totales: 0";

            Random random = new Random();
            turno = random.Next(1, 3);
            label_turno.Text = "Turno: Jugador " + turno;

            palabraSecreta = GenerarPalabra(categoriaSeleccionada);
            InicializarBotones();
            InicializarTeclado();
            ActualizarImagenAhorcado(0);
        }

        private static string GenerarPalabra(string categoriaSeleccionada)
        {
            // Ruta del archivo XML
            string rutaArchivoXml = @"..\..\..\Resources\Dictionary.xml";

            // Crea un objeto XmlDocument y carga el archivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rutaArchivoXml);

            // Obtén la lista de palabras que pertenecen a la categoría seleccionada
            XmlNodeList words = xmlDoc.SelectNodes("/wordlist/word[@category='" + categoriaSeleccionada + "']");

            // Obtén una palabra aleatoria de la lista
            Random random = new Random();
            string palabraSecreta = words[random.Next(words.Count)].InnerText.ToUpper();

            return palabraSecreta;
        }

        private void InicializarBotones()
        {
            // Rellena el array letrasBotones con los botones correspondientes
            for (int i = 0; i < 12; i++)
            {
                letrasBotones[i] = panel1.Controls["letra" + (i + 1)] as Button;
                letrasBotones[i].Text = "";
            }

            // Inicializa los botones con guiones bajos según la longitud de palabraSecreta
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (i < letrasBotones.Length)
                {
                    letrasBotones[i].Text = "_";
                    letrasBotones[i].Visible = true;
                }
            }
        }
        private void InicializarTeclado()
        {
            // Crear un array de letras del teclado
            char[] letrasTeclado = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            foreach (char letra in letrasTeclado)
            {
                Button boton = Controls[letra + "_Key"] as Button;
                if (boton != null)
                {
                    boton.BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject($"{letra}_Key_Light");
                    boton.Enabled = true;
                }
            }
        }

        public void InicializarAvatar(int selectedAvatar, int jugador)
        {
            PictureBox avatarPictureBox = null;

            if (jugador == 1)
            {
                avatarPictureBox = avatar1_pictureBox;
            }
            else if (jugador == 2)
            {
                avatarPictureBox = avatar2_pictureBox;
            }

            if (avatarPictureBox != null)
            {
                switch (selectedAvatar)
                {
                    case 1: avatarPictureBox.Image = Properties.Resources.Avatar1; break;
                    case 2: avatarPictureBox.Image = Properties.Resources.Avatar2; break;
                    case 3: avatarPictureBox.Image = Properties.Resources.Avatar3; break;
                    case 4: avatarPictureBox.Image = Properties.Resources.Avatar4; break;
                    case 5: avatarPictureBox.Image = Properties.Resources.Avatar5; break;
                    case 6: avatarPictureBox.Image = Properties.Resources.Avatar6; break;
                    case 7: avatarPictureBox.Image = Properties.Resources.Avatar7; break;
                    default: avatarPictureBox.Image = null; break;
                }
                avatarPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void ActualizarImagenAhorcado(int intentos)
        {
            // Actualiza la imagen del ahorcado
            switch (intentos)
            {
                case 0: pictureBox_ahorcado.Image = null; break;
                case 1: pictureBox_ahorcado.Image = Properties.Resources.GummyBear1; break;
                case 2: pictureBox_ahorcado.Image = Properties.Resources.GummyBear2; break;
                case 3: pictureBox_ahorcado.Image = Properties.Resources.GummyBear3; break;
                case 4: pictureBox_ahorcado.Image = Properties.Resources.GummyBear4; break;
                case 5: pictureBox_ahorcado.Image = Properties.Resources.GummyBear5; break;
            }
            pictureBox_ahorcado.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private bool ComprobarLetra(char letra)
        {
            bool acierto = false;

            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (palabraSecreta[i] == letra)
                {
                    acierto = true;
                    letrasBotones[i].Text = letra.ToString();
                    if (turno == 1)
                    {
                        puntosJ1 = puntosJ1 + 2;
                        label_puntosJ1.Text = "Puntuación: " + puntosJ1;
                    } else if (turno == 2)
                    {
                        puntosJ2 = puntosJ2 + 2;
                        label_puntosJ2.Text = "Puntuación: " + puntosJ2;
                    }
                }
            }

            if (!acierto)
            {
                // La letra no se encuentra en la palabra
                intentosFallidosTot++;
                ActualizarImagenAhorcado(intentosFallidosTot);
                label_erroresTot.Text = "Errores totales: " + intentosFallidosTot;
                if (turno == 1)
                {
                    puntosJ1 = puntosJ1 - 1;
                    label_puntosJ1.Text = "Puntuación: " + puntosJ1;
                    erroresJ1 = erroresJ1 + 1;
                    label_erroresJ1.Text = "Errores: " + erroresJ1;
                }
                else if (turno == 2)
                {
                    puntosJ2 = puntosJ2 - 1;
                    label_puntosJ2.Text = "Puntuación: " + puntosJ2;
                    erroresJ2 = erroresJ2 + 1;
                    label_erroresJ2.Text = "Errores: " + erroresJ2;
                }
                return false;
            }
            return true;
        }

        private bool ComprobarVictoria()
        {
            foreach (Button boton in letrasBotones)
            {
                if (boton.Text == "_")
                {
                    return false; // Todavía hay al menos una letra sin adivinar
                }
            }
            string message = "¡Jugador " + turno + " ha ganado! Obtiene 10 puntos extra.\n¿Deseas jugar otra partida?";
            if (turno == 1)
            {
                puntosJ1 = puntosJ1 + 10;
            } else if (turno == 2)
            {
                puntosJ2 = puntosJ2 + 10;
            }
            DialogResult result = MessageBox.Show(message, "Partida finalizada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                IniciarPartida();
            }
            return true;
        }

        private bool ComprobarDerrota()
        {
            if (intentosFallidosTot >= 6)
            {
                string message = "¡Jugador " + turno + " ha perdido! Este jugador perdido 5 puntos. \nLa palabra era: " + palabraSecreta + ".\n¿Deseas jugar otra partida?";
                if (turno == 1)
                {
                    puntosJ1 = puntosJ1 - 5;
                }
                else if (turno == 2)
                {
                    puntosJ2 = puntosJ2 - 5;
                }
                DialogResult result = MessageBox.Show(message, "Partida finalizada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    IniciarPartida();
                }
                return true;
            }
            return false;
        }

        private void Letra_Click(object sender, EventArgs e, char letra)
        {
            if (ComprobarLetra(letra))
            {
                ((Button)sender).BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject($"{letra}_Key_Green");
            }
            else
            {
                ((Button)sender).BackgroundImage = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject($"{letra}_Key_Red");
                if (turno == 1)
                {
                    turno = 2;
                } else if (turno == 2)
                {
                    turno = 1;
                }
                label_turno.Text = "Turno: Jugador " + turno;
            }
             ((Button)sender).Enabled = false;

            ComprobarDerrota();
            ComprobarVictoria();
        }

        private void A_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'A');
        }

        private void B_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'B');
        }

        private void C_Key_Click_1(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'C');
        }

        private void D_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'D');
        }

        private void E_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'E');
        }

        private void F_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'F');
        }

        private void G_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'G');
        }

        private void H_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'H');
        }

        private void I_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'I');
        }

        private void J_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'J');
        }

        private void K_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'K');
        }

        private void L_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'L');
        }

        private void M_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'M');
        }

        private void N_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'N');
        }

        private void O_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'O');
        }

        private void P_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'P');
        }

        private void Q_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'Q');
        }

        private void R__Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'R');
        }

        private void S_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'S');
        }

        private void T_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'T');
        }

        private void U_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'U');
        }

        private void V_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'V');
        }

        private void W_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'W');
        }

        private void X_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'X');
        }

        private void Y_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'Y');
        }

        private void Z_Key_Click(object sender, EventArgs e)
        {
            Letra_Click(sender, e, 'Z');
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_howtoplay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pulsa con el mouse cada letra para intentar adivinar la palabra.\nTeneis 6 intentos.\nSi un jugador acierta la letra, sigue su turno. Por lo contrario, si falla la letra el turno pasa al otro jugador", "¿Cómo jugar?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
