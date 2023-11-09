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
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            cboRegra = new ComboBox();
            cboCarteira = new ComboBox();
            btnPesquisar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 181);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 257);
            dataGridView1.TabIndex = 0;
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
            cboCarteira.Location = new Point(97, 90);
            cboCarteira.Name = "cboCarteira";
            cboCarteira.Size = new Size(194, 28);
            cboCarteira.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(422, 62);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(117, 39);
            btnPesquisar.TabIndex = 5;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // frmDropdown
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPesquisar);
            Controls.Add(cboCarteira);
            Controls.Add(cboRegra);
            Controls.Add(dataGridView1);
            Name = "frmDropdown";
            Text = "frmDropdown";
            Load += frmDropdown_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ComboBox cboRegra;
        private ComboBox cboCarteira;
        private Button btnPesquisar;
    }
}