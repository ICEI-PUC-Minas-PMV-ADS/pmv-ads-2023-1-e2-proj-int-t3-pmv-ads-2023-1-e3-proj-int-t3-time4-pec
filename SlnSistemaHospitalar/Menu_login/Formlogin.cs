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
    public partial class Formlogin : Form
    {
        public Formlogin()
        {
            InitializeComponent();
        }

        public object LogadaMain { get; private set; }

        private void btnacesso_Click(object sender, EventArgs e)
        {
            String User = "admin";
            String Password = "admin";
            if (txtusuario.Text == User & txtsenha.Text == Password)
            {
                MessageBox.Show("Acesso liberado");
                LoginController LogadaMain = new LoginController();
                LogadaMain.Show();
                this.Hide();
                
            }else
            {
                MessageBox.Show("Usuario ou senha incorreta");
            }
        }

        private class LoginController
        {
            public LoginController()
            {
            }

            internal void Show()
            {
                throw new NotImplementedException();
            }
        }
    }
}
