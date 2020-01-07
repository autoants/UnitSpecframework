Feature: GetCityInformation
	In order to go for a tour in US
	As a tourist
	I want to get the information of a city

@API
Scenario: GetCityInformation
	Given I have the base api for us cities
	| url                         |
	| http://api.zippopotam.us/us/ |
	When I request the city information using zipcode
	| zipcode |
	| 27513   |
	Then the server returns the response with the city information
	| city |
	| Cary |

