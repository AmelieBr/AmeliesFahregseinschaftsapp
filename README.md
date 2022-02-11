# AmeliesFahregseinschaftsapp

INSERT INTO Notifications ([Subject], [Body])
VALUES
('A carpool was deleted - ShareARide', 'Hi #FirstName #LastName! \n The carpool #CarpoolID from #RouteStart to #RouteEnd at #StartTime was deleted.'),
('A carpool was created - ShareARide', 'Hi #FirstName #LastName! \n The carpool #CarpoolID was created:\n Route: #RouteStart - #RouteEnd \n Time: #StartTime - #StartEnd \n Seats: #Seats'),
('The carpool was updated - ShareARide', 'Hi #FirstName #LastName! \n The carpool #CarpoolID from #RouteStart to #RouteEnd at #StartTime to #EndTime was updated. /n There are now #Seats Seats'),
('A user joined the carpool - ShareARide', 'Hi,\n There is a new passenger in the carpool #CarpoolID from #RouteStart to #RouteEnd at #StartTime.\n All Passengers:\n #CarpoolUserslist'),
('A user left the carpool - ShareARide', 'Hi,\n A passenger left the carpool #CarpoolID from #RouteStart to #RouteEnd at #StartTime.\n All Passengers:\n #CarpoolUserslist'),
('Your account was deleted - ShareARide', 'Hi #FirstName #LastName we are sad to see you go! \n Your account was deleted! '),
('You created your new account - ShareARide', 'Welcome #FirstName #LastName to ShareARide! \n Your ID is #UserID \n Your phonenumber is #Phone'),
('Your account was updated - ShareARide', 'Hi #FirstName #LastName! \n Your account was updated! \n Your ID is #UserID. \n Your phonenumber is #Phone.')