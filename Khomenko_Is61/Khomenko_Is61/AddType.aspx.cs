using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khomenko_Is61
{
    public partial class AddType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandsRptr();
            }
        }

        private void BindBrandsRptr()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Type_vehicle", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dtLoc = new DataTable();
                        sda.Fill(dtLoc);
                        rptrLoc.DataSource = dtLoc;
                        rptrLoc.DataBind();
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtType.Text != "" && txtSp.Text != "" && txtPr.Text != "" && txtTim.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into Type_vehicle values('" + txtType.Text + "','"+ txtSp.Text+"','"+ txtPr.Text+"','"+ txtTim.Text+"')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    txtType.Text = string.Empty;
                    txtSp.Text = string.Empty;
                    txtPr.Text = string.Empty;
                    txtTim.Text = string.Empty;
                }
                BindBrandsRptr();
            }
        }
    }
}