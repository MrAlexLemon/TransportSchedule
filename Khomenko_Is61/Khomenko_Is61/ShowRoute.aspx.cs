using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Khomenko_Is61
{
    public partial class ShowRoute : System.Web.UI.Page
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

        protected void btnSort_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string query = "select A.*,B.*,C.*,D.*,E.*,Rank() Over(Partition by CAST(TName as NVARCHAR(100)) Order by CAST(RName as NVARCHAR(100))) from Route A inner join Vehicle B on B.Id=A.Vehicleid inner join Location C on C.Id=A.StartLoc inner join Location D on D.Id=A.FinishLoc inner join Type_vehicle E on E.Id=B.Type"; //and StartTime Between (@Time-'00:30:00') and (@Time+'00:30:00')";// and A.StartTime between @Time -  and ";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                
                using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
                {
                    DataTable dtLoc = new DataTable();
                    sda.Fill(dtLoc);
                    rptrLoc.DataSource = dtLoc;
                    rptrLoc.DataBind();
                }
            }
        }

        protected void btnGroup_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                string query = "select A.*,B.*,C.*,D.*,E.*,Rank() Over(Partition by CAST(VName as NVARCHAR(100)) Order by CAST(RName as NVARCHAR(100))) from Route A inner join Vehicle B on B.Id=A.Vehicleid inner join Location C on C.Id=A.StartLoc inner join Location D on D.Id=A.FinishLoc inner join Type_vehicle E on E.Id=B.Type"; //and StartTime Between (@Time-'00:30:00') and (@Time+'00:30:00')";// and A.StartTime between @Time -  and ";
                SqlCommand sqlCmd = new SqlCommand(query, con);

                using (SqlDataAdapter sda = new SqlDataAdapter(sqlCmd))
                {
                    DataTable dtLoc = new DataTable();
                    sda.Fill(dtLoc);
                    rptrLoc.DataSource = dtLoc;
                    rptrLoc.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=RepeaterExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            rptrLoc.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}