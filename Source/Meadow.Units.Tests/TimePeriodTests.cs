using Xunit;

namespace Meadow.Units.Tests
{
    public class TimePeriodTests
    {
        [Fact()]
        public void MicroSecondsCreationTests()
        {
            var p = TimePeriod.FromMicroseconds(1);
            Assert.Equal(0.000001d, p.Seconds);
            Assert.Equal(0.001d, p.Milliseconds);
            Assert.Equal(1000, p.Nanoseconds);
        }
    }
}
