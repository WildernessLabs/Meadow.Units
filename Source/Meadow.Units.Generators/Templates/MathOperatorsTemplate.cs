using System.Text;

namespace Meadow.Units.Generators.Templates;

internal static class MathOperatorsTemplate
{
    public static string Generate(string typeName, string valueMember)
    {
        return $$"""
    /// <summary>
    /// Addition operator to add two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new {{typeName}} object with a value of left + right</returns>
    [Pure] public static {{typeName}} operator +({{typeName}} left, {{typeName}} right) => new(left.{{valueMember}} + right.{{valueMember}});

    /// <summary>
    /// Subtraction operator to subtract two {{typeName}} objects
    /// </summary>
    /// <param name="left">left value</param>
    /// <param name="right">right value</param>
    /// <returns>A new {{typeName}} object with a value of left - right</returns>
    [Pure] public static {{typeName}} operator -({{typeName}} left, {{typeName}} right) => new(left.{{valueMember}} - right.{{valueMember}});

    /// <summary>
    /// Multiplication operator to multiply by a double
    /// </summary>
    /// <param name="value">object to multiply</param>
    /// <param name="operand">operand to multiply object</param>
    /// <returns>A new {{typeName}} object with a value of value multiplied by the operand</returns>
    [Pure] public static {{typeName}} operator *({{typeName}} value, double operand) => new(value.{{valueMember}} * operand);

    /// <summary>
    /// Division operator to divide by a double
    /// </summary>
    /// <param name="value">object to be divided</param>
    /// <param name="operand">operand to divide object</param>
    /// <returns>A new {{typeName}} object with a value of value divided by the operand</returns>
    [Pure] public static {{typeName}} operator /({{typeName}} value, double operand) => new(value.{{valueMember}} / operand);

    /// <summary>
    /// Returns the absolute value of the <see cref="{{typeName}}"/>
    /// </summary>
    /// <returns></returns>
    [Pure] public {{typeName}} Abs() { return new {{typeName}}(Math.Abs({{valueMember}})); }

""";
    }
}
