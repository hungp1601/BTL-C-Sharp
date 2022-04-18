
namespace WindowsFormsApp2
{
    partial class fmSach
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
            this.components = new System.ComponentModel.Container();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtTG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDanhSachHDN = new System.Windows.Forms.DataGridView();
            this.masch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manxb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tennxb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tacgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theloai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbNXB = new System.Windows.Forms.ComboBox();
            this.txtTheLoai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTim = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTenSach
            // 
            this.txtTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTenSach.Location = new System.Drawing.Point(135, 289);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(91, 20);
            this.txtTenSach.TabIndex = 104;
            this.txtTenSach.Validating += new System.ComponentModel.CancelEventHandler(this.txtTenSach_Validating);
            // 
            // txtMaSach
            // 
            this.txtMaSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMaSach.Location = new System.Drawing.Point(135, 235);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(91, 20);
            this.txtMaSach.TabIndex = 103;
            this.txtMaSach.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaSach_Validating);
            // 
            // txtTG
            // 
            this.txtTG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTG.Location = new System.Drawing.Point(346, 238);
            this.txtTG.Name = "txtTG";
            this.txtTG.Size = new System.Drawing.Size(91, 20);
            this.txtTG.TabIndex = 102;
            this.txtTG.Validating += new System.ComponentModel.CancelEventHandler(this.txtTG_Validating);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 101;
            this.label4.Text = "Tác giả";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Nhà xuất bản";
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Location = new System.Drawing.Point(566, 345);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(64, 26);
            this.btnXoa.TabIndex = 98;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Location = new System.Drawing.Point(566, 293);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(64, 25);
            this.btnSua.TabIndex = 97;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Location = new System.Drawing.Point(566, 237);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(64, 26);
            this.btnThem.TabIndex = 96;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt.AutoSize = true;
            this.txt.Location = new System.Drawing.Point(38, 292);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(52, 13);
            this.txt.TabIndex = 95;
            this.txt.Text = "Tên sách";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Mã sách";
            // 
            // dgvDanhSachHDN
            // 
            this.dgvDanhSachHDN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachHDN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachHDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachHDN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masch,
            this.tensach,
            this.manxb,
            this.tennxb,
            this.tacgia,
            this.theloai,
            this.sl});
            this.dgvDanhSachHDN.Location = new System.Drawing.Point(2, 27);
            this.dgvDanhSachHDN.Name = "dgvDanhSachHDN";
            this.dgvDanhSachHDN.ReadOnly = true;
            this.dgvDanhSachHDN.RowHeadersWidth = 51;
            this.dgvDanhSachHDN.RowTemplate.Height = 25;
            this.dgvDanhSachHDN.Size = new System.Drawing.Size(684, 186);
            this.dgvDanhSachHDN.TabIndex = 93;
            this.dgvDanhSachHDN.SelectionChanged += new System.EventHandler(this.dgvDanhSachHDN_SelectionChanged);
            // 
            // masch
            // 
            this.masch.DataPropertyName = "sMasach";
            this.masch.HeaderText = "Mã sách";
            this.masch.Name = "masch";
            this.masch.ReadOnly = true;
            // 
            // tensach
            // 
            this.tensach.DataPropertyName = "sTensach";
            this.tensach.HeaderText = "Tên sách";
            this.tensach.Name = "tensach";
            this.tensach.ReadOnly = true;
            // 
            // manxb
            // 
            this.manxb.DataPropertyName = "sMaNXB";
            this.manxb.HeaderText = "Mã NXB";
            this.manxb.Name = "manxb";
            this.manxb.ReadOnly = true;
            // 
            // tennxb
            // 
            this.tennxb.DataPropertyName = "ten nxb";
            this.tennxb.HeaderText = "Tên NXB";
            this.tennxb.Name = "tennxb";
            this.tennxb.ReadOnly = true;
            // 
            // tacgia
            // 
            this.tacgia.DataPropertyName = "sTacgia";
            this.tacgia.HeaderText = "Tác giả";
            this.tacgia.Name = "tacgia";
            this.tacgia.ReadOnly = true;
            // 
            // theloai
            // 
            this.theloai.DataPropertyName = "sTheLoai";
            this.theloai.HeaderText = "Thể loại";
            this.theloai.Name = "theloai";
            this.theloai.ReadOnly = true;
            // 
            // sl
            // 
            this.sl.DataPropertyName = "iSLSach";
            this.sl.HeaderText = "Số lượng";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            // 
            // cbbNXB
            // 
            this.cbbNXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbbNXB.FormattingEnabled = true;
            this.cbbNXB.Location = new System.Drawing.Point(135, 346);
            this.cbbNXB.Name = "cbbNXB";
            this.cbbNXB.Size = new System.Drawing.Size(102, 21);
            this.cbbNXB.TabIndex = 107;
            this.cbbNXB.SelectedIndexChanged += new System.EventHandler(this.cbbNXB_SelectedIndexChanged);
            // 
            // txtTheLoai
            // 
            this.txtTheLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTheLoai.Location = new System.Drawing.Point(346, 289);
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.Size = new System.Drawing.Size(91, 20);
            this.txtTheLoai.TabIndex = 109;
            this.txtTheLoai.Validating += new System.ComponentModel.CancelEventHandler(this.txtTheLoai_Validating);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Thể loại";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtTim
            // 
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTim.Location = new System.Drawing.Point(545, 4);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(133, 20);
            this.txtTim.TabIndex = 110;
            this.txtTim.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSL.Location = new System.Drawing.Point(346, 345);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(91, 20);
            this.txtSL.TabIndex = 111;
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSL_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = "Số lượng";
            // 
            // fmSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.txtTheLoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbNXB);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.txtTG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDanhSachHDN);
            this.Name = "fmSach";
            this.Text = "fmSach";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmSach_FormClosing);
            this.Load += new System.EventHandler(this.fmSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachHDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDanhSachHDN;
        private System.Windows.Forms.ComboBox cbbNXB;
        private System.Windows.Forms.TextBox txtTheLoai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn masch;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensach;
        private System.Windows.Forms.DataGridViewTextBoxColumn manxb;
        private System.Windows.Forms.DataGridViewTextBoxColumn tennxb;
        private System.Windows.Forms.DataGridViewTextBoxColumn tacgia;
        private System.Windows.Forms.DataGridViewTextBoxColumn theloai;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSL;
    }
}