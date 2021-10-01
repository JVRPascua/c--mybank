using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace IT22_OE2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string account_name, account_number, balance, user;
            user = txtUsername.Text.Trim();
            string con = "Server =localhost; Uid=root; password= ; persistSecurityInfo=True; database=mybank_db; SslMode=none";
            MySqlConnection mycon = new MySqlConnection(con);
            MySqlCommand com = null;

            try { 
            if (user == "admin")
            {

                com = new MySqlCommand("Select * from depositors_tbl where accountnumber =@username and pinnumber=@password", mycon);
                com.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                com.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                mycon.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                mycon.Close();
                int count = ds.Tables[0].Rows.Count;

                if (count == 1)
                {
                    mycon.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {
                        account_name = read["accountname"].ToString();
                        account_number = read["accountnumber"].ToString();
                        
                        Session["accountname"] = account_name;
                        Session["accountnumber"] = account_number;
                     

                        }
                    Response.Redirect("AdminDashboard.aspx");
                }
                //else
              //  {
                    //Response.Write("<script>alert('Error Login') </script>");

               // }
            }

            else if (user != "admin")
            {


                com = new MySqlCommand("Select * from depositors_tbl where accountnumber =@username and pinnumber=@password", mycon);
                com.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                com.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                mycon.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                mycon.Close();
                int count = ds.Tables[0].Rows.Count;

                if (count == 1)
                {
                    mycon.Open();
                    MySqlDataReader read = com.ExecuteReader();
                    if (read.Read())
                    {
                        account_name = read["accountname"].ToString();
                        account_number = read["accountnumber"].ToString();
                            balance = read["initialdeposit"].ToString();
                            Session["accountname"] = account_name;
                        Session["accountnumber"] = account_number;
                            Session["initialdeposit"] = balance;

                        }
                    Response.Redirect("UserAccounts.aspx");
                }
               // else
                //{
                    //Response.Write("<script>alert('Error Login') </script>");

               // }
            }

        }
        catch (Exception ex)
            {
            Response.Write("<script>alert('" + ex.Message + "') </script>");
            }
            }

         
        }
    }
