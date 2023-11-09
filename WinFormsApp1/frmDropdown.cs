using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmDropdown : Form
    {
        private SqlConnection cnn;
        private SqlDataAdapter da;
        private DataSet ds;
        public frmDropdown()
        {
            InitializeComponent();

            cnn = new SqlConnection("Server=DESKTOP-BLATUSV\\SQLEXPRESS;Database=db1; Integrated Security = True");
            ds = new DataSet();
        }

        private void frmDropdown_Load(object sender, EventArgs e)
        {
            string query = "SELECT id_regra, ds_regra FROM TB_REGRAS";
            FillDropDown(query, cboRegra, "TB_REGRAS");

            query = "SELECT id_carteira, ds_carteira FROM TB_CARTEIRA";
            FillDropDown(query, cboCarteira, "TB_CARTEIRA");

        }

        private void FillDropDown(string query, ComboBox comboBox, string tableName)
        {
            try
            {
                da = new SqlDataAdapter(query, cnn);
                ds = new DataSet(tableName);
                da.Fill(ds, tableName);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    comboBox.Items.Add(ds.Tables[0].Rows[i][0] + " " + ds.Tables[0].Rows[i][1]);
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string selectedRegra = cboRegra.SelectedItem.ToString();
            string selectedCarteira = cboCarteira.SelectedItem.ToString();



        }
    }
}
