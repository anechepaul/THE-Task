Feature: Users
	

@agnostic
Scenario: Get list of users
#Test to ensure that i get 200 OK when i send GET request for multiple users
	Given I have a base url 'https://fakerestapi.azurewebsites.net' and endpoint '/api/v1/Users'
	When I send a GET request 
	Then response code is 200
	And response body are:
	| id | userName | password  |
	| 1  | User 1   | Password1 |
	| 2  | User 2   | Password2 |
	| 3  | User 3   | Password3 |
	| 4  | User 4   | Password4 |
	| 5  | User 5   | Password5 |
	| 6  | User 6   | Password6 |
	| 7  | User 7   | Password7 |
	| 8  | User 8   | Password8 |
	| 9  | User 9   | Password9 |
	| 10 | User 10  | Password10|
	

@agnostic
Scenario: Get one single user
#Test to ensure 200 response code is returned when i send single GET user request
	Given I have a base url 'https://fakerestapi.azurewebsites.net' and endpoint '/api/v1/Users/1'
	When I send a GET request 
	Then response code is 200
	And response body is:
	| id | userName | password  |
	| 1  | User 1   | Password1 |

@ResponseDriven
Scenario: Get user which doesnt exist
#Test to ensure a 404 response code is returned when user does not exist
	Given I have a base url 'https://fakerestapi.azurewebsites.net' and endpoint '/api/v1/Users/0'
	When I send a GET request 
	Then response code is 404

@RequestDriven
Scenario: Invalid request verb(type)
#Test to ensure a 405 response code is returned when request verb is invalid to indicate method not allowed
	Given I have a base url 'https://fakerestapi.azurewebsites.net' and endpoint '/api/v1/Users/1'
	When I send a POST request 
	Then response code is 405

@RequestDriven
Scenario: Internal server error
#Test to ensure a 500 response code is returned when endpoint is invalid



@RequestDriven
Scenario: Invalid parameter type
#Test to ensure a 500 response code is returned when endpoint is invalid


@RequestDriven
Scenario: Missing parameter type
#Test to ensure a 500 response code is returned when endpoint is invalid