using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreDb
{
    class Program
    {
        SqlConnection con = new SqlConnection("data source=DESKTOP-4L35IVI;database=BooksDb;Integrated security = true;");
        SqlCommand cmd;
        public void AllBooks()
        {
            cmd = new SqlCommand("select * from tbl_Books", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("Book Id : " + rdr[0]);
                Console.WriteLine("Title : " + rdr[1]);
                Console.WriteLine("Price : " + rdr[3].ToString());
                Console.WriteLine("-------------------------------------");
            }
            con.Close();
            Console.ReadLine();
        }
        public void Insert_BookSP()
        {
            Console.WriteLine("Please enter the BookID you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the AuthorID");
            int aid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Price");
            float price = float.Parse(Console.ReadLine());

            cmd = new SqlCommand("sp_InsBook", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            //SqlParameter p1 = new SqlParameter();
            //p1.ParameterName = "@Title";
            //p1.SqlDbType = SqlDbType.VarChar;
            //p1.Value = title;
            //cmd.Parameters.Add(p1);
            //SqlParameter p2 = new SqlParameter();
            //p2.ParameterName = "@AuthorID";
            //p2.SqlDbType = SqlDbType.Int;
            //p2.Value = aid;
            //cmd.Parameters.Add(p2);
            //SqlParameter p3 = new SqlParameter();
            //p3.ParameterName = "@Price";
            //p3.SqlDbType = SqlDbType.Money;
            //p3.Value = price;
            //cmd.Parameters.Add(p3);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateBooks()
        {
            Console.WriteLine("Please enter the BookID you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the AuthorID");
            int aid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Price");
            float price = float.Parse(Console.ReadLine());
            cmd = new SqlCommand("sp_UpdBook", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.Int).Value = id;
            cmd.Parameters.AddWithValue("@Title", SqlDbType.NVarChar).Value = title;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = aid;
            cmd.Parameters.AddWithValue("@Price", SqlDbType.Money).Value = price;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteBooks()
        {
            Console.WriteLine("Please enter the BookID you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("sp_DelBook", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookID", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AllAuthors()
        {
            cmd = new SqlCommand("select * from tbl_author", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine("Author Id : " + rdr[0]);
                Console.WriteLine("Author's Name : " + rdr[1]);
                Console.WriteLine("-------------------------------------");
            }
            con.Close();
            Console.ReadLine();
        }
        public void Insert_Author()
        {
            Console.WriteLine("Enter Author Name");
            string authorname = Console.ReadLine();
            cmd = new SqlCommand("sp_InsAuthor", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = authorname;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateAuthor()
        {
            Console.WriteLine("Please enter the AuthorID you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Author's Name");
            string authorname = Console.ReadLine();
            cmd = new SqlCommand("sp_UpdAuthor", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = id;
            cmd.Parameters.AddWithValue("@AuthorName", SqlDbType.NVarChar).Value = authorname;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteAuthor()
        {
            Console.WriteLine("Please enter the AuthorID you want to update");
            int id = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("sp_DelAuthor", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AuthorID", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void Display()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Choose what you wanna do");
                Console.WriteLine("1. Print Books");
                Console.WriteLine("2. Insert a Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Print Authors");
                Console.WriteLine("6. Insert Author");
                Console.WriteLine("7. Edit Author");
                Console.WriteLine("8. Delete Author");
                Console.WriteLine("9. Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AllBooks();
                        break;
                    case 2:
                        Insert_BookSP();
                        break;
                    case 3:
                        UpdateBooks();
                        break;
                    case 4:
                        DeleteBooks();
                        break;
                    case 5:
                        AllAuthors();
                        break;
                    case 6:
                        Insert_Author();
                        break;
                    case 7:
                        UpdateAuthor();
                        break;
                    case 8:
                        DeleteAuthor();
                        break;
                    default:
                        Console.WriteLine("Please enter the valid choice");
                        break;

                }

            } while (choice != 9);
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.Display();

        }
    }
}
