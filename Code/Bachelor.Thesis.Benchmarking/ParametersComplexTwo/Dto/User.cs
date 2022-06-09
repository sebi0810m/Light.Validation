﻿using System.ComponentModel.DataAnnotations;

namespace Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;

public class User
{
    public static User ValidUser = new ()
    {
        UserName = "JohnDoe1337",
        Password = "P4SsW0rD123",
        Name = "John Doe",
        Email = "john.doe@example.com",
        Active = true,
        Age = 42
    };

    public static User InvalidUser = new ()
    {
        UserName = "John",
        Password = "P4S$W0r",
        Name = "J",
        Email = "D",
        Age = 16
    };

    [Required]
    [StringLength(30, MinimumLength = 8)]
    public string UserName { get; set; } = string.Empty;

    // password must contain minimum of eight characters with at least one letter and one number
    [Required]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public bool Active { get; set; } = true;

    [Required]
    [Range(18, 130)]
    public int Age { get; set; }
}