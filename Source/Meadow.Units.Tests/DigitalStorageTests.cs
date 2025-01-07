using Xunit;

namespace Meadow.Units.Tests;

public class DigitalStorageTests
{
    [Fact]
    public void DigitalStorageOneByteConstructor()
    {
        var one = new DigitalStorage(1, DigitalStorage.UnitType.Bytes);
        Assert.True(one.Bytes == 1);
    }

    [Fact]
    public void DigitalStorageOneKBConstructor()
    {
        var one = new DigitalStorage(1, DigitalStorage.UnitType.KiloBytes);
        Assert.True(one.Bytes == 1000);
        Assert.True(one.Bits == one.Bytes * 8);

        var oneA = new DigitalStorage(1000, DigitalStorage.UnitType.Bytes);
        Assert.True(oneA.KiloBytes == 1);
    }

    [Fact]
    public void DigitalStorageOneKiBConstructor()
    {
        var one = new DigitalStorage(1, DigitalStorage.UnitType.KibiBytes);
        Assert.True(one.Bytes == 1024);
        Assert.True(one.Bits == one.Bytes * 8);

        var oneA = new DigitalStorage(1024, DigitalStorage.UnitType.Bytes);
        Assert.True(oneA.KibiBytes == 1);
        Assert.True(oneA.Kibibits == 0.125);
    }

    [Fact]
    public void DigitalStorageOneMBConstructor()
    {
        var one = new DigitalStorage(1, DigitalStorage.UnitType.MegaBytes);
        Assert.True(one.Bytes == 1000_000);
        Assert.True(one.Bits == one.Bytes * 8);

        var oneA = new DigitalStorage(1000_000, DigitalStorage.UnitType.Bytes);
        Assert.True(oneA.MegaBytes == 1);
    }

    [Fact]
    public void DigitalStorageOneMiBConstructor()
    {
        var one = new DigitalStorage(1, DigitalStorage.UnitType.MebiBytes);
        Assert.True(one.Bytes == 1024 * 1024);
        Assert.True(one.Bits == one.Bytes * 8);

        var oneA = new DigitalStorage(1024 * 1024, DigitalStorage.UnitType.Bytes);
        Assert.True(oneA.MebiBytes == 1);
        Assert.True(oneA.Mebibits == 0.125);
    }

    [Fact]
    public void DigitalStorageOneGBConstructor()
    {
        var one = new DigitalStorage(1, DigitalStorage.UnitType.GigaBytes);
        Assert.True(one.Bytes == 1000_000_000);
        Assert.True(one.Bits == one.Bytes * 8);
    }

    [Fact]
    public void DigitalStorageOneGiBConstructor()
    {
        var one = new DigitalStorage(1, DigitalStorage.UnitType.GibiBytes);
        Assert.True(one.Bytes == 1024 * 1024 * 1024);
        Assert.True(one.Bits == one.Bytes * 8);

        var oneA = new DigitalStorage(1024 * 1024 * 1024, DigitalStorage.UnitType.Bytes);
        Assert.True(oneA.GibiBytes == 1);
    }

    [Fact]
    public void Subtraction()
    {
        var total = new DigitalStorage(30431968, DigitalStorage.UnitType.KibiBytes);
        var available = new DigitalStorage(25975940, DigitalStorage.UnitType.KibiBytes);
        var inUse = new DigitalStorage(4456028, DigitalStorage.UnitType.KibiBytes);

        var testAvailable = total - inUse;
        Assert.Equal(available.Bytes, testAvailable.Bytes);
    }
}
