﻿using MiniBank.Core.Tools;

namespace MiniBank.Web.Dtos;

public class AccountDto
{
    private string _currency = string.Empty;

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public double Balance { get; set; }

    public string Currency
    {
        get => _currency;
        set => _currency = value ?? throw new ValidationException("Currency is null");
    }

    public bool IsActive { get; set; }
    public DateTime DateOpened { get; set; }
    public DateTime DateClosed { get; set; }
}