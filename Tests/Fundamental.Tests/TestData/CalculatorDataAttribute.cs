using System.Reflection;
using Xunit.Sdk;

namespace Fundamental.Tests.TestData;

public class CalculatorDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod) 
    {
        yield return new object[] { 3, true };
        yield return new object[] { 2, false };
        yield return new object[] { 0, false };
        yield return new object[] { -3, true };
        yield return new object[] { -2, false };
    }
}