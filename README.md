# dotnet.academic
.NET Academic Projects

Project Name: wk8_james_kobell_cs 
Description: A WEB API 2 project with a shopping cart. There is a jQuery front-end making AJAX calls to the Get and Post Controller methods, and a Entity back-end with SQL database. 
Summary: On document ready, a dropdown is populated with the shopping Categories which correspond to db tables. A Category selection change event will cause a call to the Controller Get method that corresponds to the selected Category. A table is created to display the results. User will mouse click on any table row to place items in Shopping Cart table. A different category may be selected at any time. 
The Shopping cart table allows for item quantity selection, remove item or clear cart.
User information is required when shopping cart is saved. After user information for validation, the user information is put into the Customer table of the database with a AJAX POST call to the Customer Controller. Likewise, the Shopping Cart contents are put into the Cart table. 
    