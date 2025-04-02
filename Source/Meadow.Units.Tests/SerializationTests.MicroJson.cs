using Meadow.Foundation.Serialization;
using Meadow.Units.Serialization;
using Xunit;

namespace Meadow.Units.Tests;

public partial class SerializationTests
{
    [Fact()]
    public void TemperatureSerializationMicroJson()
    {
        var strategy = new MicroJsonUnitJsonConverter();
        Temperature t1 = 50.Fahrenheit();
        var json = MicroJson.Serialize(t1, serializationStrategy: strategy);
        Assert.NotNull(json);
        var t2 = MicroJson.Deserialize<Temperature>(json, strategy);
        Assert.Equal(t1, t2);
    }

    [Fact()]
    public void TemperatureArraySerializationMicroJson()
    {
        var strategy = new MicroJsonUnitJsonConverter();
        var t1 = new Temperature[] { 50.Fahrenheit(), 51.Fahrenheit(), 52.Fahrenheit() };
        var json = MicroJson.Serialize(t1, serializationStrategy: strategy);
        Assert.NotNull(json);
        var t2 = MicroJson.Deserialize<Temperature[]>(json, strategy);
        Assert.Equal(t1, t2);
    }
}