﻿using Bachelor.Thesis.Benchmarking.ParametersComplexTwo.Dto;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using Synnotech.Linq2Db;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.ParametersComplexTwo;

public class LinqToDbAddCustomerSession : AsyncSession, IAddCustomerSession
{
    public LinqToDbAddCustomerSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<object> InsertCustomerAsync(CustomerDto customer)
    {
        var serializedCustomer = new SerializedCustomerDto
        {
            CustomerId = customer.CustomerId,
            User = JsonConvert.SerializeObject(customer.User),
            Address = JsonConvert.SerializeObject(customer.Address)
        };
        
        return DataConnection.InsertWithIdentityAsync(serializedCustomer);
    }
}