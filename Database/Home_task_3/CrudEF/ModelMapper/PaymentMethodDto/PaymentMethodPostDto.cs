﻿using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.PaymentMethodDto
{
    public class PaymentMethodPostDto
    {
        [Required(ErrorMessage = "Method is required")]
        public string Method { get; set; } = null!;
    }
}
