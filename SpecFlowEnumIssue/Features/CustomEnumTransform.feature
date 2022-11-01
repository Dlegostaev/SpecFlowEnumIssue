Feature: CustomEnumTransform

  Scenario: Check regular
    When I choose Regular enum option - Custom Transform

  Scenario: Check two words
    When I choose Two Words enum option - Custom Transform

  Scenario: Check special character
    When I choose Special!Character enum option - Custom Transform

  Scenario: Check non matching description and enum name
    When I choose Non Matching enum option - Custom Transform