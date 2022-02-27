﻿using FluentAssertions;
using Light.Validation.Checks;
using Light.Validation.Tests.TestHelpers;
using Xunit;

namespace Light.Validation.Tests.Checks;

public static class IsNotNullForReferencesTests
{
    public static readonly TheoryData<string> ValidValues =
        new ()
        {
            "Foo",
            "Bar",
            "c",
            "",
            " ",
            "\t\r\n"
        };

    [Fact]
    public static void ValueIsNull()
    {
        var dto = new Dto();
        var context = new ValidationContext();

        var check = context.Check(dto.ReferenceValue).IsNotNull();

        context.ShouldHaveSingleError("referenceValue", "referenceValue must not be null.");
        check.IsShortCircuited.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(ValidValues))]
    public static void NotNull(string validString)
    {
        var dto = new Dto { ReferenceValue = validString };
        var context = new ValidationContext();

        var check = context.Check(dto.ReferenceValue).IsNotNull();

        context.ShouldHaveNoError();
        check.IsShortCircuited.Should().BeFalse();
    }

    [Fact]
    public static void CustomErrorMessage()
    {
        var dto = new Dto();
        var context = new ValidationContext();

        var check = context.Check(dto.ReferenceValue).IsNotNull("How can you pass null?");

        context.ShouldHaveSingleError("referenceValue", "How can you pass null?");
        check.IsShortCircuited.Should().BeTrue();
    }

    [Fact]
    public static void CustomErrorMessageFactory()
    {
        var dto = new Dto();
        var context = new ValidationContext();

        var check = context.Check(dto.ReferenceValue).IsNotNull(c => $"Damn you, {c.Key} is null!");

        context.ShouldHaveSingleError("referenceValue", "Damn you, referenceValue is null!");
        check.IsShortCircuited.Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(ValidValues))]
    public static void NoErrorWithCustomMessageFactory(string validValue)
    {
        var dto = new Dto { ReferenceValue = validValue };
        var context = new ValidationContext();

        var check = context.Check(dto.ReferenceValue).IsNotNull(_ => "It doesn't matter");

        context.ShouldHaveNoError();
        check.IsShortCircuited.Should().BeFalse();
    }

    [Fact]
    public static void NoErrorForShortCircuitedChecks()
    {
        var dto = new Dto();
        var context = new ValidationContext();

        context.Check(dto.ReferenceValue)
               .ShortCircuit()
               .IsNotNull();

        context.ShouldHaveNoError();
    }

    [Fact]
    public static void AvoidShortCircuitOnError()
    {
        var dto = new Dto();
        var context = new ValidationContext();

        var check = context.Check(dto.ReferenceValue)
                           .IsNotNull(shortCircuitOnError: false);

        check.IsShortCircuited.Should().BeFalse();
        check.HasError.Should().BeTrue();
    }

    [Fact]
    public static void AvoidShortCircuitOnCustomErrorMessage()
    {
        var dto = new Dto();
        var context = new ValidationContext();
        
        var check = context.Check(dto.ReferenceValue).IsNotNull(c => $"Damn you, {c.Key} is null!", false);

        check.IsShortCircuited.Should().BeFalse();
    }

    private sealed class Dto
    {
        public string ReferenceValue { get; init; } = null!;
    }
}