using MbUnit.Framework;
using System;

namespace EfficientlyLazy.Crypto.Test
{
    [TestFixture]
    public class VersionGenerator
    {
        [Test]
        public void Generate()
        {
            DateTime now = DateTime.Now;

            DateTime jan1 = new DateTime(now.Year, 1, 1, 0, 0, 0);

            TimeSpan hourTimespan = TimeSpan.FromTicks(now.Ticks - jan1.Ticks);

            int hours = (int)hourTimespan.TotalHours;

            string version = string.Format("{0}.{1}.{2}.{3}", "x", "x", now.Year, hours.ToString().Replace(",", ""));

            Assert.IsNotNull(version);
        }
    }
}
