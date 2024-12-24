namespace Program1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnOpenWindow1 = new System.Windows.Forms.Button();
            this.btnOpenWindow2 = new System.Windows.Forms.Button();
            this.btnOpenWindow3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenWindow1
            // 
            this.btnOpenWindow1.Location = new System.Drawing.Point(50, 50);
            this.btnOpenWindow1.Name = "btnOpenWindow1";
            this.btnOpenWindow1.Size = new System.Drawing.Size(150, 30);
            this.btnOpenWindow1.TabIndex = 0;
            this.btnOpenWindow1.Text = "Открыть первое окно";
            this.btnOpenWindow1.UseVisualStyleBackColor = true;
            this.btnOpenWindow1.Click += new System.EventHandler(this.btnOpenWindow1_Click);
            // 
            // btnOpenWindow2
            // 
            this.btnOpenWindow2.Location = new System.Drawing.Point(50, 100);
            this.btnOpenWindow2.Name = "btnOpenWindow2";
            this.btnOpenWindow2.Size = new System.Drawing.Size(150, 30);
            this.btnOpenWindow2.TabIndex = 1;
            this.btnOpenWindow2.Text = "Открыть второе окно";
            this.btnOpenWindow2.UseVisualStyleBackColor = true;
            this.btnOpenWindow2.Click += new System.EventHandler(this.btnOpenWindow2_Click);
            // 
            // btnOpenWindow3
            // 
            this.btnOpenWindow3.Location = new System.Drawing.Point(50, 150);
            this.btnOpenWindow3.Name = "btnOpenWindow3";
            this.btnOpenWindow3.Size = new System.Drawing.Size(150, 30);
            this.btnOpenWindow3.TabIndex = 2;
            this.btnOpenWindow3.Text = "Открыть третье окно";
            this.btnOpenWindow3.UseVisualStyleBackColor = true;
            this.btnOpenWindow3.Click += new System.EventHandler(this.btnOpenWindow3_Click);
            // 
            // Form
            //
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnOpenWindow3);
            this.Controls.Add(this.btnOpenWindow2);
            this.Controls.Add(this.btnOpenWindow1);
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnOpenWindow1;
        private System.Windows.Forms.Button btnOpenWindow2;
        private System.Windows.Forms.Button btnOpenWindow3;
    }
}
