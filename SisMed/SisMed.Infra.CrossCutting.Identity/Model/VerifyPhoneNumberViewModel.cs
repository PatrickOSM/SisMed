﻿using System.ComponentModel.DataAnnotations;

namespace SisMed.Infra.CrossCutting.Identity.Model
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }
    }
}