using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragonContracts.Models
{
    public class Contract
    {
        public string Subject { get; set; }
        public Contact FirtsParty { get; set; }
        public Contact SecondParty { get; set; }
        public double Price { get; set; }
        public DateTime SignedOn { get; set; }
        public int Id { get; set; }
    }

    public class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}