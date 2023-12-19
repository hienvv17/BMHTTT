namespace Project_BMHTTT
{
    partial class Home
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
            this.btn_phanhe1 = new System.Windows.Forms.Button();
            this.btn_phanhe2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_phanhe1
            // 
            this.btn_phanhe1.BackColor = System.Drawing.Color.DarkRed;
            this.btn_phanhe1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btn_phanhe1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_phanhe1.Location = new System.Drawing.Point(133, 185);
            this.btn_phanhe1.Margin = new System.Windows.Forms.Padding(4);
            this.btn_phanhe1.Name = "btn_phanhe1";
            this.btn_phanhe1.Size = new System.Drawing.Size(307, 308);
            this.btn_phanhe1.TabIndex = 0;
            this.btn_phanhe1.Text = "Giai đoạn 1";
            this.btn_phanhe1.UseVisualStyleBackColor = false;
            this.btn_phanhe1.Click += new System.EventHandler(this.btn_phanhe1_Click);
            // 
            // btn_phanhe2
            // 
            this.btn_phanhe2.BackColor = System.Drawing.Color.Peru;
            this.btn_phanhe2.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_phanhe2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_phanhe2.Location = new System.Drawing.Point(611, 185);
            this.btn_phanhe2.Margin = new System.Windows.Forms.Padding(4);
            this.btn_phanhe2.Name = "btn_phanhe2";
            this.btn_phanhe2.Size = new System.Drawing.Size(307, 308);
            this.btn_phanhe2.TabIndex = 1;
            this.btn_phanhe2.Text = "Giai đoạn 2";
            this.btn_phanhe2.UseVisualStyleBackColor = false;
            this.btn_phanhe2.Click += new System.EventHandler(this.btn_phanhe2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(684, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "MÔN HỌC : BẢO MẬT HỆ THỐNG THÔNG TIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.OliveDrab;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(449, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "NHÓM 2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 530);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_phanhe2);
            this.Controls.Add(this.btn_phanhe1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_phanhe1;
        private System.Windows.Forms.Button btn_phanhe2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}