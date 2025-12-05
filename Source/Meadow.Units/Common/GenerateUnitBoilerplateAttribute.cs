using System;

namespace Meadow.Units;

/// <summary>
/// Marks a unit struct for automatic boilerplate code generation via source generator.
/// </summary>
[AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
internal sealed class GenerateUnitBoilerplateAttribute : Attribute
{
    /// <summary>
    /// Gets or sets the name of the field or property that holds the canonical unit value.
    /// Defaults to "Value".
    /// </summary>
    public string ValueMemberName { get; set; } = "Value";
}
