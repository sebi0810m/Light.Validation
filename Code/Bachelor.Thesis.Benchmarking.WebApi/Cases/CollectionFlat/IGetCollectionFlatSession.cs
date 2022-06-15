﻿using Bachelor.Thesis.Benchmarking.CollectionFlat;
using Synnotech.DatabaseAbstractions;

namespace Bachelor.Thesis.Benchmarking.WebApi.Cases.CollectionFlat;

public interface IGetCollectionFlatSession : IAsyncReadOnlySession
{
    Task<SerializedCollectionFlat?> GetCollectionFlatByIdAsync(Guid id);
}