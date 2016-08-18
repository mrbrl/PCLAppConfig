Feature: General
	In order to easily manage my application deployments
	As a devops
	I want to be able to read app.config settings


Scenario: Read setting from file system
	Given I am on the main page
	Then I can see a Label with text ""
	When I click on the text button
	Then I can see a Label with text "fs_testvalue"