using Meadow.Units.Conversions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Meadow.Units
{
    /// <summary>
    /// Represents a value of Digital Storage.
    /// </summary>
    [Serializable]
    [ImmutableObject(true)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DigitalStorage :
        IComparable, IFormattable, IConvertible,
        IEquatable<double>, IComparable<double>
    {
        /// <summary>
        /// Creates a new `DigitalStorage` object.
        /// </summary>
        /// <param name="value">The DigitalStorage value.</param>
        /// <param name="type">Bytes by default.</param>
        public DigitalStorage(double value, UnitType type = UnitType.Bytes)
        {
            Value = DigitalStorageConversions.Convert(value, type, UnitType.Bytes);
        }

        /// <summary>
        /// Creates a new `DigitalStorage` object from an existing DigitalStorage object
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
            /// Represents a unit of data size in kibibits (Kibit)
            /// </summary>
            Kibibits,
            /// <summary>
            /// Represents a unit of data size in mebibits (Mibit)
            /// </summary>
            Mebibits,
            /// <summary>
            /// Represents a unit of data size in gibibits (Gibit)
            /// </summary>
            Gibibits,
        }

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
        /// Get DigitalStorage in kibibits (Kibit)
        /// </summary>
        public double Kibibits => From(UnitType.Kibibits);

        /// <summary>
        /// Get DigitalStorage in mebibits (Mibit)
        /// </summary>
        public double Mebibits => From(UnitType.Mebibits);

        /// <summary>
        /// Get DigitalStorage in gibibits (Gibit)
        /// </summary>
        public double Gibibits => From(UnitType.Gibibits);

        /// <summary>
        /// Convert to a specific unit
        /// </summary>
        /// <param name="convertTo">the unit to convert to</param>
        /// <returns></returns>
        [Pure]
        public double From(UnitType convertTo)
        {
            return DigitalStorageConversions.Convert(Value, DigitalStorage.UnitType.Bytes, convertTo);
        }

        /// <summary>
        /// Compare to another DigitalStorage object
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>true if equal</returns>
        [Pure]
        public override bool Equals(object obj)
        {
            if (obj is null) { return false; }
            if (Equals(this, obj)) { return true; }
            return obj.GetType() == GetType() && Equals((DigitalStorage)obj);
        }

        /// <summary>
        /// Get hash of object
        /// </summary>
        /// <returns>int32 hash value</returns>
        [Pure] public override int GetHashCode() => Value.GetHashCode();

        // implicit conversions
        //[Pure] public static implicit operator DigitalStorage(ushort value) => new DigitalStorage(value);
        //[Pure] public static implicit operator DigitalStorage(short value) => new DigitalStorage(value);
        //[Pure] public static implicit operator DigitalStorage(uint value) => new DigitalStorage(value);
        //[Pure] public static implicit operator DigitalStorage(long value) => new DigitalStorage(value);
        //[Pure] public static implicit operator DigitalStorage(int value) => new DigitalStorage(value);
        //[Pure] public static implicit operator DigitalStorage(float value) => new DigitalStorage(value);
        //[Pure] public static implicit operator DigitalStorage(double value) => new DigitalStorage(value);
        //[Pure] public static implicit operator DigitalStorage(decimal value) => new DigitalStorage((double)value);

        // Comparison
        /// <summary>
        /// Compare to another DigitalStorage object
        /// </summary>
        /// <param name="other">The object to compare</param>
        /// <returns>true if equal</returns>
        [Pure] public bool Equals(DigitalStorage other) => Value == other.Value;

        /// <summary>
        /// Equals operator to compare two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if equal</returns>
        [Pure] public static bool operator ==(DigitalStorage left, DigitalStorage right) => Equals(left.Value, right.Value);

        /// <summary>
        /// Not equals operator to compare two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if not equal</returns>
        [Pure] public static bool operator !=(DigitalStorage left, DigitalStorage right) => !Equals(left.Value, right.Value);

        /// <summary>
        /// Compare to another DigitalStorage object
        /// </summary>
        /// <param name="other"></param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(DigitalStorage other) => Equals(Value, other.Value) ? 0 : Value.CompareTo(other.Value);

        /// <summary>
        /// Less than operator to compare two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is less than right</returns>
        [Pure] public static bool operator <(DigitalStorage left, DigitalStorage right) => Comparer<double>.Default.Compare(left.Value, right.Value) < 0;

        /// <summary>
        /// Greater than operator to compare two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is greater than right</returns>
        [Pure] public static bool operator >(DigitalStorage left, DigitalStorage right) => Comparer<double>.Default.Compare(left.Value, right.Value) > 0;

        /// <summary>
        /// Less than or equal operator to compare two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is less than or equal to right</returns>
        [Pure] public static bool operator <=(DigitalStorage left, DigitalStorage right) => Comparer<double>.Default.Compare(left.Value, right.Value) <= 0;

        /// <summary>
        /// Greater than or equal operator to compare two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>true if left is greater than or equal to right</returns>
        [Pure] public static bool operator >=(DigitalStorage left, DigitalStorage right) => Comparer<double>.Default.Compare(left.Value, right.Value) >= 0;

        // Math
        /// <summary>
        /// Addition operator to add two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>A new DigitalStorage object with a value of left + right</returns>
        [Pure] public static DigitalStorage operator +(DigitalStorage left, DigitalStorage right) => new(left.Value + right.Value);

        /// <summary>
        /// Subtraction operator to subtract two DigitalStorage objects
        /// </summary>
        /// <param name="left">left value</param>
        /// <param name="right">right value</param>
        /// <returns>A new DigitalStorage object with a value of left - right</returns>
        [Pure] public static DigitalStorage operator -(DigitalStorage left, DigitalStorage right) => new(left.Value - right.Value);

        /// <summary>
        /// Multiplication operator to multiply by a double
        /// </summary>
        /// <param name="value">object to multiply</param>
        /// <param name="operand">operand to multiply object</param>
        /// <returns>A new DigitalStorage object with a value of value multiplied by the operand</returns>
        [Pure] public static DigitalStorage operator *(DigitalStorage value, double operand) => new(value.Value * operand);

        /// <summary>
        /// Division operator to divide by a double
        /// </summary>
        /// <param name="value">object to be divided</param>
        /// <param name="operand">operand to divide object</param>
        /// <returns>A new DigitalStorage object with a value of value divided by the operand</returns>
        [Pure] public static DigitalStorage operator /(DigitalStorage value, double operand) => new(value.Value / operand);

        /// <summary>
        /// Returns the absolute value of the <see cref="DigitalStorage"/>
        /// </summary>
        /// <returns></returns>
        [Pure] public DigitalStorage Abs() { return new DigitalStorage(Math.Abs(this.Value)); }

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
        [Pure] public int CompareTo(object obj) => Value.CompareTo(obj);

        /// <summary>
        /// Get type code of object
        /// </summary>
        /// <returns>The TypeCode</returns>
        [Pure] public TypeCode GetTypeCode() => Value.GetTypeCode();

        /// <summary>
        /// Convert to boolean
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>bool representation of the object</returns>
        [Pure] public bool ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

        /// <summary>
        /// Convert to byte
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>byte representation of the object</returns>
        [Pure] public byte ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

        /// <summary>
        /// Convert to char
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>char representation of the object</returns>
        [Pure] public char ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

        /// <summary>
        /// Convert to DateTime
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>DateTime representation of the object</returns>
        [Pure] public DateTime ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

        /// <summary>
        /// Convert to Decimal
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>Decimal representation of the object</returns>
        [Pure] public decimal ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

        /// <summary>
        /// Convert to double
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>double representation of the object</returns>
        [Pure] public double ToDouble(IFormatProvider provider) => Value;

        /// <summary>
        /// Convert to in16
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int16 representation of the object</returns>
        [Pure] public short ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

        /// <summary>
        /// Convert to int32
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int32 representation of the object</returns>
        [Pure] public int ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

        /// <summary>
        /// Convert to int64
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>int64 representation of the object</returns>
        [Pure] public long ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

        /// <summary>
        /// Convert to sbyte
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>sbyte representation of the object</returns>
        [Pure] public sbyte ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

        /// <summary>
        /// Convert to float
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>float representation of the object</returns>
        [Pure] public float ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>string representation of the object</returns>
        [Pure] public string ToString(IFormatProvider provider) => Value.ToString(provider);

        /// <summary>
        /// Convert to type
        /// </summary>
        /// <param name="conversionType">conversion unit type</param>
        /// <param name="provider">format provider</param>
        /// <returns>type representation of the object</returns>
        [Pure] public object ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToType(conversionType, provider);

        /// <summary>
        /// Convert to uint16
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint16 representation of the object</returns>
        [Pure] public ushort ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

        /// <summary>
        /// Convert to uint32
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint32 representation of the object</returns>
        [Pure] public uint ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

        /// <summary>
        /// Convert to uint64
        /// </summary>
        /// <param name="provider">format provider</param>
        /// <returns>uint64 representation of the object</returns>
        [Pure] public ulong ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure]
        public int CompareTo(double? other)
        {
            return (other is null) ? -1 : (Value).CompareTo(other.Value);
        }

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public bool Equals(double? other) => Value.Equals(other);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public bool Equals(double other) => Value.Equals(other);

        /// <summary>
        /// Compare the default value to a double 
        /// </summary>
        /// <param name="other">value to compare</param>
        /// <returns>0 if equal</returns>
        [Pure] public int CompareTo(double other) => Value.CompareTo(other);
    }
}