﻿using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionComplex;

public interface IGetCollectionComplexSession : IAsyncReadOnlySession
{
    Task<CollectionComplexEntity?> GetCollectionComplexByIdAsync(int id);
}