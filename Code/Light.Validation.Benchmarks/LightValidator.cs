﻿using Light.Validation.Checks;
using Light.Validation.Tools;

namespace Light.Validation.Benchmarks;

public sealed class LightValidator : Validator<UpdateUserNameDto>
{
    protected override void PerformValidation(ValidationContext context, UpdateUserNameDto dto)
    {
        context.Check(dto.Id).IsGreaterThan(0);
        dto.UserName = context.Check(dto.UserName)
                              .Normalize()
                              .IsNotNullOrWhiteSpace()
                              .Value;
    }
}