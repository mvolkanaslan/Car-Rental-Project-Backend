using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //CarManager Operation
        public static string Add_Msg = "Add Operation Successful !";
        public static string AddErrorMsg = "Error : Please enter valid value !";

        

        public static string DeleteMsg = "Delete Operation Successful !";
        public static string UpdateMsg = "Update Operation Successful !";
        public static string ListMsg = "Listing Operation Successful !";
        public static string ErrorMsg = "An Error occured in this operation !";


        #region ImageProcess
        public static string ImageFormatError = "The file is not an image !";
        public static string ImageLimitError = "Image Capacity Reached Full !";
        public static string ImageUploadSuccess = "Image Uploading Success !";
        public static string CarImageNotFound = "Car Image Not Found !";
        public static string ImageDeleteSuccess = "Image Update Successful !";
        public static string FileTypeInValid = "File Type Invalid !";
        #endregion

        #region Authorization
        public static string AuthorizationDenied = "You are not Authorized";
        public static string AccessTokenCreated = "Token Creation Successful !";
        public static string UserAlreadyExists = "User Already Exist !";
        public static string SuccessfulLogin = "Login Successful !";
        public static string PasswordError = "Password is invalid !";
        public static string UserNotFound = "User not Found !";
        public static string UserRegistered = "The User Registered !";
        #endregion

        #region Rent Operation
        public static string CarIsRentable = "The Car is Rentable";
        public static string RentalValid = "Your Rantel Succesful !";
        public static string RentalInValid = "The Selected Car is already Rented !";

        #endregion

        public static string PaymentSuccessful="Payment is Success !";
        public static string PaymentUnSeccessful= "InValid Card or Insufficient Amount !";
    }
}
