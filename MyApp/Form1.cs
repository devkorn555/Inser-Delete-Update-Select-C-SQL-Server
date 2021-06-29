using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace MyApp
{
    public partial class Form1 : Form
    {

        private ClassCon c = new ClassCon();
        public Form1()
        {
            InitializeComponent();
        }



        #region "เพิ่มข้อมูล"

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                c = new ClassCon();
                c.Condb();
                string txt = "INSERT INTO tbmember(Fid,Fname,Flname,Ftel) VALUES('" + tbid.Text + "','" + tbname.Text + "','" + tblname.Text + "','" + tbtel.Text + "')";
                c.cmd = new SqlCommand(txt, c.cn);
                c.cmd.ExecuteNonQuery();
                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Reload เมื่อเพิ่มข้อมูล
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("ข้อมูลซ้ำ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

        #region "ดึงข้อมูลจากฐานข้อมูล"
        private void LoadData()
        {
            c = new ClassCon();
            c.Condb();
            string txt = @"SELECT * FROM tbmember";
            c.da = new SqlDataAdapter(txt, c.cn);
            c.dt = new DataTable();
            c.da.Fill(c.dt);

            dtg.DataSource = c.dt;

        }
        #endregion

        #region "ลบข้อมูล"

        private void DelData()
        {
            c.Condb();

            if (MessageBox.Show("ยืนยันลบข้อมูล", "แจ้งเตือน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string txt = @"DELETE FROM tbmember WHERE Fid='" + tbid.Text + "'";
                c.cmd = new SqlCommand(txt, c.cn);
                c.cmd.ExecuteNonQuery();
                LoadData();
            }
            else
            {
                return;
            }


        }

        #endregion

        #region "แก้ไขข้อมูล"

        private void EditData()
        {
            c = new ClassCon();
            c.Condb();

            string txt = @"UPDATE tbmember SET Fname='" + tbname.Text + "',Flname='" + tblname.Text + "',Ftel='" + tbtel.Text + "' WHERE Fid='" + tbid.Text + "'";
            c.cmd = new SqlCommand(txt, c.cn);
            c.cmd.ExecuteNonQuery();

            LoadData();
        }
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DelData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditData();
        }
    }
}
