using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectX
{
    public class Contact : Contacts
    {
        private string UserIdValue;
        private string FirstNameValue;
        private string LastNameValue;
        private string EmailValue;

        public Contact(string userId, string firstName, string lastName, string email) : base (userId, firstName, lastName, email)
        {

        }

        public string UserId
        {
            get
            {
                return UserIdValue;
            }
            set
            {
                
                UserIdValue = value;
            }
        }

        public string FirstName
        {
            get
            {
                return FirstNameValue;
            }
            set
            {
                //Check for length max 50, REGEX -> Enkel letters en leestekens die in namen voor komen
                FirstNameValue = value;
            }
        }

        public string LastName
        {
            get
            {
                return LastNameValue;
            }
            set
            {
                //Check for length max 50, REGEX -> Enkel letters en leestekens die in namen voor komen
                LastNameValue = value;
            }
        }

        public string Email
        {
            get
            {
                return EmailValue;
            }
            set
            {
                //Regex Email
                EmailValue = value;
            }
        }
    }
}
