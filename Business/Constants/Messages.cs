﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    public class Messages
    {

        public static string MaintenanceTime = "System is under maintenance";

        //CAR MESSAGES
        public static string CarAdded = "Car is added";
        public static string CarUpdated = "Car is updated";
        public static string CarDeleted = "Car is deleted";
        public static string CarGet = "Car is listed";
        public static string AllCarList = "All the cars are listed";
        public static string CarsListedByColor = "Cars are listed by color id";
        public static string CarsListedByBrand = "Cars are listed by brand id";

        //BRAND MESSAGES
        public static string BrandAdded = "Brand is added";
        public static string BrandDeleted = "Brand is deleted";
        public static string BrandUpdated = "Brand is updated";
        public static string BrandsListed = "Brands listed";
        public static string BrandListById = "Brand listed by id";
        
        //COLOR MESSAGES
        public static string ColorAdded = "Color is added";
        public static string ColorDeleted = "Color is deleted";
        public static string ColorUpdated = "Color is updated";
        public static string ColorsListed = "Colors listed";
        public static string ColorListById = "Color listed by id";

        //CUSTOMER MESSAGES
        public static string CustomerAdded = "Customer is added";
        public static string CustomerDeleted = "Customer is deleted";
        public static string CustomerUpdated = "Customer is updated";
        public static string CustomersListed = "Customers listed";
        public static string CustomerListById = "Customer listed by id";

        //USER MESSAGES

        public static string UserAdded = "User is added";
        public static string UserDeleted = "User is deleted";
        public static string UserUpdated = "User is updated";
        public static string UsersListed = "Users listed";
        public static string UserListById = "User listed by id";

        //RENTAL MESSAGES

        public static string RentalAdded = "Rental is added";
        public static string RentalDeleted = "Rental is deleted";
        public static string RentalUpdated = "Rental is updated";
        public static string RentalsListed = "Rentals listed";
        public static string RentalListById = "Rental listed by id";
        public static string RentalDetailsListed = "Rental details listed";

        //CAR IMAGE MESSAGES

        public static string CarNotAvalible = "The car has not been delivered yet";
        public static string ImageIsAdded = "Image is added";
        public static string ImageCapacityExceed = "Image capacity Exceed";
        public static string CarImageIsDeleted= "Car image is deleted";
        public static string CarImageListedById= "Car image is listed by id";
        public static string AllTheCarImagesListed="Car images are Listed";

        //AUTHENTICATION MESSAGES

        public static string ClaimsListed = "Claims Listed";
        public static string UserNotFound ="User not found!";
        public static string PasswordError= "Wrong Password!";
        public static string SuccessfullLogin= "Successfull Login!";
        public static string UserExists="User is already registered";
        public static string UserIsRegistered="User registration completed";
        public static string AccessTokenCreated= "Access token created";
        public static string AuthorizationDenied="Authorization Denied!!!";
    }
}
