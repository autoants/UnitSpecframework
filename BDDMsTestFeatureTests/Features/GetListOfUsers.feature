Feature: GetListOfUsers
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@API
Scenario:  GetListOfUsers
Given I have the base url
         | url |
         | https://reqres.in/api/users   |
When I Request or all users in a page
|page |
|    2   |
Then I get user list in the given page
| page |
| 2    |