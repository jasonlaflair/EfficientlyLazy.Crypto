using System;
using Xunit;

namespace EfficientlyLazy.Crypto.Test
{
    public class VersionGenerator
    {
        [Fact]
        public void Generate()
        {
            var now = DateTime.Now;

            var jan1 = new DateTime(now.Year, 1, 1, 0, 0, 0);

            var hourTimespan = TimeSpan.FromTicks(now.Ticks - jan1.Ticks);

            var hours = (int)hourTimespan.TotalHours;

            var version = string.Format("{0}.{1}.{2}.{3}", "x", "x", now.Year, hours.ToString().Replace(",", ""));

            Assert.NotNull(version);
        }
    }
}
