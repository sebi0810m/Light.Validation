﻿using System.ComponentModel.DataAnnotations;

namespace Bachelor.Thesis.Benchmarking.ComplexTwoParametersDto;

public class ComplexTwoParametersDto
{
    [Required]
    public User User { get; set; } = new ();

    [Required]
    public Address Address { get; set; } = new();
}