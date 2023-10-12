using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmPopup : Form
    {
        public frmPopup()
        {
            InitializeComponent();
        }

        private void AdicionatBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idTextbox.Text) || string.IsNullOrEmpty(dataTextbox.Text))
            {
                MessageBox.Show("Os campos de Id e Data estão vazios.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Don't proceed if fields are empty
            }

            string Id = idTextbox.Text;
            string Dados = dataTextbox.Text;
            bool Flag = flagCheckbox.Checked;

            frmTeste frmTeste = new frmTeste();

            string inserir = frmTeste.InserirNovaLinha(Id, Dados, Flag);
            if (inserir != "ok")
            {
                return;
            }

            this.Close();

            
        }

        private void addCancelarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
