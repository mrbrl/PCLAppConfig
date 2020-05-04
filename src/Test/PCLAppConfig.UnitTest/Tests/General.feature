Feature: General
	In order to easily manage my application deployments
	As a devops
	I want to be able to read app.config settings

Scenario: Read setting from file system
	Given I navigate to the "MainPage" view
	Then I can see a label "ConfigText" with text ""
	When I click on "PclSetting" button
	Then I can see a label "ConfigText" with text "fs_testvalue"