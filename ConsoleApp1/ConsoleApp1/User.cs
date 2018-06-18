using System;
using System.Collections.Generic;
using System.Text;



//BASIS CLASS voor USER aanmaak
//To do Validatie op alle ingegeven data (Zowel in de functie bij aanmaak van een nieuwe user als bij Creëren van het object)

namespace ProjectX
{

    public class User : Users
    {
        private int UserIdValue;
        private string FirstNameValue;
        private string LastNameValue;
        private DateTime BirthDayValue;
        private string EmailValue;
        private string TelephoneNumberValue;
        private string PasswordValue;
        private List<Contact> ContactsValue;


        public User(string firstname, string lastname, DateTime birthday, string email, string telephone, string password) : base (firstname, lastname, birthday, email, telephone, password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Birthday = birthday;
            this.Email = email;
            this.Telephone = telephone;
            this.Password = password;
        }

        public int UserId
        {
            get
            {
                return UserIdValue;
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
                if (value.Length > 50)
                {
                    //Te lang max 50 tekens throw exception
                }
                else
                {
                    //Eventueel Regex die enkel Letters en bepaalde leestekend toelaat die voorkomen in namen
                    //if(Regex.IsMatch(value)
                    //{
                    FirstNameValue = value;
                    //}
                    //else
                    //{
                    //throw exception
                    //}
                }
                
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
                if (value.Length > 50)
                {
                    //Te lang max 50 tekens throw exception
                }
                else
                {
                    //Eventueel Regex die enkel Letters en bepaalde leestekend toelaat die voorkomen in namen
                    //if(Regex.IsMatch(value)
                    //{
                    LastNameValue = value;
                    //}
                    //else
                    //{
                    //throw exception
                    //}
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                return BirthDayValue;
            }
            set
            {
                //Check of persoon reeds geboren is en ouder is dan 13
                BirthDayValue = value;
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
                //Regex voor EMAIL
                EmailValue = value;
            }
        }

        public string Telephone
        {
            get
            {
                return TelephoneNumberValue;
            }
            set
            {
                //Regex voor Telefoonnummer 
                TelephoneNumberValue = value;
            }
        }

        public string Password
        {
            get
            {
                return PasswordValue;
            }
            set
            {
                //Check minimum aantal tekens 10 moet minstens 1 cijfer en 1 letter bevatten
                PasswordValue = value;
            }
        }

        public List<Contact> Contacts
        {
            get
            {
                return ContactsValue;
            }
        }
    }
}
