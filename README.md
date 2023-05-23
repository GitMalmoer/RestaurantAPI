# RestaurantAPI
API made for organizing restaurants with its menus(dishes). Database operations are handled by Entity Framework.

Features:
- Entity Framework
- Auto mapper
- Middlewares (error handling,too long request)
- Exception handling
- Pagination

#### AccountController: This controller handles user account-related operations such as user registration and login. It contains two action methods:
- RegisterUser: Accepts a RegisterUserDto object in the request body and calls the RegisterUser method of the IAccountService interface to register a new user.
- Login: Accepts a LoginDto object in the request body, generates a JWT (JSON Web Token) using the GenerateJwt method of the IAccountService interface, and returns the token in the response.

#### DishController: This controller manages dish-related operations for a restaurant. It is responsible for CRUD (Create, Read, Update, Delete) operations on dishes. The controller is nested under the /api/restaurant/{restaurantId} route, indicating that it operates on dishes within a specific restaurant. It contains the following action methods:
- Post: Creates a new dish for a specific restaurant. It accepts the restaurantId as a route parameter and a CreateDishDto object in the request body. The Create method of the IDishService interface is called to create the dish, and the ID of the newly created dish is returned in the response.
- DeleteAllDishes: Deletes all dishes associated with a specific restaurant. It accepts the restaurantId as a route parameter and calls the DeleteAll method of the IDishService interface to delete all dishes.
- DeleteOne: Deletes a specific dish within a restaurant. It accepts the restaurantId and dishId as route parameters and calls the DeleteOneDish method of the IDishService interface to delete the dish.
- Get: Retrieves a specific dish within a restaurant. It accepts the restaurantId and dishId as route parameters and calls the GetById method of the IDishService interface to get the dish details.
- GetAll: Retrieves all dishes within a restaurant. It accepts the restaurantId as a route parameter and calls the GetAll method of the IDishService interface to get a list of all dishes.

#### FileController: This controller handles file-related operations such as downloading files and uploading files to a specific directory. It is mapped to the /file route. The controller contains the following action methods:
- GetFile: Retrieves a file from the server. It accepts the fileName as a query parameter, constructs the file path, and returns the file as a downloadable response.
- Upload: Uploads a file to the server. It accepts the file data as a form file and saves it to the specified directory.

#### RestaurantController: This controller handles restaurant-related operations. It is responsible for creating, deleting, updating, and retrieving restaurants. The controller is mapped to the /api/restaurant route and requires authorization. It contains the following action methods:
- CreateRestaurant: Creates a new restaurant. It accepts a CreateRestaurantDto object in the request body and calls the Create method of the IRestaurantService interface to create the restaurant. The ID of the newly created restaurant is returned in the response.
- Delete: Deletes a specific restaurant. It accepts the id of the restaurant to be deleted and calls the Delete method of the IRestaurantService interface to delete the restaurant.
- GetAll: Retrieves a list of all restaurants. It accepts optional query parameters (RestaurantQuery) for filtering


![image](https://github.com/GitMalmoer/RestaurantAPI/assets/113827015/18198c31-d5de-402a-a84c-0b54ff039449)
