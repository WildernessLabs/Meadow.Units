using System.Text;

namespace Meadow.Units.Generators.Templates;

internal static class IComparableDoubleTemplate
{
    public static string Generate(string typeName, string valueMember)
    {
        return $$"""
    /// <summary>
    /// Compare the default value to a double
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure]
    public int CompareTo(double? other)
    {
        return (other is null) ? -1 : ({{valueMember}}).CompareTo(other.Value);
    }

    /// <summary>
    /// Compare the default value to a double
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double? other) => {{valueMember}}.Equals(other);

    /// <summary>
    /// Compare the default value to a double
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public bool Equals(double other) => {{valueMember}}.Equals(other);

    /// <summary>
    /// Compare the default value to a double
    /// </summary>
    /// <param name="other">value to compare</param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo(double other) => {{valueMember}}.CompareTo(other);

""";
    }
}
