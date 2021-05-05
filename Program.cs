using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            //connect to the sql server and security enable and use pubs to use queries
            conString = @"server=DESKTOP-4L35IVI;Integrated security= true; Initial catalog=pubs";
            //sqlconnection is done here..
            con = new SqlConnection(conString);
        }
        void FetchMoviesById()
        {
            //write query
            string strcmd = "Select * from tblMovies where id=@mid";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                //open the connection
                con.Open();
                Console.WriteLine("Please enter the Id");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;

                // this will return the sqldatareader
                //Data Reader is user to read the data from the Sql
                SqlDataReader drMovies = cmd.ExecuteReader();
                //this loop will continue until there are elements in the authors table
                while (drMovies.Read())
                {
                    // get the value by accessing the index
                    Console.WriteLine("Movie Id : " + drMovies[0].ToString());
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                //this block will be executed whther or not the try catch is executed
                con.Close();
                //close the connection
            }
        }
        void FetchAllMovies()
        {
            //write query
            string strcmd = "Select * from tblMovies";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                //open the connection
                con.Open();

                //cmd.Parameters.Add("@mid", SqlDbType.Int);
                //cmd.Parameters[0].Value = id;

                // this will return the sqldatareader
                //Data Reader is user to read the data from the Sql
                SqlDataReader drMovies = cmd.ExecuteReader();
                //this loop will continue until there are elements in the authors table
                while (drMovies.Read())
                {
                    // get the value by accessing the index
                    Console.WriteLine("Movie Id : " + drMovies[0].ToString());
                    Console.WriteLine("Movie Name : " + drMovies[1]);
                    Console.WriteLine("Movie Duration : " + drMovies[2].ToString());
                    Console.WriteLine("---------------------------------");
                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                //this block will be executed whther or not the try catch is executed
                con.Close();
                //close the connection
            }
        }
        void AddMovie()
        {
            Console.WriteLine("Please enter the movie name");
            string mName = Console.ReadLine();
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()),2);
            string strcmd = "insert into tblMovies(name,duration) values(@mname,@mdur)";
            cmd = new SqlCommand(strcmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie inserted");
                else
                    Console.WriteLine("No no not done");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void UpdateMovieDuration()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the movie duration");
            float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
            string strcmd = "update tblMovies set duration=@mdur where id=@mid";
            cmd = new SqlCommand(strcmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie inserted");
                else
                    Console.WriteLine("No no not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void DeleteMovie()
        {
            Console.WriteLine("Please enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());
            string strcmd = "delete from tblMovies where id=@mid";
            cmd = new SqlCommand(strcmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Deleted");
                else
                    Console.WriteLine("No no not done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void PrintMenu()
        {
            int ch;
            do
            {
                Console.WriteLine("1.Print movie by id");
                Console.WriteLine("2.Print all movies");
                Console.WriteLine("3.Add a movie");
                Console.WriteLine("4.Update movie");
                Console.WriteLine("5.Delete movie");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Please Choose an option");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        FetchMoviesById();
                        break;
                    case 2:
                        FetchAllMovies();
                        break;
                    case 3:
                        AddMovie();
                        break;
                    case 4:
                        UpdateMovieDuration();
                        break;
                    case 5:
                        DeleteMovie();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (ch != 6);
            
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //new Program().UpdateMovieDuration();
            new Program().PrintMenu();
            //new Program().FetchMoviesFromDatabase();
        }
    }
}
