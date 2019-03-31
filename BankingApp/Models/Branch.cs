using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Branch
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Branch_Name { get; set; }
        [StringLength(20)]
        public string City { get; set; }
        [StringLength(20)]
        public string State { get; set; }
        [StringLength(20)]
        public string Zip_Code { get; set; }
        [StringLength(20)]
        public string Phone_Number { get; set; }
        [StringLength(20)]
        public string Street_Address { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Account> Accounts { get; set; }
        public Branch()
        {
            this.Employees = new List<Employee>();
            this.Accounts = new List<Account>();
        }


    }
}
