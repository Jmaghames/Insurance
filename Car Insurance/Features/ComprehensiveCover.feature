Feature: Comprehensive Cover
To compare, select and apply for immediate cover tell us some details about the car you wish to insure.



Background: About your car
    Given I select the Make 'Honda'
    When I select the Model 'Accord'
    Then I select the year '2021'
    And I select the car type or series '10th Gen MY21 VTi-LX Sedan 4dr CVT 1sp 1.5T (5yr Roadside Assist)'
    Then I select the colour 'Beige'


@comprehensive
Scenario: About your car - Comprehensive cover – with factory Fitted Options
    Given I am on the 'What level of cover are you looking for?' page 
    When I select the level of cover 'Comprehensive'
    Then I am on the 'Why are you looking for cover?' page 
    And I select 'I have bought a new car' from the dropdown menu
    Then I am on the 'Does your car have any anti-theft devices?' page
    And I select 'Alarm' from the dropdown menu
    Then I am on the 'Does your car have any factory fitted options?' page
    And I click 'Yes' button
    Then I select 'Standard Paint' factory options from the dropdown menu
    And I click 'Ok' button


@comprehensive
Scenario: About your car - Comprehensive cover – without factory Fitted Options
    Given I am on the 'What level of cover are you looking for?' page 
    When I select the level of cover 'Comprehensive'
    Then I am on the 'Why are you looking for cover?' page 
    And I select 'Just want to compare' from the dropdown menu
    Then I am on the 'Does your car have any anti-theft devices?' page
    And I select 'Immobiliser' from the dropdown menu
    Then I am on the 'Does your car have any factory fitted options?' page
    And I click 'Yes' button
    And I click 'Ok' button
    And I verify the Alert 'Please select an option' is displayed on the page
