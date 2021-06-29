using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace MyApp
{
    class ClassCon
    {

        public SqlConnection cn;
        public string strcon = @"Data Source=DESKTOP-MPTIJRG\SQLEXPRESS;Initial Catalog=testdb;User ID=sa;PWD=12345";
        public SqlCommand cmd;
        public DataTable dt;
        public SqlDataAdapter da;


        public void Condb()
        {
            cn = new SqlConnection(strcon);
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Open();
        }
    }
}
