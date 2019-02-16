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
    public partial class AddCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategory();
                BindBrandsRptr();
            }
        }

        private void BindBrandsRptr()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select A.*,B.* from Company A inner join Location B on B.Id=A.Address", con))
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

        private void BindMainCategory()
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Location", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlAddr.DataSource = dt;
                    ddlAddr.DataTextField = "AName";
                    ddlAddr.DataValueField = "Id";
                    ddlAddr.DataBind();
                    ddlAddr.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtComp.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into Company values('" + txtComp.Text + "','"+ddlAddr.SelectedItem.Value+"')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    txtComp.Text = string.Empty;
                    ddlAddr.ClearSelection();
                    ddlAddr.Items.FindByValue("0").Selected = true;
                }
                BindBrandsRptr();
            }
        }
    }
}