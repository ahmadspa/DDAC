using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace Cruise_App.WebForm
{
    public partial class ViewMyProfile : System.Web.UI.Page
    {
        public static String StrConn = "Driver={SQL Server Native Client 10.0};Server=tcp:ahmadspaserver.database.windows.net,1433;Database=CruiseDB;Uid=ahmad123@ahmadspaserver;Pwd={Ahmadspa123@};Encrypt=yes;Connection Timeout=130;";
        public static OdbcConnection conn = new OdbcConnection(StrConn);
        public static OdbcCommand cmd = conn.CreateCommand();
        public static OdbcDataReader dr;

        //public static String StrConn = "Data Source=BRY\\SQLEXPRESS;Initial Catalog=CruiseDB;Integrated Security=True";
        //public static SqlConnection conn = new SqlConnection(StrConn);
        //public static SqlCommand cmd = conn.CreateCommand();
        //public static SqlDataReader dr;

        public static int UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                UserID = int.Parse(Session["Value"].ToString());
                try
                {
                    cmd.CommandText = "SELECT First_Name, Last_Name, Gender, Contact, Address, Email, Username, Password FROM Customer WHERE Customer_ID = '"+UserID.ToString()+"'";
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtFname.Text = dr["First_Name"].ToString();
                        txtLname.Text = dr["Last_Name"].ToString();
                        dpoGender.SelectedValue = dr["Gender"].ToString();
                        txtContact.Text = dr["Contact"].ToString();
                        txtAddress.Text = dr["Address"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtUsername.Text = dr["Username"].ToString();
                        txtPassword.Text = dr["Password"].ToString();
                        
                    }
                    dr.Close();
                }catch(Exception ex){
                    Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='ViewMyProfile.aspx.aspx';</script>");
                    return;
                }finally{
                    conn.Close();
                }
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "UPDATE Customer SET First_Name ='" + txtFname.Text + "', Last_Name ='" + txtLname.Text + "', Gender = '" + dpoGender.SelectedValue.ToString() + "', Contact = '"+txtContact.Text+"', Address = '"+txtAddress.Text+"', Email = '"+txtEmail.Text+"', Username = '"+txtUsername.Text+"', Password = '"+txtPassword.Text+"' WHERE Customer_ID = '"+UserID.ToString()+"'";
                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Data Successfully Updated'); " + "window.location='ViewMyProfile.aspx';</script>");
                return;
            }catch(Exception ex){
                Response.Write("<script>alert('" + ex.ToString() + "'); " + "window.location='ViewMyProfile.aspx';</script>");
                return;
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("MyProfile.aspx");
        }

        protected void lnlTrackCuise_Click(object sender, EventArgs e)
        {
            Session["Value"] = UserID.ToString();
            Response.Redirect("Tracking.aspx");
        }
    }
}