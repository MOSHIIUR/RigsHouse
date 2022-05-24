
namespace RigsHouse
{
    partial class cart
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
            this.label1 = new System.Windows.Forms.Label();
            this.viewData = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewData)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(266, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "cart";
            // 
            // viewData
            // 
            this.viewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewData.Location = new System.Drawing.Point(101, 177);
            this.viewData.Margin = new System.Windows.Forms.Padding(2);
            this.viewData.Name = "viewData";
            this.viewData.RowHeadersWidth = 51;
            this.viewData.RowTemplate.Height = 24;
            this.viewData.Size = new System.Drawing.Size(473, 285);
            this.viewData.TabIndex = 148;
            this.viewData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.viewData_CellMouseClick);
            this.viewData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.viewData_CellMouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(656, 80);
            this.panel2.TabIndex = 145;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnDelete.Location = new System.Drawing.Point(281, 466);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 42);
            this.btnDelete.TabIndex = 150;
            this.btnDelete.Text = "Remove";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 29);
            this.textBox1.TabIndex = 153;
            this.textBox1.Visible = false;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.id.Location = new System.Drawing.Point(64, 112);
            this.id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(31, 22);
            this.id.TabIndex = 154;
            this.id.Text = "ID:";
            this.id.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SeaGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnUpdate.Location = new System.Drawing.Point(382, 131);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 42);
            this.btnUpdate.TabIndex = 149;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Palatino Linotype", 12F);
            this.numericUpDown1.Location = new System.Drawing.Point(281, 137);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(71, 29);
            this.numericUpDown1.TabIndex = 151;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Crimson;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15F);
            this.label5.Location = new System.Drawing.Point(220, 139);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 27);
            this.label5.TabIndex = 152;
            this.label5.Text = "Unit:";
            // 
            // cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 519);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.viewData);
            this.Controls.Add(this.panel2);
            this.Name = "cart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "cart";
            this.Load += new System.EventHandler(this.cart_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cart_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.viewData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView viewData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
    }
}