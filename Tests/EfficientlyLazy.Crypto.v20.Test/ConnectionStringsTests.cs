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
        private static readonly ICryptoEngine _engine = new RijndaelEngine("myKey");

        [Test(Order = 10)]
        public void InvalidConnectionStringName()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            var setting = conn.Get("pookie1");

            Assert.IsNull(setting);
        }

        [Test(Order = 20)]
        public void ValidConnectionStringNameClearText()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            var setting = conn.Get("validClearText");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual("initialcatalog1", builder.InitialCatalog);
            Assert.AreEqual("datasource1", builder.DataSource);
            Assert.AreEqual("username1", builder.UserID);
            Assert.AreEqual("password1", builder.Password);
        }

        [Test(Order = 30)]
        public void ValidConnectionStringNameEncrypted()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            var setting = conn.Get("validEncrypted");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual("initialcatalog2", builder.InitialCatalog);
            Assert.AreEqual("datasource2", builder.DataSource);
            Assert.AreEqual("username2", builder.UserID);
            Assert.AreEqual("password2", builder.Password);
        }

        [Test(Order = 40)]
        public void UpdateConnectionStringAsClearText()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            var setting = conn.Get("updateClearText");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual("initialcatalog3", builder.InitialCatalog);
            Assert.AreEqual("datasource3", builder.DataSource);
            Assert.AreEqual("username3", builder.UserID);
            Assert.AreEqual("password3", builder.Password);

            builder.InitialCatalog = "initialcatalog_3";
            builder.DataSource = "datasource_3";
            builder.UserID = "username_3";
            builder.Password = "password_3";

            conn.Update("updateClearText", builder.ConnectionString, false);

            string newString = ConfigurationManager.ConnectionStrings["updateClearText"].ConnectionString;

            SqlConnectionStringBuilder newBuilder = new SqlConnectionStringBuilder(newString);

            Assert.AreEqual("initialcatalog_3", newBuilder.InitialCatalog);
            Assert.AreEqual("datasource_3", newBuilder.DataSource);
            Assert.AreEqual("username_3", newBuilder.UserID);
            Assert.AreEqual("password_3", newBuilder.Password);
        }

        [Test(Order = 50)]
        public void UpdateConnectionStringAsEncrypted()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            var setting = conn.Get("updateEncrypted");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual("initialcatalog4", builder.InitialCatalog);
            Assert.AreEqual("datasource4", builder.DataSource);
            Assert.AreEqual("username4", builder.UserID);
            Assert.AreEqual("password4", builder.Password);

            builder.InitialCatalog = "initialcatalog_4";
            builder.DataSource = "datasource_4";
            builder.UserID = "username_4";
            builder.Password = "password_4";

            conn.Update("updateEncrypted", builder.ConnectionString, true);

            string newString = ConfigurationManager.ConnectionStrings["updateEncrypted"].ConnectionString;

            newString = _engine.Decrypt(newString);

            SqlConnectionStringBuilder newBuilder = new SqlConnectionStringBuilder(newString);

            Assert.AreEqual("initialcatalog_4", newBuilder.InitialCatalog);
            Assert.AreEqual("datasource_4", newBuilder.DataSource);
            Assert.AreEqual("username_4", newBuilder.UserID);
            Assert.AreEqual("password_4", newBuilder.Password);
        }

        [Test(Order = 50)]
        [ExpectedArgumentException]
        public void UpdateConnectionStringWithInvalidConnectionStringName()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            var setting = conn.Get("updateInvalidName");

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(setting.ConnectionString);

            Assert.AreEqual("initialcatalog5", builder.InitialCatalog);
            Assert.AreEqual("datasource5", builder.DataSource);
            Assert.AreEqual("username5", builder.UserID);
            Assert.AreEqual("password5", builder.Password);

            builder.InitialCatalog = "initialcatalog_xx";
            builder.DataSource = "datasource_xx";
            builder.UserID = "username_xx";
            builder.Password = "password_xx";

            conn.Update("invalidConnectionStringName", builder.ConnectionString, true);
        }

        [Test(Order = 60)]
        public void Decrypt()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            string encrypted = ConfigurationManager.ConnectionStrings["encrypted"].ConnectionString;

            Assert.DoesNotContain(encrypted, "username");

            conn.Decrypt("encrypted");

            string decrypted = ConfigurationManager.ConnectionStrings["encrypted"].ConnectionString;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(decrypted);

            Assert.AreEqual("initialcatalog6", builder.InitialCatalog);
            Assert.AreEqual("datasource6", builder.DataSource);
            Assert.AreEqual("username6", builder.UserID);
            Assert.AreEqual("password6", builder.Password);
        }

        [Test(Order = 70)]
        public void Encrypt()
        {
            SecureConnectionStrings conn = new SecureConnectionStrings(_engine);

            string decrypted = ConfigurationManager.ConnectionStrings["decrypted"].ConnectionString;

            Assert.Contains(decrypted, "username");

            conn.Encrypt("decrypted");

            string encrypted = ConfigurationManager.ConnectionStrings["decrypted"].ConnectionString;

            Assert.AreEqual(_engine.Encrypt(decrypted), encrypted);
        }

        [Test(Order = 80)]
        public void HasMixedEncryptedDecrypted()
        {
            int total = 0;
            int clear = 0;

            foreach (ConnectionStringSettings setting in ConfigurationManager.ConnectionStrings)
            {
                total++;
                if (setting.ConnectionString.Contains("username"))
                {
                    clear++;
                }
            }

            Assert.AreNotEqual(total, clear);
            Assert.AreNotEqual(total, 0);
        }
    }
}