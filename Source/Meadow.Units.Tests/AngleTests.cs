using System;
using Xunit;

namespace Meadow.Units.Tests
{
    public class AngleTests
    {
        private readonly Random _random = new Random();

        [Fact]
        public void ConstructorTests()
        {
            foreach (Angle.UnitType unit in Enum.GetValues(typeof(Angle.UnitType)))
            {
                var value = _random.NextDouble() * 360;
                var a = new Angle(value, unit);
                var p = typeof(Angle).GetProperty(Enum.GetName(typeof(Angle.UnitType), unit));

                Assert.Equal(Math.Round(value, 6), Math.Round((double)p.GetValue(a), 6));
            }
        }

        [Fact]
        public void DivisionTests()
        {
            var initial = _random.NextDouble() * 360;
            var operand = _random.NextDouble() * 10;

            var a = new Angle(initial);
            a /= operand;
            Assert.Equal(initial / operand, a.Degrees);
        }

        [Fact]
        public void LtGtTests()
        {
            var minusTen = new Angle(-10);
            var zero = Angle.Zero;
            var plusTen = new Angle(10);

            Assert.True(minusTen < zero);
            Assert.True(minusTen < plusTen);
            Assert.True(zero < plusTen);

            Assert.True(zero > minusTen);
            Assert.True(plusTen > zero);
            Assert.True(plusTen > minusTen);
        }
    }
}
