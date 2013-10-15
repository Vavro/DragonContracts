using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragonContracts.Models
{
    public class Contract
    {
        public Contract()
        {
            FirstParty = new Contact();
            SecondParty = new Contact();
            Subject = "";
            Price = 0;
            SignedOn = DateTime.Now;
            Id = null;
        }

        public string Subject { get; set; }
        public Contact FirstParty { get; set; }
        public Contact SecondParty { get; set; }
        public double Price { get; set; }
        public DateTime SignedOn { get; set; }
        public string Id { get; set; }
    }

    public class Contact
    {
        public Contact()
        {
            Name = "";
            Address = new Address();
        }

        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public Address()
        {
            Street = "";
            Number = "";
            City = "";
            ZipCode = "";
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}