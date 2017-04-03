using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using System.Data.Odbc;


namespace Cruise_App.WebForm
{
    public partial class ProceedBooking : System.Web.UI.Page
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

        public static int UserID = 0;
        public static string depTime = "", desTime = "", MealID = "", shipID = "", cabinID ="0",tripID="";
        public DateTime tripdate = new DateTime(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                UserID = int.Parse(Session["Value"].ToString());
                
                Page last_page = (Page)Context.Handler;
                if (last_page is Manage_Booking)
                {
                    
                    lblDays.Text =((Manage_Booking)last_page).ShipLength;
                    lblArrivalCity.Text = ((Manage_Booking)last_page).DestinationPort;
                    lblDeparture.Text = ((Manage_Booking)last_page).DeparturePort;
                    lblShipName.Text = ((Manage_Booking)last_page).ShipName;
                    lblDepur.Text = ((Manage_Booking)last_page).DeparturePort;
                    lblDesti.Text = ((Manage_Booking)last_page).DestinationPort;
                    lblDepartureDate.Text = ((Manage_Booking)last_page).DepartureDate;
                    lblArrivalDate.Text = ((Manage_Booking)last_page).ArrivalDate;
                    tripID = ((Manage_Booking)last_page).Trip_ID;
                    //lblErrorMessage4.Text = UserID.ToString();
                    //lblErrorMessage.Text = tripID.ToString();
                    //retrieve some infor
                    try
                    {
                        cmd.CommandText = "SELECT CT.Departure_Time, CT.Arrival_Time FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON SP.Ship_ID = CR.Ship_ID WHERE CT.Departure_Port ='" + lblDeparture.Text + "' AND CT.Destination_Port = '" + lblArrivalCity.Text + "' AND CT.Cruise_Length = '" + lblDays.Text + "'";
                        conn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            desTime = dr["Arrival_Time"].ToString();
                            depTime = dr["Departure_Time"].ToString();
                        }
                        lblDepartureTime.Text = depTime.ToString();
                        lblArrivalTime.Text = desTime.ToString();
                        tripdate = DateTime.Parse(lblDepartureDate.Text);
                        String shortDateTime = tripdate.ToLongDateString();
                        lblTripDate1.Text = shortDateTime.ToString();
                        lblAnotherShipName.Text = ((Manage_Booking)last_page).ShipName;
                        dr.Close();
                        
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.ToString();
                    }
                    finally
                    {
                        
                        if (conn!=null)
                        {
                            conn.Close();
                        }
                        
                    }
                }
               
               
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manage Booking.aspx");
        }



        protected void rdbOceanview_CheckedChanged(object sender, EventArgs e)
        {
            if (dpoGuestNumber.SelectedIndex == 1 && rdbOceanview.Checked == true)
            {
                rdbBalcony.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";
                lblTripCost.Text = "430.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 2 && rdbOceanview.Checked == true)
            {
                rdbBalcony.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";
                lblTripCost.Text = "226.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 3 && rdbOceanview.Checked == true)
            {
                rdbBalcony.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";
                lblTripCost.Text = "226.00";
            }
            else if(dpoGuestNumber.SelectedIndex == 0 && rdbOceanview.Checked == true)
            {
                //display message
            }
        }

        protected void rdbBalcony_CheckedChanged(object sender, EventArgs e)
        {
            if (dpoGuestNumber.SelectedIndex == 1 && rdbBalcony.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "580.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 2 && rdbBalcony.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "292.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 3 && rdbBalcony.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "292.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 0 && rdbBalcony.Checked == true)
            {
                //display message
            }
        }

        protected void rdbSuite_CheckedChanged(object sender, EventArgs e)
        {
            if (dpoGuestNumber.SelectedIndex == 1 && rdbSuite.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbBalcony.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "1600.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 2 && rdbSuite.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbBalcony.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "820.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 2 && rdbSuite.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbBalcony.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "820.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 0 && rdbSuite.Checked == true)
            {
                //display message
            }
        }

        protected void dpoGuestNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpoGuestNumber.SelectedIndex == 1 && rdbOceanview.Checked == true)
            {
                rdbBalcony.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";
                lblTripCost.Text = "430.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 1 && rdbBalcony.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "580.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 1 && rdbSuite.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbBalcony.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";
                
                lblTripCost.Text = "1600.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 2 && rdbOceanview.Checked == true)
            {
                rdbBalcony.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";
                lblTripCost.Text = "226.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 2 && rdbBalcony.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "292.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 2 && rdbSuite.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbBalcony.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "820.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 3 && rdbOceanview.Checked == true)
            {
                rdbBalcony.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";
                lblTripCost.Text = "226.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 3 && rdbBalcony.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbSuite.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "292.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 3 && rdbSuite.Checked == true)
            {
                rdbOceanview.Checked = false;
                rdbBalcony.Checked = false;
                lblOceanViewPrice1.Text = "430.00";
                lblOceanViewPrice2.Text = "226.00";
                lblBalconyPrice1.Text = "580.00";
                lblBalconyPrice2.Text = "292.00";
                lblSuitePrice1.Text = "1600.00";
                lblSuitePrice2.Text = "820.00";

                lblTripCost.Text = "820.00";
            }
            else if (dpoGuestNumber.SelectedIndex == 0 || rdbBalcony.Checked == true || rdbSuite.Checked == true || rdbOceanview.Checked == true)
            {
                //display a message
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
  
            if (rdbOceanview.Checked == true)
            {
                InsertOceanView();
            }
            else if (rdbBalcony.Checked == true)
            {
                InsertBalcony();
            }
            else if (rdbSuite.Checked == true)
            {
                insertSuite();
            }
            
        }
        private void InsertOceanView()
        {
            //get ship id based on the name of ship
            string cabintype = "Ocean View";
            try
            {
                cmd.CommandText = "SELECT Ship_ID FROM Ship  WHERE Ship_Description = '" + lblShipName.Text + "'";
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    shipID = dr["Ship_ID"].ToString();
                }
                dr.Close();
                
            }catch(Exception ex){
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //insert into cabin table with the price of cabin include ship id.
            try
            {
                cmd.CommandText = "INSERT INTO Cabin VALUES ('" + cabintype.ToString() + "','" + dpoGuestNumber.SelectedValue.ToString() + "','" + lblTripCost.Text + "','" + shipID.ToString() + "')";
                conn.Open();
                cmd.ExecuteNonQuery();
                //lblErrorMessage.Text = "Data Successfully Inserted";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            //select the cabin id you insert above
            try
            {
                cmd.CommandText = "SELECT Cabin_ID FROM Cabin WHERE Cabin_Type = '" + cabintype.ToString() + "' AND Cabin_Description = '" + dpoGuestNumber.SelectedValue.ToString() + "'  AND Price = '" + lblTripCost.Text + "' AND Ship_ID = '" + shipID.ToString() + "'";
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cabinID = dr["Cabin_ID"].ToString();
                }
                dr.Close();
                //lblErrorMessage.Text = cabinID.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //insert data into reservation ship id, customer id, trip id, meal id and other data.
            try
            {
                string todaydate = DateTime.Today.ToLongDateString();
                cmd.CommandText = "INSERT INTO Reservation (Reservation_Date,Reservation_Status, Customer_ID,Cabin_ID, Trip_ID, Active) VALUES ('" + todaydate.ToString() + "','Pending','" + UserID.ToString() + "','" + cabinID.ToString() + "','" + tripID.ToString() + "','True')";
                conn.Open();
                cmd.ExecuteNonQuery();

                lblMessage.Text = "You Have Succefully Booked.";

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
        private void InsertBalcony()
        {
            //get ship id based on the name of ship
            string cabintype = "Balcony";
            try
            {
                cmd.CommandText = "SELECT Ship_ID FROM Ship  WHERE Ship_Description = '" + lblShipName.Text + "'";
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    shipID = dr["Ship_ID"].ToString();
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //insert into cabin table with the price of cabin include ship id.
            try
            {
                cmd.CommandText = "INSERT INTO Cabin VALUES ('" + cabintype.ToString() + "','" + dpoGuestNumber.SelectedValue.ToString() + "','" + lblTripCost.Text + "','" + shipID.ToString() + "')";
                conn.Open();
                cmd.ExecuteNonQuery();
                //lblErrorMessage.Text = "Data Successfully Inserted";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            //select the cabin id you insert above
            try
            {
                cmd.CommandText = "SELECT Cabin_ID FROM Cabin WHERE Cabin_Type = '" + cabintype.ToString() + "' AND Cabin_Description = '" + dpoGuestNumber.SelectedValue.ToString() + "'  AND Price = '" + lblTripCost.Text + "' AND Ship_ID = '" + shipID.ToString() + "'";
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cabinID = dr["Cabin_ID"].ToString();
                }
                dr.Close();
                //lblErrorMessage.Text = cabinID.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //insert data into reservation ship id, customer id, trip id, meal id and other data.
            try
            {
                string todaydate = DateTime.Today.ToLongDateString();
                cmd.CommandText = "INSERT INTO Reservation (Reservation_Date,Reservation_Status, Customer_ID,Cabin_ID, Trip_ID, Active) VALUES ('" + todaydate.ToString() + "','Pending','" + UserID.ToString() + "','" + cabinID.ToString() + "','" + tripID.ToString() + "','True')";
                conn.Open();
                cmd.ExecuteNonQuery();

                lblMessage.Text = "You Have Succefully Booked.";

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
        private void insertSuite()
        {
            //get ship id based on the name of ship
            string cabintype = "Suite";
            try
            {
                cmd.CommandText = "SELECT Ship_ID FROM Ship  WHERE Ship_Description = '" + lblShipName.Text + "'";
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    shipID = dr["Ship_ID"].ToString();
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //insert into cabin table with the price of cabin include ship id.
            try
            {
                cmd.CommandText = "INSERT INTO Cabin VALUES ('" + cabintype.ToString() + "','" + dpoGuestNumber.SelectedValue.ToString() + "','" + lblTripCost.Text + "','" + shipID.ToString() + "')";
                conn.Open();
                cmd.ExecuteNonQuery();
                //lblErrorMessage.Text = "Data Successfully Inserted";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            //select the cabin id you insert above
            try
            {
                cmd.CommandText = "SELECT Cabin_ID FROM Cabin WHERE Cabin_Type = '" + cabintype.ToString() + "' AND Cabin_Description = '" + dpoGuestNumber.SelectedValue.ToString() + "'  AND Price = '" + lblTripCost.Text + "' AND Ship_ID = '" + shipID.ToString() + "'";
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cabinID = dr["Cabin_ID"].ToString();
                }
                dr.Close();
                //lblErrorMessage.Text = cabinID.ToString();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }

            //insert data into reservation ship id, customer id, trip id, meal id and other data.
            try
            {
                string todaydate = DateTime.Today.ToLongDateString();
                cmd.CommandText = "INSERT INTO Reservation (Reservation_Date,Reservation_Status, Customer_ID,Cabin_ID, Trip_ID, Active) VALUES ('" + todaydate.ToString() + "','Pending','" + UserID.ToString() + "','" + cabinID.ToString() + "','" + tripID.ToString() + "','True')";
                conn.Open();
                cmd.ExecuteNonQuery();

                lblMessage.Text = "You Have Succefully Booked.";

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

        protected void lnlTrackCuise_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Tracking.aspx");
        }  
    }
}