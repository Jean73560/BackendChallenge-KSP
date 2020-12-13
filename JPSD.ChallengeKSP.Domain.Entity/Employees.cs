using System;
using System.Collections.Generic;
using System.Text;

namespace JPSD.ChallengeKSP.Domain.Entity
{
    public class Employees
	{
        public int EmployeeID { get; set; }
		public string FullName { get; set; }
		public string Work { get; set; }
		public decimal Salary { get; set; }
		public bool Status { get; set; }
		public DateTime HireDate { get; set; }
		public string PhotoPath { get; set; }
		public string Phone { get; set; }
	}
}
