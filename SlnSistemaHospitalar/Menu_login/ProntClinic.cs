using SistemaHospitalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_login
{
    public partial class ProntClinic : Form
    {
        public ProntClinic()
        {
            InitializeComponent();
        }

        private object Button1_Click(object sender, EventArgs e)
        {
            string User = "admin";
            string Password = "admin";

            if (txtusuario.Text == User & txtsenha.Text == Password)
            {

                MessageBox.Show("Acesso liberado");
                sln Menumain = new sln();
                Menumain.Show();
                this.Hide();

            }else
            {
                MessageBox.Show("usuario ou senha incorreto");
            }

        }
    }
}
