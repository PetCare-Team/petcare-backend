Feature: PaymentServiceTests
    As a Developer
    I want to post a payment through API
    In order to make it available for application
    Background: 
        Given the Endpoint https://localhost:5013/api/v1/payment is available
        @Payment-posting
        Scenario: Get payments
            When a Post Request is sent
            | Name | LastName | Number           | ExpiratedDa | Cvv | UserId |
            | Juan | Perez    | 4000478465871254 | 12/25       | 988 | 1      |
            Then A Response is received with Status 201
            And a Payment Resource is included in Response Body
              | Id | Name | LastName | Number           | ExpiratedDa | Cvv | UserId |
              | 1  | Juan | Perez    | 4000478465871254 | 12/25       | 988 | 1      |
        @Payment-posting-error
        Scenario: Database has an error to store
        Given a Post Request is sent
          | Name | LastName | Number | ExpiratedDa | Cvv              | UserId |
          | Juan | Perez    | 988    | 12/25       | 4000478465871254 | 1      |
          When is something wrong with the database
          Then A Response is received with Status 500
          And An Error Message is returned with value "An error occurred while saving the payment"
