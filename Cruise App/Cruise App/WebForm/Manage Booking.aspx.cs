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
    public partial class Manage_Booking : System.Web.UI.Page
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
        //public static OdbcDataAdapter da;
        
        public static DataSet ds = new DataSet();
        public static DataTable dt = new DataTable();
        public static int UserID = 0;
        public string trip_id,ship, departure_port, desination_port, arrival_date, departure_date, length;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack) 
            {
                UserID = int.Parse(Session["Value"].ToString());
                
            }
        }
        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
                if (dpoCountry.SelectedIndex == 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(1);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(2);
                }
                else if (dpoCountry.SelectedIndex == 0 && dpoDeparture.SelectedIndex != 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(3);
                }
                else if (dpoCountry.SelectedIndex == 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex != 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(4);
                }
                else if (dpoCountry.SelectedIndex == 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex != 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(5);
                }
                else if (dpoCountry.SelectedIndex == 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex != 0)
                {
                    Display(6);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex != 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(7);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex != 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(8);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex != 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(9);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex == 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex != 0)
                {
                    Display(10);
                }
                else if (dpoCountry.SelectedIndex == 0 && dpoDeparture.SelectedIndex != 0 && dpoDestination.SelectedIndex != 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex == 0)
                {
                    Display(11);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex != 0 && dpoDestination.SelectedIndex != 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex != 0)
                {
                    Display(12);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex != 0 && dpoDestination.SelectedIndex != 0 && dpoLenght.SelectedIndex != 0 && dpoShip.SelectedIndex != 0)
                {
                    Display(13);
                }
                else if (dpoCountry.SelectedIndex != 0 && dpoDeparture.SelectedIndex != 0 && dpoDestination.SelectedIndex == 0 && dpoLenght.SelectedIndex == 0 && dpoShip.SelectedIndex != 0)
                {
                    Display(14);
                }
                
    
        }

        private void Display(int option)
        {
            switch (option)
            {
                case 1:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date],CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID ";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();
                           
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        
                        conn.Close();
                    }
                break;
                case 2:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date],CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Country = '" + dpoCountry.Text + "'";
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
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }finally{

                        conn.Close();
                    }
                break;
                case 3:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date],CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Departure_Port = '" + dpoDeparture.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();
                            
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        
                        conn.Close();
                    }
                break;
                case 4:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date],CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Destination_Port = '" + dpoDestination.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();
                         
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        
                        conn.Close();
                    }
                break;
                case 5:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date],CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Cruise_Length = '" + dpoLenght.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();
                            
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                       
                        conn.Close();
                    }
                break;
                case 6:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE SP.Ship_Description = '" + dpoShip.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();
                           
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('"+ex.ToString()+"'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 7:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Country = '" + dpoCountry.Text + "' AND CT.Departure_Port = '" + dpoDeparture.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();

                        }

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 8:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Country = '" + dpoCountry.Text + "' AND CT.Destination_Port = '" + dpoDestination.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();

                        }

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 9:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Country = '" + dpoCountry.Text + "' AND CT.Destination_Port = '" + dpoDestination.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();

                        }

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 10:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Country = '" + dpoCountry.Text + "' AND SP.Ship_Description = '" + dpoShip.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();

                        }

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 11:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Departure_Port = '" + dpoDeparture.Text + "' AND CT.Destination_Port = '" + dpoDestination.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();

                        }

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 12:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Departure_Port = '" + dpoDeparture.Text + "' AND CT.Destination_Port = '" + dpoDestination.Text + "' AND CT.Country = '" + dpoCountry.Text + "' AND SP.Ship_Description = '" + dpoShip.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();

                        }

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 13:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Departure_Port = '" + dpoDeparture.Text + "' AND CT.Destination_Port = '" + dpoDestination.Text + "' AND CT.Country = '" + dpoCountry.Text + "' AND SP.Ship_Description = '" + dpoShip.Text + "' AND CT.Length = '" + dpoLenght.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();

                        }

                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                case 14:
                    try
                    {
                        cmd.CommandText = "SELECT CT.Trip_ID, SP.Ship_Description AS [Ship], CT.Trip_Option AS [Trip], CT.Departure_Port AS [Departure Port], CT.Destination_Port AS [Destination Port], CT.Departure_Date AS [Departure Date], CT.Arrival_Date AS [Arrival Date] ,CT.Cruise_Length AS [Length] FROM Cruise_Trip CT INNER JOIN Cruise CR ON CT.Cruise_ID = CR.Cruise_ID INNER JOIN Ship SP ON CR.Ship_ID = CR.Ship_ID WHERE CT.Departure_Port = '" + dpoDeparture.Text + "'  AND CT.Country = '" + dpoCountry.Text + "' AND SP.Ship_Description = '" + dpoShip.Text + "'";
                        conn.Open();
                        da = new OdbcDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                            ds.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        //write a script to display error
                        Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='Manage Booking.aspx';</script>");
                        return;
                    }
                    finally
                    {
                        conn.Close();
                    }
                break;
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trip_id = GridView1.SelectedRow.Cells[1].Text; 
            ship = GridView1.SelectedRow.Cells[2].Text;
            departure_port = GridView1.SelectedRow.Cells[4].Text;
            desination_port = GridView1.SelectedRow.Cells[5].Text;
            departure_date = GridView1.SelectedRow.Cells[6].Text;
            arrival_date = GridView1.SelectedRow.Cells[7].Text;
            length = GridView1.SelectedRow.Cells[8].Text;
            //Response.Redirect("ProceedBooking.aspx");
            Session["Value"] = UserID.ToString();
            Server.Transfer("ProceedBooking.aspx");
        }
        public string Trip_ID
        {
            get
            {
                return trip_id;
            }
        }
        public string ShipName
        {
            get
            {
                return ship;
            }
        }
        public string DeparturePort
        {
            get
            {
                return departure_port;
            }
        }
        public string DestinationPort
        {
            get
            {
                return desination_port;
            }
        }
        public string DepartureDate
        {
            get
            {
                return departure_date;
            }
        }
        public string ArrivalDate
        {
            get
            {
                return arrival_date;
            }
        }
        public string ShipLength
        {
            get
            {
                return length;
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