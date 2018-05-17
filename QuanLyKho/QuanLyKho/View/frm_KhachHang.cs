using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyKho.Object;
using QuanLyKho.Control;

namespace QuanLyKho.View
{
    public partial class frm_KhachHang : Form
    {
        DataTable db = new DataTable();
        int fl = 0;
        KhachHangObjTH khObj = new KhachHangObjTH();
        KhachHangCtrlTH khCtrl = new KhachHangCtrlTH();
        public frm_KhachHang()
        {
            InitializeComponent();
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            db = khCtrl.GetData();
            dgv_KhachHang.DataSource = db;
            dgv_KhachHang.ReadOnly = true;
            bingding();
            ReadOnly(true);
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            txt_TimKiem.ReadOnly = false;
        }
        public void bingding()
        {
            txt_makh.DataBindings.Clear();
            txt_makh.DataBindings.Add("Text", dgv_KhachHang.DataSource, "MaKH");
            txt_tenkh.DataBindings.Clear();
            txt_tenkh.DataBindings.Add("Text", dgv_KhachHang.DataSource, "TenKH");
            txt_diachi.DataBindings.Clear();
            txt_diachi.DataBindings.Add("Text", dgv_KhachHang.DataSource, "DiaChi");
            txt_sdt.DataBindings.Clear();
            txt_sdt.DataBindings.Add("Text", dgv_KhachHang.DataSource, "SDT");
            cb_kieuthanhtoan.DataBindings.Clear();
            cb_kieuthanhtoan.DataBindings.Add("Text", dgv_KhachHang.DataSource, "KieuThanhToan");

        }
        public void ReadOnly(bool e)
        {
            txt_diachi.ReadOnly = e;
            txt_sdt.ReadOnly = e;
            txt_makh.ReadOnly = e;
            txt_tenkh.ReadOnly = e;
            cb_kieuthanhtoan.Enabled = !e;



        }

        void ganDuLieu(KhachHangObjTH Obj)
        {
            Obj.makh = txt_makh.Text.Trim(); ;
            Obj.tenkh = txt_tenkh.Text.Trim();

            Obj.diachi = txt_diachi.Text.Trim();
            Obj.kieuthanhtoan = cb_kieuthanhtoan.Text.Trim();
            Obj.sdt = txt_sdt.Text.Trim();

        }
        public void ClearDt()
        {
            txt_makh.Text = "";
            txt_tenkh.Text = "";
            txt_diachi.Text = "";
            txt_sdt.Text = "";


        }
        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dgv_NhanVien_RowPrePaint_1(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv_KhachHang.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            fl = 0;
            txt_TimKiem.ReadOnly = true;
            ClearDt();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            ReadOnly(false);
            btn_Them.Enabled = false;
            btn_Huy.Enabled = true;
            btn_Luu.Enabled = true;

            db = khCtrl.GetData();
            string a = "";
            if (db.Rows.Count <= 0)
            {
                a = "KH01";
            }
            else
            {
                int k;
                a = "KH";
                k = int.Parse(db.Rows[db.Rows.Count - 1][0].ToString().Trim().Substring(2, 2));
                k = k + 1;
                string tam = k.ToString();
                for (int i = 0; i < (2 - tam.Length); i++)
                {
                    a += "0";
                }
                a = a + k.ToString();
            }
            txt_makh.Text = a;
            this.txt_tenkh.Focus();

            string[] s = { "Thẻ", "Tiền Mặt" };
            cb_kieuthanhtoan.DataSource = s;
            cb_kieuthanhtoan.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    }


    
    }

