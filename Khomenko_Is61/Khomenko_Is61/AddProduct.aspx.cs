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
    public partial class AddProduct : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("select A.*,B.*,C.*,D.*,E.* from Route A inner join Vehicle B on B.Id=A.Vehicleid inner join Location C on C.Id=A.StartLoc inner join Location D on D.Id=A.FinishLoc inner join Type_vehicle E on E.id=B.Type", con)) // inner join Company E on E.id=B.Company inner join Location F on F.id=E.Address
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
                SqlCommand cmd = new SqlCommand("select * from Vehicle", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlVeh.DataSource = dt;
                    ddlVeh.DataTextField = "VName";
                    ddlVeh.DataValueField = "Id";
                    ddlVeh.DataBind();
                    ddlVeh.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Location", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlStar.DataSource = dt;
                    ddlStar.DataTextField = "AName";
                    ddlStar.DataValueField = "Id";
                    ddlStar.DataBind();
                    ddlStar.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Location", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    ddlFin.DataSource = dt;
                    ddlFin.DataTextField = "AName";
                    ddlFin.DataValueField = "Id";
                    ddlFin.DataBind();
                    ddlFin.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNamR.Text != "" && txtSt.Text != "" && txtFn.Text != "")
            {
                String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("insert into Route values('" + txtNamR.Text + "','" + ddlStar.SelectedItem.Value + "','" + ddlFin.SelectedItem.Value + "','" + ddlVeh.SelectedItem.Value + "','" + txtSt.Text + "','" + txtFn.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    txtNamR.Text = string.Empty;
                    txtSt.Text = string.Empty;
                    txtFn.Text = string.Empty;
                    ddlStar.ClearSelection();
                    ddlStar.Items.FindByValue("0").Selected = true;
                    ddlFin.ClearSelection();
                    ddlFin.Items.FindByValue("0").Selected = true;
                    ddlVeh.ClearSelection();
                    ddlVeh.Items.FindByValue("0").Selected = true;
                }
                BindBrandsRptr();
            }
        }
    }
}