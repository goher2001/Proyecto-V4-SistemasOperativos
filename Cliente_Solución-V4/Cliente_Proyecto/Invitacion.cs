using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Proyecto
{
    public partial class Invitacion : Form
    {
        int confirmar;
        public Invitacion()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            confirmar = 1;
            this.Close();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            confirmar = 0;
            this.Close();
        }

        public string Mensaje ()
        {
            string mensaje;
            if (confirmar == 0)
            {
                mensaje = "10/0";

                return mensaje;
            }

            if (confirmar == 1)
            {
                mensaje = "10/1";
                return mensaje;
            }
            mensaje = "10/2";
            return mensaje;
        }

        private void Invitacion_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Aquamarine;
        }
    }
}
