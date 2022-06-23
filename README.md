# IqExercise

Project contains user endpoints for CRUD operations. Following featuers are implemented in this project
	1. Onion architecture.
	2. Mediator Pattern
	3. Repositary Pattern
	4. Code First Approach
	5. Global handling of error using middleware extension
	6. Helper class for image upload
	7. Extension method for full adress display and model null check
	8. Automapper for request/ response and model
	9. Paging, sorting and filtering get endpoint.
	10.EfCore
	11.PostMan Collection
	12.Initial migration script

Folder Structure
	Core
		Domain
			1. Entites - db model
		Application
			- Commands and Queries
			- Extension methods
			- Helper class
	Persistance
		- Context and Repositary
	WebApi
		- User Controller
		- Exception handling
		- Middleware
		- Configuration
		
Endpoints
	
	1. Get- api/user
	2. Get- api/user/1
	3. Post- api/user ,request
	4. Put- api/user/1 ,request
	5. Delete -api/user/1
			