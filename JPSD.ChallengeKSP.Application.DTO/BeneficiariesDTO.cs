﻿using System;

namespace JPSD.ChallengeKSP.Application.DTO
{
    public class BeneficiariesDTO
    {
		public int BeneficiaryID { get; set; }
		public int EmployeeID { get; set; }
		public string FullName { get; set; }
		public string Relationship { get; set; }
		public DateTime BirthDate { get; set; }
		public string Gender { get; set; }
	}
}
