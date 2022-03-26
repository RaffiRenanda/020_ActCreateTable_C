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

            new Program().InsertData();
        }
        public void Create_table()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=LAPTOP-4S8UKI2A\\RAFFIRENANDA;database=Exercise2PABD;User ID=sa;Password=12345678");
                con.Open();
                SqlCommand cm1 = new SqlCommand("Create table Pembeli (Nama_Pembeli Varchar (30) not null primary key," + "Alamat Varchar(40), No_Hp Char(5))", con);
                cm1.ExecuteNonQuery();
                SqlCommand cm = new SqlCommand("Create table Cake (Id_Kue Integer not null primary key," + "Nama_Kue Varchar(30), Jumlah_Kue Varchar (10), Nama_Pembeli Varchar (30) not null  foreign key references Pembeli (Nama_Pembeli))", con);
                cm.ExecuteNonQuery();

                SqlCommand cm3 = new SqlCommand("Create table Transaksi (Nama_Kue Varchar (30) not null primary key," + "Nama_Pembeli Varchar (30) foreign key references Pembeli (Nama_Pembeli), Jumlah_Beli Varchar(10), Harga_Satuan Money, Tanggal_Transaksi Date)", con);
                cm3.ExecuteNonQuery();
                
                SqlCommand cm2 = new SqlCommand("Create table Penjual (Nama_Penjual Varchar (32) not null primary key," + "No_Hp Char(11), Alamat_Toko Varchar(40), Nama_Kue Varchar (30), Harga_Satuan Money, Id_Kue Integer not null foreign key references Cake (Id_Kue))", con);
                cm2.ExecuteNonQuery();
                

                Console.WriteLine("Create table berhasil");
                Console.WriteLine("Coba push");
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

        public void InsertData()
        {
            SqlConnection conne = null;
            try
            {
                conne = new SqlConnection("data source=LAPTOP-4S8UKI2A\\RAFFIRENANDA;database=Exercise2PABD;User ID=sa;Password=12345678");
                conne.Open();

                SqlCommand cm = new SqlCommand("insert into Pembeli (Nama_Pembeli, Alamat, No_Hp) values ('Siti' , 'Bali' , '08182')"+
                    "insert into Pembeli (Nama_Pembeli, Alamat, No_Hp) values ('Sujio' , 'Semarang' , '08992')"+
                    "insert into Pembeli (Nama_Pembeli, Alamat, No_Hp) values ('Paijo' , 'Solo' , '08289')"+
                    "insert into Pembeli (Nama_Pembeli, Alamat, No_Hp) values ('Puji' , 'Jogja' , '08392')"+
                    "insert into Pembeli (Nama_Pembeli, Alamat, No_Hp) values ('Suroto' , 'Purworejo' , '08182')"+

                    "insert into Cake (Id_Kue, Nama_Kue, Jumlah_Kue, Nama_Pembeli) values ('223', 'Nastar', '100' , 'siti')"+
                    "insert into Cake (Id_Kue, Nama_Kue, Jumlah_Kue, Nama_Pembeli) values ('224', 'Bolu Kukus', '50' , 'Sujio')"+
                    "insert into Cake (Id_Kue, Nama_Kue, Jumlah_Kue, Nama_Pembeli) values ('225', 'Semprit', '100' , 'Paijo')"+
                    "insert into Cake (Id_Kue, Nama_Kue, Jumlah_Kue, Nama_Pembeli) values ('226', 'Brownies', '100' , 'Puji')"+
                    "insert into Cake (Id_Kue, Nama_Kue, Jumlah_Kue, Nama_Pembeli) values ('227', 'Shiffon', '50' , 'Suroto')"+

                    "insert into Penjual(Nama_Penjual,No_Hp,Alamat_Toko,Nama_Kue,Harga_Satuan,Id_Kue) values ('mila','08183467854','Wates','Nastar','50000','223')"+
                    "insert into Penjual(Nama_Penjual,No_Hp,Alamat_Toko,Nama_Kue,Harga_Satuan,Id_Kue) values ('Aziz','08183467854','Wates','Bolu Kukus','25000','224')"+
                    "insert into Penjual(Nama_Penjual,No_Hp,Alamat_Toko,Nama_Kue,Harga_Satuan,Id_Kue) values ('Raden','08183467854','Wates','Semprit','27000','225')"+
                    "insert into Penjual(Nama_Penjual,No_Hp,Alamat_Toko,Nama_Kue,Harga_Satuan,Id_Kue) values ('Nisa','08183467854','Wates','Brownies','30000','226')"+
                    "insert into Penjual(Nama_Penjual,No_Hp,Alamat_Toko,Nama_Kue,Harga_Satuan,Id_Kue) values ('Eny','08183467854','Wates','Shiffon','32000','227')" + 

                    "insert into Transaksi(Nama_Kue,Nama_Pembeli,Jumlah_Beli,Harga_Satuan,Tanggal_Transaksi) values ('Nastar','siti','2','50000','3-26-2022')" + 
                    "insert into Transaksi(Nama_Kue,Nama_Pembeli,Jumlah_Beli,Harga_Satuan,Tanggal_Transaksi) values ('Bolu Kukus','Sujio','4','25000','3-25-2022')"+
                    "insert into Transaksi(Nama_Kue,Nama_Pembeli,Jumlah_Beli,Harga_Satuan,Tanggal_Transaksi) values ('Semprit','Paijo','10','27000','3-24-2022')"+
                    "insert into Transaksi(Nama_Kue,Nama_Pembeli,Jumlah_Beli,Harga_Satuan,Tanggal_Transaksi) values ('Brownies','Puji','2','30000','3-26-2022')"+
                    "insert into Transaksi(Nama_Kue,Nama_Pembeli,Jumlah_Beli,Harga_Satuan,Tanggal_Transaksi) values ('Shiffon','Suroto','2','32000','3-26-2022')"
                    , conne);
                cm.ExecuteNonQuery();

                Console.WriteLine("Sukses memasukkan data");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Gagal menambah data" + e);
                Console.ReadKey();
            }
            finally
            {
                conne.Close();
            }
        }
    }
}
