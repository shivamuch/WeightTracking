using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DomainClasses
{
    public class WeightHistory
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        [Display(Name = "Weight")]
        public decimal Value { get; set; }
        public string Fk_UserId { get; set; }
    }
}
