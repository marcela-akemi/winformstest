using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public int extractNumber(string comboValue)
        {
            string numberPattern = @"\b\d{1,3}\b";

            Match match = Regex.Match(comboValue, numberPattern);
            if (match.Success)
            {

                string numberString = match.Value;
                int number = int.Parse(numberString);

                return number;
            }
            else
            {
                MessageBox.Show("No nubmer found");
                return -1;
            }


        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string regra = cboRegra.SelectedItem.ToString();
            int selectedRegra = extractNumber(regra);
            string carteira = cboCarteira.SelectedItem.ToString();
            int selectedCarteira = extractNumber(carteira);

            string query = $"SELECT * FROM TB_POLITICA WHERE ID_REGRA = '{selectedRegra}' AND ID_CARTEIRA = '{selectedCarteira}'";
            da.SelectCommand.CommandText = query;
            ds.Clear();
            da.Fill(ds, "TB_POLITICA");

            dataGridView1.DataSource = ds.Tables["TB_POLITICA"];

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                dataTable.Rows[selectedIndex]["ID"] = textBoxID.Text;
                dataTable.Rows[selectedIndex]["Name"] = textBoxName.Text;

                string connectionString = "Data Source=YOUR_DATA_SOURCE;Initial Catalog=YOUR_DATABASE;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE YourTable SET ID = @ID, Name = @Name WHERE ID = @OriginalID";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@ID", textBoxID.Text);
                    command.Parameters.AddWithValue("@Name", textBoxName.Text);
                    command.Parameters.AddWithValue("@OriginalID", dataGridView1.Rows[selectedIndex].Cells["ID"].Value.ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
    }
}
