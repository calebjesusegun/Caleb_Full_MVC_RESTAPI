using System.ComponentModel.DataAnnotations;

namespace CalebMVCAPI.Dtos
{
   public class calebAPIUpdateDto
   {
      [Required]
      [MaxLength(250)]
      public string HowTo { get; set; }

      [Required]
      public string Line { get; set; }
      [Required]
      public string Platform { get; set; }
   }
}