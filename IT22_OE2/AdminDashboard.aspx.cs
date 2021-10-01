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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        string constring = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewAllRecords();
            }
        }

        protected void ViewAllRecords()
        {
            using (MySqlConnection mycon = new MySqlConnection(constring))
            {
                mycon.Open();
                MySqlCommand cmd = new MySqlCommand("viewallrecords", mycon);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows == true)
                {
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                }
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            ViewAllRecords();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            string ac_name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string ac_type = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string ac_pin = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            using (MySqlConnection mycon = new MySqlConnection(constring))
            {
                mycon.Open();
                MySqlCommand cmd = new MySqlCommand("update depositors_tbl set accountname='" + ac_name + "', accounttype='" + ac_type + "', pinnumber= '" + ac_pin + "' where accountnumber='" + id + "'", mycon);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    Response.Write("<script> alert('Account has been updated!') </script>");
                    GridView1.EditIndex = -1;
                    ViewAllRecords();
                }


            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ViewAllRecords();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            using (MySqlConnection mycon = new MySqlConnection(constring))
            {
                mycon.Open();
                MySqlCommand cmd = new MySqlCommand("delete from depositors_tbl where accountnumber='"+ id +"'",mycon);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    Response.Write("<script> alert('Account has been deleted!') </script>");
                    GridView1.EditIndex = -1;
                    ViewAllRecords();
                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string constring = "Server =localhost; Uid=root; password= ; persistSecurityInfo=True; database=mybank_db; SslMode=none";
            MySqlConnection mycon = new MySqlConnection(constring);
            MySqlDataAdapter ada = new MySqlDataAdapter();
            MySqlCommand com = new MySqlCommand();
            //DataTable view = new DataTable();
            DataSet view = new DataSet();


            mycon.Open();
            com.Connection = mycon;
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from depositors_tbl where accountname like '%" + txtSearch.Text + "%' ";
            ada.SelectCommand = com;
            ada.Fill(view);
            //view.Load(com.ExecuteReader());


            GridView1.DataSource = view;
            GridView1.DataBind();
            ada.Update(view);

            mycon.Close();
        }

        protected void txtSearch_TextChanged1(object sender, EventArgs e)
        {

        }
    }

}

