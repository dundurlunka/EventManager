namespace EventManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Event : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Event name must be at least 3 symbols long!")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Event location must be at least 3 symbols long!")]
        public string Location { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate>EndDate)
            {
                yield return new ValidationResult("The start date cannot be after the end date");
            }
            if (StartDate<DateTime.UtcNow)
            {
                yield return new ValidationResult("The start date cannot be in the past");
            }

        }
    }
}
