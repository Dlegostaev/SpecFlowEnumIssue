Feature: DefaultEnumTransformRegex

  Scenario: Check regular
    When I choose Regular enum option - Default Transform Regex

  Scenario: Check two words
    When I choose Two Words enum option - Default Transform Regex

  Scenario: Check special character
    When I choose Special!Character enum option - Default Transform Regex

  Scenario: Check non matching description and enum name
    When I choose Non Matching enum option - Default Transform Regex