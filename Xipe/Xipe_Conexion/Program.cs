using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Xipe_Conexion
{

    public interface IDatabase {
        void OpenConexion();
        void WriteConexion(string message);
        string Read();
        void CloseConexion();

    
    }
    public class MySQLDatabase : IDatabase
    {
        public void OpenConexion()
        {
            Console.WriteLine("Connection to MySQL open");
        }

        public void WriteConexion(string message)
        {
            Console.WriteLine($"Connection in MySQL: {message}");
        }

        public string Read()
        {
            Console.WriteLine("Reading of MySQL");
            return "Data of MySQL";
        }

        public void CloseConexion()
        {
            Console.WriteLine("Connection to MySQL closed");
        }
    }

    
    public class SQLDatabase : IDatabase
    {
        public void OpenConexion()
        {
            Console.WriteLine("Connection to SQL open");
        }

        public void WriteConexion(string message)
        {
            Console.WriteLine($"Connection in SQL: {message}");
        }

        public string Read()
        {
            Console.WriteLine("Reading of SQL");
            return "Data of SQL";
        }

        public void CloseConexion()
        {
            Console.WriteLine("Connection to SQL closed");
        }
    }
    public class DatabaseFactory
    {
        public static IDatabase CreateDatabase(string databaseType)
        {
            switch (databaseType)
            {
                case "MySQL":
                    return new MySQLDatabase();
                case "SQL":
                    return new SQLDatabase();
                default:
                    throw new ArgumentException("Type database not valid");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string databaseType = "MySQL";

            IDatabase database = DatabaseFactory.CreateDatabase(databaseType);


            database.OpenConexion();
            Thread.Sleep(5000);
            database.WriteConexion("Test data");
            Thread.Sleep(5000);
            string data = database.Read();
            Thread.Sleep(5000);
            Console.WriteLine($"data read: {data}");
            Thread.Sleep(5000);
            database.CloseConexion();
        }
    }
}
