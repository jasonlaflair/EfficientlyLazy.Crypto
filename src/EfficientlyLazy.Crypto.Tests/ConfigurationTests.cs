using System;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Test
{
    public class ConfigurationTests
    {
        private ICryptoEngine _engine;

        public ConfigurationTests()
        {
            _engine = new RijndaelEngine("WVZwzJ/n<Czp1p73iL=?!0_FR[yYjqq#~zJi$Z")
                .SetInitVector("nj9VU7Bksh9EAqPE")
                .SetRandomSaltLength(13, 19)
                .SetKeySize(KeySize.Key256Bit);
        }

        [Theory]
        [InlineData("App.Setting.01", "Simple Setting Data")]
        [InlineData("App.Setting.02", "Another Simple Setting Data")]
        [InlineData("App.Setting.03", "Simple Encrypted Data")]
        [InlineData("App.Setting.04", "Another Random Set of Encrypted Data")]
        [InlineData("App.Setting.05", "0V6KOK1ot2II06Q03S/grjjBDe1NYFUGqYKtlUFA8PSboFAAaxaXY2fzsLIJNBSdrwraLzoiKtOuldELxsheZg==")]
        //[InlineData("App.Setting.06", "should bomb")] // TODO: FIX
        [InlineData("App.Setting.Missing", "")]
        public void Sett(string key, string expectedValue)
        {
            // ACT
            var actual = _engine.GetSetting(key);

            // ASSERT
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void GetSqlConnectionString_With_No_Encrypted_Values()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION01");

            // ASSERT
            Assert.Equal("server", builder.DataSource);
            Assert.Equal("db", builder.InitialCatalog);
            Assert.Equal(false, builder.IntegratedSecurity);
            Assert.Equal("uid", builder.UserID);
            Assert.Equal("pass", builder.Password);
            Assert.Equal(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.Equal("", builder.WorkstationID);
            Assert.Equal(15, builder.ConnectTimeout);
            Assert.Equal(true, builder.Pooling);
        }

        [Fact]
        public void GetSqlConnectionString_With_Encrypted_Values()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION02");

            // ASSERT
            Assert.Equal("server", builder.DataSource);
            Assert.Equal("db", builder.InitialCatalog);
            Assert.Equal(false, builder.IntegratedSecurity);
            Assert.Equal("encryptedUser", builder.UserID);
            Assert.Equal("encryptedPassword", builder.Password);
            Assert.Equal(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.Equal("", builder.WorkstationID);
            Assert.Equal(15, builder.ConnectTimeout);
            Assert.Equal(true, builder.Pooling);
        }

        [Fact]
        public void GetSqlConnectionString_Mixed_Values_Uses_UnEncrypted()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION03");

            // ASSERT
            Assert.Equal("server", builder.DataSource);
            Assert.Equal("db", builder.InitialCatalog);
            Assert.Equal(false, builder.IntegratedSecurity);
            Assert.Equal("unEncryptedUser", builder.UserID);
            Assert.Equal("unEncryptedPassword", builder.Password);
            Assert.Equal(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.Equal("", builder.WorkstationID);
            Assert.Equal(15, builder.ConnectTimeout);
            Assert.Equal(true, builder.Pooling);
        }

        [Fact]
        public void GetSqlConnectionString_Use_Windows_Authentication()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION04");

            // ASSERT
            Assert.Equal("server", builder.DataSource);
            Assert.Equal("db", builder.InitialCatalog);
            Assert.Equal(true, builder.IntegratedSecurity);
            Assert.Equal("", builder.UserID);
            Assert.Equal("", builder.Password);
            Assert.Equal(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.Equal("", builder.WorkstationID);
            Assert.Equal(15, builder.ConnectTimeout);
            Assert.Equal(true, builder.Pooling);
        }

        [Fact]
        public void GetSqlConnectionString_Show_WorkstationID()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION05");

            // ASSERT
            Assert.Equal("server", builder.DataSource);
            Assert.Equal("db", builder.InitialCatalog);
            Assert.Equal(false, builder.IntegratedSecurity);
            Assert.Equal("uid", builder.UserID);
            Assert.Equal("pass", builder.Password);
            Assert.Equal(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.Equal(Environment.MachineName, builder.WorkstationID);
            Assert.Equal(15, builder.ConnectTimeout);
            Assert.Equal(true, builder.Pooling);
        }


        [Fact]
        public void GetSqlConnectionString_Custom_App_Name()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION06");

            // ASSERT
            Assert.Equal("server", builder.DataSource);
            Assert.Equal("db", builder.InitialCatalog);
            Assert.Equal(false, builder.IntegratedSecurity);
            Assert.Equal("uid", builder.UserID);
            Assert.Equal("pass", builder.Password);
            Assert.Equal("My Awesome App", builder.ApplicationName);
            Assert.Equal(Environment.MachineName, builder.WorkstationID);
            Assert.Equal(15, builder.ConnectTimeout);
            Assert.Equal(true, builder.Pooling);
        }

        [Fact]
        public void GetSqlConnectionString_Custom_Settings()
        {
            // ACT
            var builder = _engine.GetSqlConnectionString("CONNECTION07");

            // ASSERT
            Assert.Equal("server", builder.DataSource);
            Assert.Equal("db", builder.InitialCatalog);
            Assert.Equal(false, builder.IntegratedSecurity);
            Assert.Equal("uid", builder.UserID);
            Assert.Equal("pass", builder.Password);
            Assert.Equal(".Net SqlClient Data Provider", builder.ApplicationName);
            Assert.Equal(Environment.MachineName, builder.WorkstationID);
            Assert.Equal(1000, builder.ConnectTimeout);
            Assert.Equal(false, builder.Pooling);
        }
    }
}
