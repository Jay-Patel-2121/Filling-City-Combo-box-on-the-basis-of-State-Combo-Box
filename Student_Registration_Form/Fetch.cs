using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Student_Registration_Form
{
    class Fetch
    {
        public static SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\SEM 4\GUI Programming\Visual C# Projects\Student_Registration_Form\Student_Registration_Form\Student_Registration.mdf;Integrated Security=True");
        public static SqlCommand cmd;

        public DataTable city(int id)
        {
            cmd = new SqlCommand("Fetch_State_City");            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Con;
            cmd.Parameters.AddWithValue("@stid", id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public DataTable states()
        {
            cmd = new SqlCommand("fetch_states");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Con;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public bool isNameAvailable(string name)
        {
            cmd = new SqlCommand("isNameAvailable");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = Con;
            cmd.Parameters.AddWithValue("@name", name);
            Con.Open();
            int res = Convert.ToInt32(cmd.ExecuteScalar());
            Con.Close();
            if (res == 0)
                return true;
            else
                return false;
        }

    }
}
