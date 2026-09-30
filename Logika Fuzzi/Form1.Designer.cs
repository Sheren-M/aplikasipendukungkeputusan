namespace Logika_Fuzzi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelT1 = new Label();
            labelT2 = new Label();
            labelT3 = new Label();
            labelT4 = new Label();
            labelT5 = new Label();
            txtT1 = new TextBox();
            txtT2 = new TextBox();
            txtT3 = new TextBox();
            txtT4 = new TextBox();
            txtT5 = new TextBox();
            labelUTS = new Label();
            labelUAS = new Label();
            txtUTS = new TextBox();
            txtUAS = new TextBox();
            btnHitung = new Button();
            btnReset = new Button();
            labelAvg = new Label();
            lblAvgValue = new Label();
            labelFinal = new Label();
            lblFinalValue = new Label();
            labelCategory = new Label();
            lblCategoryValue = new Label();
            SuspendLayout();

            // form styling
            BackColor = Color.WhiteSmoke;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            // header panel
            var headerPanel = new Panel();
            headerPanel.BackColor = Color.FromArgb(21, 90, 140);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Size = new Size(640, 72);
            headerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            var titleLabel = new Label();
            titleLabel.Text = "Sistem Penilaian Mahasiswa — Logika Fuzzy";
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(20, 18);
            titleLabel.AutoSize = true;
            headerPanel.Controls.Add(titleLabel);

            // left panel for input
            var leftPanel = new Panel();
            leftPanel.Location = new Point(20, 92);
            leftPanel.Size = new Size(300, 330);
            leftPanel.BackColor = Color.White;
            leftPanel.BorderStyle = BorderStyle.FixedSingle;

            // right panel for results
            var rightPanel = new Panel();
            rightPanel.Location = new Point(340, 92);
            rightPanel.Size = new Size(280, 330);
            rightPanel.BackColor = Color.White;
            rightPanel.BorderStyle = BorderStyle.FixedSingle;

            // left inputs
            labelT1.AutoSize = true; labelT1.Location = new Point(16, 16); labelT1.Text = "Tugas 1"; labelT1.Font = new Font("Segoe UI", 9F);
            txtT1.Location = new Point(110, 12); txtT1.Size = new Size(170, 27); txtT1.PlaceholderText = "0–100"; txtT1.KeyPress += Txt_DigitsOnly;

            labelT2.AutoSize = true; labelT2.Location = new Point(16, 56); labelT2.Text = "Tugas 2"; labelT2.Font = new Font("Segoe UI", 9F);
            txtT2.Location = new Point(110, 52); txtT2.Size = new Size(170, 27); txtT2.PlaceholderText = "0–100"; txtT2.KeyPress += Txt_DigitsOnly;

            labelT3.AutoSize = true; labelT3.Location = new Point(16, 96); labelT3.Text = "Tugas 3"; labelT3.Font = new Font("Segoe UI", 9F);
            txtT3.Location = new Point(110, 92); txtT3.Size = new Size(170, 27); txtT3.PlaceholderText = "0–100"; txtT3.KeyPress += Txt_DigitsOnly;

            labelT4.AutoSize = true; labelT4.Location = new Point(16, 136); labelT4.Text = "Tugas 4"; labelT4.Font = new Font("Segoe UI", 9F);
            txtT4.Location = new Point(110, 132); txtT4.Size = new Size(170, 27); txtT4.PlaceholderText = "0–100"; txtT4.KeyPress += Txt_DigitsOnly;

            labelT5.AutoSize = true; labelT5.Location = new Point(16, 176); labelT5.Text = "Tugas 5"; labelT5.Font = new Font("Segoe UI", 9F);
            txtT5.Location = new Point(110, 172); txtT5.Size = new Size(170, 27); txtT5.PlaceholderText = "0–100"; txtT5.KeyPress += Txt_DigitsOnly;

            labelUTS.AutoSize = true; labelUTS.Location = new Point(16, 212); labelUTS.Text = "UTS"; labelUTS.Font = new Font("Segoe UI", 9F);
            txtUTS.Location = new Point(110, 208); txtUTS.Size = new Size(170, 27); txtUTS.PlaceholderText = "0–100"; txtUTS.KeyPress += Txt_DigitsOnly;

            labelUAS.AutoSize = true; labelUAS.Location = new Point(16, 248); labelUAS.Text = "UAS"; labelUAS.Font = new Font("Segoe UI", 9F);
            txtUAS.Location = new Point(110, 244); txtUAS.Size = new Size(170, 27); txtUAS.PlaceholderText = "0–100"; txtUAS.KeyPress += Txt_DigitsOnly;

            btnHitung.Location = new Point(16, 288); btnHitung.Size = new Size(150, 36); btnHitung.Text = "Hitung Nilai"; btnHitung.BackColor = Color.FromArgb(13, 140, 136); btnHitung.ForeColor = Color.White; btnHitung.FlatStyle = FlatStyle.Flat; btnHitung.Click += btnHitung_Click;
            btnReset.Location = new Point(170, 288); btnReset.Size = new Size(110, 36); btnReset.Text = "Reset"; btnReset.BackColor = Color.White; btnReset.ForeColor = Color.FromArgb(13, 140, 136); btnReset.FlatStyle = FlatStyle.Flat; btnReset.FlatAppearance.BorderColor = Color.FromArgb(13, 140, 136); btnReset.Click += btnReset_Click;

            // right results
            labelAvg.AutoSize = true; labelAvg.Location = new Point(16, 16); labelAvg.Text = "Rata-rata Tugas"; labelAvg.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAvgValue.Location = new Point(20, 44); lblAvgValue.Size = new Size(240, 44); lblAvgValue.Text = "-"; lblAvgValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold); lblAvgValue.BackColor = Color.FromArgb(240, 248, 250); lblAvgValue.TextAlign = ContentAlignment.MiddleCenter;

            labelFinal.AutoSize = true; labelFinal.Location = new Point(16, 108); labelFinal.Text = "Nilai Akhir"; labelFinal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFinalValue.Location = new Point(20, 136); lblFinalValue.Size = new Size(240, 44); lblFinalValue.Text = "-"; lblFinalValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold); lblFinalValue.BackColor = Color.FromArgb(240, 248, 250); lblFinalValue.TextAlign = ContentAlignment.MiddleCenter;

            labelCategory.AutoSize = true; labelCategory.Location = new Point(16, 200); labelCategory.Text = "Kategori Fuzzy"; labelCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCategoryValue.Location = new Point(20, 228); lblCategoryValue.Size = new Size(240, 48); lblCategoryValue.Text = "-"; lblCategoryValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold); lblCategoryValue.BackColor = Color.FromArgb(217, 249, 243); lblCategoryValue.TextAlign = ContentAlignment.MiddleCenter; lblCategoryValue.ForeColor = Color.FromArgb(6, 94, 84);

            // add to panels
            leftPanel.Controls.Add(labelT1);
            leftPanel.Controls.Add(txtT1);
            leftPanel.Controls.Add(labelT2);
            leftPanel.Controls.Add(txtT2);
            leftPanel.Controls.Add(labelT3);
            leftPanel.Controls.Add(txtT3);
            leftPanel.Controls.Add(labelT4);
            leftPanel.Controls.Add(txtT4);
            leftPanel.Controls.Add(labelT5);
            leftPanel.Controls.Add(txtT5);
            leftPanel.Controls.Add(labelUTS);
            leftPanel.Controls.Add(txtUTS);
            leftPanel.Controls.Add(labelUAS);
            leftPanel.Controls.Add(txtUAS);
            leftPanel.Controls.Add(btnHitung);
            leftPanel.Controls.Add(btnReset);

            rightPanel.Controls.Add(labelAvg);
            rightPanel.Controls.Add(lblAvgValue);
            rightPanel.Controls.Add(labelFinal);
            rightPanel.Controls.Add(lblFinalValue);
            rightPanel.Controls.Add(labelCategory);
            rightPanel.Controls.Add(lblCategoryValue);

            // add to form
            Controls.Add(headerPanel);
            Controls.Add(leftPanel);
            Controls.Add(rightPanel);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 440);
            Name = "Form1";
            Text = "Sistem Penilaian Mahasiswa - Logika Fuzzy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelT1;
        private Label labelT2;
        private Label labelT3;
        private Label labelT4;
        private Label labelT5;
        private TextBox txtT1;
        private TextBox txtT2;
        private TextBox txtT3;
        private TextBox txtT4;
        private TextBox txtT5;
        private Label labelUTS;
        private Label labelUAS;
        private TextBox txtUTS;
        private TextBox txtUAS;
        private Button btnHitung;
        private Button btnReset;
        private Label labelAvg;
        private Label lblAvgValue;
        private Label labelFinal;
        private Label lblFinalValue;
        private Label labelCategory;
        private Label lblCategoryValue;
    }
}
