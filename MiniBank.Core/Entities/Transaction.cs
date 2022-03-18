﻿namespace MiniBank.Core.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public string Currency { get; set; }
    public double Amount { get; set; }
    public double Commission { get; set; }
    public Guid FromAccountId { get; set; }
    public Guid ToAccountId { get; set; }
}