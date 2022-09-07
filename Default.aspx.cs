using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCau3.Entities;
using WebCau3.Lib;

namespace WebCau3
{
    public partial class _Default : Page
    {
        private DatabaseService databaseService = new DatabaseService();
        protected void Page_Load(object sender, EventArgs e)
        {
            // LoadData();
            //LoadCombobox();
        }

        private void LoadCombobox()
        {
            // load combobox xi nghiep
            var xiNghieps = databaseService.GetAllXiNghiep();
            gvList.DataSource = xiNghieps;


        }
        private void LoadData()
        {
            // load to gvList
            var tiemVacXins = databaseService.GetAllTiemVacXin();
            gvList.DataSourceID = null;
            gvList.DataSource = tiemVacXins;
            gvList.DataBind();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // add TiemVacXin
            var tiemVacXin = new TiemVacXin();
            tiemVacXin.HoTen = txtHoten.Text;
            tiemVacXin.XiNghiepId = int.Parse(ddbXiNghiep.SelectedValue);
            bool gioiTinh = false;
            if (rdbGioiTinhNam.Checked)
            {
                gioiTinh = true;
            }
            tiemVacXin.GioiTinh = gioiTinh;
            bool daTiem = false;
            if (rdbTiem2.Checked)
            {
                daTiem = true;
            }
            tiemVacXin.Status = daTiem;
            databaseService.AddNewTiemVacXin(tiemVacXin);
            // show message
            Response.Write("<script>alert('Thêm thành công');</script>");

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // bind to text box
            txtId.Text = gvList.SelectedRow.Cells[1].Text;
            txtHoten.Text = gvList.SelectedRow.Cells[2].Text;
            ddbXiNghiep.SelectedValue = gvList.SelectedRow.Cells[3].Text;
            if (gvList.SelectedRow.Cells[4].Text == "0")
            {
                rdbGioiTinhNam.Checked = true;
            }
            else
            {
                rdbGioiTinhNu.Checked = true;
            }
            if (gvList.SelectedRow.Cells[5].Text == "1")
            {
                rdbTiem1.Checked = true;
            }
            else
            {
                rdbTiem2.Checked = true;
            }


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // delete TiemVacXin
            var id = int.Parse(gvList.SelectedRow.Cells[1].Text);
            databaseService.RemoveTiemVacXin(id);
            // show message
            Response.Write("<script>alert('Xóa thành công')</script>");
        }

        protected void gvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // bind to text box
            txtId.Text = gvList.SelectedRow.Cells[1].Text;
            txtHoten.Text = gvList.SelectedRow.Cells[2].Text;
            ddbXiNghiep.SelectedValue = gvList.SelectedRow.Cells[3].Text;
            if (gvList.SelectedRow.Cells[4].Text == "0")
            {
                rdbGioiTinhNam.Checked = true;
            }
            else
            {
                rdbGioiTinhNu.Checked = true;
            }
            if (gvList.SelectedRow.Cells[5].Text == "1")
            {
                rdbTiem1.Checked = true;
            }
            else
            {
                rdbTiem2.Checked = true;
            }

        }

        protected void btnEditMan_Click(object sender, EventArgs e)
        {
            // edit TiemVacXin
            var tiemVacXin = new TiemVacXin();
            tiemVacXin.Id = int.Parse(txtId.Text);
            tiemVacXin.HoTen = txtHoten.Text;
            tiemVacXin.XiNghiepId = int.Parse(ddbXiNghiep.SelectedValue);
            bool gioiTinh = false;
            if (rdbGioiTinhNam.Checked)
            {
                gioiTinh = true;
            }
            tiemVacXin.GioiTinh = gioiTinh;
            bool daTiem = false;
            if (rdbTiem2.Checked)
            {
                daTiem = true;
            }
            tiemVacXin.Status = daTiem;
            databaseService.UpdateTiemVacXin(tiemVacXin);
            LoadData();
        }

        protected void btnNamTiemVacXin_Click(object sender, EventArgs e)
        {
            // load to gvList
            var tiemVacXins = databaseService.GetByGioiTinhAndXiNghiep("0", "Mỹ Tho – Châu Thành");
            if (tiemVacXins == null)
            {
                Response.Write("<script>alert('Không có dữ liệu')</script>");
            }
            else
            {
                gvList.DataSource = tiemVacXins;
            }
        }

        protected void SoLuongNguoiDaTien_Click(object sender, EventArgs e)
        {
            // load to gvList
            var res = databaseService.GetCountByStatus("1");
            Response.Write($"<script>alert('So nguoi da tiem: {res}');</script>");
        }
    }
}