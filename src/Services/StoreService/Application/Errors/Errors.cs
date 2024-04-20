using Communal.Application.Constants;
using Communal.Application.Infrastructure.Errors;

namespace StoreService.Application.Errors
{
    public static class Errors
    {
        // Code ranges for General Services is between 01000 and 01199

        public static ErrorModel InvalidInputValidationError = new ErrorModel(
            code: 1000,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid input"
            ));

        public static ErrorModel InvalidPhoneNumberValidationError = new ErrorModel(
            code: 1001,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid phone number"
            ));

        public static ErrorModel InvalidEmailValidationError = new ErrorModel(
            code: 1002,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid email address"
            ));
        
        public static ErrorModel InvalidBankAccountNumberValidationError = new ErrorModel(
            code: 1003,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid bank account number"
            ));

        public static ErrorModel InvalidFirstNameValidationError = new ErrorModel(
            code: 1004,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid first name"
            ));

        public static ErrorModel InvalidLastNameValidationError = new ErrorModel(
            code: 1005,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid last name"
            ));
        
        public static ErrorModel InvalidDateOfBirthValidationError = new ErrorModel(
            code: 1006,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid birth date"
            ));
        public static ErrorModel InvalidTitleValidationError = new ErrorModel(
            code: 1007,
            title: "General Error",
            (
                Language: Language.English,
                Message: "Invalid title"
            ));
    }
}