using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EfCore.BulkOperations;

public static class DbContextExtensions
{
     /// <summary>
    ///     Performs an asynchronous bulk insert operation.
    /// </summary>
    /// <param name="dbContext">The DbContext instance to use for the operation.</param>
    /// <param name="items">A collection of entities.</param>
    /// <param name="optionFactory">Optional factory function for configuring bulk operation (batch size, ignore properties).</param>
    /// <param name="transaction">An optional transaction for the operation.</param>
    /// <param name="cancellationToken">Cancellation Token.</param>
    /// <returns>the total number of rows affected.</returns>
    public static async Task<int> BulkInsertAsync<T>(this DbContext dbContext,
        IReadOnlyCollection<T> items,
        Action<BulkOption<T>>? optionFactory = null,
        DbTransaction? transaction = null,
        CancellationToken? cancellationToken = null)
        where T : class
    {
        return await EfCoreBulkUtils.BulkInsertAsync(dbContext, items, optionFactory, transaction, cancellationToken);
    }


    /// <summary>
    ///     Performs an asynchronous bulk update operation.
    /// </summary>
    /// <param name="dbContext">The DbContext instance to use for the operation.</param>
    /// <param name="items">A collection of entities.</param>
    /// <param name="optionFactory">Optional factory function for configuring bulk operation (batch size, ignore properties).</param>
    /// <param name="transaction">An optional transaction for the operation.</param>
    /// <param name="cancellationToken">Cancellation Token.</param>
    /// <returns>the total number of rows affected.</returns>
    public static async Task<int> BulkUpdateAsync<T>(this DbContext dbContext,
        IReadOnlyCollection<T> items,
        Action<BulkOption<T>>? optionFactory = null,
        DbTransaction? transaction = null,
        CancellationToken? cancellationToken = null)
        where T : class
    {
        return await EfCoreBulkUtils.BulkUpdateAsync(dbContext, items, optionFactory, transaction, cancellationToken);
    }

    /// <summary>
    ///     Performs an asynchronous bulk delete operation.
    /// </summary>
    /// <param name="dbContext">The DbContext instance to use for the operation.</param>
    /// <param name="items">A collection of entities.</param>
    /// <param name="optionFactory">Optional factory function for configuring bulk operation (batch size, ignore properties).</param>
    /// <param name="transaction">An optional transaction for the operation.</param>
    /// <param name="cancellationToken">Cancellation Token.</param>
    /// <returns>the total number of rows affected.</returns>
    public static async Task<int> BulkDeleteAsync<T>(this DbContext dbContext,
        IReadOnlyCollection<T> items,
        Action<BulkOption<T>>? optionFactory = null,
        DbTransaction? transaction = null,
        CancellationToken? cancellationToken = null)
        where T : class
    {
        return await EfCoreBulkUtils.BulkDeleteAsync(dbContext, items, optionFactory, transaction, cancellationToken);
    }


    /// <summary>
    ///     Performs an asynchronous bulk merge operation.
    ///     (use `ON DUPLICATE KEY UPDATE` which is support MySql only)
    /// </summary>
    /// <param name="dbContext">The DbContext instance to use for the operation.</param>
    /// <param name="items">A collection of entities.</param>
    /// <param name="optionFactory">Optional factory function for configuring bulk operation (batch size, ignore properties).</param>
    /// <param name="transaction">An optional transaction for the operation.</param>
    /// <param name="cancellationToken">Cancellation Token.</param>
    /// <returns>the total number of rows affected.</returns>
    public static async Task<int> BulkMergeAsync<T>(this DbContext dbContext,
        List<T> items,
        Action<BulkOption<T>>? optionFactory = null,
        DbTransaction? transaction = null,
        CancellationToken? cancellationToken = null)
        where T : class
    {
        return await EfCoreBulkUtils.BulkMergeAsync(dbContext, items, optionFactory, transaction, cancellationToken);
    }
}