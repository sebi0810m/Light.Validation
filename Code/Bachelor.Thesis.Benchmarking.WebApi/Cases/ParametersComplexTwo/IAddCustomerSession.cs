﻿using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public interface IAddCustomerSession : IAsyncSession
{
    public Task<int> InsertCustomerAsync(CustomerDto customer);
}