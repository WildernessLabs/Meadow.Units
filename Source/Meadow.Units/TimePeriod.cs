using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a sub-millisecond-capable Time Period
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
public struct TimePeriod :
    IComparable, IFormattable,
    IComparable<TimePeriod>, IComparable<TimeSpan>
{
    private static TimePeriod _zero;

    static TimePeriod()
    {
        _zero = new TimePeriod(0, UnitType.Seconds);
    }

    /// <summary>
    /// Gets a TimePeriod of zero time
    /// </summary>
    public static TimePeriod Zero => _zero;

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="TimePeriod"/> struct with a specified value and unit type.
    /// </summary>
    /// <param name="value">The value of the time period.</param>
    /// <param name="type">The unit type of the value. Default is <see cref="UnitType.Seconds"/>.</param>
    public TimePeriod(double value, UnitType type = UnitType.Seconds)
    {
        Value = TimePeriodConversions.Convert(value, type, UnitType.Seconds);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimePeriod"/> struct from another <see cref="TimePeriod"/>.
    /// </summary>
    /// <param name="timePeriod">The <see cref="TimePeriod"/> to copy.</param>
    public TimePeriod(TimePeriod timePeriod)
    {
        Value = timePeriod.Value;
    }

    /// <summary>
    /// The type of units available to describe the <see cref="TimePeriod"/>.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Represents time in nanoseconds.
        /// </summary>
        Nanoseconds,

        /// <summary>
        /// Represents time in microseconds.
        /// </summary>
        Microseconds,

        /// <summary>
        /// Represents time in milliseconds.
        /// </summary>
        Milliseconds,

        /// <summary>
        /// Represents time in seconds.
        /// </summary>
        Seconds,

        /// <summary>
        /// Represents time in minutes.
        /// </summary>
        Minutes,

        /// <summary>
        /// Represents time in hours.
        /// </summary>
        Hours,

        /// <summary>
        /// Represents time in days.
        /// </summary>
        Days,
    }

    /// <summary>
    /// Gets the time period value in nanoseconds.
    /// </summary>
    public readonly double Nanoseconds => From(UnitType.Nanoseconds);

    /// <summary>
    /// Gets the time period value in microseconds.
    /// </summary>
    public readonly double Microseconds => From(UnitType.Microseconds);

    /// <summary>
    /// Gets the time period value in milliseconds.
    /// </summary>
    public readonly double Milliseconds => From(UnitType.Milliseconds);

    /// <summary>
    /// Gets the time period value in seconds.
    /// </summary>
    public readonly double Seconds => From(UnitType.Seconds);

    /// <summary>
    /// Gets the time period value in minutes.
    /// </summary>
    public readonly double Minutes => From(UnitType.Minutes);

    /// <summary>
    /// Gets the time period value in hours.
    /// </summary>
    public readonly double Hours => From(UnitType.Hours);

    /// <summary>
    /// Gets the time period value in days.
    /// </summary>
    public readonly double Days => From(UnitType.Days);


    /// <summary>
    /// Converts the current <see cref="TimePeriod"/> value to the specified unit type.
    /// </summary>
    /// <param name="convertTo">The unit type to convert to.</param>
    /// <returns>The value of the current <see cref="TimePeriod"/> in the specified unit type.</returns>
    [Pure]
    public readonly double From(UnitType convertTo)
    {
        return TimePeriodConversions.Convert(Value, UnitType.Seconds, convertTo);
    }

    /// <summary>
    /// Creates a new <see cref="TimePeriod"/> from the specified number of seconds.
    /// </summary>
    /// <param name="seconds">The number of seconds.</param>
    /// <returns>A new <see cref="TimePeriod"/> representing the specified number of seconds.</returns>
    [Pure]
    public static TimePeriod FromSeconds(double seconds)
    {
        return new TimePeriod(seconds, UnitType.Seconds);
    }

    /// <summary>
    /// Creates a new <see cref="TimePeriod"/> from the specified number of milliseconds.
    /// </summary>
    /// <param name="milliseconds">The number of milliseconds.</param>
    /// <returns>A new <see cref="TimePeriod"/> representing the specified number of milliseconds.</returns>
    [Pure]
    public static TimePeriod FromMilliseconds(double milliseconds)
    {
        return new TimePeriod(milliseconds, UnitType.Milliseconds);
    }

    /// <summary>
    /// Creates a new <see cref="TimePeriod"/> from the specified number of microseconds.
    /// </summary>
    /// <param name="microseconds">The number of microseconds.</param>
    /// <returns>A new <see cref="TimePeriod"/> representing the specified number of microseconds.</returns>
    [Pure]
    public static TimePeriod FromMicroseconds(double microseconds)
    {
        return new TimePeriod(microseconds, UnitType.Microseconds);
    }

    /// <summary>
    /// Converts the <see cref="TimePeriod"/> to its string representation using the specified format and format provider.
    /// </summary>
    /// <param name="format">A standard or custom format string.</param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <returns>A string representation of the value of the current <see cref="TimePeriod"/> instance.</returns>
    public string ToString(string format, IFormatProvider formatProvider)
    {
        var total = Days;
        var d = Math.Truncate(total);
        total = (total - d) * 24;
        var h = Math.Truncate(total);
        total = (total - h) * 60;
        var m = Math.Truncate(total);
        total = (total - m) * 60;
        var s = Math.Truncate(total);
        return $"{d:N0}:{h:N0}:{m:N0}:{s:N4}";
    }

    /// <summary>
    /// Less than operator to compare two TimePeriod objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <(TimePeriod left, TimePeriod right) => Comparer<double>.Default.Compare(left.Value, right.Value) < 0;

    /// <summary>
    /// Greater than operator to compare two TimePeriod objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >(TimePeriod left, TimePeriod right) => Comparer<double>.Default.Compare(left.Value, right.Value) > 0;

    /// <summary>
    /// Less than or equal operator to compare two TimePeriod objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=(TimePeriod left, TimePeriod right) => Comparer<double>.Default.Compare(left.Value, right.Value) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two TimePeriod objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=(TimePeriod left, TimePeriod right) => Comparer<double>.Default.Compare(left.Value, right.Value) >= 0;

    /// <summary>
    /// Addition operator
    /// </summary>
    /// <param name="left">Left operand</param>
    /// <param name="right">Right operand</param>
    /// <returns>A sum of the two TimePeriods</returns>
    [Pure] public static TimePeriod operator +(TimePeriod left, TimePeriod right) => new(left.Value + right.Value);

    /// <summary>
    /// Subtraction operator
    /// </summary>
    /// <param name="left">Left operand</param>
    /// <param name="right">Right operand</param>
    /// <returns>A difference between the two TimePeriods</returns>
    [Pure] public static TimePeriod operator -(TimePeriod left, TimePeriod right) => new(left.Value - right.Value);

    /// <summary>
    /// Adds the specified <see cref="TimePeriod"/> to the current <see cref="TimePeriod"/>.
    /// </summary>
    /// <param name="period">The <see cref="TimePeriod"/> to add.</param>
    /// <returns>A new <see cref="TimePeriod"/> that is the sum of the current instance and the specified <see cref="TimePeriod"/>.</returns>
    public TimePeriod Add(TimePeriod period)
    {
        return new TimePeriod(Value + period.Value);
    }

    /// <summary>
    /// Compares a TimePeriod to another object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    public int CompareTo(object obj)
    {
        if (obj is TimePeriod t)
        {
            return Value.CompareTo(t.Value);
        }

        throw new ArgumentException("Object is not a TimePeriod");
    }

    /// <summary>
    /// Compares two TimePeriods
    /// </summary>
    /// <param name="other"></param>
    public int CompareTo(TimePeriod other)
    {
        return this.Value.CompareTo(other.Value);
    }

    /// <summary>
    /// Compares a TimePeriod to a TimeSpan
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(TimeSpan other)
    {
        return this.CompareTo((TimePeriod)other);
    }

    /// <summary>
    /// Explicit conversion of a TimeSpan to a TimePeriod
    /// </summary>
    public static explicit operator TimePeriod(TimeSpan timeSpan)
    {
        return TimePeriod.FromSeconds(timeSpan.TotalSeconds);
    }

    /// <summary>
    /// Impplicit conversion of a Timeperiod to a TimeSpan
    /// </summary>
    public static explicit operator TimeSpan(TimePeriod timePeriod)
    {
        return TimeSpan.FromSeconds(timePeriod.Seconds);
    }
}
