using CaterBll;
using CaterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterUI
{
    public partial class FormDishInfo : Form
    {
        public FormDishInfo()
        {
            InitializeComponent();
        }
        private DishInfoBll dib = new DishInfoBll();
        private void FormDishInfo_Load(object sender, EventArgs e)
        {
            LoadTypeList();
            LoadList();
        }

        private void LoadTypeList()
        {
            DishTypeInfoBll dtiBll = new DishTypeInfoBll();
            List<DishTypeInfo> list = dtiBll.GetList();
            list.Insert(0,new DishTypeInfo() {
                DId = -1,
                DTitle = "全部"
            });
            ddlTypeSearch.DataSource = list;
            ddlTypeSearch.ValueMember = "DId";
            ddlTypeSearch.DisplayMember = "DTitle";
        }

        private void LoadList()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (txtTitleSearch.Text!="")
            {
                dict.Add("di.Dtitle", txtTitleSearch.Text.Trim());
            }

            if (ddlTypeSearch.SelectedIndex!=0)
            {
                dict.Add("di.DTypeId", ddlTypeSearch.SelectedValue.ToString());
            }

            dgvList.AutoGenerateColumns = false;
            dgvList.DataSource = dib.GetList(dict);
        }

        private void txtTitleSearch_Leave(object sender, EventArgs e)
        {
            LoadList();
        }

        private void ddlTypeSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtTitleSearch.Text = "";
            ddlTypeSearch.SelectedIndex = 0;
            LoadList();
        }
    }
}
