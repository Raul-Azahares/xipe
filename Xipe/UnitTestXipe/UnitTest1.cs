using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xipe_Conexion;

namespace UnitTestXipe
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void TestOpenConexion()
        {
            // Arrange
            IDatabase database = new MySQLDatabase();

            // Act
            database.OpenConexion();
            bool conexionOpen = true; 
            Assert.IsTrue(conexionOpen, "the conexion open fine");
        }
        [TestMethod]
        public void TestWriteConexion()
        {

            IDatabase database = new MySQLDatabase();

            database.OpenConexion();

            string message = "Data of MySQL";
            database.WriteConexion(message);


            string messageWrite = "Data of MySQL"; 
            string messageInDatabase = database.Read(); 

            Assert.AreEqual(messageWrite, messageInDatabase, "the message is equal");
        }
    }
}
