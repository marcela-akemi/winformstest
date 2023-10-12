namespace WinFormsApp1
{
    partial class frmPopup
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
            idTextbox = new TextBox();
            dataTextbox = new TextBox();
            flagCheckbox = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            AdicionatBtn = new Button();
            addCancelarBtn = new Button();
            SuspendLayout();
            // 
            // idTextbox
            // 
            idTextbox.Location = new Point(82, 62);
            idTextbox.Name = "idTextbox";
            idTextbox.Size = new Size(194, 27);
            idTextbox.TabIndex = 0;
            // 
            // dataTextbox
            // 
            dataTextbox.Location = new Point(82, 114);
            dataTextbox.Name = "dataTextbox";
            dataTextbox.Size = new Size(194, 27);
            dataTextbox.TabIndex = 1;
            // 
            // flagCheckbox
            // 
            flagCheckbox.AutoSize = true;
            flagCheckbox.Location = new Point(82, 170);
            flagCheckbox.Name = "flagCheckbox";
            flagCheckbox.Size = new Size(68, 24);
            flagCheckbox.TabIndex = 2;
            flagCheckbox.Text = "Fase 2";
            flagCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 62);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 3;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 117);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 4;
            label2.Text = "Data";
            // 
            // AdicionatBtn
            // 
            AdicionatBtn.DialogResult = DialogResult.OK;
            AdicionatBtn.Location = new Point(177, 235);
            AdicionatBtn.Name = "AdicionatBtn";
            AdicionatBtn.Size = new Size(99, 31);
            AdicionatBtn.TabIndex = 5;
            AdicionatBtn.Text = "Adicionar";
            AdicionatBtn.UseVisualStyleBackColor = true;
            AdicionatBtn.Click += AdicionatBtn_Click;
            // 
            // addCancelarBtn
            // 
            addCancelarBtn.DialogResult = DialogResult.Cancel;
            addCancelarBtn.Location = new Point(51, 235);
            addCancelarBtn.Name = "addCancelarBtn";
            addCancelarBtn.Size = new Size(99, 31);
            addCancelarBtn.TabIndex = 6;
            addCancelarBtn.Text = "Cancelar";
            addCancelarBtn.UseVisualStyleBackColor = true;
            addCancelarBtn.Click += addCancelarBtn_Click;
            // 
            // frmPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 278);
            Controls.Add(addCancelarBtn);
            Controls.Add(AdicionatBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flagCheckbox);
            Controls.Add(dataTextbox);
            Controls.Add(idTextbox);
            Name = "frmPopup";
            Text = "Adicionar item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextbox;
        private TextBox dataTextbox;
        private CheckBox flagCheckbox;
        private Label label1;
        private Label label2;
        private Button AdicionatBtn;
        private Button addCancelarBtn;
    }
}