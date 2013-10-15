using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Subject = null;
            Price = 0;
            SignedOn = DateTime.Now;
            Id = null;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole Předmět je vyžadováno")]
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
            Name = null;
            Address = new Address();
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole Jméno je vyžadováno")]
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public Address()
        {
            Street = null;
            Number = null;
            City = null;
            ZipCode = null;
        }

        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}