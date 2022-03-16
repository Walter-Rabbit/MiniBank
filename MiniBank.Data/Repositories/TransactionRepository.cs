﻿using MiniBank.Core.Entities;
using MiniBank.Core.Repositories;
using MiniBank.Core.Tools;
using MiniBank.Data.Repositories.DbModels;

namespace MiniBank.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private static readonly List<TransactionDbModel> Transactions = new();

    public Transaction GetTransactionById(Guid id)
    {
        var transactionDbModel = Transactions.FirstOrDefault(t => t.Id == id);

        if (transactionDbModel is null)
        {
            throw new NotFoundException("There is no transaction with such id");
        }

        return new Transaction(
            transactionDbModel.Id,
            transactionDbModel.Amount,
            transactionDbModel.Currency,
            transactionDbModel.FromAccountId,
            transactionDbModel.ToAccountId);
    }

    public IEnumerable<Transaction> GetAllTransactions()
    {
        return Transactions.Select(t => new Transaction(
            t.Id,
            t.Amount,
            t.Currency,
            t.FromAccountId,
            t.ToAccountId));
    }

    public Guid CreateTransaction(Transaction transaction)
    {
        var transactionDbModel = new TransactionDbModel(
            Guid.NewGuid(), 
            transaction.Amount,
            transaction.Currency,
            transaction.FromAccountId,
            transaction.ToAccountId);

        Transactions.Add(transactionDbModel);

        return transactionDbModel.Id;
    }

    public void UpdateTransaction(Transaction transaction)
    {
        var transactionDbModel = Transactions.FirstOrDefault(t => t.Id == transaction.Id);

        if (transactionDbModel is null)
        {
            throw new NotFoundException("There is no such transaction");
        }

        transactionDbModel.Amount = transaction.Amount;
        transactionDbModel.Currency = transaction.Currency;
        transactionDbModel.FromAccountId = transaction.FromAccountId;
        transactionDbModel.ToAccountId = transaction.ToAccountId;
    }

    public void DeleteTransaction(Guid id)
    {
        var transactionDbModel = Transactions.FirstOrDefault(t => t.Id == id);

        if (transactionDbModel is null)
        {
            throw new NotFoundException("There is no such transaction");
        }

        Transactions.Remove(transactionDbModel);
    }
}