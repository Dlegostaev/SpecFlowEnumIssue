This project was made to reproduce the issue:
https://github.com/SpecFlowOSS/SpecFlow/issues/2669

In the **_plugin_** branch you can see current implementation of solution. If you would like to use it, please, pay attention to my comments and made a review of code you are copying, because it was not fully tested by me, and most of it was written just for PoC and for reference. Same statement is also applicable to the project structure and code styling.

In the **_plugin_error_** branch you can see an example of incorrect exception throwing from method intented to be used for conversion in CustomStepArgumentTypeConverter

Here are some screenshots representing original issue

## DefaultEnumTransform
![image](https://user-images.githubusercontent.com/24895280/199183827-eb1a923c-77d4-4f97-8d93-0a63002d155e.png)

## CustomEnumTransform
![image](https://user-images.githubusercontent.com/24895280/199183775-27fbcd10-47a5-4496-89b8-91bea129880e.png)

## DefaultEnumTransformRegex
![image](https://user-images.githubusercontent.com/24895280/199183852-de2a5461-4946-413e-b78e-555ee216fa51.png)
