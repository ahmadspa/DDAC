using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace Cruise_App.WebForm
{
    public partial class Tracking : System.Web.UI.Page
    {
        public static String StrConn = "Driver={SQL Server Native Client 10.0};Server=tcp:ahmadspaserver.database.windows.net,1433;Database=CruiseDB;Uid=ahmad123@ahmadspaserver;Pwd={Ahmadspa123@};Encrypt=yes;Connection Timeout=130;";
        public static OdbcConnection conn = new OdbcConnection(StrConn);
        public static OdbcCommand cmd = conn.CreateCommand();
        public static OdbcDataReader dr;
        public static OdbcDataAdapter da;

        //public static String StrConn = "Data Source=BRY\\SQLEXPRESS;Initial Catalog=CruiseDB;Integrated Security=True";
        //public static SqlConnection conn = new SqlConnection(StrConn);
        //public static SqlCommand cmd = conn.CreateCommand();
        //public static SqlDataReader dr;
        //public static SqlDataAdapter da;

        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();
        public static int UserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                UserID = int.Parse(Session["Value"].ToString());
                Time();
                FillGridview();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Time();
        }
        public void Time()
        {
            string[] medet = {"AM","PM"};
            System.DateTime mytime = new System.DateTime();
            if (DateTime.Now.ToString("tt") == "AM")
            {
                
                lblHour.Text = DateTime.Now.Hour.ToString();
                lblMinute.Text = DateTime.Now.Minute.ToString();
                lblSecond.Text = DateTime.Now.Second.ToString();
                lblMediterinian.Text = medet[0];
            }
            else
            {
                lblHour.Text = DateTime.Now.Hour.ToString();
                lblMinute.Text = DateTime.Now.Minute.ToString();
                lblSecond.Text = DateTime.Now.Second.ToString();
                lblMediterinian.Text = medet[1];
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime str = DateTime.Parse(GridView1.SelectedRow.Cells[3].Text);
            TimeSpan diff = str - DateTime.Today;
            int leftday = (diff.Days);
            Label5.Text = leftday.ToString();
        }
        private void FillGridview()
        {
            try
            {
                cmd.CommandText = "SELECT P.Fullname AS [Full Name], P.DepartureCity AS [Departure Port], P.DepartureDate AS [D.Date], P.DestinationCity AS [Arrival Port], P.DestinationDate AS [A.Date], CB.Cabin_Type AS [Cabin], P.MealType AS Meal FROM Payment P INNER JOIN Customer C ON P.CustomerID = C.Customer_ID INNER JOIN Reservation R ON R.Customer_ID = C.Customer_ID INNER JOIN Cabin CB ON CB.Cabin_ID = R.Cabin_ID WHERE R.Reservation_Status = 'Confirmed' AND R.Active = 'True'";
                conn.Open();
                da = new OdbcDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    //ds.Clear();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Tracking.aspx';</script>");
                return;
            }
        }

        protected void lnkMyProfile_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("MyProfile.aspx");
        }

        protected void lnkManageBooking_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Manage Booking.aspx");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}