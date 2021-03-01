using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //CarManager Operation
        public static string Add_Msg = "Add Operation Successful !";
        public static string AddErrorMsg = "Error : Please enter valid value !";

        public static string RentalValid = "Your Rantel Succesful !";
        public static string RentalInValid = "The Car Your Selected is Rented !";

        public static string DeleteMsg = "Delete Operation Successful !";
        public static string UpdateMsg = "Update Operation Successful !";
        public static string ListMsg = "\nListing Operation Successful !";


        public static string ErrorMsg = "An Error occured in this operation !";

        #region ImageProcess
        public static string ImageFormatError = "The file is not an image !";
        public static string ImageLimitError = "Image Capacity Reached Full !";
        public static string ImageUploadSuccess = "Image Uploading Success !";
        public static string CarImageNotFound="Car Image Not Found !";
        public static string ImageDeleteSuccess= "Image Update Successful !";
        public static string FileTypeInValid= "File Type Invalid !";
        #endregion
    }
}
