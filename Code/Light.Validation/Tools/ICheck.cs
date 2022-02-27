﻿namespace Light.Validation.Tools;

/// <summary>
/// Represents the abstraction of the check struct that leaves out the generic value to be checked.
/// </summary>
public interface ICheck
{
    /// <summary>
    /// Gets the key that identifies errors for the value.
    /// </summary>
    string Key { get; }
    
    /// <summary>
    /// Gets the context that manages the errors dictionary.
    /// </summary>
    ValidationContext Context { get; }
    
    /// <summary>
    /// Gets the value indicating whether the context has errors
    /// for the key of this check instance.
    /// </summary>
    bool HasError { get; }
    
    /// <summary>
    /// Gets the value indicating whether no further checks should
    /// be performed with this instance.
    /// </summary>
    bool IsShortCircuited { get; }
    
    /// <summary>
    /// Gets the value indicating whether the value of the check is null.
    /// </summary>
    bool IsValueNull { get; }

    /// <summary>
    /// Adds the specified error message to the context. By default,
    /// the error will not be added when <see cref="IsShortCircuited" /> is true
    /// on this check instance. You can change this behavior by setting
    /// <paramref name="isRespectingShortCircuit" /> to false.
    /// </summary>
    /// <param name="errorMessage">The message that should be added to the context.</param>
    /// <param name="isRespectingShortCircuit"></param>
    void AddError(string errorMessage, bool isRespectingShortCircuit = true);
}