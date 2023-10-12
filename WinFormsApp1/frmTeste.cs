using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class frmTeste : Form
    {
        public frmTeste()
        {
            InitializeComponent();
            CarregarDadosAsync();
        }

        string connectionString = "Server=DESKTOP-BLATUSV\\SQLEXPRESS;Database=db1; Integrated Security = True";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Flag")
                {
                    bool newValue = (bool)dataGridView1.Rows[e.RowIndex].Cells["Flag"].Value;

                    int id = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                    AtualizaValorFlag(id, newValue);
                }
            }
        }

        private void AtualizaValorFlag(int id, bool newValue)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(AtualizaDadosTabelaBlock(), conn))
                {
                    cmd.Parameters.AddWithValue("@NewValue", newValue);
                    cmd.Parameters.AddWithValue("ID", id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        private string AtualizaDadosTabelaBlock()
        {
            string query = $@"UPDATE [dbo].[winforms]
                           SET 
                           [flag] = @NewValue
                             WHERE id = @ID";

            return query;
        }



        private async void ImportarCSVbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string connectionString = "Server=DESKTOP-BLATUSV\\SQLEXPRESS;Database=db1; Integrated Security = True";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CreateSpecificCulture("en")))
                    {
                        var records = csv.GetRecords<DataClass>().ToList();

                        foreach (var record in records)
                        {

                            using (var cmd = new SqlCommand("INSERT INTO dbo.winforms (ID, DATA, FLAG) VALUES (@Id, @Data, @Flag)", sqlConnection))
                            {
                                cmd.Parameters.AddWithValue("@Id", record.id);
                                cmd.Parameters.AddWithValue("@Data", record.data);
                                cmd.Parameters.AddWithValue("@Flag", record.flag);
                                cmd.ExecuteNonQuery();

                            }
                        }
                    }
                }



                MessageBox.Show("CSV importado com sucesso");
            }
            await CarregarDadosAsync();
        }

        private async Task CarregarDadosAsync()
        {
            string connectionString = "Server=DESKTOP-BLATUSV\\SQLEXPRESS;Database=db1; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                string query = "SELECT * FROM dbo.winforms order by id desc";

                DataTable dadosTabela = new DataTable();

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dadosTabela);
                }


                dataGridView1.DataSource = dadosTabela;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void ExportarCSVbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Exportar para CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    var data = new List<string>();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value);
                        data.Add(string.Join(",", cells));
                    }

                    File.WriteAllLines(filePath, data);

                    MessageBox.Show("Dados exportados com sucesso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting data: " + ex.Message);
                }
            }
        }
    }
}
