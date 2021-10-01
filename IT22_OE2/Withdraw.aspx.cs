using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace IT22_OE2
{
    public partial class Withdraw : System.Web.UI.Page
    {
        //Connection String
        string constring = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        String TransactionType = "Debit";
        String ac_number;
        String account_name, account_number, balance, bal_format;

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            Deposit_Transaction();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ac_number = "" + Session["accountnumber"];
            lblAccountNumber.Text = "" + Session["accountnumber"];
            lblAccountName.Text = "" + Session["accountname"];
            lblBalance.Text = "" + Convert.ToDecimal(Session["balance"]).ToString("P ###,###.00");
            lblUser.Text = "" + Session["accountname"];
            myAccount();
        }
        protected void Deposit_Transaction()
        {
            MySqlConnection mycon = new MySqlConnection(constring);
            try
            {
                MySqlParameter[] x = new MySqlParameter[5];

                x[0] = new MySqlParameter("p_AccountNumber", MySqlDbType.Int32);
                x[0].Value = lblAccountNumber.Text;

                x[1] = new MySqlParameter("p_Amount", MySqlDbType.Double);
                x[1].Value = Convert.ToDecimal(txtWithdraw.Text);

                x[2] = new MySqlParameter("p_TrType", MySqlDbType.VarChar);
                x[2].Value = TransactionType.ToString();

                x[3] = new MySqlParameter("p_Date", MySqlDbType.Date);
                x[3].Value = DateTime.Now.ToString("yyyy-MM-dd");

                x[4] = new MySqlParameter("p_Time", MySqlDbType.Time);
                String currentTime = DateTime.Now.ToString("HH:mm:ss");
                TimeSpan orderTime = TimeSpan.Parse(currentTime);
                x[4].Value = orderTime;

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = mycon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "transaction_wid";
                cmd.Parameters.AddRange(x);
                mycon.Open();
                cmd.ExecuteNonQuery();
                mycon.Close();
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('" + e.Message + "') </script>");
            }
            Response.Write("<script>alert('Withdraw Successful...') </script>");
            myAccount();
        } //end of deposit transaction
        protected void myAccount()
        {
            MySqlConnection mycon = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand();
            cmd = new MySqlCommand("Select * from depositors_tbl where accountnumber ='" + ac_number + "'", mycon);
            mycon.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            mycon.Close();
            int count = ds.Tables[0].Rows.Count;

            if (count == 1)
            {
                mycon.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    account_name = read["accountname"].ToString();
                    account_number = read["accountnumber"].ToString();
                    balance = read["balance"].ToString();
                    bal_format = Convert.ToDecimal(balance).ToString("P ###,###.00");
                    lblAccountNumber.Text = account_number;
                    lblAccountName.Text = account_name;
                    lblBalance.Text = bal_format;
                }
            }
        }
    }
}