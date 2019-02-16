using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khomenko_Is61
{
    public partial class ChooseWay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMainCategory();
                BindBrandsRptr();
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

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Type_vehicle", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "TName";
                    DropDownList1.DataValueField = "Id";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("-Select-", "0"));
                }
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

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["USERNAME"] = null;
            Response.Redirect("~/Default.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;


            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string query = "select A.*,B.*,C.*,D.*,E.* from Route A inner join Vehicle B on B.Id=A.Vehicleid inner join Location C on C.Id=A.StartLoc inner join Location D on D.Id=A.FinishLoc inner join Type_vehicle E on E.Id=B.Type where StartLoc=@Sloc and FinishLoc=@Floc and E.Id=@TpVeh order by StartTime"; //and StartTime Between (@Time-'00:30:00') and (@Time+'00:30:00')";// and A.StartTime between @Time -  and ";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.Parameters.AddWithValue("@Sloc", ddlStar.SelectedItem.Value.ToString());
                sqlCmd.Parameters.AddWithValue("@Floc", ddlFin.SelectedItem.Value);
                sqlCmd.Parameters.AddWithValue("@TpVeh", DropDownList1.SelectedItem.Value);
               // DateTime dateTime = DateTime.ParseExact(TextBox1.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
                //sqlCmd.Parameters.AddWithValue("@Time", dateTime);
                
                using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
                {
                    DataTable dtLoc = new DataTable();
                    sda.Fill(dtLoc);
                    rptrLoc.DataSource = dtLoc;
                    rptrLoc.DataBind();
                }
            }
        }
    }
}