Feature: Login

Scenario: Login with valid credential
	Given A user is logged out
	When I login with username "admin" and passwoird "secret"
	Then I have logged in

Scenario: Login with invalid credential
	Given A user is logged out
	When I login with username "admin" and passwoird "123456"
	Then I have not logged in


