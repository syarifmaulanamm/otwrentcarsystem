namespace otwrentcarsystem.Order
{
    partial class FormReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReservation));
            this.label1 = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.TextBox();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.btnSelectCar = new System.Windows.Forms.Button();
            this.carModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.numberOfDays = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.routes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(12, 27);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(232, 23);
            this.customerName.TabIndex = 1;
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Location = new System.Drawing.Point(250, 26);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(112, 24);
            this.btnSelectCustomer.TabIndex = 2;
            this.btnSelectCustomer.Text = "Select Customer";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // btnSelectCar
            // 
            this.btnSelectCar.Location = new System.Drawing.Point(250, 83);
            this.btnSelectCar.Name = "btnSelectCar";
            this.btnSelectCar.Size = new System.Drawing.Size(112, 24);
            this.btnSelectCar.TabIndex = 5;
            this.btnSelectCar.Text = "Select Car";
            this.btnSelectCar.UseVisualStyleBackColor = true;
            this.btnSelectCar.Click += new System.EventHandler(this.btnSelectCar_Click);
            // 
            // carModel
            // 
            this.carModel.Location = new System.Drawing.Point(12, 84);
            this.carModel.Name = "carModel";
            this.carModel.Size = new System.Drawing.Size(232, 23);
            this.carModel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Car";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category";
            // 
            // category
            // 
            this.category.FormattingEnabled = true;
            this.category.Items.AddRange(new object[] {
            "With Driver",
            "Car Only"});
            this.category.Location = new System.Drawing.Point(12, 143);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(350, 23);
            this.category.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "End Date";
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "";
            this.startDate.Location = new System.Drawing.Point(12, 206);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(132, 23);
            this.startDate.TabIndex = 10;
            this.startDate.Value = new System.DateTime(2023, 1, 19, 0, 0, 0, 0);
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // endDate
            // 
            this.endDate.CustomFormat = "";
            this.endDate.Location = new System.Drawing.Point(160, 206);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(130, 23);
            this.endDate.TabIndex = 11;
            this.endDate.Value = new System.DateTime(2023, 1, 19, 0, 0, 0, 0);
            this.endDate.ValueChanged += new System.EventHandler(this.endDate_ValueChanged);
            // 
            // numberOfDays
            // 
            this.numberOfDays.Location = new System.Drawing.Point(306, 206);
            this.numberOfDays.Name = "numberOfDays";
            this.numberOfDays.ReadOnly = true;
            this.numberOfDays.Size = new System.Drawing.Size(56, 23);
            this.numberOfDays.TabIndex = 12;
            this.numberOfDays.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Days";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Routes";
            // 
            // routes
            // 
            this.routes.Location = new System.Drawing.Point(13, 266);
            this.routes.Multiline = true;
            this.routes.Name = "routes";
            this.routes.Size = new System.Drawing.Size(349, 47);
            this.routes.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Price Per Day";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(13, 351);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(160, 23);
            this.price.TabIndex = 17;
            this.price.TextChanged += new System.EventHandler(this.price_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(194, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Amount";
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(194, 351);
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Size = new System.Drawing.Size(168, 23);
            this.amount.TabIndex = 19;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackgroundImage = global::otwrentcarsystem.Properties.Resources.BG;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSubmit.Location = new System.Drawing.Point(250, 397);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(112, 32);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FormReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(375, 447);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.routes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numberOfDays);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.category);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelectCar);
            this.Controls.Add(this.carModel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectCustomer);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox customerName;
        private Button btnSelectCustomer;
        private Button btnSelectCar;
        private TextBox carModel;
        private Label label2;
        private Label label3;
        private ComboBox category;
        private Label label4;
        private Label label5;
        private DateTimePicker startDate;
        private DateTimePicker endDate;
        private TextBox numberOfDays;
        private Label label6;
        private Label label7;
        private TextBox routes;
        private Label label8;
        private TextBox price;
        private Label label9;
        private TextBox amount;
        private Button btnSubmit;
    }
}