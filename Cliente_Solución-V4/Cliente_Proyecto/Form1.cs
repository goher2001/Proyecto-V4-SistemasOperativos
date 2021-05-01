using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cliente_Proyecto
{
    public partial class Form1 : Form
    {
      
        Socket server;
        Thread atender;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.CadetBlue;
        }
        private void AtenderServidor()
        {
            while (true)
            {
                byte[] msg2 = new byte[700];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string[] trozos = mensaje.Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                mensaje = trozos[1];
                switch (codigo)
                {
                
                    case 1:
                        
                       MessageBox.Show(mensaje);
                       break;
                 
                    case 2:
                       
                    MessageBox.Show(mensaje);
                    break;
               
                    case  3: 
                   
                    MessageBox.Show(mensaje);
                    break;

                    case 4:
                        
                        MessageBox.Show(mensaje);
                        break;

                    case 5:
                       
                        MessageBox.Show(mensaje);
                        break;

                    case 6:
                        
                        MessageBox.Show(mensaje);
                        break;

                    case 7:
                        MessageBox.Show(mensaje);
                        break;

                    case 8:
                        Invitacion f = new Invitacion();
                        f.ShowDialog();
                       string result = f.Mensaje();
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(result);
                        server.Send(msg);
                        break;

                    case 9:
                        MessageBox.Show(mensaje);
                        break;



                }
            }
            
        }
        private void ConectarB_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("147.83.117.22");
            IPEndPoint ipep = new IPEndPoint(direc, 50051);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);

                MessageBox.Show("Conectado");
                Conectar V = new Conectar();
                V.ShowDialog();
                string mensaje = V.Mensaje();
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);


            }
            catch (SocketException ex)
            {

                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
            ThreadStart ts = delegate {AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
            
        }

        private void EnviarB_Click(object sender, EventArgs e)
        {
            if (MostrarJR.Checked)
            {
                string mensaje = "1/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

               
            }
          
            else if (PganadasR.Checked)
            {
                string mensaje = ("2/" + nombreG.Text + "/");
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                
            }
          
          else  if (ResultadosR.Checked)
            {
                string mensaje = "3/";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
              
                
            }
        }

        private void IniciarSB_Click(object sender, EventArgs e)
        {
             Logging formv = new Logging();
            formv.ShowDialog();
           string mensaje = formv.Mensaje();
            
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            
           

        }

        private void DesconectarB_Click(object sender, EventArgs e)
        {
            string mensaje = "0/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            atender.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            MessageBox.Show("Desconectado");

        }

        private void RegistrarB_Click(object sender, EventArgs e)
        {
            Registro form = new Registro();
            form.ShowDialog();
            string mensaje = form.mensaje();
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

          


           
        }

       

        private void Usuarios_Click(object sender, EventArgs e)
        {
            string mensaje = "8/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[100];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            MessageBox.Show(mensaje);
        }

        private void Invitar_Click(object sender, EventArgs e)
        {
            string mensaje = "9/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }
    }
}
