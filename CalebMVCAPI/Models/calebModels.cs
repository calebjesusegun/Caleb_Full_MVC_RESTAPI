using System;
using System.ComponentModel.DataAnnotations;

namespace CalebMVCAPI.Models
{
   public class calebModels
   {
      [Key]
      public int Id { get; set; }

      [Required]
      [MaxLength(250)]
      public String HowTo { get; set; }

      [Required]
      public String Line { get; set; }

      [Required]
      public String Platform { get; set; }
   }
}