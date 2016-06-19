﻿using ConsoleApplication2.Common;

namespace ConsoleApplication2.People
{
    using System;
    using Validation;

    public class ContactInfo
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string email;
        private string phoneNumber;

        public ContactInfo(string firstName, string middleName, string lastName, string phoneNumber, string email = null)
        {
            this.FirstName = firstName.Trim();
            this.MiddleName = middleName.Trim();
            this.LastName = lastName.Trim();
            this.Email = email.Trim();
            this.PhoneNumber = phoneNumber.Trim();
        }

        public string FullName
        {
            get { return $"{FirstName} {MiddleName} {LastName}"; }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if ( string.IsNullOrEmpty(value) )
                {
                    throw new ArgumentException(GlobalErrorMessages.FirstNameEmptyErrorMessage);
                }
                else
                {
                    this.firstName = value;
                }
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            set
            {
                if ( string.IsNullOrEmpty(value) )
                {
                    throw new ArgumentException(GlobalErrorMessages.MiddleNameEmptyErrorMessage);
                }
                else
                {
                    this.middleName = value;
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if ( string.IsNullOrEmpty(value) )
                {
                    throw new ArgumentException(GlobalErrorMessages.LastNameEmptyErrorMessage);
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (ObjectValidator.CheckIfEmailIsValid(value))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException(GlobalErrorMessages.InvalidEmailErrorMessage);
                }
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (ObjectValidator.CheckIfPhoneIsValidLandline(value)
                    || ObjectValidator.CheckIfMobilePhoneIsValid(value))
                {
                phoneNumber = value;

                }
                else
                {
                    throw new ArgumentException(GlobalErrorMessages.InvalidPhoneErrorMessage);
                }
            }
        }
    }
}