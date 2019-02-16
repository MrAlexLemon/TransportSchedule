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
    public partial class UpdateRoute : System.Web.UI.Page
    {
        int n;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindMainCategory();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                RepeaterItem item = rptrLoc.Items[n];
                Label lblname = (Label)item.FindControl("Id");
                string str = lblname.Text;
                con.Open();
                string query = "update Route set RName=@RName, StartTime=@StartTime, ArrivalTime=@ArrivalTime  where Id=@Id";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                //sqlCmd.Parameters.AddWithValue("@RName", (rptrLoc.Items[n].FindControl("RName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@RName", txtNamR.Text);
                sqlCmd.Parameters.AddWithValue("@Id", str);//(rptrLoc.Items[n].FindControl("Id") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@StartTime", TextBox1.Text);
                sqlCmd.Parameters.AddWithValue("@ArrivalTime", TextBox2.Text);
                //sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                RepeaterItem item = rptrLoc.Items[n];
                Label lblname = (Label)item.FindControl("Id");
                string str = lblname.Text;
                con.Open();
                string query = "update Vehicle set VName=@VName where Id=@Id";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.Parameters.AddWithValue("@VName", TextBox3.Text);
                sqlCmd.Parameters.AddWithValue("@Id", str);//(rptrLoc.Items[n].FindControl("Id") as TextBox).Text.Trim());
                //sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
            }

            using (SqlConnection con = new SqlConnection(CS))
            {
                RepeaterItem item = rptrLoc.Items[n];
                Label lblname = (Label)item.FindControl("Id");
                string str = lblname.Text;
                con.Open();
                string query = "update Type_vehicle set TName=@TName, Speed=@Speed, Price=@Price, Interval=@Interval where Id=@Id";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.Parameters.AddWithValue("@TName", txtSt.Text);
                sqlCmd.Parameters.AddWithValue("@Id", str);//(rptrLoc.Items[n].FindControl("Id") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Speed", txtFn.Text);
                sqlCmd.Parameters.AddWithValue("@Price", TextBox4.Text);
                sqlCmd.Parameters.AddWithValue("@Interval", TextBox5.Text);
                //sqlCmd.Parameters.AddWithValue("@Id", Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
            }

            BindBrandsRptr();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox7.Text != "")
            {
                n = Convert.ToInt32(TextBox7.Text);
                n -= 1;
                if (n < 0 || n >= rptrLoc.Items.Count)
                {
                    txtNamR.Text = "";
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    txtSt.Text = "";
                    txtFn.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    
                    Label11.Text = "Error number of rom must be >=1";
                }
                else
                {
                    RepeaterItem item = rptrLoc.Items[n];
                    Label lblname = (Label)item.FindControl("RName");
                    //string name = lblname.Text;
                    //Label lblname1 = (Label)item.FindControl("RName");
                    //name = lblname.Text;
                    txtNamR.Text = lblname.Text;

                    lblname = (Label)item.FindControl("StartTime");
                    TextBox1.Text = lblname.Text;

                    lblname = (Label)item.FindControl("ArrivalTime");
                    TextBox2.Text = lblname.Text;

                    lblname = (Label)item.FindControl("VName");
                    TextBox3.Text = lblname.Text;

                    lblname = (Label)item.FindControl("TName");
                    txtSt.Text = lblname.Text;

                    lblname = (Label)item.FindControl("Speed");
                    txtFn.Text = lblname.Text;

                    lblname = (Label)item.FindControl("Price");
                    TextBox4.Text = lblname.Text;

                    lblname = (Label)item.FindControl("Interval");
                    TextBox5.Text = lblname.Text;


                }
            }
        }
    }
}