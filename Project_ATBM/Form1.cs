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
    public partial class Form1 : Form
    {
        string pwd, user_name, ho_ten;
        int ma_tv;
        public Form1(string username, string password, string hoten, int matv)
        {
            InitializeComponent();
            user_name = username;
            pwd = password;
            ho_ten = hoten;
            ma_tv = matv;
            // pass_word.Text = password;

            string connectionString = @"Data Source=(DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
    (CONNECT_DATA =
      (SERVER = DEDICATED)
      (SERVICE_NAME = pdbtest)
    )
  );User Id = " + username + ";password=" + password;

            //  MessageBox.Show(connectionString);

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy dữ liệu danh sách sản phẩm nhưng chỉ ở trong cùng store
            OracleCommand getRoleList = new OracleCommand();
            getRoleList.CommandText = "select * from hienadm.product";

            getRoleList.Connection = con;

            getRoleList.CommandType = CommandType.Text;

            OracleDataReader roleListData = getRoleList.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleListData);

            dataGridView1.DataSource = tableRoleList;

            //Lấy dữ liệu danh sách sản phẩm
            OracleCommand getCompetitorList = new OracleCommand();
            getCompetitorList.CommandText = "select * from hienadm.product";

            getCompetitorList.Connection = con;

            getCompetitorList.CommandType = CommandType.Text;

            OracleDataReader competitorListData = getCompetitorList.ExecuteReader();

            DataTable tableCompetitorList = new DataTable();

            tableCompetitorList.Load(competitorListData);


            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            con.Close();
        }

        private void dataGridView1_DataBindingComplete(object sender,
    DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoResizeColumns();
        }

     
    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

             
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
    (CONNECT_DATA =
      (SERVER = DEDICATED)
      (SERVICE_NAME = pdbtest)
    )
  );User Id = " + user_name + ";password=" + pwd;

            //  MessageBox.Show(connectionString);

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            //Lấy lại danh sách sản phẩm
            OracleCommand getRoleList = new OracleCommand();
            getRoleList.CommandText = "select * from hienadm.product";

            getRoleList.Connection = con;

            getRoleList.CommandType = CommandType.Text;

            OracleDataReader roleListData = getRoleList.ExecuteReader();

            DataTable tableRoleList = new DataTable();

            tableRoleList.Load(roleListData);

            dataGridView1.DataSource = tableRoleList;

            con.Close();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
