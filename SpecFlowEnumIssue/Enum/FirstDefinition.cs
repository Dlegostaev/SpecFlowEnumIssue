using System.ComponentModel;

namespace SpecFlowEnumIssue.Enum;

public enum FirstDefinition
{
    [Description("Definition")] NonMatchingToDescriptionMember
}