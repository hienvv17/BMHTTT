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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void login_btn_Click(object sender, EventArgs e)
        {
         
            OracleConnection con = new OracleConnection();


            OracleCommand command = new OracleCommand();
            command.Connection = con;

            command.Parameters.Add(new OracleParameter("para_username", OracleDbType.Varchar2, 32767)).Value = user_name.Text.Trim().ToUpper();
            command.Parameters.Add(new OracleParameter("para_pass_word", OracleDbType.Varchar2, 32767)).Value = pwd.Text.Trim();
            string user1 = user_name.Text.Trim().ToUpper();
            string pwd1 = pwd.Text.Trim();
            
            string con2 = @"Data Source= localhost:1521/pdbtest ;User Id= " + user1 + " ;Password= " + pwd1 + " ";
            con.ConnectionString= con2;

            command.Parameters.Add("para_hoten", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;

            command.Parameters.Add("para_role", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                // command.ExecuteNonQuery

                string hoten = "hienadm";
                string role = "pdb_dba";

                OracleCommand getRoleList = new OracleCommand();
                getRoleList.CommandText = "select GRANTED_ROLE from USER_ROLE_PRIVS where username = :user_name";


                getRoleList.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2)).Value = user_name.Text.Trim().ToUpper();

                getRoleList.Connection = con;

                getRoleList.CommandType = CommandType.Text;

                OracleDataReader dr = getRoleList.ExecuteReader();
                while(dr.Read())
                {

                    string name_role = dr.GetString(dr.GetOrdinal("GRANTED_ROLE"));
                    if (name_role == "PDB_DBA")
                    { role = name_role; 
                        break; }
                }

                DataTable dt = new DataTable();

                dt.Load(dr);

                //  int ma_tv = Int32.Parse(dt.Rows[0]["owner_member"].ToString());
                int ma_tv = 1;

                if (role == "PDB_DBA")
                {
                   // MessageBox.Show("The role of this user is: " + role);
                    Form1 form = new Form1(user_name.Text.Trim().ToUpper(), pwd.Text.Trim(), hoten, ma_tv);
                    form.Show();
                    con.Close();
                }

             

                else
                {
                    Form1 form = new Form1(user_name.Text.Trim().ToUpper(), pwd.Text.Trim(), hoten, ma_tv);
                    form.Show();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Invalid username or password!");
            }
        }
    }
}
    