﻿using System.ComponentModel.DataAnnotations;

namespace Ciudadanos_Sanos.Models
{
    public class Register
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public ICollection<User>? Users { get; set; } = default!;
    }
}
