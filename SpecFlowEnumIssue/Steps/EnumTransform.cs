using SpecFlowEnumIssue.Enum;
using SpecFlowEnumIssue.Utils;
using Xunit;

namespace SpecFlowEnumIssue.Steps;

[Binding]
public sealed class EnumTransform
{
    private readonly ScenarioContext _scenarioContext;

    public EnumTransform(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"I choose {TestOptions} enum option - Default Transform")]
    public void WhenIChooseTestOptionsEnumOptionDefaultTransform(TestOptions option)
    {
        Console.WriteLine(option);  // No assert needed
    }
    
    [When(@"I choose (.*) enum option - Custom Transform")]
    public void WhenIChooseEnumOptionCustomTransform(string option)
    {
        TestOptions? optionEnumExpected = null;
        switch (option)
        {
            case "Regular":
                optionEnumExpected = TestOptions.Regular;
                break;
            case "Two Words":
                optionEnumExpected = TestOptions.TwoWords;
                break;
            case "Special!Character":
                optionEnumExpected = TestOptions.SpecialCharacter;
                break;
            case "Non Matching":
                optionEnumExpected = TestOptions.NonSense;
                break;
        }
        var optionEnumActual = option.AsEnum<TestOptions>();
        Assert.Equal(optionEnumExpected, optionEnumActual);
    }

    [When(@"^I choose (.*) enum option - Default Transform Regex")]
    public void WhenIChooseEnumOptionDefaultTransformRegex(TestOptions option)
    {
        Console.WriteLine(option);  // No assert needed
    }
}