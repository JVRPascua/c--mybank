using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace IT22_OE2
{
    public partial class Registration : System.Web.UI.Page
    {

        void clear()
        {
            txtAccountNumber.Text = "";
            txtAccountName.Text = "";
            txtAccountType.Text = "";
            txtBranch.Text = "";
            txtAddress.Text = "";
            txtContactNumber.Text = "";
            txtCurrency.Text = "";
            txtInitialDeposit.Text = "";
            txtPin.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string account_no = Request.Form.Get("txtAccountNumber");
            string account_na = Request.Form.Get("txtAccountName");
            string account_ty = Request.Form.Get("txtAccountType");
            string account_br = Request.Form.Get("txtBranch");
            string account_ad = Request.Form.Get("txtAddress");
            string account_co = Request.Form.Get("txtContactNumber");
            string account_cu = Request.Form.Get("txtCurrency");
            string account_in = Request.Form.Get("txtInitialDeposit");
            string account_pi = Request.Form.Get("txtPin");

            string con = "Server =localhost; Uid=root; password= ; persistSecurityInfo=True; database=mybank_db; SslMode=none";
            MySqlConnection mycon = new MySqlConnection(con);
            MySqlCommand com = null;

            try
            {
                com = new MySqlCommand("insert into depositors_tbl(accountnumber,accountname,accounttype,branch,address,contactnumber,currency,initialdeposit,pinnumber) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)", mycon);
                com.Parameters.AddWithValue("@a1", account_no);
                com.Parameters.AddWithValue("@a2", account_na);
                com.Parameters.AddWithValue("@a3", account_ty);
                com.Parameters.AddWithValue("@a4", account_br);
                com.Parameters.AddWithValue("@a5", account_ad);
                com.Parameters.AddWithValue("@a6", account_co);
                com.Parameters.AddWithValue("@a7", account_cu);
                com.Parameters.AddWithValue("@a8", account_in);
                com.Parameters.AddWithValue("@a9", account_pi);
                mycon.Open();
                com.ExecuteNonQuery();
                mycon.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "') </script>");
                mycon.Close();
            }
            Response.Write("<script>alert('Bank Account successfully created.....') </script>");
            clear();
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            string con = "Server =localhost; Uid=root; password= ; persistSecurityInfo=True; database=mybank_db; SslMode=none";
            MySqlConnection mycon = new MySqlConnection(con);
            DataTable view = new DataTable();
            MySqlCommand com = null;
            try {
                com = new MySqlCommand("select * from depositors_tbl",mycon);
                mycon.Open();
                view.Load(com.ExecuteReader());
                mycon.Close();
            }
            catch (Exception ex) {
                Response.Write("<script>alert('" + ex.Message + "') </script>");
                mycon.Close();
            }
            GridView1.DataSource = view;
            GridView1.DataBind();
        }

        
    }
}