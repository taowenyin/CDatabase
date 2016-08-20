using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CDatabase;

namespace Test
{
    [TestClass]
    public class DatabaseTest
    {
        private IDatabase database = null;

        public DatabaseTest()
        {
            DbConfig config = new DbConfig();
            config.Server = "localhost";
            config.User = "root";
            config.Password = "Password12!";
            config.Port = 3306;
            config.Database = "spslocal";
            database = DatabaseFactory.CreateDatabase(config,
                DbConfig.DbType.MYSQL);
        }

        [TestMethod]
        public void TestOpenDatabase()
        {
            try
            {
                database.Open();
            }
            catch (DatabaseException e)
            {
                Assert.Fail("Open database fail, error code:" + e.GetErrorCode() + ", error message:" + e.GetErrorMsg());
            }
        }

        [TestMethod]
        public void TestSingleton()
        {
            DbConfig config = new DbConfig();
            config.Server = "localhost";
            config.User = "root";
            config.Password = "Password12!";
            config.Port = 3306;
            config.Database = "spslocal";

            IDatabase database = DatabaseFactory.CreateDatabase(config,
                DbConfig.DbType.MYSQL);

            Assert.AreSame(this.database, database, "单例测试失败");
        }

        [TestMethod]
        public void TestCloseDatabase()
        {
            try
            {
                database.Open();
                database.Close();
            }
            catch (DatabaseException e)
            {
                Assert.Fail("Close database fail, error code:" + e.GetErrorCode() + ", error message:" + e.GetErrorMsg());
            }
        }

        [TestMethod]
        public void TestExecSQL()
        {
            database.Open();
            database.Close();

            int actual = database.ExecSQL(
                "CREATE SCHEMA IF NOT EXISTS `testdatabase` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci", 
                null);
            Assert.IsTrue(actual > 0, "执行SQL语句测试失败");
        }

        [TestMethod]
        public void TestInsert()
        {

        }
    }
}
