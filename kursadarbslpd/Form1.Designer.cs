namespace kursadarbslpd
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orderspicesbtn = new System.Windows.Forms.Button();
            this.spicecategoriesbtn = new System.Windows.Forms.Button();
            this.ordersbtn = new System.Windows.Forms.Button();
            this.supplybtn = new System.Windows.Forms.Button();
            this.spicesbtn = new System.Windows.Forms.Button();
            this.shopbtn = new System.Windows.Forms.Button();
            this.deliveryaddressbtn = new System.Windows.Forms.Button();
            this.customerbtn = new System.Windows.Forms.Button();
            this.employeesbtn = new System.Windows.Forms.Button();
            this.GetData = new System.Windows.Forms.ToolStripButton();
            this.SaveData = new System.Windows.Forms.ToolStripButton();
            this.employeesdgv = new System.Windows.Forms.DataGridView();
            this.customersdgv = new System.Windows.Forms.DataGridView();
            this.deliveryaddressdgv = new System.Windows.Forms.DataGridView();
            this.shopdgv = new System.Windows.Forms.DataGridView();
            this.spicesdgv = new System.Windows.Forms.DataGridView();
            this.supplydgv = new System.Windows.Forms.DataGridView();
            this.ordersdgv = new System.Windows.Forms.DataGridView();
            this.categoriesdgv = new System.Windows.Forms.DataGridView();
            this.orderspicesdgv = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryaddressdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spicesdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplydgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesdgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderspicesdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GetData,
            this.SaveData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1040, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.orderspicesbtn);
            this.panel1.Controls.Add(this.spicecategoriesbtn);
            this.panel1.Controls.Add(this.ordersbtn);
            this.panel1.Controls.Add(this.supplybtn);
            this.panel1.Controls.Add(this.spicesbtn);
            this.panel1.Controls.Add(this.shopbtn);
            this.panel1.Controls.Add(this.deliveryaddressbtn);
            this.panel1.Controls.Add(this.customerbtn);
            this.panel1.Controls.Add(this.employeesbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 431);
            this.panel1.TabIndex = 2;
            // 
            // orderspicesbtn
            // 
            this.orderspicesbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.orderspicesbtn.Location = new System.Drawing.Point(0, 184);
            this.orderspicesbtn.Name = "orderspicesbtn";
            this.orderspicesbtn.Size = new System.Drawing.Size(200, 23);
            this.orderspicesbtn.TabIndex = 8;
            this.orderspicesbtn.Text = "Order Spices";
            this.orderspicesbtn.UseVisualStyleBackColor = true;
            this.orderspicesbtn.Click += new System.EventHandler(this.orderspicesbtn_Click);
            // 
            // spicecategoriesbtn
            // 
            this.spicecategoriesbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.spicecategoriesbtn.Location = new System.Drawing.Point(0, 161);
            this.spicecategoriesbtn.Name = "spicecategoriesbtn";
            this.spicecategoriesbtn.Size = new System.Drawing.Size(200, 23);
            this.spicecategoriesbtn.TabIndex = 7;
            this.spicecategoriesbtn.Text = "Spice Categories";
            this.spicecategoriesbtn.UseVisualStyleBackColor = true;
            this.spicecategoriesbtn.Click += new System.EventHandler(this.spicecategoriesbtn_Click);
            // 
            // ordersbtn
            // 
            this.ordersbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ordersbtn.Location = new System.Drawing.Point(0, 138);
            this.ordersbtn.Name = "ordersbtn";
            this.ordersbtn.Size = new System.Drawing.Size(200, 23);
            this.ordersbtn.TabIndex = 6;
            this.ordersbtn.Text = "Orders";
            this.ordersbtn.UseVisualStyleBackColor = true;
            this.ordersbtn.Click += new System.EventHandler(this.ordersbtn_Click);
            // 
            // supplybtn
            // 
            this.supplybtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.supplybtn.Location = new System.Drawing.Point(0, 115);
            this.supplybtn.Name = "supplybtn";
            this.supplybtn.Size = new System.Drawing.Size(200, 23);
            this.supplybtn.TabIndex = 5;
            this.supplybtn.Text = "Supply";
            this.supplybtn.UseVisualStyleBackColor = true;
            this.supplybtn.Click += new System.EventHandler(this.supplybtn_Click);
            // 
            // spicesbtn
            // 
            this.spicesbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.spicesbtn.Location = new System.Drawing.Point(0, 92);
            this.spicesbtn.Name = "spicesbtn";
            this.spicesbtn.Size = new System.Drawing.Size(200, 23);
            this.spicesbtn.TabIndex = 4;
            this.spicesbtn.Text = "Spices";
            this.spicesbtn.UseVisualStyleBackColor = true;
            this.spicesbtn.Click += new System.EventHandler(this.spicesbtn_Click);
            // 
            // shopbtn
            // 
            this.shopbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.shopbtn.Location = new System.Drawing.Point(0, 69);
            this.shopbtn.Name = "shopbtn";
            this.shopbtn.Size = new System.Drawing.Size(200, 23);
            this.shopbtn.TabIndex = 3;
            this.shopbtn.Text = "Shop";
            this.shopbtn.UseVisualStyleBackColor = true;
            this.shopbtn.Click += new System.EventHandler(this.shopbtn_Click);
            // 
            // deliveryaddressbtn
            // 
            this.deliveryaddressbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.deliveryaddressbtn.Location = new System.Drawing.Point(0, 46);
            this.deliveryaddressbtn.Name = "deliveryaddressbtn";
            this.deliveryaddressbtn.Size = new System.Drawing.Size(200, 23);
            this.deliveryaddressbtn.TabIndex = 2;
            this.deliveryaddressbtn.Text = "Delivery Address";
            this.deliveryaddressbtn.UseVisualStyleBackColor = true;
            this.deliveryaddressbtn.Click += new System.EventHandler(this.deliveryaddressbtn_Click);
            // 
            // customerbtn
            // 
            this.customerbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.customerbtn.Location = new System.Drawing.Point(0, 23);
            this.customerbtn.Name = "customerbtn";
            this.customerbtn.Size = new System.Drawing.Size(200, 23);
            this.customerbtn.TabIndex = 1;
            this.customerbtn.Text = "Customers";
            this.customerbtn.UseVisualStyleBackColor = true;
            this.customerbtn.Click += new System.EventHandler(this.customerbtn_Click);
            // 
            // employeesbtn
            // 
            this.employeesbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.employeesbtn.Location = new System.Drawing.Point(0, 0);
            this.employeesbtn.Name = "employeesbtn";
            this.employeesbtn.Size = new System.Drawing.Size(200, 23);
            this.employeesbtn.TabIndex = 0;
            this.employeesbtn.Text = "Employees";
            this.employeesbtn.UseVisualStyleBackColor = true;
            this.employeesbtn.Click += new System.EventHandler(this.employeesbtn_Click);
            // 
            // GetData
            // 
            this.GetData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GetData.Image = ((System.Drawing.Image)(resources.GetObject("GetData.Image")));
            this.GetData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GetData.Name = "GetData";
            this.GetData.Size = new System.Drawing.Size(53, 22);
            this.GetData.Text = "GetData";
            // 
            // SaveData
            // 
            this.SaveData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveData.Image = ((System.Drawing.Image)(resources.GetObject("SaveData.Image")));
            this.SaveData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(59, 22);
            this.SaveData.Text = "SaveData";
            this.SaveData.Click += new System.EventHandler(this.SaveData_Click);
            // 
            // employeesdgv
            // 
            this.employeesdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeesdgv.Location = new System.Drawing.Point(200, 25);
            this.employeesdgv.Name = "employeesdgv";
            this.employeesdgv.Size = new System.Drawing.Size(840, 431);
            this.employeesdgv.TabIndex = 3;
            // 
            // customersdgv
            // 
            this.customersdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customersdgv.Location = new System.Drawing.Point(200, 25);
            this.customersdgv.Name = "customersdgv";
            this.customersdgv.Size = new System.Drawing.Size(840, 431);
            this.customersdgv.TabIndex = 4;
            // 
            // deliveryaddressdgv
            // 
            this.deliveryaddressdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deliveryaddressdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deliveryaddressdgv.Location = new System.Drawing.Point(200, 25);
            this.deliveryaddressdgv.Name = "deliveryaddressdgv";
            this.deliveryaddressdgv.Size = new System.Drawing.Size(840, 431);
            this.deliveryaddressdgv.TabIndex = 5;
            // 
            // shopdgv
            // 
            this.shopdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shopdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shopdgv.Location = new System.Drawing.Point(200, 25);
            this.shopdgv.Name = "shopdgv";
            this.shopdgv.Size = new System.Drawing.Size(840, 431);
            this.shopdgv.TabIndex = 6;
            // 
            // spicesdgv
            // 
            this.spicesdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.spicesdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spicesdgv.Location = new System.Drawing.Point(200, 25);
            this.spicesdgv.Name = "spicesdgv";
            this.spicesdgv.Size = new System.Drawing.Size(840, 431);
            this.spicesdgv.TabIndex = 7;
            // 
            // supplydgv
            // 
            this.supplydgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplydgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supplydgv.Location = new System.Drawing.Point(200, 25);
            this.supplydgv.Name = "supplydgv";
            this.supplydgv.Size = new System.Drawing.Size(840, 431);
            this.supplydgv.TabIndex = 8;
            // 
            // ordersdgv
            // 
            this.ordersdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersdgv.Location = new System.Drawing.Point(200, 25);
            this.ordersdgv.Name = "ordersdgv";
            this.ordersdgv.Size = new System.Drawing.Size(840, 431);
            this.ordersdgv.TabIndex = 9;
            // 
            // categoriesdgv
            // 
            this.categoriesdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriesdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesdgv.Location = new System.Drawing.Point(200, 25);
            this.categoriesdgv.Name = "categoriesdgv";
            this.categoriesdgv.Size = new System.Drawing.Size(840, 431);
            this.categoriesdgv.TabIndex = 10;
            // 
            // orderspicesdgv
            // 
            this.orderspicesdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderspicesdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderspicesdgv.Location = new System.Drawing.Point(200, 25);
            this.orderspicesdgv.Name = "orderspicesdgv";
            this.orderspicesdgv.Size = new System.Drawing.Size(840, 431);
            this.orderspicesdgv.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 456);
            this.Controls.Add(this.orderspicesdgv);
            this.Controls.Add(this.categoriesdgv);
            this.Controls.Add(this.ordersdgv);
            this.Controls.Add(this.supplydgv);
            this.Controls.Add(this.spicesdgv);
            this.Controls.Add(this.shopdgv);
            this.Controls.Add(this.deliveryaddressdgv);
            this.Controls.Add(this.customersdgv);
            this.Controls.Add(this.employeesdgv);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeesdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryaddressdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spicesdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplydgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesdgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderspicesdgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton GetData;
        private System.Windows.Forms.ToolStripButton SaveData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button orderspicesbtn;
        private System.Windows.Forms.Button spicecategoriesbtn;
        private System.Windows.Forms.Button ordersbtn;
        private System.Windows.Forms.Button supplybtn;
        private System.Windows.Forms.Button spicesbtn;
        private System.Windows.Forms.Button shopbtn;
        private System.Windows.Forms.Button deliveryaddressbtn;
        private System.Windows.Forms.Button customerbtn;
        private System.Windows.Forms.Button employeesbtn;
        private System.Windows.Forms.DataGridView employeesdgv;
        private System.Windows.Forms.DataGridView customersdgv;
        private System.Windows.Forms.DataGridView deliveryaddressdgv;
        private System.Windows.Forms.DataGridView shopdgv;
        private System.Windows.Forms.DataGridView spicesdgv;
        private System.Windows.Forms.DataGridView supplydgv;
        private System.Windows.Forms.DataGridView ordersdgv;
        private System.Windows.Forms.DataGridView categoriesdgv;
        private System.Windows.Forms.DataGridView orderspicesdgv;
    }
}

