using Meadow.Units.Serialization;
using System.Text.Json;
using Xunit;

namespace Meadow.Units.Tests;

public partial class SerializationTests
{
    [Fact()]
    public void TemperatureSerialization_SystemText()
    {
        Temperature t1 = 50.Fahrenheit();
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitJsonConverterFactory());

        var json = JsonSerializer.Serialize(t1, options);
        Assert.NotNull(json);
        var t2 = JsonSerializer.Deserialize<Temperature>(json, options);
        Assert.Equal(t1, t2);
    }

    [Fact()]
    public void TemperatureArraySerialization_SystemText()
    {
        var t1 = new Temperature[] { 50.Fahrenheit(), 51.Fahrenheit(), 52.Fahrenheit() };
        var options = new JsonSerializerOptions();
        options.Converters.Add(new UnitJsonConverterFactory());

        var json = JsonSerializer.Serialize(t1, options);
        Assert.NotNull(json);
        var t2 = JsonSerializer.Deserialize<Temperature[]>(json, options);
        Assert.Equal(t1, t2);
    }
}