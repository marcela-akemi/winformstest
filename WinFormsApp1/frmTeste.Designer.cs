namespace WinFormsApp1
{
    partial class frmTeste
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Data = new DataGridViewTextBoxColumn();
            Flag = new DataGridViewCheckBoxColumn();
            ImportarCSVbtn = new Button();
            ExportarCSVbtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            AdicionarBlock_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Data, Flag });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.Location = new Point(5, 57);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(948, 496);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChangedAsync;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            // 
            // Id
            // 
            Id.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Id.DataPropertyName = "id";
            Id.HeaderText = "ID";
            Id.Name = "Id";
            Id.Width = 49;
            // 
            // Data
            // 
            Data.DataPropertyName = "data";
            Data.HeaderText = "Data";
            Data.Name = "Data";
            // 
            // Flag
            // 
            Flag.DataPropertyName = "flag";
            Flag.HeaderText = "Flag";
            Flag.Name = "Flag";
            // 
            // ImportarCSVbtn
            // 
            ImportarCSVbtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ImportarCSVbtn.Location = new Point(766, 3);
            ImportarCSVbtn.Name = "ImportarCSVbtn";
            ImportarCSVbtn.Size = new Size(182, 40);
            ImportarCSVbtn.TabIndex = 1;
            ImportarCSVbtn.Text = "Importar CSV";
            ImportarCSVbtn.UseVisualStyleBackColor = true;
            ImportarCSVbtn.Click += ImportarCSVbtn_Click;
            // 
            // ExportarCSVbtn
            // 
            ExportarCSVbtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ExportarCSVbtn.Location = new Point(597, 3);
            ExportarCSVbtn.Name = "ExportarCSVbtn";
            ExportarCSVbtn.Size = new Size(160, 40);
            ExportarCSVbtn.TabIndex = 2;
            ExportarCSVbtn.Text = "Exportar para CSV";
            ExportarCSVbtn.UseVisualStyleBackColor = true;
            ExportarCSVbtn.Click += ExportarCSVbtn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.BackColor = SystemColors.Menu;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(ExportarCSVbtn, 1, 0);
            tableLayoutPanel1.Controls.Add(ImportarCSVbtn, 2, 0);
            tableLayoutPanel1.Controls.Add(AdicionarBlock_btn, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(5, 5);
            tableLayoutPanel1.MinimumSize = new Size(800, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(951, 48);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // AdicionarBlock_btn
            // 
            AdicionarBlock_btn.Location = new Point(3, 3);
            AdicionarBlock_btn.Name = "AdicionarBlock_btn";
            AdicionarBlock_btn.Size = new Size(128, 42);
            AdicionarBlock_btn.TabIndex = 3;
            AdicionarBlock_btn.Text = "Adicionar Item";
            AdicionarBlock_btn.UseVisualStyleBackColor = true;
            AdicionarBlock_btn.Click += AdicionarBlock_btn_Click;
            // 
            // frmTeste
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 561);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dataGridView1);
            MinimumSize = new Size(800, 600);
            Name = "frmTeste";
            Padding = new Padding(5);
            Text = "frmTeste";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewCheckBoxColumn Flag;
        private Button ImportarCSVbtn;
        private Button ExportarCSVbtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Button AdicionarBlock_btn;
    }
}