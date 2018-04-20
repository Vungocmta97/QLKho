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
    public partial class frm_QLNV : Form
    {
        DataTable db = new DataTable();
        int fl = 0;
        NhanVienObjTH nvObj = new NhanVienObjTH();
        NhanVienCtrlTH nvCtrl = new NhanVienCtrlTH();
        public frm_QLNV()
        {
            InitializeComponent();
        }

        private void frm_QLNV_Load(object sender, EventArgs e)
        {
            db = nvCtrl.GetData();
            dgv_NhanVien.DataSource = db;
            dgv_NhanVien.ReadOnly = true;
            bingding();
            ReadOnly(true);
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            txt_TimKiem.ReadOnly = false;
        }

        public void bingding()
        {
            txt_manv.DataBindings.Clear();
            txt_manv.DataBindings.Add("Text", dgv_NhanVien.DataSource, "MaNV");
            txt_tennv.DataBindings.Clear();
            txt_tennv.DataBindings.Add("Text", dgv_NhanVien.DataSource, "TenNV");
            txt_diachi.DataBindings.Clear();
            txt_diachi.DataBindings.Add("Text", dgv_NhanVien.DataSource, "DiaChi");
            txt_sdt.DataBindings.Clear();
            txt_sdt.DataBindings.Add("Text", dgv_NhanVien.DataSource, "SDT");
            cb_gioitinh.DataBindings.Clear();
            cb_gioitinh.DataBindings.Add("Text", dgv_NhanVien.DataSource, "GioiTinh");
            dt_ngaysinh.DataBindings.Clear();
            dt_ngaysinh.DataBindings.Add("Text", dgv_NhanVien.DataSource, "NgaySinh");
        }


    }
}
