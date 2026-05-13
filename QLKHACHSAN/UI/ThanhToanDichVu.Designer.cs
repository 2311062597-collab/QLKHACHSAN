namespace QLKHACHSAN.UI
{
    partial class ThanhToanDichVuForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpThongTinThanhToan = new System.Windows.Forms.GroupBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numCustomerPaid = new System.Windows.Forms.NumericUpDown();
            this.lblCustomerPaid = new System.Windows.Forms.Label();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.lblQRCode = new System.Windows.Forms.Label();
            this.lblPaymentMethodValue = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblAmountValue = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblQuantityValue = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblServiceNameValue = new System.Windows.Forms.Label();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.lblCustomerNameValue = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.grpThongTinThanhToan.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCustomerPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(667, 74);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thanh Toán Dịch Vụ";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.grpThongTinThanhToan);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 74);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.pnlContent.Size = new System.Drawing.Size(667, 603);
            this.pnlContent.TabIndex = 1;
            // 
            // grpThongTinThanhToan
            // 
            this.grpThongTinThanhToan.Controls.Add(this.pnlButtons);
            this.grpThongTinThanhToan.Controls.Add(this.lblChange);
            this.grpThongTinThanhToan.Controls.Add(this.numCustomerPaid);
            this.grpThongTinThanhToan.Controls.Add(this.lblCustomerPaid);
            this.grpThongTinThanhToan.Controls.Add(this.picQRCode);
            this.grpThongTinThanhToan.Controls.Add(this.lblQRCode);
            this.grpThongTinThanhToan.Controls.Add(this.lblPaymentMethodValue);
            this.grpThongTinThanhToan.Controls.Add(this.lblPaymentMethod);
            this.grpThongTinThanhToan.Controls.Add(this.lblAmountValue);
            this.grpThongTinThanhToan.Controls.Add(this.lblAmount);
            this.grpThongTinThanhToan.Controls.Add(this.lblQuantityValue);
            this.grpThongTinThanhToan.Controls.Add(this.lblQuantity);
            this.grpThongTinThanhToan.Controls.Add(this.lblServiceNameValue);
            this.grpThongTinThanhToan.Controls.Add(this.lblServiceName);
            this.grpThongTinThanhToan.Controls.Add(this.lblCustomerNameValue);
            this.grpThongTinThanhToan.Controls.Add(this.lblCustomerName);
            this.grpThongTinThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThongTinThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinThanhToan.Location = new System.Drawing.Point(20, 18);
            this.grpThongTinThanhToan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpThongTinThanhToan.Name = "grpThongTinThanhToan";
            this.grpThongTinThanhToan.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.grpThongTinThanhToan.Size = new System.Drawing.Size(627, 567);
            this.grpThongTinThanhToan.TabIndex = 0;
            this.grpThongTinThanhToan.TabStop = false;
            this.grpThongTinThanhToan.Text = "Thông Tin Thanh Toán";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnConfirm);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(20, 487);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(587, 62);
            this.pnlButtons.TabIndex = 12;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(100, 10);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(160, 43);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Xác Nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(327, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 43);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numCustomerPaid
            // 
            this.numCustomerPaid.Location = new System.Drawing.Point(187, 239);
            this.numCustomerPaid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numCustomerPaid.Name = "numCustomerPaid";
            this.numCustomerPaid.Size = new System.Drawing.Size(160, 26);
            this.numCustomerPaid.TabIndex = 15;
            // 
            // lblCustomerPaid
            // 
            this.lblCustomerPaid.Location = new System.Drawing.Point(24, 235);
            this.lblCustomerPaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPaid.Name = "lblCustomerPaid";
            this.lblCustomerPaid.Size = new System.Drawing.Size(133, 28);
            this.lblCustomerPaid.TabIndex = 16;
            // 
            // picQRCode
            // 
            this.picQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQRCode.Location = new System.Drawing.Point(120, 297);
            this.picQRCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(372, 192);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 11;
            this.picQRCode.TabStop = false;
            this.picQRCode.Visible = false;
            // 
            // lblQRCode
            // 
            this.lblQRCode.AutoSize = true;
            this.lblQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQRCode.Location = new System.Drawing.Point(24, 273);
            this.lblQRCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQRCode.Name = "lblQRCode";
            this.lblQRCode.Size = new System.Drawing.Size(172, 20);
            this.lblQRCode.TabIndex = 10;
            this.lblQRCode.Text = "Mã QR Ngân Hàng:";
            this.lblQRCode.Visible = false;
            // 
            // lblPaymentMethodValue
            // 
            this.lblPaymentMethodValue.AutoSize = true;
            this.lblPaymentMethodValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethodValue.Location = new System.Drawing.Point(200, 215);
            this.lblPaymentMethodValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentMethodValue.Name = "lblPaymentMethodValue";
            this.lblPaymentMethodValue.Size = new System.Drawing.Size(0, 20);
            this.lblPaymentMethodValue.TabIndex = 9;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(24, 215);
            this.lblPaymentMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(124, 20);
            this.lblPaymentMethod.TabIndex = 8;
            this.lblPaymentMethod.Text = "Phương Thức:";
            // 
            // lblAmountValue
            // 
            this.lblAmountValue.AutoSize = true;
            this.lblAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountValue.ForeColor = System.Drawing.Color.Red;
            this.lblAmountValue.Location = new System.Drawing.Point(200, 172);
            this.lblAmountValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmountValue.Name = "lblAmountValue";
            this.lblAmountValue.Size = new System.Drawing.Size(0, 20);
            this.lblAmountValue.TabIndex = 7;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(24, 172);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(79, 20);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Số Tiền:";
            // 
            // lblQuantityValue
            // 
            this.lblQuantityValue.AutoSize = true;
            this.lblQuantityValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityValue.Location = new System.Drawing.Point(200, 129);
            this.lblQuantityValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantityValue.Name = "lblQuantityValue";
            this.lblQuantityValue.Size = new System.Drawing.Size(0, 20);
            this.lblQuantityValue.TabIndex = 5;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(24, 129);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(94, 20);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Số Lượng:";
            // 
            // lblServiceNameValue
            // 
            this.lblServiceNameValue.AutoSize = true;
            this.lblServiceNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceNameValue.Location = new System.Drawing.Point(200, 86);
            this.lblServiceNameValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServiceNameValue.Name = "lblServiceNameValue";
            this.lblServiceNameValue.Size = new System.Drawing.Size(0, 20);
            this.lblServiceNameValue.TabIndex = 3;
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceName.Location = new System.Drawing.Point(24, 86);
            this.lblServiceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(119, 20);
            this.lblServiceName.TabIndex = 2;
            this.lblServiceName.Text = "Tên Dịch Vụ:";
            // 
            // lblCustomerNameValue
            // 
            this.lblCustomerNameValue.AutoSize = true;
            this.lblCustomerNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameValue.Location = new System.Drawing.Point(200, 43);
            this.lblCustomerNameValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerNameValue.Name = "lblCustomerNameValue";
            this.lblCustomerNameValue.Size = new System.Drawing.Size(0, 20);
            this.lblCustomerNameValue.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(24, 43);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(154, 20);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Tên Khách Hàng:";
            // 
            // lblChange
            // 
            this.lblChange.Location = new System.Drawing.Point(387, 172);
            this.lblChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(133, 28);
            this.lblChange.TabIndex = 14;
            // 
            // ThanhToanDichVuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 677);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThanhToanDichVuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh Toán Dịch Vụ";
            this.Load += new System.EventHandler(this.ThanhToanDichVuForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.grpThongTinThanhToan.ResumeLayout(false);
            this.grpThongTinThanhToan.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCustomerPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpThongTinThanhToan;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerNameValue;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Label lblServiceNameValue;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblQuantityValue;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAmountValue;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethodValue;
        private System.Windows.Forms.Label lblQRCode;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCustomerPaid;
        private System.Windows.Forms.NumericUpDown numCustomerPaid;
        private System.Windows.Forms.Label lblChange;
    }
}
