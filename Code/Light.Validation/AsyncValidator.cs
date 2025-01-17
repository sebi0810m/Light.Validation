﻿using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Light.GuardClauses;

namespace Light.Validation;

/// <summary>
/// Represents the base class for validators that validate a single value which is usually a
/// Data Transfer Object (DTO). This validator runs asynchronously.
/// </summary>
/// <typeparam name="T">The type of the value to be validated.</typeparam>
public abstract class AsyncValidator<T> : BaseValidator<T>
{
    /// <summary>
    /// Initializes a new instance of <see cref="Validator{T}" />.
    /// </summary>
    /// <param name="validationContextFactory">
    /// The factory that is used to create a new <see cref="ValidationContext" /> instance.
    /// </param>
    /// <param name="isNullCheckingEnabled">
    /// The value indicating whether the validator automatically performs null-checking (optional).
    /// The default value is true. If enabled, the validator will automatically check if a value is
    /// null and then return the a error message that the value must not be null.
    /// </param>
    /// <param name="continueOnCapturedContextAfterAwait">
    /// The value indicating whether the continuation after the internal async validation should
    /// be executed on the captured synchronization context (optional). The default value
    /// is false. This is the boolean value passed to ConfigureAwait for the
    /// PerformValidationAsync task. If you have no clue, just leave it to false.
    /// </param>
    protected AsyncValidator(ValidationContextFactory validationContextFactory,
                             bool isNullCheckingEnabled = true,
                             bool continueOnCapturedContextAfterAwait = false)
        : base(validationContextFactory, isNullCheckingEnabled) =>
        ContinueOnCapturedContextAfterAwait = continueOnCapturedContextAfterAwait;

    private bool ContinueOnCapturedContextAfterAwait { get; }

    /// <summary>
    /// Asynchronously validates the specified value and returns a structure containing
    /// the validation result.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <param name="key">
    /// The string that identifies the corresponding errors in the internal dictionary of the validation context (optional).
    /// You do not need to pass this value as it is automatically obtained by the expression that is passed to <paramref name="value" />
    /// via the <see cref="CallerArgumentExpressionAttribute" />. This value is only relevant if this validator is
    /// called by another validator.
    /// </param>
    /// <param name="displayName">
    /// The human-readable name of the value (optional). The default value is null.
    /// This parameter will be set to the value of the <paramref name="key" /> parameter if null is passed.
    /// It will also be normalized if no dedicated display name is set.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is null.</exception>
    public Task<ValidationResult<T>> ValidateAsync([ValidatedNotNull] T? value,
                                                   [CallerArgumentExpression("value")] string key = "",
                                                   string? displayName = null) =>
        ValidateAsync(value, ValidationContextFactory.CreateValidationContext(), key, displayName);

    /// <summary>
    /// Asynchronously validates the specified value while reusing the specified validation context.
    /// </summary>
    /// <param name="value">The value to be checked</param>
    /// <param name="context">The validation context that manages the errors dictionary.</param>
    /// <param name="key">
    /// The string that identifies the corresponding errors in the internal dictionary of the validation context (optional).
    /// You do not need to pass this value as it is automatically obtained by the expression that is passed to <paramref name="value" />
    /// via the <see cref="CallerArgumentExpressionAttribute" />. This value is only relevant if this validator is
    /// called by another validator.
    /// </param>
    /// <param name="displayName">
    /// The human-readable name of the value (optional). The default value is null.
    /// This parameter will be set to the value of the <paramref name="key" /> parameter if null is passed.
    /// It will also be normalized if no dedicated display name is set.
    /// </param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="context" /> or <paramref name="key"/> are null.</exception>
    public async Task<ValidationResult<T>> ValidateAsync([ValidatedNotNull] T? value,
                                                         ValidationContext context,
                                                         [CallerArgumentExpression("value")] string key = "",
                                                         string? displayName = null)
    {
        context.MustNotBeNull();
        key.MustNotBeNull();

        displayName ??= key;

        if (TryCheckForNull(value, context, key, displayName, out var error))
            return new ValidationResult<T>(value!, error);

        value = await PerformValidationAsync(context, value).ConfigureAwait(ContinueOnCapturedContextAfterAwait);
        return new ValidationResult<T>(value, context.Errors);
    }

    /// <summary>
    /// Performs the actual checks to validate the value. You should
    /// usually call <c>context.Check(value.SomeProperty)</c> on properties of the specified value
    /// to validate them. By default, the passed <paramref name="value" /> is not null because
    /// the validator performs an automatic null-check before calling this method. You can
    /// change this behavior by setting isNullCheckingEnabled to false when calling the base
    /// class constructor.
    /// </summary>
    /// <param name="context">The context that tracks errors in a dictionary.</param>
    /// <param name="value">The value to be checked.</param>
    protected abstract Task<T> PerformValidationAsync(ValidationContext context, T value);
}