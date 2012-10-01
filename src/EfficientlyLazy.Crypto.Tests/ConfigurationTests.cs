using System;
using EfficientlyLazy.Crypto.Engines;
using Xunit;
using Xunit.Extensions;

namespace EfficientlyLazy.Crypto.Tests
{
    public class ConfigurationTests
    {
        private readonly ICryptoEngine _engine;

        public ConfigurationTests()
        {
            _engine = new RijndaelEngine("WVZwzJ/n<Czp1p73iL=?!0_FR[yYjqq#~zJi$Z")
                .SetInitVector("nj9VU7Bksh9EAqPE")
                .SetRandomSaltLength(13, 19)
                .SetKeySize(RijndaelKeySize.Key256Bit);
        }

        [Theory]
        [InlineData("App.Setting.01", "Simple Setting Data")]
        [InlineData("App.Setting.02", "Another Simple Setting Data")]
        [InlineData("App.Setting.03", "Simple Encrypted Data")]
        [InlineData("App.Setting.04", "Another Random Set of Encrypted Data")]
        [InlineData("App.Setting.05", "0V6KOK1ot2II06Q03S/grjjBDe1NYFUGqYKtlUFA8PSboFAAaxaXY2fzsLIJNBSdrwraLzoiKtOuldELxsheZg==")]
        [InlineData("App.Setting.Missing", "")]
        public void GetSetting_Sucessful(string key, string expectedValue)
        {
            // Act
            var actual = _engine.GetSetting(key);

            // Assert
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void GetSetting_Fails()
        {
            // Assert
            Assert.Throws<FormatException>(() => _engine.GetSetting("App.Setting.06"));
        }

        [Fact]
        public void GetSqlConnectionString_With_No_Encrypted_Values()
        {
            // Act
            var builder = _engine.GetSqlConnectionString("CONNECTION01");

            // Assert
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
            // Act
            var builder = _engine.GetSqlConnectionString("CONNECTION02");

            // Assert
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
            // Act
            var builder = _engine.GetSqlConnectionString("CONNECTION03");

            // Assert
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
            // Act
            var builder = _engine.GetSqlConnectionString("CONNECTION04");

            // Assert
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
            // Act
            var builder = _engine.GetSqlConnectionString("CONNECTION05");

            // Assert
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
            // Act
            var builder = _engine.GetSqlConnectionString("CONNECTION06");

            // Assert
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
            // Act
            var builder = _engine.GetSqlConnectionString("CONNECTION07");

            // Assert
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
