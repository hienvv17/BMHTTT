﻿using System;
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
    public partial class QLyUser : Form
    {
       
        string connectionString = @"Data Source= localhost:1521/pdbtest ;User Id= dbadmin ;Password= pass; DBA Privilege=SYSDBA;"; 
        public QLyUser()
        {
            InitializeComponent();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu cho table danh sách các user trong hệ thống, ở mức user not system
            OracleCommand getRoleList = new OracleCommand();

              getRoleList.CommandText = "select all_users.user_id, all_users.username, all_users.created, " +
                "dba_users.account_status, dba_users.lock_date, dba_users.default_tablespace" +
              " from all_users inner join dba_users on all_users.user_id = dba_users.user_id ";

          //  getRoleList.CommandText = "select all_users.user_id  from all_users ";

            getRoleList.Connection = con;

            getRoleList.CommandType = CommandType.Text;

            OracleDataReader roleListData = getRoleList.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleListData);

            dataGridView1.DataSource = tableRoleList;

            //Lấy dữ liệu cho table danh sách các privileges của các user trong hệ thống

            OracleCommand getCompetitorList = new OracleCommand();
            getCompetitorList.CommandText = "select al.username, db.privilege, db.admin_option, db.common from dba_sys_privs db, all_users al where db.grantee = al.username";

            getCompetitorList.Connection = con;

            getCompetitorList.CommandType = CommandType.Text;

            OracleDataReader competitorListData = getCompetitorList.ExecuteReader();

            DataTable tableCompetitorList = new DataTable();

            tableCompetitorList.Load(competitorListData);

            dataGridView2.DataSource = tableCompetitorList;

            //Lấy dữ liệu cho table danh sách role được gán cho các user trong hệ thống

            OracleCommand getCompetitorList1 = new OracleCommand();
            //getCompetitorList1.CommandText = "select db.grantee, db.privilege, db.admin_option, db.common from dba_sys_privs db, all_users al where db.grantee = al.us";
            getCompetitorList1.CommandText = "SELECT * FROM DBA_ROLE_PRIVS";

            getCompetitorList1.Connection = con;

            getCompetitorList1.CommandType = CommandType.Text;

            OracleDataReader competitorListData1 = getCompetitorList1.ExecuteReader();

            DataTable tableCompetitorList1 = new DataTable();

            tableCompetitorList1.Load(competitorListData1);

            dataGridView3.DataSource = tableCompetitorList1;

            // Đổ danh sách username
            OracleCommand getUserList3 = new OracleCommand();

            getUserList3.CommandText = "select username from all_users";

            getUserList3.Connection = con;

            getUserList3.CommandType = CommandType.Text;

            OracleDataReader userListData2 = getUserList3.ExecuteReader();

            while (userListData2.Read())
            {
                usernameListFind.Items.Add(userListData2[0]);
                UsernameListDel.Items.Add(userListData2[0]);
                findUsernameOfPriv.Items.Add(userListData2[0]);
            }

            // Đổ danh sách username chưa bị lock
            OracleCommand getUserList4 = new OracleCommand();

            getUserList4.CommandText = "select username from dba_users where account_status = 'OPEN'";

            getUserList4.Connection = con;

            getUserList4.CommandType = CommandType.Text;

            OracleDataReader userListData3 = getUserList4.ExecuteReader();

            while (userListData3.Read())
            {
                usernameFindLock.Items.Add(userListData3[0]);
            }
            con.Close();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand getRoleList = new OracleCommand();

             getRoleList.CommandText = "select all_users.user_id, all_users.username, all_users.created, " +
                "dba_users.account_status, dba_users.lock_date, dba_users.default_tablespace" +
                " from all_users inner join dba_users on all_users.user_id = dba_users.user_id ";
          

            getRoleList.Connection = con;

            getRoleList.CommandType = CommandType.Text;

            OracleDataReader roleListData = getRoleList.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleListData);

            dataGridView1.DataSource = tableRoleList;

            //cập nhật combobox username
            OracleCommand getUserList3 = new OracleCommand();

            getUserList3.CommandText = "select username from all_users";

            getUserList3.Connection = con;

            getUserList3.CommandType = CommandType.Text;

            OracleDataReader userListData2 = getUserList3.ExecuteReader();

            while (userListData2.Read())
            {
                usernameListFind.Items.Add(userListData2[0]);
                UsernameListDel.Items.Add(userListData2[0]);
                findUsernameOfPriv.Items.Add(userListData2[0]);
            }

            // Đổ danh sách username chưa bị lock
            OracleCommand getUserList4 = new OracleCommand();

            getUserList4.CommandText = "select username from dba_users where account_status = 'OPEN'";

            getUserList4.Connection = con;

            getUserList4.CommandType = CommandType.Text;

            OracleDataReader userListData3 = getUserList4.ExecuteReader();

            while (userListData3.Read())
            {
                usernameFindLock.Items.Add(userListData3[0]);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand getCompetitorList = new OracleCommand();
            getCompetitorList.CommandText = "select * from dba_sys_privs";

            getCompetitorList.Connection = con;

            getCompetitorList.CommandType = CommandType.Text;

            OracleDataReader competitorListData = getCompetitorList.ExecuteReader();

            DataTable tableCompetitorList = new DataTable();

            tableCompetitorList.Load(competitorListData);

            dataGridView2.DataSource = tableCompetitorList;

            con.Close();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            AddUser form = new AddUser();
            form.Show();
        }
        private void btn_grantRole_Click(object sender, EventArgs e)
        {

        }

        private void btn_DelUser_Click_1(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand commandCheckToTruong = new OracleCommand();
            commandCheckToTruong.Connection = con;

            commandCheckToTruong.CommandText = "pr_drop_user";
            commandCheckToTruong.CommandType = CommandType.StoredProcedure;

            commandCheckToTruong.Parameters.Add(new OracleParameter("pi_username", OracleDbType.NVarchar2)).Value = UsernameListDel.Text.Trim();// pwd.Text.Trim();
            try
            {
              
                commandCheckToTruong.ExecuteNonQuery();

                MessageBox.Show("Đã xóa user " + UsernameListDel.Text.Trim() + " thành công!");

                //cập nhật combobox username
                OracleCommand getUserList3 = new OracleCommand();

                getUserList3.CommandText = "select username from all_users";

                getUserList3.Connection = con;

                getUserList3.CommandType = CommandType.Text;

                OracleDataReader userListData2 = getUserList3.ExecuteReader();

                while (userListData2.Read())
                {
                    usernameListFind.Items.Add(userListData2[0]);
                    UsernameListDel.Items.Add(userListData2[0]);
                    findUsernameOfPriv.Items.Add(userListData2[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }

        private void btn_findUsername_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu cho table danh sách các user trong hệ thống
            OracleCommand getRoleList = new OracleCommand();

            getRoleList.CommandText = "select all_users.user_id, all_users.username, all_users.created, " +
                "dba_users.account_status, dba_users.lock_date, dba_users.default_tablespace" +
                " from all_users inner join dba_users on all_users.user_id = dba_users.user_id  where all_users.username = :user_name";

            getRoleList.Parameters.Add(":user_name", usernameListFind.Text.Trim().ToUpper()); ;

            getRoleList.Connection = con;

            getRoleList.CommandType = CommandType.Text;

            OracleDataReader roleListData = getRoleList.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleListData);

            dataGridView1.DataSource = tableRoleList;

            con.Close();
        }

        private void btn_grantRole_Click_1(object sender, EventArgs e)
        {
            GrantRoleToUser form = new GrantRoleToUser();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RevokeRoleFromUser form = new RevokeRoleFromUser();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand getRoleList = new OracleCommand();

            getRoleList.CommandText = "SELECT * FROM DBA_ROLE_PRIVS";

            getRoleList.Connection = con;

            getRoleList.CommandType = CommandType.Text;

            OracleDataReader roleListData = getRoleList.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleListData);

            dataGridView3.DataSource = tableRoleList;

            con.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            GrantPrivToUser form = new GrantPrivToUser();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RevokePrivOfUser form = new RevokePrivOfUser();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand getCompetitorList = new OracleCommand();
            getCompetitorList.CommandText = "select * from dba_sys_privs where grantee = :user_name";

            getCompetitorList.Parameters.Add(":user_name", findUsernameOfPriv.Text.Trim().ToUpper()); ;

            getCompetitorList.Connection = con;

            getCompetitorList.CommandType = CommandType.Text;

            OracleDataReader competitorListData = getCompetitorList.ExecuteReader();

            DataTable tableCompetitorList = new DataTable();

            tableCompetitorList.Load(competitorListData);

            dataGridView2.DataSource = tableCompetitorList;

            con.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            UnlockUser form = new UnlockUser();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            OracleCommand commandCheckToTruong = new OracleCommand();
            commandCheckToTruong.Connection = con;

            commandCheckToTruong.CommandText = "pr_lock_user";
            commandCheckToTruong.CommandType = CommandType.StoredProcedure;

            commandCheckToTruong.Parameters.Add(new OracleParameter("pi_username", OracleDbType.NVarchar2)).Value = usernameFindLock.Text.Trim();
            try
            {
                OracleCommand script = new OracleCommand();

                script.CommandText = "alter session set \"_ORACLE_SCRIPT\"=true";

                script.Connection = con;

                script.CommandType = CommandType.Text;
                script.ExecuteNonQuery();

                commandCheckToTruong.ExecuteNonQuery();
                MessageBox.Show("Đã lock user " + usernameFindLock.Text.Trim() + " thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
