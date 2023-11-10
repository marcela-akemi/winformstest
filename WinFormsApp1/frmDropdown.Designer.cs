namespace WinFormsApp1
{
    partial class frmDropdown
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            idPolitica = new DataGridViewTextBoxColumn();
            idRegra = new DataGridViewTextBoxColumn();
            idCarteira = new DataGridViewTextBoxColumn();
            dsPolitica = new DataGridViewTextBoxColumn();
            dtInclusao = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            cboRegra = new ComboBox();
            cboCarteira = new ComboBox();
            btnPesquisar = new Button();
            labelRegra = new Label();
            labelCarteira = new Label();
            textBoxRegra = new TextBox();
            textBoxCarteira = new TextBox();
            cboEditCarteira = new ComboBox();
            btnSalvar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idPolitica, idRegra, idCarteira, dsPolitica, dtInclusao });
            dataGridView1.Location = new Point(12, 181);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 100;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 257);
            dataGridView1.TabIndex = 0;
            // 
            // idPolitica
            // 
            idPolitica.DataPropertyName = "ID_POLITICA";
            idPolitica.HeaderText = "ID Politica";
            idPolitica.Name = "idPolitica";
            // 
            // idRegra
            // 
            idRegra.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idRegra.DataPropertyName = "ID_REGRA";
            idRegra.HeaderText = "ID Regra";
            idRegra.Name = "idRegra";
            // 
            // idCarteira
            // 
            idCarteira.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idCarteira.DataPropertyName = "ID_CARTEIRA";
            idCarteira.HeaderText = "ID Carteira";
            idCarteira.Name = "idCarteira";
            // 
            // dsPolitica
            // 
            dsPolitica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dsPolitica.DataPropertyName = "DS_POLITICA";
            dsPolitica.HeaderText = "Politica";
            dsPolitica.Name = "dsPolitica";
            // 
            // dtInclusao
            // 
            dtInclusao.DataPropertyName = "DT_INCLUSAO";
            dtInclusao.HeaderText = "Data Inclusao";
            dtInclusao.Name = "dtInclusao";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // cboRegra
            // 
            cboRegra.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRegra.FormattingEnabled = true;
            cboRegra.Location = new Point(97, 41);
            cboRegra.Name = "cboRegra";
            cboRegra.Size = new Size(194, 28);
            cboRegra.TabIndex = 3;
            // 
            // cboCarteira
            // 
            cboCarteira.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCarteira.FormattingEnabled = true;
            cboCarteira.Location = new Point(393, 41);
            cboCarteira.Name = "cboCarteira";
            cboCarteira.Size = new Size(194, 28);
            cboCarteira.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(629, 38);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(117, 33);
            btnPesquisar.TabIndex = 5;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // labelRegra
            // 
            labelRegra.AutoSize = true;
            labelRegra.Location = new Point(43, 44);
            labelRegra.Name = "labelRegra";
            labelRegra.Size = new Size(48, 20);
            labelRegra.TabIndex = 6;
            labelRegra.Text = "Regra";
            // 
            // labelCarteira
            // 
            labelCarteira.AutoSize = true;
            labelCarteira.Location = new Point(326, 44);
            labelCarteira.Name = "labelCarteira";
            labelCarteira.Size = new Size(61, 20);
            labelCarteira.TabIndex = 7;
            labelCarteira.Text = "Carteira";
            // 
            // textBoxRegra
            // 
            textBoxRegra.Location = new Point(97, 107);
            textBoxRegra.Name = "textBoxRegra";
            textBoxRegra.Size = new Size(155, 27);
            textBoxRegra.TabIndex = 8;
            // 
            // textBoxCarteira
            // 
            textBoxCarteira.Location = new Point(97, 140);
            textBoxCarteira.Name = "textBoxCarteira";
            textBoxCarteira.Size = new Size(156, 27);
            textBoxCarteira.TabIndex = 9;
            // 
            // cboEditCarteira
            // 
            cboEditCarteira.FormattingEnabled = true;
            cboEditCarteira.Location = new Point(266, 107);
            cboEditCarteira.Name = "cboEditCarteira";
            cboEditCarteira.Size = new Size(151, 28);
            cboEditCarteira.TabIndex = 10;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(629, 107);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(103, 35);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // frmDropdown
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalvar);
            Controls.Add(cboEditCarteira);
            Controls.Add(textBoxCarteira);
            Controls.Add(textBoxRegra);
            Controls.Add(labelCarteira);
            Controls.Add(labelRegra);
            Controls.Add(btnPesquisar);
            Controls.Add(cboCarteira);
            Controls.Add(cboRegra);
            Controls.Add(dataGridView1);
            Name = "frmDropdown";
            Text = "frmDropdown";
            Load += frmDropdown_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ComboBox cboRegra;
        private ComboBox cboCarteira;
        private Button btnPesquisar;
        private Label labelRegra;
        private Label labelCarteira;
        private DataGridViewTextBoxColumn idPolitica;
        private DataGridViewTextBoxColumn idRegra;
        private DataGridViewTextBoxColumn idCarteira;
        private DataGridViewTextBoxColumn dsPolitica;
        private DataGridViewTextBoxColumn dtInclusao;
        private TextBox textBoxRegra;
        private TextBox textBoxCarteira;
        private ComboBox cboEditCarteira;
        private Button btnSalvar;
    }
}