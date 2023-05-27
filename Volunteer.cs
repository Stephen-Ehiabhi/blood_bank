using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class Volunteer : Person
    {
        private string id, bloodType, dateOfDonation;

        protected internal Volunteer(string name, string lastname, string email, int socialID, int phonenumber, string bloodType, string id, string dateOfDonation)
        {
            this.name = name;
            this.lastname = lastname;
            this.email = email;
            this.phonenumber = phonenumber;
            this.bloodType = bloodType;
            this.dateOfDonation = dateOfDonation;
            this.socialID = socialID;
            this.id = id;
        }
        public string PrintData()
        {
            return $"{this.name}|{this.lastname}|{this.email}|{this.phonenumber}|{this.bloodType}|{this.dateOfDonation}|{this.id}|{this.socialID}\n";

        }
        public string UpdateData()
        {
            return $"{this.name}|{this.lastname}|{this.email}|{this.phonenumber}|{this.bloodType}|{this.dateOfDonation}|{this.id}|{this.socialID}";

        }

        //For Read Only 
        public string Name{get{return this.name;}}        
        public string LName { get { return this.lastname; } set { this.lastname = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string BloodType { get { return this.bloodType; } set { this.bloodType = value; } }
        public int PhoneNumber { get { return this.phonenumber; } set { this.phonenumber = value; } }
        public string DateOfDonation { get { return this.dateOfDonation; } }
        public string ID { get { return this.id; } }
        public int SocialID { get { return this.socialID; } }

        //For Edit
        public string SetName { set { this.name = value; } }
        public string SetLName {set { this.lastname = value; } }
        public string SetEmail {set { this.email = value; } }
        public int SetPhoneNumber {set { this.phonenumber = value; } }
        public string SetBloodType { set { this.bloodType = value; } }
        public string SetDateOFDonation { set { this.dateOfDonation = value; } }
        public int SetSocialId { set { this.socialID = value; } }

    }
}
