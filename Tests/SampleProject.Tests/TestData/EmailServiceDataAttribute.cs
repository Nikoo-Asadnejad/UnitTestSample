using System.Reflection;
using Xunit.Sdk;

namespace Fundamental.Tests.TestData;

public class EmailServiceNullBodyDataAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new string[] { null };
        yield return new[] { "" };
        yield return new[] { " " };
    }
}