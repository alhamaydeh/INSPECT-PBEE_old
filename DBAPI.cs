using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWizard
{
    public class DBAPI
    {
        private static int  count =0;
        private static SQLiteConnection cn= null;
        private static SQLiteCommand  cmd = new SQLiteCommand();
        private static string last_query="";
        private static SQLiteDataReader rd = null;
        public  static void instantiate(string database)
        {
            if(cn==null)
            {
                cn = new SQLiteConnection(@"Data Source=" + Var.pp + @"\"+database+";Version=3;");
              //  rd = new SQLiteDataReader();
            }
        }
       [MethodImpl(MethodImplOptions.Synchronized)]
        public static int executeNonQuery(string query)
        {
           if(rd!=null)
           if (!rd.IsClosed)
            {
                Console.WriteLine("Reader is still opened, last quers is \r\n" + last_query+"\r\nQuery # is : "+count++);
                rd.Close();
            }
            if (cn.State != ConnectionState.Closed)
            {
                Console.WriteLine("Execute Non Query Connection is still opened, last quers is \r\n" + last_query + "\r\nQuery # is : " + count++);
                cn.Close();
            }
            
            cn.Open();
           
            cmd.Connection = cn;
            cmd.CommandText = query;
            int res = -1;
            try
            {
                 res = cmd.ExecuteNonQuery();
            }
           catch(Exception ee)
            {
                MessageBox.Show("Error Executing Query" + "\r\nQuery # is : " + count++);
                Console.WriteLine(ee.StackTrace);
            }
            finally
            {
                cn.Close();
            }
            last_query = query;
           
            return res;
        }
       [MethodImpl(MethodImplOptions.Synchronized)]
       public static int executeNonQueries(List<string> queries)
       {
           if (rd != null)
               if (!rd.IsClosed)
               {
                   Console.WriteLine("Reader is still opened, last queris is \r\n" + last_query + "\r\nQuery # is : " + count++);
                   rd.Close();
               }
           if (cn.State != ConnectionState.Closed)
           {
               Console.WriteLine("Execute Non Query Connection is still opened, last queries is \r\n" + last_query + "\r\nQuery # is : " + count++);
               cn.Close();
           }

           cn.Open();
           cmd.Connection = cn;
           
           int res = -1;
           try
           {
               cmd.CommandText = "begin"; 
               cmd.ExecuteNonQuery();
               for (int i = 0; i < queries.Count(); i++)
               {
                   cmd.CommandText = queries[i];
                   res = cmd.ExecuteNonQuery();
                   last_query = queries[i];
               }

               cmd.CommandText = "end"; cmd.ExecuteNonQuery();
           }
           catch (Exception ee)
           {
               MessageBox.Show("Error Executing Query" + "\r\nQuery # is : " + count++);
               Console.WriteLine(ee.StackTrace);
           }
           finally
           {
               cn.Close();
           }
           

           return res;
       }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public  static SQLiteDataReader executeQuery(string query)
        {
            if(rd!=null)
            if (!rd.IsClosed)
            {
                Console.WriteLine("Reader is still opened, last quers is \r\n" + last_query + "\r\nQuery # is : " + count++);
                rd.Close();
            }
            if (cn.State != ConnectionState.Closed)
            {
                Console.WriteLine("Execute Non Query Connection is still opened, last quers is \r\n" + last_query + "\r\nQuery # is : " + count++);
                cn.Close() ;
            }
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = query;
            try
            {
                rd = cmd.ExecuteReader();
            }
            catch(Exception ee)
            {
                MessageBox.Show("Error Executing Reader" + "\r\nQuery # is : " + count++);
                Console.WriteLine(ee.StackTrace);
                return null;
            }
            last_query = query;
            return rd;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static bool TableExists(String tableName)
        {
            if (rd != null)
                if (!rd.IsClosed)
                {
                    Console.WriteLine("Reader is still opened, last queris is \r\n" + last_query + "\r\nQuery # is : " + count++);
                    rd.Close();
                }
            if (cn.State != ConnectionState.Closed)
            {
                Console.WriteLine("Execute Non Query Connection is still opened, last queries is \r\n" + last_query + "\r\nQuery # is : " + count++);
                cn.Close();
            }

            cn.Open();
            cmd.Connection = cn;

           
                cmd.CommandType = CommandType.Text;
               
                cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
                cmd.Parameters.AddWithValue("@name", tableName);

                using (SQLiteDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    if (sqlDataReader.Read())
                    {
                        sqlDataReader.Close();
                        return true;
                    }
                    else
                    {
                        sqlDataReader.Close();
                        return false;
                    }
                }
            
        }
    }
}
