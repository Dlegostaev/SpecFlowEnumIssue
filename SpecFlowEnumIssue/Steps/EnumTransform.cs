using SpecFlowEnumIssue.Enum;

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

    [When(@"^I choose (.*) enum option - Default Transform Regex")]
    public void WhenIChooseEnumOptionDefaultTransformRegex(TestOptions option)
    {
        Console.WriteLine(option);  // No assert needed
    }
}