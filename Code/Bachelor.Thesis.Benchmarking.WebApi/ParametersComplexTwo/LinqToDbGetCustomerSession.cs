﻿using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.ParametersComplexTwo;

public class LinqToDbGetCustomerSession : AsyncReadOnlySession, IGetCustomerSession
{
    public LinqToDbGetCustomerSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<NewCustomerDto?> GetCustomerByIdAsync(Guid customerId) =>
        DataConnection.GetTable<NewCustomerDto>()
                      .FirstOrDefaultAsync(customer => customer.CustomerId == customerId);
}