// // Copyright 2008-2009 LaFlair.NET
// // 
// // Licensed under the Apache License, Version 2.0 (the "License");
// // you may not use this file except in compliance with the License.
// // You may obtain a copy of the License at
// // 
// //     http://www.apache.org/licenses/LICENSE-2.0
// // 
// // Unless required by applicable law or agreed to in writing, software
// // distributed under the License is distributed on an "AS IS" BASIS,
// // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// // See the License for the specific language governing permissions and
// // limitations under the License.
// 
namespace EfficientlyLazy.Crypto.Test
{
    using System.Configuration;
    using System.Data.SqlClient;
    using MbUnit.Framework;

    [TestFixture]
    public class ConnectionStringsTests
    {
        private const string DEFAULT_NAME = "connStringName";
        private static readonly ICryptoEngine _engine = new RijndaelEngine("myKey");

        private void SetConnectionString(string connectionString)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ConnectionStringSettings current = config.ConnectionStrings.ConnectionStrings[DEFAULT_NAME];

            current.ConnectionString = connectionString;

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private SqlConnectionStringBuilder GenerateRandomConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                                                 {
                                                     DataSource = DataGenerator.RandomString(10, 15, true, true, false, false),
                                                     InitialCatalog = DataGenerator.RandomString(10, 15, true, true, false, false),
                                                     UserID = DataGenerator.RandomString(10, 15, true, true, false, false),
                                                     Password = DataGenerator.RandomString(10, 15, true, true, false, false),
                                                     IntegratedSecurity = false
                                                 };

            SetConnectionString(builder.ToString());

            return builder;
        }

        [Test(Order = 10)]
        public void InvalidConnectionStringName()
        {
            SecuredConnectionStrings conn = new SecuredConnectionStrings(_engine);

            var setting = conn.Get("pookie1");

            Assert.AreEqual(ConnectionStringStates.NotFound, setting.State);
        }

        [Test(Order = 20)]
        public void ValidConnectionStringNameClearText()
        {
            SqlConnectionStringBuilder expected = GenerateRandomConnectionString();

            SecuredConnectionStrings conn = new SecuredConnectionStrings(_engine);

            var setting = conn.Get(DEFAULT_NAME);

            Assert.AreEqual(ConnectionStringStates.ClearText, setting.State);

            SqlConnectionStringBuilder actual = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual(expected.InitialCatalog, actual.InitialCatalog);
            Assert.AreEqual(expected.DataSource, actual.DataSource);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.Password, actual.Password);
        }

        [Test(Order = 30)]
        public void ValidConnectionStringNameEncrypted()
        {
            SqlConnectionStringBuilder expected = GenerateRandomConnectionString();

            SecuredConnectionStrings conn1 = new SecuredConnectionStrings(_engine);
            conn1.Update(DEFAULT_NAME, expected.ToString(), true);

            SecuredConnectionStrings conn2 = new SecuredConnectionStrings(_engine);
            conn2.Update(DEFAULT_NAME, expected.ToString(), true);

            var setting = conn2.Get(DEFAULT_NAME);

            Assert.AreEqual(ConnectionStringStates.Decrypted, setting.State);

            SqlConnectionStringBuilder actual = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual(expected.InitialCatalog, actual.InitialCatalog);
            Assert.AreEqual(expected.DataSource, actual.DataSource);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.Password, actual.Password);
        }

        [Test(Order = 40)]
        public void UpdateConnectionStringAsClearText()
        {
            SqlConnectionStringBuilder expected = GenerateRandomConnectionString();

            SecuredConnectionStrings conn1 = new SecuredConnectionStrings(_engine);
            conn1.Update(DEFAULT_NAME, expected.ToString(), true);

            SecuredConnectionStrings conn2 = new SecuredConnectionStrings(_engine);
            conn2.Update(DEFAULT_NAME, expected.ToString(), false);

            var setting = conn2.Get(DEFAULT_NAME);

            Assert.AreEqual(ConnectionStringStates.ClearText, setting.State);

            SqlConnectionStringBuilder actual = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual(expected.InitialCatalog, actual.InitialCatalog);
            Assert.AreEqual(expected.DataSource, actual.DataSource);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.Password, actual.Password);
        }

        [Test(Order = 50)]
        public void UpdateConnectionStringAsEncrypted()
        {
            SqlConnectionStringBuilder expected = GenerateRandomConnectionString();

            SecuredConnectionStrings conn1 = new SecuredConnectionStrings(_engine);
            conn1.Update(DEFAULT_NAME, expected.ToString(), true);

            SecuredConnectionStrings conn2 = new SecuredConnectionStrings(_engine);
            conn2.Update(DEFAULT_NAME, expected.ToString(), true);

            var setting = conn2.Get(DEFAULT_NAME);

            Assert.AreEqual(ConnectionStringStates.Decrypted, setting.State);

            SqlConnectionStringBuilder actual = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual(expected.InitialCatalog, actual.InitialCatalog);
            Assert.AreEqual(expected.DataSource, actual.DataSource);
            Assert.AreEqual(expected.UserID, actual.UserID);
            Assert.AreEqual(expected.Password, actual.Password);
        }

        [Test(Order = 60)]
        [ExpectedArgumentException]
        public void UpdateConnectionStringWithInvalidConnectionStringName()
        {
            SecuredConnectionStrings conn = new SecuredConnectionStrings(_engine);

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                                                 {
                                                     DataSource = "pookie",
                                                     InitialCatalog = "myDb",
                                                     UserID = "dummy",
                                                     Password = "guess",
                                                     IntegratedSecurity = false
                                                 };

            conn.Update("invalidConnectionStringName", builder.ConnectionString, true);
        }
    }
}