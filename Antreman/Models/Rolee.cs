using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antreman.Models
{
    public class Rolee
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte RoleeID { get; set; }

        [Required(ErrorMessage ="{0} gerekli"), StringLength(20, MinimumLength = 3, ErrorMessage ="{0}, {2} - {1} karakter olmalı")]
        public string RoleeName { get; set;}
    }
}
