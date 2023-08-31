using Xunit;

namespace Meadow.Units.Tests;

public class ConcentrationTests
{
    [Fact()]
    public void ConversionTests()
    {
        var pph = new Concentration(1, Concentration.UnitType.PartsPerHundred);
        Assert.Equal(1, pph.PartsPerHundred);
        Assert.Equal(10, pph.PartsPerThousand);
        Assert.Equal(10000, pph.PartsPerMillion);
        Assert.Equal(10000000, pph.PartsPerBillion);

        var ppt = new Concentration(1, Concentration.UnitType.PartsPerThousand);
        Assert.Equal(0.1, ppt.PartsPerHundred);
        Assert.Equal(1, ppt.PartsPerThousand);
        Assert.Equal(1000, ppt.PartsPerMillion);
        Assert.Equal(1000000, ppt.PartsPerBillion);

        var ppm = new Concentration(1, Concentration.UnitType.PartsPerMillion);
        Assert.Equal(0.0001, ppm.PartsPerHundred);
        Assert.Equal(0.001, ppm.PartsPerThousand);
        Assert.Equal(1, ppm.PartsPerMillion);
        Assert.Equal(1000, ppm.PartsPerBillion);

        var ppb = new Concentration(1, Concentration.UnitType.PartsPerBillion);
        Assert.Equal(1, ppb.PartsPerBillion);
        Assert.Equal(0.001, ppb.PartsPerMillion);
        Assert.Equal(0.000001, ppb.PartsPerThousand);
        Assert.Equal(0.0000001, ppb.PartsPerHundred);
    }
}
