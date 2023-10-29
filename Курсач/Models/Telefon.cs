using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Курсач.Models
{
    [Table("Телефонный справочник")]
    public class Telefon
    {    
            [Key]
            [Required]
            public int Id { get; set; }

            [Display(Name = "Имя")]
            public string? f_Name { get; set; }

            [Display(Name = "Фамилия")]
            public string? s_Name { get; set; }

            [Display(Name = "Отчество")]
            public string? t_Name { get; set; }

            [Display(Name = "Номер телефона")]  
            public string? PhoneNumb { get; set; }


        
    }
}
