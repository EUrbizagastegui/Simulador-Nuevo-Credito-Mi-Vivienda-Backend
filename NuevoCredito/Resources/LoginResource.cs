﻿using System.ComponentModel.DataAnnotations;

namespace NuevoCreditoAPI.NuevoCredito.Resources;

public class LoginResource
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}