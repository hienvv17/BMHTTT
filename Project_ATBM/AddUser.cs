using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Project_BMHTTT
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();

            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = pdbtest)
            )
            );User Id = dbadmin ; password=pass;  DBA Privilege=SYSDBA;";

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand getStoreId = new OracleCommand();

            getStoreId.CommandText = "select id from  hienadm.store";

            getStoreId.Connection = con;

            getStoreId.CommandType = CommandType.Text;

            OracleDataReader storeList = getStoreId.ExecuteReader();

            while (storeList.Read())
            {
                textBox1.Items.Add(storeList["id"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = orcl)
            )
            );User Id = dbadmin ; password=pass";

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from all_users where username = :user_name";

            cmd.Parameters.Add(":user_name", txtusername.Text.Trim().ToUpper()); ;

            cmd.Connection = con;

            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            // Đổ danh sách username
            

            DataTable dt = new DataTable();

            dt.Load(dr);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Username đã tồn tại!");
            }
            else
            {
                OracleCommand script = new OracleCommand();

                script.CommandText = "alter session set \"_ORACLE_SCRIPT\"=true";

                script.Connection = con;

                script.CommandType = CommandType.Text;
                script.ExecuteNonQuery();

                OracleCommand commandCheckToTruong = new OracleCommand();
                commandCheckToTruong.Connection = con;

                commandCheckToTruong.CommandText = "pr_create_user";
                commandCheckToTruong.CommandType = CommandType.StoredProcedure;

                commandCheckToTruong.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2)).Value = txtusername.Text.Trim();// pwd.Text.Trim();
                commandCheckToTruong.Parameters.Add(new OracleParameter("pwd", OracleDbType.Varchar2)).Value = txtpassword.Text.Trim();// pwd.Text.Trim();
                try
                {
                    commandCheckToTruong.ExecuteNonQuery();
                    MessageBox.Show("Thêm user mới thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

   


    }
}
