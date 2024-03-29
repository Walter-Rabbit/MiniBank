﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniBank.Core.Domain.Currencies;

namespace MiniBank.Data.Accounts;

public class AccountDbModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public double Balance { get; set; }
    public Currency Currency { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateOpened { get; set; }
    public DateTime? DateClosed { get; set; }
}

internal class Map : IEntityTypeConfiguration<AccountDbModel>
{
    public void Configure(EntityTypeBuilder<AccountDbModel> builder)
    {
        builder.ToTable("account");
    }
}