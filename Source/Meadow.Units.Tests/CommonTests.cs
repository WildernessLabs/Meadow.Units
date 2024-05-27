using Xunit;
using System;
using System.Linq;
using Meadow.Units;

namespace Meadow.Units.Tests;

public class CommonTests
{
    [Fact]
    public void CompareToObjectOfSameType()
    {
        // find all comparable structs in the assembly
        var testTypes = typeof(Temperature)
            .Assembly
            .GetTypes()
            .Where(t => t.IsValueType && typeof(IComparable).IsAssignableFrom(t))
            .ToArray();

        var failCount = 0;
        var successCount = 0;

        foreach (var t in testTypes)
        {
            var testItemA = Activator.CreateInstance(t);
            var testItemB = Activator.CreateInstance(t);

            try
            {
                var shouldBeZero = (testItemA as IComparable).CompareTo(testItemB);
                Assert.Equal(0, shouldBeZero);
                successCount++;
            }
            catch (Exception)
            {
                failCount++;
            }
        }

        Assert.True(failCount == 0, $"{failCount} out of {failCount + successCount} failed CompareTo(object)");
    }
}
