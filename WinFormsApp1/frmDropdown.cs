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
using ComboBox = System.Windows.Forms.ComboBox;

namespace WinFormsApp1
{
    public partial class frmDropdown : Form
    {
        private SqlConnection cnn;

        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataSet dataSet;
        private int pageSize = 5;
        private int currentPage = 1;
        private int totalRows;

        public frmDropdown()
        {

            cnn = new SqlConnection("Server=DESKTOP-BLATUSV\\SQLEXPRESS;Database=db1; Integrated Security = True");
          
            InitializeComponent();
            InitializeDataGridView();
            LoadData();

        }

        private void LoadData()
        {
            UpdateDataGridView("TB_POLITICAS");
        }

        private void InitializeDataGridView()
        {
            try
            {

                dataAdapter = new SqlDataAdapter(queryLoad(), cnn);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "TB_POLITICAS");

                totalRows = dataSet.Tables["TB_POLITICAS"].Rows.Count;

                UpdateDataGridView("TB_POLITICAS");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void UpdateDataGridView(string tableName)
        {
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalRows);

            DataTable pageTable = dataSet.Tables[tableName].Clone();

            for (int i = startIndex; i < endIndex; i++)
            {
                pageTable.ImportRow(dataSet.Tables[tableName].Rows[i]);
            }

            dataGridView1.DataSource = pageTable;

            UpdateNavigationButtons();
        }

        private void UpdateNavigationButtons()
        {
            btnPrevious.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalRows / pageSize;
        }

        public string queryLoad()
        {
            string query = "SELECT * FROM TB_POLITICAS";
            return query;
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
                dataAdapter = new SqlDataAdapter(query, cnn);
                dataSet = new DataSet(tableName);
                dataAdapter.Fill(dataSet, tableName);

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    comboBox.Items.Add(dataSet.Tables[0].Rows[i][0] + " " + dataSet.Tables[0].Rows[i][1]);
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
            string query = $"SELECT * FROM TB_POLITICAS WHERE ID_REGRA = '{selectedRegra}' AND ID_CARTEIRA = '{selectedCarteira}'";

            PerformSearch(query);


            //dataGridView1.DataSource = dataSet.Tables["TB_POLITICAS_SEARCH_QUERY"];

        }

        private void PerformSearch(string query)
        {
            
            dataAdapter.SelectCommand.CommandText = query;
            dataSet.Clear();
            dataAdapter.Fill(dataSet, "TB_POLITICAS_SEARCH_QUERY");

            totalRows = dataSet.Tables["TB_POLITICAS_SEARCH_QUERY"].Rows.Count;

            currentPage = 1;
            UpdateDataGridView("TB_POLITICAS_SEARCH_QUERY");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                cboRegraEdit.Text = selectedRow.Cells[1].Value.ToString();
                cboEditCarteira.Text = selectedRow.Cells[2].Value.ToString();

            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);

                SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet, "TB_POLITICAS");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cboRegra.SelectedIndex = -1;
            cboCarteira.SelectedIndex = -1;
            dataGridView1.ClearSelection();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalRows / pageSize)
            {
                currentPage++;
                UpdateDataGridView(dataGridView1.DataSource.ToString());
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                UpdateDataGridView(dataGridView1.DataSource.ToString());
            }
        }
    }
}
