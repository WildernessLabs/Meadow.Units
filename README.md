<img src="Design/meadow.units.jpg" alt="iot, dotnet, meadow, meadow-units" style="margin-bottom:10px" />

# Meadow.Units

This repo contains a strong unitization into the entire stack of Meadow. No more ambiguous `float` returns for temperature, pressure, distance, voltage, or other units. Instead sensors return strongly-typed units such as `Temperature` and `Voltage`, with properties that do automatic conversions to the various representations, such as `Celsius` or `Fahrenheit`.

## Contents
* [Using unitization](#using-unitization)
* [Nullable Everywhere](#nullable-everywhere)
* [Unit types](#unit-types)
* [Unit Conversions](#unit-conversions)

## Using unitization

Consider the following `AnalogTemperature` sensor sample:

```csharp
analogTemperature.TemperatureUpdated += (object sender, IChangeResult<Temperature> result) => 
{
    Console.WriteLine($"Temp Changed, temp: {result.New.Celsius:N2}C, old: {result.Old?.Celsius:N2}C");
};
```

When the `TemperatureUpdated` event is raised, it passes an `IChangeResult<Temperature>` parameter. That result has a `New` and `Old` property of type `Temperature`, whose value can be accessed via a direct conversion to `Celsius`, `Fahrenheit`, or `Kelvin` on properties of the same name.

## Nullable Everywhere

Not also that Meadow fully embraces C# 8’s nullable features, so the result’s `Old` property is nullable, and in fact, on the first reading, it will be `null` because there isn’t a previous reading to populate it with.

## Unit types

We've added a number of unit types that describe a measure of something, including:

 * `AbsoluteHumidity`
 * `Acceleration`
 * `Acceleration3D`
 * `Angle`
 * `AngularAcceleration`
 * `AngularAcceleration3D`
 * `AngularVelocity`
 * `Azimuth`
 * `Concentration`
 * `Current`
 * `Density`
 * `Energy`
 * `Frequency`
 * `Illuminance`
 * `Length`
 * `MagneticField`
 * `MagneticField3D`
 * `Mass`
 * `Power`
 * `Pressure`
 * `RelativeHumidity`
 * `Speed`
 * `Temperature`
 * `Torque`
 * `Voltage`
 * `Volume`

 ## Unit Conversions

 Each of these units have an enum of `UnitTypes` that they can be described as, as well as accessed as, via properties.

For instance the `Temperature` type has properties such as `Fahrenheit`, `Celsius`, `Kelvin`, etc. that allow you to access the unit value, converted to that particular `UnitType`. Consider the following code:

```csharp
var temp = new Temperature(32, UnitType.Fahrenheit);
Console.WriteLine($"{temp.Celsius:N2}C"); // outputs `0C`
Console.WriteLine($"{temp.Fahrenheit:N2}F"); // outputs `32F`
```

The units are all lightweight `struct` types which help to reduce heap allocations (when not boxed by Nullable), and have built in math operator and comparison support so you can perform math operations and comparison such as:

```csharp
Temperature t1 = new Temperature(1);
Temperature t2 = new Temperature(10);
Assert.That(t1 != t2);
Assert.That((t1 + t2) == new Temperature(11));
Assert.That((t2 - t1) == new Temperature(9));
Assert.That(t1 < t2);
```