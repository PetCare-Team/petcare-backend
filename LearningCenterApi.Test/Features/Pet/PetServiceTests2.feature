Feature: PetServiceTests2
As a Developer
I want to add new Pet through API
In order to make it available for applications.
	Background:
		Given the Endpoint https://localhost:5013/api/v1/pet is available
	@Pet-adding
	Scenario: Add Tutorial 
		When a Post Request is sent 
		  | Name  | Description  | Castrado | User Id |
		  | Bobby | soy un perro | 1        | 1       |
		Then A Response is received with Status 201
		And a Pet Resource is included in Response Body
		  | Id | Name  | Description  | Castrado | User Id |
		  | 1  | Bobby | soy un perro | 1        | 1       |
	@tutorial-adding
	Scenario: Database has an error to store
		Given a Post Request is sent 
		  | Name  | Description  | Castrado | User Id |
		  | Bobby | soy un perro | 1        | 1       |
		When is something wrong with the database
		Then A Response is received with Status 500
		And An Error Message is returned with value "An error has ocurred to connect with the server"