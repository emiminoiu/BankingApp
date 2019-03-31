using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(30)]
        public string Street_Address { get; set; }
        [StringLength(20)]
        public string City { get; set; }
        [StringLength(20)]
        public string ZipCode { get; set; }
        [StringLength(20)]
        public string State { get; set; }
        [StringLength(1)]
        public string Sex { get; set; }

        public DateTime Birthdate { get; set; }


    }
}
