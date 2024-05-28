using System;
using System.Collections.Generic;
using Xunit;

namespace Meadow.Units.Tests;


public class AzimuthTests
{
    private Random _random = new Random();

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

        Azimuth az = new Azimuth(0d);
        Assert.True(az.DecimalDegrees == 0);

        Azimuth a2 = new Azimuth();
        Assert.True(a2.DecimalDegrees == 0);

        Azimuth a3 = Azimuth.FromCompass16PointCardinalName(Azimuth16PointCardinalNames.E);
        Assert.True(a3.Compass16PointCardinalName == Azimuth16PointCardinalNames.E);
        Assert.Equal(90d, a3.DecimalDegrees);

        Azimuth v4 = Azimuth.FromDecimalDegrees(270);
        Assert.True(v4.DecimalDegrees == 270);
    }

    [Fact()]
    public void ConversionTests()
    {
        Azimuth v = new Azimuth(90);
        Assert.True(v.Compass16PointCardinalName == Azimuth16PointCardinalNames.E);

        Azimuth v2 = new Azimuth(Azimuth16PointCardinalNames.NNW);
        Assert.True(v2.DecimalDegrees == 337.5);

        Azimuth v3 = new Azimuth(191.25);
        Assert.True(v3.Compass16PointCardinalName == Azimuth16PointCardinalNames.SSW);

    }

    [Fact()]
    public void MathTests()
    {
        // first do some simple known-value tests
        var a1 = new Azimuth(270);
        var a2 = a1 + new Azimuth(180);
        Assert.Equal(90d, a2.DecimalDegrees);

        var a3 = new Azimuth(90);
        var a4 = a3 - new Azimuth(180);
        Assert.Equal(270d, a4.DecimalDegrees);

        var a5 = a3 * 5;
        Assert.Equal(90d, a5.DecimalDegrees);

        var m = new Azimuth(90) * 5;
        Assert.Equal(90d, m.DecimalDegrees);

        var m2 = new Azimuth(90) * -1;
        Assert.Equal(270d, m2.DecimalDegrees);

        var m3 = new Azimuth(360 * 5.5);
        Assert.Equal(180d, m3.DecimalDegrees);
    }

    [Fact]
    public void ExtensionTests()
    {
        var count = 5;
        var range = 20;
        var middle = 45;
        var samples = new List<Azimuth>();

        // test mean around 45
        for (var i = 0; i < count; i++)
        {
            samples.Add(new Azimuth(_random.Next(middle - (range / 2), middle + (range / 2))));
        }
        var mean = samples.Mean();
        Assert.True(mean.DecimalDegrees > (middle - (range / 2)));
        Assert.True(mean.DecimalDegrees < (middle + (range / 2)));

        // test mean around 270
        middle = 270;
        samples.Clear();
        for (var i = 0; i < count; i++)
        {
            samples.Add(new Azimuth(_random.Next(middle - (range / 2), middle + (range / 2))));
        }
        mean = samples.Mean();
        Assert.True(mean.DecimalDegrees > (middle - (range / 2)));
        Assert.True(mean.DecimalDegrees < (middle + (range / 2)));

        // test mean around 180
        middle = 180;
        samples.Clear();
        for (var i = 0; i < count; i++)
        {
            samples.Add(new Azimuth(_random.Next(middle - (range / 2), middle + (range / 2))));
        }
        mean = samples.Mean();
        Assert.True(mean.DecimalDegrees > (middle - (range / 2)));
        Assert.True(mean.DecimalDegrees < (middle + (range / 2)));

        // test mean around 0
        middle = 0;
        samples.Clear();
        for (var i = 0; i < count; i++)
        {
            samples.Add(new Azimuth(_random.Next(middle - (range / 2), middle + (range / 2))));
        }
        mean = samples.Mean();
        if (mean.DecimalDegrees > 270)
        {
            Assert.True(mean.DecimalDegrees > (360 - (range / 2)));
        }
        else
        {
            Assert.True(mean.DecimalDegrees < (0 + (range / 2)));
        }

    }
}