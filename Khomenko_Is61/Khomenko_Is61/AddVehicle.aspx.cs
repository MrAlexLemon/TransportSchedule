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
    public partial class AddVehicle : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.* from Vehicle A inner join Type_vehicle B on B.Id=A.Type inner join Company C on C.Id=A.Company inner join Location D on D.Id=C.Address", con))
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
                SqlCommand cmd = new SqlCommand("select * from Company", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlCom.DataSource = dt;
                    ddlCom.DataTextField = "CName";
                    ddlCom.DataValueField = "Id";
                    ddlCom.DataBind();
                    ddlCom.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Type_vehicle", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlType.DataSource = dt;
                    ddlType.DataTextField = "TName";
                    ddlType.DataValueField = "Id";
                    ddlType.DataBind();
                    ddlType.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNam.Text != "" && txtDriv.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into Vehicle values('" + txtNam.Text + "','" + txtDriv.Text  + "','"+ ddlCom.SelectedItem.Value + "','" + ddlType.SelectedItem.Value + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    txtNam.Text = string.Empty;
                    txtDriv.Text = string.Empty;
                    ddlCom.ClearSelection();
                    ddlCom.Items.FindByValue("0").Selected = true;
                    ddlType.ClearSelection();
                    ddlType.Items.FindByValue("0").Selected = true;
                }
                BindBrandsRptr();
            }
        }
    }
}