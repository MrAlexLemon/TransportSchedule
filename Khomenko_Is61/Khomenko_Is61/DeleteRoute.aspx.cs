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
    public partial class DeleteRoute : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox7.Text != "")
            {
                n = Convert.ToInt32(TextBox7.Text);
                n -= 1;
                if (n < 0 || n >= rptrLoc.Items.Count)
                {
                    Label11.Text = "Error number of rom must be >=1";
                }
                else
                {
                    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        RepeaterItem item = rptrLoc.Items[n];
                        Label lblname = (Label)item.FindControl("Id");
                        string str = lblname.Text;
                        con.Open();
                        string query = "delete from Route where Id=@Id";
                        SqlCommand sqlCmd = new SqlCommand(query, con);
                        //sqlCmd.Parameters.AddWithValue("@RName", (rptrLoc.Items[n].FindControl("RName") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Id", str);//(rptrLoc.Items[n].FindControl("Id") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                    }
                    BindBrandsRptr();
                }
            }
        }
    }
}