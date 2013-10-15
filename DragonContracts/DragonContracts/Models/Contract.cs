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
        [Display(Name = "Předmět")]
        public string Subject { get; set; }
        [Display(Name = "Objednatel")]
        public Contact FirstParty { get; set; }
        [Display(Name = "Zhotovitel")]
        public Contact SecondParty { get; set; }
        [Display(Name = "Cena")]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Datum podpisu")]
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
        [Display(Name = "Jméno")]
        public string Name { get; set; }
        [Display(Name = "Adresa")]
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

        [Display(Name = "Ulice")]
        public string Street { get; set; }
        [Display(Name = "Číslo popisné/orientační")]
        public string Number { get; set; }
        [Display(Name = "Město")]
        public string City { get; set; }
        [Display(Name = "PSČ")]
        public string ZipCode { get; set; }
    }
}