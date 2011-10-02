using System;
using MbUnit.Framework;

namespace EfficientlyLazy.Crypto.Test
{
    [TestFixture]
    public class ConfigurationTests
    {
        private ICryptoEngine _engine;

        [FixtureSetUp]
        public void FixtureSetup()
        {
            _engine = new RijndaelEngine("WVZwzJ/n<Czp1p73iL=?!0_FR[yYjqq#~zJi$Z")
                .SetInitVector("nj9VU7Bksh9EAqPE")
                .SetRandomSaltLength(13, 19)
                .SetKeySize(KeySize.Key256Bit);
        }

        [Test]
        [Row("App.Setting.01", "Simple Setting Data")]
        [Row("App.Setting.02", "Another Simple Setting Data")]
        [Row("App.Setting.03", "Simple Encrypted Data")]
        [Row("App.Setting.04", "Another Random Set of Encrypted Data")]
        [Row("App.Setting.05", "0V6KOK1ot2II06Q03S/grjjBDe1NYFUGqYKtlUFA8PSboFAAaxaXY2fzsLIJNBSdrwraLzoiKtOuldELxsheZg==")]
        [Row("App.Setting.06", "should bomb", ExpectedException = typeof(FormatException))]
        [Row("App.Setting.Missing", "")]
        public void Sett(string key, string expectedValue)
        {
            // ACT
            var actual = _engine.GetSetting(key);

            // ASSERT
            Assert.AreEqual(expectedValue, actual);
        }

        [Test]
        public void GetSqlConnectionString_With_No_Encrypted_Values()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION01");

            // ASSERT
            Assert.AreEqual("server", builder.DataSource);
            Assert.AreEqual("db", builder.InitialCatalog);
            Assert.AreEqual(false, builder.IntegratedSecurity);
            Assert.AreEqual("uid", builder.UserID);
            Assert.AreEqual("pass", builder.Password);
            Assert.AreEqual(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.AreEqual("", builder.WorkstationID);
            Assert.AreEqual(15, builder.ConnectTimeout);
            Assert.AreEqual(true, builder.Pooling);
        }

        [Test]
        public void GetSqlConnectionString_With_Encrypted_Values()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION02");

            // ASSERT
            Assert.AreEqual("server", builder.DataSource);
            Assert.AreEqual("db", builder.InitialCatalog);
            Assert.AreEqual(false, builder.IntegratedSecurity);
            Assert.AreEqual("encryptedUser", builder.UserID);
            Assert.AreEqual("encryptedPassword", builder.Password);
            Assert.AreEqual(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.AreEqual("", builder.WorkstationID);
            Assert.AreEqual(15, builder.ConnectTimeout);
            Assert.AreEqual(true, builder.Pooling);
        }

        [Test]
        public void GetSqlConnectionString_Mixed_Values_Uses_UnEncrypted()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION03");

            // ASSERT
            Assert.AreEqual("server", builder.DataSource);
            Assert.AreEqual("db", builder.InitialCatalog);
            Assert.AreEqual(false, builder.IntegratedSecurity);
            Assert.AreEqual("unEncryptedUser", builder.UserID);
            Assert.AreEqual("unEncryptedPassword", builder.Password);
            Assert.AreEqual(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.AreEqual("", builder.WorkstationID);
            Assert.AreEqual(15, builder.ConnectTimeout);
            Assert.AreEqual(true, builder.Pooling);
        }

        [Test]
        public void GetSqlConnectionString_Use_Windows_Authentication()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION04");

            // ASSERT
            Assert.AreEqual("server", builder.DataSource);
            Assert.AreEqual("db", builder.InitialCatalog);
            Assert.AreEqual(true, builder.IntegratedSecurity);
            Assert.AreEqual("", builder.UserID);
            Assert.AreEqual("", builder.Password);
            Assert.AreEqual(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.AreEqual("", builder.WorkstationID);
            Assert.AreEqual(15, builder.ConnectTimeout);
            Assert.AreEqual(true, builder.Pooling);
        }

        [Test]
        public void GetSqlConnectionString_Show_WorkstationID()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION05");

            // ASSERT
            Assert.AreEqual("server", builder.DataSource);
            Assert.AreEqual("db", builder.InitialCatalog);
            Assert.AreEqual(false, builder.IntegratedSecurity);
            Assert.AreEqual("uid", builder.UserID);
            Assert.AreEqual("pass", builder.Password);
            Assert.AreEqual(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.AreEqual(Environment.MachineName, builder.WorkstationID);
            Assert.AreEqual(15, builder.ConnectTimeout);
            Assert.AreEqual(true, builder.Pooling);
        }


        [Test]
        public void GetSqlConnectionString_Custom_App_Name()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION06");

            // ASSERT
            Assert.AreEqual("server", builder.DataSource);
            Assert.AreEqual("db", builder.InitialCatalog);
            Assert.AreEqual(false, builder.IntegratedSecurity);
            Assert.AreEqual("uid", builder.UserID);
            Assert.AreEqual("pass", builder.Password);
            Assert.AreEqual("My Awesome App", builder.ApplicationName);
            Assert.AreEqual(Environment.MachineName, builder.WorkstationID);
            Assert.AreEqual(15, builder.ConnectTimeout);
            Assert.AreEqual(true, builder.Pooling);
        }

        [Test]
        public void GetSqlConnectionString_Custom_Settings()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION07");

            // ASSERT
            Assert.AreEqual("server", builder.DataSource);
            Assert.AreEqual("db", builder.InitialCatalog);
            Assert.AreEqual(false, builder.IntegratedSecurity);
            Assert.AreEqual("uid", builder.UserID);
            Assert.AreEqual("pass", builder.Password);
            Assert.AreEqual(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.AreEqual(Environment.MachineName, builder.WorkstationID);
            Assert.AreEqual(1000, builder.ConnectTimeout);
            Assert.AreEqual(false, builder.Pooling);
        }
    }
}
