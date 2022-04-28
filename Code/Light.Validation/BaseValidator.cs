﻿using System.Diagnostics.CodeAnalysis;
using Light.GuardClauses;

namespace Light.Validation;

/// <summary>
/// Provides common members for validator classes. DO NOT derive from this class directly.
/// Instead, use the <see cref="Validator{T}" /> or <see cref="AsyncValidator{T}" /> classes.
/// </summary>
public abstract class BaseValidator<T>
{
    /// <summary>
    /// Initializes a new instance of <see cref="BaseValidator{T}" />
    /// </summary>
    /// <param name="validationContextFactory">
    /// The factory that is used to create a new <see cref="ValidationContext" /> instance.
    /// </param>
    /// <param name="isNullCheckingEnabled">
    /// The value indicating whether the validator automatically performs null-checking (optional).
    /// The default value is true. If enabled, the validator will automatically check if a value is
    /// null and then return the a error message that the value must not be null.
    /// </param>
    protected BaseValidator(IValidationContextFactory validationContextFactory, bool isNullCheckingEnabled)
    {
        ValidationContextFactory = validationContextFactory.MustNotBeNull();
        IsNullCheckingEnabled = isNullCheckingEnabled;
    }

    /// <summary>
    /// Gets the factory that can be used to create validation contexts.
    /// </summary>
    protected IValidationContextFactory ValidationContextFactory { get; }

    /// <summary>
    /// Gets the value indicating whether the validator should perform automatic null-checking.
    /// </summary>
    public bool IsNullCheckingEnabled { get; }

    /// <summary>
    /// This method checks if the validator should perform an automatic null-check (<see cref="IsNullCheckingEnabled" />)
    /// and if yes, performs the null check. This method returns true if null-checking is enabled and the value is actually null,
    /// or otherwise false will be returned.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <param name="context">The validation context that is used to assemble the error message.</param>
    /// <param name="key">The key that identifies the value.</param>
    /// <param name="error">The error message when the null-check fails.</param>
    protected bool TryCheckForNull([NotNullWhen(false)] T? value,
                                   ValidationContext context,
                                   string key,
                                   [NotNullWhen(true)] out object? error)
    {
        context.MustNotBeNull();
        if (IsNullCheckingEnabled)
            return context.CheckForNull(value, out error, key);

        error = default;
        return false;
    }
}