using BookFactorys.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFactorys
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //page load focus on textbox username
            txtUsername.Focus();
            lblMsg.Text = string.Empty;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            try
            {
                LoginEntity loginDetails = ChcekIsUserValid();
                if(loginDetails != null)
                {
                    Response.Redirect("~/BookDetails.aspx?isAdmin='" + loginDetails.isAdmin + "'");
                }
                else
                {
                    lblMsg.Text = "Invaild Username/Password";
                }
            }
            catch (Exception ex)
            {
                //display the error message to user
                lblMsg.Text = ex.Message;
            }
        }

        /// <summary>
        /// Thsi method is used to cehck username and password is right or wrong.
        /// </summary>
        /// <returns></returns>
        public LoginEntity ChcekIsUserValid()
        {

            try
            {


                LoginEntity loginEntity = null;
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.AppSettings.Get("ConnectionString")))
                {
                    using (SqlCommand command = conn.CreateCommand())
                    {

                        conn.Open();
                        command.CommandType = CommandType.Text;
                        command.Connection = conn;
                        string strQuery = "select UserId,UserName,IsAdmin from login where username ='" + txtUsername.Text + "'  and password='" + txtPassword.Text + "'";
                        command.CommandText = strQuery;
                        IDataReader reader = null;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            loginEntity = new LoginEntity();
                            loginEntity.UserId = Convert.ToInt32(reader[0]);
                            loginEntity.Username = Convert.ToString(reader[1]);
                            loginEntity.isAdmin = Convert.ToBoolean(reader[2]);
                        }
                    }
                }
                return loginEntity;
            }
            catch (Exception)
            {
                throw ;
            }
        }
    }
}