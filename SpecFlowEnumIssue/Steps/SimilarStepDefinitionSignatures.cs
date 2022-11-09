using SpecFlowEnumIssue.Enum;

namespace SpecFlowEnumIssue.Steps;

[Binding]
public class SimilarStepDefinitionSignatures
{
    [When(@"I use step with {FirstDefinition} with closed signature")]
    public void WhenIUseStepWithDefinition(FirstDefinition similarFirstDefinition)
    {
    }
    
    [When(@"I use step with Similar {FirstDefinition} with closed signature")]
    public void WhenIUseStepWithSimilarDefinition(FirstDefinition firstDefinition)
    {
    }
}