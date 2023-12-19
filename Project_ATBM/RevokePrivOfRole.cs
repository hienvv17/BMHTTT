using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace Project_BMHTTT
{
    public partial class RevokePrivOfRole : Form
    {
        string connectionString = @"Data Source= localhost:1521/pdbtest ;User Id= dbadmin ;Password= pass; DBA Privilege=SYSDBA;";
        public RevokePrivOfRole()
        {
            InitializeComponent();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            // Đổ danh sách role
            OracleCommand getUserList3 = new OracleCommand();

            getUserList3.CommandText = "select distinct role from dba_roles order by role asc";

            getUserList3.Connection = con;

            getUserList3.CommandType = CommandType.Text;

            OracleDataReader userListData2 = getUserList3.ExecuteReader();

            while (userListData2.Read())
            {
                RoleList.Items.Add(userListData2[0]);
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand commandCheckToTruong = new OracleCommand();
            commandCheckToTruong.Connection = con;

            commandCheckToTruong.CommandText = "pr_revoke_pri_from_user_or_role";
            commandCheckToTruong.CommandType = CommandType.StoredProcedure;

            commandCheckToTruong.Parameters.Add(new OracleParameter("pi_user_or_role", OracleDbType.NVarchar2)).Value = RoleList.Text.Trim().ToUpper();// pwd.Text.Trim();
            commandCheckToTruong.Parameters.Add(new OracleParameter("pi_privilege", OracleDbType.NVarchar2)).Value = PrivesList.Text.Trim().ToUpper();// pwd.Text.Trim();
            try
            {
                commandCheckToTruong.ExecuteNonQuery();
                MessageBox.Show("Đã thu hồi thành công quyền " + PrivesList.Text.Trim() + " của role " + RoleList.Text.Trim());
                PrivesList.Text = "";
                PrivesList.Items.Remove(PrivesList.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //MessageBox.Show("Đã xảy ra lỗi khi thực hiện xóa user!");
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrivesList.Items.Clear();

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            // Đổ danh sách prilves
            OracleCommand getUserList4 = new OracleCommand();

            getUserList4.CommandText = "select privilege from dba_sys_privs where grantee =: grantee_name";

            getUserList4.Parameters.Add(":grantee_name", RoleList.Text.Trim().ToUpper()); ;

            getUserList4.Connection = con;

            getUserList4.CommandType = CommandType.Text;

            OracleDataReader userListData3 = getUserList4.ExecuteReader();

            while (userListData3.Read())
            {
                PrivesList.Items.Add(userListData3[0]);
            }

            con.Close();
        }

        private void PrivesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RoleList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
