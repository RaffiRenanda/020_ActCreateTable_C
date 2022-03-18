using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace Create
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Create_table();
        }
        public void Create_table()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-4S8UKI2A\\RAFFIRENANDA;database=ProdiTI;User ID=sa;Password=12345678");
                con.Open();

                SqlCommand cm = new SqlCommand("Create table mahasiswaVS2 (NIM Char (12) not null primary key," + "Nama Varchar(50), Jenis_Kelamin Varchar(5))", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Create table berhasil");
                Console.ReadKey();
            }

            catch (Exception e)
            {
                Console.WriteLine("error", e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
