﻿using MiniBank.Core.Domain.Currencies;

namespace MiniBank.Web.Controllers.Accounts.Dto;

public class AccountDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public double Balance { get; set; }
    public Currency Currency { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateOpened { get; set; }
    public DateTime? DateClosed { get; set; }
}