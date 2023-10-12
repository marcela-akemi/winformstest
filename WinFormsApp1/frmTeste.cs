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

        private Task CarregarDadosAsync()
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
                return Task.FromException(ex);

            }
            finally
            {
                sqlConnection.Close();
            }

            return Task.CompletedTask;
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

        private Task AtualizaValorFlag(int id, bool newValue)
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
            return Task.CompletedTask;
        }

        private async void dataGridView1_CellValueChangedAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Flag")
                {
                    bool newValue = (bool)dataGridView1.Rows[e.RowIndex].Cells["Flag"].Value;

                    int id = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
                    await AtualizaValorFlag(id, newValue);
                }
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }




        public string InserirNovaLinha(string novoId, string novoData, bool novoFlag)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(InserirTabelaBloqueados(), conn))
                {

                    cmd.Parameters.AddWithValue("@Id", novoId);
                    cmd.Parameters.AddWithValue("@Data", novoData);
                    cmd.Parameters.AddWithValue("@Flag", novoFlag);
                    cmd.ExecuteNonQuery();

                }

                conn.Close();
            }

            return "ok";


        }

        private string AtualizaDadosTabelaBlock()
        {
            string query = $@"UPDATE [dbo].[winforms]
                           SET 
                           [flag] = @NewValue
                             WHERE id = @ID";

            return query;
        }
        private string InserirTabelaBloqueados()
        {
            string query = $@"INSERT INTO dbo.winforms (ID, DATA, FLAG) 
                            VALUES 
                            (
                              @Id
                            , @Data
                            , @Flag
                             )";

            return query;
        }

        private void AdicionarBlock_btn_Click(object sender, EventArgs e)
        {
            using (frmPopup formPopup = new frmPopup())
            {
                DialogResult result = formPopup.ShowDialog();
                if (formPopup.DialogResult != DialogResult.None)
                {
                    CarregarDadosAsync();
                } 
            }

            return;
        }


        //private async void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dataGridView1.Columns[e.ColumnIndex].Name == "Flag")
        //    {
        //        if (dataGridView1.Columns[e.ColumnIndex].Name == "Flag")
        //        {
        //            bool newValue = (bool)dataGridView1.Rows[e.RowIndex].Cells["Flag"].Value;

        //            int id = (int)dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
        //            await AtualizaValorFlag(id, newValue);
        //        }
        //    }
        //}
    }
}
