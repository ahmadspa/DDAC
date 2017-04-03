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
    public partial class Sign_Up : System.Web.UI.Page
    {
        public static String StrConn = "Driver={SQL Server Native Client 10.0};Server=tcp:ahmadspaserver.database.windows.net,1433;Database=CruiseDB;Uid=ahmad123@ahmadspaserver;Pwd={Ahmadspa123@};Encrypt=yes;Connection Timeout=30;";
        public static OdbcConnection conn = new OdbcConnection(StrConn);
        public static OdbcCommand cmd = conn.CreateCommand();
        public static OdbcDataReader dr;

        //public static String StrConn = "Data Source=BRY\\SQLEXPRESS;Initial Catalog=CruiseDB;Integrated Security=True";
        //public static SqlConnection conn = new SqlConnection(StrConn);
        //public static SqlCommand cmd = conn.CreateCommand();
        //public static SqlDataReader dr;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            try {
                cmd.CommandText = "INSERT INTO Customer VALUES('"+txtFname.Text+"','"+txtLname.Text+"','"+dpoGender.Text+"','"+txtContact.Text+"','"+txtAddress.Text+"','"+txtEmail.Text+"','"+txtUsername.Text+"','"+txtPassword.Text+"')";
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Thank you for your registration";
                clean();
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
        private void clean()
        {
            txtFname.Text = " ";
            txtLname.Text = " ";
            dpoGender.SelectedIndex = 0;
            txtContact.Text = " ";
            txtAddress.Text = " ";
            txtEmail.Text = " ";
            txtUsername.Text = " ";
            txtPassword.Text = " ";
            txtConfirmPassword.Text = " ";
        }
    }
}