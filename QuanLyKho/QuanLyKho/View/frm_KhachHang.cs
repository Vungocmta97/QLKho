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


    }


    
    }

