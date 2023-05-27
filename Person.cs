using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Person
    {
        public Person()
        {
        }
        protected string name, lastname, email;
        protected int phonenumber, socialID;

        private Person(string name,string lastname,string email,int socialID, int phonenumber)
        {
            this.name = name;
            this.lastname = lastname;
            this.email = email;
            this.socialID = socialID;
            this.phonenumber = phonenumber;
        }
    }
}
