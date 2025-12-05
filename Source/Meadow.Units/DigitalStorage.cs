using Meadow.Units.Conversions;
using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units;

/// <summary>
/// Represents a value of Digital Storage.
/// </summary>
[Serializable]
[ImmutableObject(true)]
[StructLayout(LayoutKind.Sequential)]
[GenerateUnitBoilerplate]
public partial struct DigitalStorage :
    IUnit<DigitalStorage, DigitalStorage.UnitType>,
    IComparable, IFormattable, IConvertible,
    IEquatable<double>, IComparable<double>
{
    private static readonly DigitalStorage _zero;

    static DigitalStorage()
    {
        _zero = new DigitalStorage(0, UnitType.Bytes);
    }

    /// <summary>
    /// Gets a DigitalStorage with a zero value
    /// </summary>
    public static DigitalStorage Zero => _zero;

    /// <summary>
    /// Creates a new <see cref="DigitalStorage"/> object.
    /// </summary>
    /// <param name="value">The DigitalStorage value.</param>
    /// <param name="type">Bytes by default.</param>
    public DigitalStorage(double value, UnitType type = UnitType.Bytes)
    {
        Value = DigitalStorageConversions.Convert(value, type, UnitType.Bytes);
    }

    /// <summary>
    /// Creates a new <see cref="DigitalStorage"/> object from an existing DigitalStorage object
    /// </summary>
    /// <param name="DigitalStorage"></param>
    public DigitalStorage(DigitalStorage DigitalStorage)
    {
        Value = DigitalStorage.Value;
    }

    /// <summary>
    /// Internal canonical value.
    /// </summary>
    private readonly double Value;

    /// <summary>
    /// The type of units available to describe the DigitalStorage.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        /// Represents a unit of data size in bits
        /// </summary>
        Bits,
        /// <summary>
        /// Represents a unit of data size in bytes
        /// </summary>
        Bytes,
        /// <summary>
        /// Represents a unit of data size in kilobytes (KB)
        /// </summary>
        KiloBytes,
        /// <summary>
        /// Represents a unit of data size in megabytes (MB)
        /// </summary>
        MegaBytes,
        /// <summary>
        /// Represents a unit of data size in gigabytes (GB)
        /// </summary>
        GigaBytes,
        /// <summary>
        /// Represents a unit of data size in terabytes (TB)
        /// </summary>
        TeraBytes,
        /// <summary>
        /// Represents a unit of data size in petabytes (PB)
        /// </summary>
        PetaBytes,
        /// <summary>
        /// Represents a unit of data size in exabytes (EB)
        /// </summary>
        ExaBytes,
        /// <summary>
        /// Represents a unit of data size in kibibytes (KiB)
        /// </summary>
        KibiBytes,
        /// <summary>
        /// Represents a unit of data size in kibibits (Kib)
        /// </summary>
        Kibibits,
        /// <summary>
        /// Represents a unit of data size in mebibytes (MiB)
        /// </summary>
        MebiBytes,
        /// <summary>
        /// Represents a unit of data size in mebibits (Mib)
        /// </summary>
        Mebibits,
        /// <summary>
        /// Represents a unit of data size in gibibytes (GiB)
        /// </summary>
        GibiBytes,
    }

    /// <summary>
    /// Creates a DigitalStorage instance from a canonical (Bytes) value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DigitalStorage FromCanonical(double value)
    {
        return new DigitalStorage(value, UnitType.Bytes);
    }

    /// <summary>
    /// Gets the value of the DigitalStorage in Canonical (Bytes) units
    /// </summary>
    /// <returns></returns>
    public double ToCanonical()
    {
        return Value;
    }

    /// <inheritdoc/>
    public UnitType GetCanonicalUnitType() => UnitType.Bytes;

    /// <summary>
    /// Get DigitalStorage in bits
    /// </summary>
    public double Bits => From(UnitType.Bits);

    /// <summary>
    /// Get DigitalStorage in bytes
    /// </summary>
    public double Bytes => From(UnitType.Bytes);

    /// <summary>
    /// Get DigitalStorage in kilobytes (KB)
    /// </summary>
    public double KiloBytes => From(UnitType.KiloBytes);

    /// <summary>
    /// Get DigitalStorage in megabytes (MB)
    /// </summary>
    public double MegaBytes => From(UnitType.MegaBytes);

    /// <summary>
    /// Get DigitalStorage in gigabytes (GB)
    /// </summary>
    public double GigaBytes => From(UnitType.GigaBytes);

    /// <summary>
    /// Get DigitalStorage in terabytes (TB)
    /// </summary>
    public double TeraBytes => From(UnitType.TeraBytes);

    /// <summary>
    /// Get DigitalStorage in petabytes (PB)
    /// </summary>
    public double PetaBytes => From(UnitType.PetaBytes);

    /// <summary>
    /// Get DigitalStorage in exabytes (EB)
    /// </summary>
    public double ExaBytes => From(UnitType.ExaBytes);

    /// <summary>
    /// Get DigitalStorage in kibibytes (KiB)
    /// </summary>
    public double KibiBytes => From(UnitType.KibiBytes);

    /// <summary>
    /// Get DigitalStorage in kibibits (Kibit)
    /// </summary>
    public double Kibibits => From(UnitType.Kibibits);

    /// <summary>
    /// Get DigitalStorage in mebibits (MiB)
    /// </summary>
    public double MebiBytes => From(UnitType.MebiBytes);

    /// <summary>
    /// Get DigitalStorage in mebibits (Mib)
    /// </summary>
    public double Mebibits => From(UnitType.Mebibits);

    /// <summary>
    /// Get DigitalStorage in gibibytes (GiB)
    /// </summary>
    public double GibiBytes => From(UnitType.GibiBytes);

    /// <summary>
    /// Convert to a specific unit
    /// </summary>
    /// <param name="convertTo">the unit to convert to</param>
    /// <returns></returns>
    [Pure]
    public double From(UnitType convertTo)
    {
        return DigitalStorageConversions.Convert(Value, UnitType.Bytes, convertTo);
    }

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <returns>A string representing the object</returns>
    [Pure] public override string ToString() => Value.ToString();

    /// <summary>
    /// Get a string representation of the object
    /// </summary>
    /// <param name="format">format</param>
    /// <param name="formatProvider">format provider</param>
    /// <returns>A string representing the object</returns>
    [Pure] public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);

    // IComparable
    /// <summary>
    /// Compare to another DigitalStorage object
    /// </summary>
    /// <param name="obj">The other DigitalStorage cast to object</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(object obj)
    {
        if (obj is DigitalStorage digitalStorage)
        {
            return Value.CompareTo(digitalStorage.Value);
        }

        throw new ArgumentException("Object is not a DigitalStorage");
    }
}