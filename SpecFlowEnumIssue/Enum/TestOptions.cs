using System.ComponentModel;

namespace SpecFlowEnumIssue.Enum;

public enum TestOptions
{
    [Description("Regular")] Regular,
    [Description("Two Words")] TwoWords,
    [Description("Special!Character")] SpecialCharacter,
    [Description("Non Matching")] NonSense
}