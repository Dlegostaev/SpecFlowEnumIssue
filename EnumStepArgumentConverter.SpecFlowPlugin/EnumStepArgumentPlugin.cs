using EnumStepArgumentConverter.SpecFlowPlugin;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.UnitTestProvider;

// If you would like to use this plugin, please review it, as it have been copied from
// https://github.com/clrudolphi/EnumDescriptionStepArgumentTransformer sample project made by Chris Rudolphi
[assembly: RuntimePlugin(typeof(EnumStepArgumentPlugin))]

namespace EnumStepArgumentConverter.SpecFlowPlugin;

public class EnumStepArgumentPlugin : IRuntimePlugin
{
    public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters, UnitTestProviderConfiguration unitTestProviderConfiguration)
    {
        runtimePluginEvents.CustomizeTestThreadDependencies += (sender, args) =>
        {
            args.ObjectContainer.RegisterTypeAs<CustomStepArgumentTypeConverter, IStepArgumentTypeConverter>();
        };
    }
}