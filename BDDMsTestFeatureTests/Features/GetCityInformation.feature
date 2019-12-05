Feature: GetCityInformation
	In order to go for a tour in US
	As a tourist
	I want to get the information of a city

@GetMethodByResource
Scenario: GetCityInformation
	Given I have the base url
	| url                         |
	| http://api.zippopotam.us/us/ |
	When I request the city information using zipcode
	| zipcode |
	| 27513   |
	Then the server returns the response with the city information
	| city |
	| Cary |
@GetMethodByQueryString
Scenario:  GetListOfUsers
Given I have the base url
         | url |
         | https://reqres.in/api/   |
When I Request or all users in a page
| user | page |
|  users    |   2   |
Then I get user list in the given page
| page |
| 2    |
