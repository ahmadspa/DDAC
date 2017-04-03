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
    public partial class MyProfile : System.Web.UI.Page
    {

        public static String StrConn = "Driver={SQL Server Native Client 10.0};Server=tcp:ahmadspaserver.database.windows.net,1433;Database=CruiseDB;Uid=ahmad123@ahmadspaserver;Pwd={Ahmadspa123@};Encrypt=yes;Connection Timeout=130;";
        public static OdbcConnection conn = new OdbcConnection(StrConn);
        public static OdbcCommand cmd = conn.CreateCommand();
        public static OdbcDataReader dr;
        public static OdbcDataAdapter ad = new OdbcDataAdapter();

        //public static String StrConn = "Data Source=BRY\\SQLEXPRESS;Initial Catalog=CruiseDB;Integrated Security=True";
        //public static SqlConnection conn = new SqlConnection(StrConn);
        //public static SqlCommand cmd = conn.CreateCommand();
        //public static SqlDataReader dr;
        //public static SqlDataAdapter ad = new SqlDataAdapter();

        public static DataTable dt = new DataTable();
        
        public static int UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserID = int.Parse(Session["Value"].ToString());
                FillGridview();
                try
                {
                    cmd.CommandText = "SELECT Full_Name, Email FROM Customer WHERE Customer_ID = '" + UserID.ToString() + "'";
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lblUsername.Text = dr["Full_Name"].ToString();
                        lblEmail.Text = dr["Email"].ToString();
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='MyProfile.aspx.aspx';</script>");
                    return;
                }
                finally
                {
                    conn.Close();
                }

                try
                {
                    cmd.CommandText = "SELECT COUNT (Reservation_ID) AS Total FROM Reservation WHERE Customer_ID = '" + UserID.ToString() + "' AND Active = 'True' AND Reservation_Status='Pending'";
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lblTotalPendingBooking.Text = dr["Total"].ToString();
                    }
                    dr.Close();
                }catch(Exception ex){
                    Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='MyProfile.aspx.aspx';</script>");
                    return;
                }
                finally
                {
                    conn.Close();
                }
                
            }
            
        }

        protected void lnkManageBooking_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Manage Booking.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("ViewMyProfile.aspx");
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Payment.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Payment.aspx");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            int i = 0;
            int j = 0;
            int totolRows = 0;
            try
            {
                cmd.CommandText = "SELECT P.Fullname AS [Full Name], P.DepartureCity AS [Departure Port], P.DepartureDate AS [D.Date], P.DestinationCity AS [Arrival Port], P.DestinationDate AS [A.Date], CB.Cabin_Type AS [Cabin Type], CB.Cabin_Description AS [Cabin Description], P.MealType AS Meal FROM Payment P INNER JOIN Customer C ON P.CustomerID = C.Customer_ID INNER JOIN Reservation R ON R.Customer_ID = C.Customer_ID INNER JOIN Cabin CB ON CB.Cabin_ID =R.Cabin_ID WHERE R.Reservation_Status = 'Confirmed' AND R.Active = 'True'";
                conn.Open();
                ad = new OdbcDataAdapter(cmd);
                dt = new DataTable();
                ad.Fill(dt);
                totolRows = dt.Rows.Count;
                string[] departurecity = new string[totolRows];
                //DateTime[] departuredate = new DateTime[totolRows];
                string[] departuredate = new string[totolRows ];
                string[] arrivalcity = new string[totolRows];
                //DateTime[] arrivaldate = new DateTime[totolRows];
                string[] arrivaldate = new string[totolRows];
                string[] cabintype = new string[totolRows];
                string[] mealtype = new string[totolRows ];
                string[] cabindescription = new string[totolRows];
                DateTime[] date1 = new DateTime[totolRows ];
                DateTime[] date2 = new DateTime[totolRows ];
                //use while loop or for loop
                for (i = 0; i <= totolRows - 1; i += 1)
                {
                    departurecity[i] = dt.Rows[i]["Departure Port"].ToString();
                    departuredate[i] = dt.Rows[i]["D.Date"].ToString();
                    arrivalcity[i] = dt.Rows[i]["Arrival Port"].ToString();
                    arrivaldate[i] = dt.Rows[i]["A.Date"].ToString();
                    cabintype[i] = dt.Rows[i]["Cabin Type"].ToString();
                    cabindescription[i] = dt.Rows[i]["Cabin Description"].ToString();
                    mealtype[i] = dt.Rows[i]["Meal"].ToString();
                }

                for (j = 0; j <= totolRows - 1; j += 1)
                {
                    //Response.Write(departuredate[j].ToString() + " " + arrivaldate[j].ToString() + " " + cabintype[j].ToString());
                    date1[j] = DateTime.Parse(departuredate[j].ToString());
                    
                    if (!e.Day.IsOtherMonth && e.Day.Date == date1[j])
                    {
                        e.Cell.ForeColor = System.Drawing.Color.White;
                        e.Cell.BackColor = System.Drawing.Color.Orange;
                        e.Cell.BorderWidth = 0;
                        string body = "Departure Port: " + departurecity[j].ToString() + Environment.NewLine;
                        body += "Departure Date: " + departuredate.ToString() + Environment.NewLine;
                        body += "Arrival Port: " + arrivalcity[j].ToString() + Environment.NewLine;
                        body += "Arrival Date: " + arrivaldate[j].ToString() + Environment.NewLine;
                        body += "Cabin Type: " + cabintype[j].ToString() + Environment.NewLine;
                        body += "Cabin Description: "+ cabindescription[j].ToString() +Environment.NewLine;
                        body += "Meal Type: "+ mealtype[j].ToString() +Environment.NewLine;
                        e.Cell.ToolTip = body.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                
            }
            finally
            {
                conn.Close();
            }
            
        }
        private void FillGridview()
        {
            DataSet ds = new DataSet();
            OdbcDataAdapter da = new OdbcDataAdapter();
            try
            {
                cmd.CommandText = "SELECT P.Fullname AS [Full Name], P.DepartureCity AS [Departure Port], P.DepartureDate AS [D.Date], P.DestinationCity AS [Arrival Port], P.DestinationDate AS [A.Date], CB.Cabin_Type AS [Cabin Type], P.MealType AS Meal FROM Payment P INNER JOIN Customer C ON P.CustomerID = C.Customer_ID INNER JOIN Reservation R ON R.Customer_ID = C.Customer_ID INNER JOIN Cabin CB ON CB.Cabin_ID =R.Cabin_ID WHERE R.Reservation_Status = 'Confirmed' AND R.Active = 'True'";
                conn.Open();
                ad = new OdbcDataAdapter(cmd);
                ad.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    //ds.Clear();
                }
            }catch(Exception ex){
                Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='MyProfile.aspx.aspx';</script>");
                    return;
            }finally{
                conn.Close();
            }
        }

        protected void lnlTrackCuise_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Tracking.aspx");
        }
        
    }
}