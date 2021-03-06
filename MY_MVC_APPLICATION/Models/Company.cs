﻿namespace Models
{
	public class Company : BaseEntity
	{
		public Company() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "Active")]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false)]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 50)]

		[System.ComponentModel.DataAnnotations.Schema.Index
			(IsUnique = true)]
		public string Name { get; set; }
		// **********
	}
}
