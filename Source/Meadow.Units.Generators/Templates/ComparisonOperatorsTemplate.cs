using System.Text;

namespace Meadow.Units.Generators.Templates;

internal static class ComparisonOperatorsTemplate
{
    public static string Generate(string typeName, string valueMember)
    {
        return $$"""
    /// <summary>
    /// Less than operator to compare two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than right</returns>
    [Pure] public static bool operator <({{typeName}} left, {{typeName}} right) => Comparer<double>.Default.Compare(left.{{valueMember}}, right.{{valueMember}}) < 0;

    /// <summary>
    /// Greater than operator to compare two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than right</returns>
    [Pure] public static bool operator >({{typeName}} left, {{typeName}} right) => Comparer<double>.Default.Compare(left.{{valueMember}}, right.{{valueMember}}) > 0;

    /// <summary>
    /// Less than or equal operator to compare two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is less than or equal to right</returns>
    [Pure] public static bool operator <=({{typeName}} left, {{typeName}} right) => Comparer<double>.Default.Compare(left.{{valueMember}}, right.{{valueMember}}) <= 0;

    /// <summary>
    /// Greater than or equal operator to compare two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>true if left is greater than or equal to right</returns>
    [Pure] public static bool operator >=({{typeName}} left, {{typeName}} right) => Comparer<double>.Default.Compare(left.{{valueMember}}, right.{{valueMember}}) >= 0;

""";
    }
}
