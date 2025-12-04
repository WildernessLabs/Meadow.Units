using System.Text;

namespace Meadow.Units.Generators.Templates;

internal static class EqualityMethodsTemplate
{
    public static string Generate(string typeName, string valueMember)
    {
        return $$"""
    /// <summary>
    /// Compare to another {{typeName}} object
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public override bool Equals(object obj) => CompareTo(obj) == 0;

    /// <summary>
    /// Get hash of object
    /// </summary>
    /// <returns>int32 hash value</returns>
    [Pure] public override int GetHashCode() => {{valueMember}}.GetHashCode();

    /// <summary>
    /// Compare to another {{typeName}} object
    /// </summary>
    /// <param name="other">The object to compare</param>
    /// <returns>true if equal</returns>
    [Pure] public bool Equals({{typeName}} other) => {{valueMember}} == other.{{valueMember}};

    /// <summary>
    /// Equals operator to compare two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if equal</returns>
    [Pure] public static bool operator ==({{typeName}} left, {{typeName}} right) => Equals(left.{{valueMember}}, right.{{valueMember}});

    /// <summary>
    /// Not equals operator to compare two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if not equal</returns>
    [Pure] public static bool operator !=({{typeName}} left, {{typeName}} right) => !Equals(left.{{valueMember}}, right.{{valueMember}});

    /// <summary>
    /// Compare to another {{typeName}} object
    /// </summary>
    /// <param name="other"></param>
    /// <returns>0 if equal</returns>
    [Pure] public int CompareTo({{typeName}} other) => Equals({{valueMember}}, other.{{valueMember}}) ? 0 : {{valueMember}}.CompareTo(other.{{valueMember}});

""";
    }
}
