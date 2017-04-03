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
    public partial class Login : System.Web.UI.Page
    {
        public static String StrConn = "Driver={SQL Server Native Client 10.0};Server=tcp:ahmadspaserver.database.windows.net,1433;Database=CruiseDB;Uid=ahmad123@ahmadspaserver;Pwd={Ahmadspa123@};Encrypt=yes;Connection Timeout=130;";
        public static OdbcConnection conn = new OdbcConnection(StrConn);
        public static OdbcCommand cmd = conn.CreateCommand();
        public static OdbcDataReader dr;

        //public static String StrConn = "Data Source=BRY\\SQLEXPRESS;Initial Catalog=CruiseDB;Integrated Security=True";
        //public static SqlConnection conn = new SqlConnection(StrConn);
        //public static SqlCommand cmd = conn.CreateCommand();
        //public static SqlDataReader dr;

        bool valid = false;
        public string username = "", useremail = "";
        public int userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.Form.DefaultButton = this.btnSend.UniqueID;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "SELECT Username, Password FROM Customer WHERE Username = '" +txtUsername.Text+ "' AND Password= '"+ txtPassword.Text +"'";
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true){
                    valid = true;
                }
                dr.Close();
            }catch(Exception ex){
                lblMessage.Text = ex.ToString();

            }finally{
               
                conn.Close();
            }
            if(valid == true){
                try{
                    cmd.CommandText = "SELECT Customer_ID FROM Customer WHERE Username = '" +txtUsername.Text+ "' AND Password= '"+ txtPassword.Text +"'";
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    while(dr.Read()){
                        userID = int.Parse(dr["Customer_ID"].ToString());
                    }
                    
                }catch(Exception ex){
                    lblMessage.Text = ex.ToString();
                }finally{
                    dr.Close();
                    conn.Close();
                }
                //lblMessage.Text = "Access Granted " + username.ToString();
                Session["Value"] = userID.ToString();
                Response.Redirect("MyProfile.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password !";
               
            }
        }


    }
}