using System;
using System.Windows.Forms;
using CsvHelper;
using System.IO;
using System.Data.SqlClient;
using WinFormsApp1.Model;
using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CarregarDadosAsync();
        }

        private async
        Task
CarregarDadosAsync()
        {
            string connectionString = "Server=DESKTOP-BLATUSV\\SQLEXPRESS;Database=db1; Integrated Security = True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                string query = "SELECT * FROM dbo.winforms";

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

        private async void button1_ClickAsync(object sender, EventArgs e)
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

                            using (var cmd = new SqlCommand("INSERT INTO dbo.winforms (ID, DATA) VALUES (@Id, @Data)", sqlConnection))
                            {
                                cmd.Parameters.AddWithValue("@Id", record.id);
                                cmd.Parameters.AddWithValue("@Data", record.data);
                                cmd.ExecuteNonQuery();

                            }
                        }
                    }
                }



                MessageBox.Show("CSV importado com sucesso");
            }
            await CarregarDadosAsync();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Exportar para CSV";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
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
                }catch(Exception ex) 
                {
                    MessageBox.Show("Error exporting data: " + ex.Message);
                }
            }
        }
    }
}