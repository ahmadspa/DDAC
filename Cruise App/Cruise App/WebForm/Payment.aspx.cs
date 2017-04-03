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
    public partial class Payment : System.Web.UI.Page
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

        public static int UserID = 0, tripID = 0, reserID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            txtPackageID.Enabled = false;
            txtFullname.Enabled = false;
            txtDate.Enabled = false;
            if (!IsPostBack)
            {
                UserID = int.Parse(Session["Value"].ToString());
                try
                {
                    cmd.CommandText = "SELECT R.Trip_ID AS Package, R.Reservation_Date AS [Reservation Date],C.Full_Name AS [Full Name],T.Country AS Country,T.Departure_Port AS Source, T.Destination_Port AS Destination, R.Reservation_Status AS Status FROM Reservation R INNER JOIN Customer C ON C.Customer_ID = R.Customer_ID INNER JOIN Cruise_Trip T ON R.Trip_ID = T.Trip_ID WHERE R.Active = 'True' AND R.Customer_ID = '"+UserID.ToString()+"' AND R.Reservation_Status = 'Pending'";
                    conn.Open();
                    da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();
                           
                        }
                }catch(Exception ex){
                    lblMessage.Text = ex.ToString();
                }finally{
                    conn.Close();
                }
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPackageID.Text = (GridView1.SelectedRow.Cells[1].Text);
            txtFullname.Text = GridView1.SelectedRow.Cells[3].Text;
            lblDepur.Text = GridView1.SelectedRow.Cells[5].Text;
            lblDesti.Text = GridView1.SelectedRow.Cells[6].Text;
            lblArrivalCity.Text = GridView1.SelectedRow.Cells[6].Text;
            lblDeparture.Text = GridView1.SelectedRow.Cells[5].Text;
            txtDate.Text = DateTime.Today.ToLongDateString();
            
            //lblMessage.Text = tripID.ToString();
             
            try
            {
                cmd.CommandText = "SELECT T.Cruise_Length AS Length, T.Departure_Date AS DepDate, T.Departure_Time AS DepTime, T.Arrival_Date AS ArrDate, T.Arrival_Time AS ArrTime, C.Cabin_Description AS CabDesc, C.Cabin_Type AS CabType,C.Price AS totalcost, S.Ship_Description AS Shipname, M.Meal_Description AS mealdescr, R.Reservation_ID AS Reservation_ID FROM Cruise_Trip T INNER JOIN Reservation R ON R.Trip_ID = T.Trip_ID INNER JOIN Cabin C ON C.Cabin_ID = R.Cabin_ID INNER JOIN Ship S ON S.Ship_ID = C.Ship_ID INNER JOIN Meal_Services M ON M.Meal_ID = T.Meal_ID WHERE T.Trip_ID = '" + txtPackageID.Text + "'";
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    reserID = int.Parse(dr["Reservation_ID"].ToString());
                    lblDays.Text = dr["Length"].ToString();
                    lblDepartureDate.Text = dr["DepDate"].ToString();
                    lblDepartureTime.Text = dr["DepTime"].ToString();
                    lblArrivalDate.Text = dr["ArrDate"].ToString();
                    lblArrivalTime.Text = dr["ArrTime"].ToString();
                    lblCabin.Text = dr["CabType"].ToString();
                    lblCabinDesction.Text = dr["CabDesc"].ToString();
                    lblShipName.Text = dr["Shipname"].ToString();
                    lblMeal.Text = dr["mealdescr"].ToString();
                   decimal num1 = decimal.Parse(dr["totalcost"].ToString());
                   decimal num = Math.Round(num1, 2);
                   lblTripCost.Text = num.ToString();
                   decimal amount = num1 + 75;
                   decimal totalcost = Math.Round(amount, 2);
                   lblTotalCost.Text = totalcost.ToString();
                }
                dr.Close();
            }catch(Exception ex){
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
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
            Session["Value"] = UserID.ToString();
            Response.Redirect("Login.aspx");
        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            decimal amount = decimal.Parse(lblTotalCost.Text);
            decimal payment = decimal.Parse(txtPayment.Text);
            decimal balance = 0;

            if (payment < amount)
            {
                Response.Write("<script>alert('Invalid amount you enter !'); " + "window.location='Payment.aspx';</script>");
                return;
            }
            else if (payment > amount)
            {
                //calcutate here
                balance = payment - amount;
                try
                {
                    cmd.CommandText = "INSERT INTO Payment VALUES ('" + UserID.ToString() + "', '" + txtFullname.Text + "', '" + lblDeparture.Text + "', '" + lblDepartureDate.Text + "', '" + lblArrivalCity.Text + "', '" + lblArrivalDate.Text +"', '"+lblCabinDesction.Text+"', '"+lblMeal.Text+"', '"+txtPayment.Text+"', '"+balance.ToString()+"','True')";
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.ToString();
                }
                finally
                {
                    conn.Close();
                }
                //update the status from true to false
                try
                {
                    cmd.CommandText = "UPDATE Reservation SET Reservation_Status = 'Confirmed' WHERE Reservation_ID = '"+reserID.ToString()+"'";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Your Balance is " + balance.ToString();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Transaction Failed, Please try agin!'); " + "window.location='Payment.aspx';</script>");
                return;
            }
        }

        protected void lnlTrackCuise_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Tracking.aspx");
        }
 
    }
}