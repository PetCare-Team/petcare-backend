Feature: PetServiceTests
As a Developer
I want to update a Pet through API
In order to make it available for applications.
	Background:
		Given the Endpoint https://localhost:5013/api/v1/pet/{id} is available
	@pet-update
	Scenario: Update a Pet stored in the database
		Given A Pet Id is found
		  | Id |
		  | 1  |
		When a Put Request is sent
		  | Name  | Description       | Castrado |
		  | Bobby | soy un perro | 1          |
		Then A Response is received with Status 200
		And a Tutorial Resource is included in Response Body
		  | Id | Title  | Description       | Castrado |
		  | 1  | Bobby | Soy un perro | 1          |
	@pet-update
	Scenario: Pet that want to update isn't stored in the database
		Given A Pet Id is not found
		  | Id |
		  | 1  |
		When a Post Request is sent
		  | Name  | Description  | Castrado |
		  | Bobby | soy un perro | 1        |
		Then A Response is received with Status 400
		And An Error Message is returned with value "Pet doesn't exists."