﻿using MiniBank.Core.Domain.Currencies;

namespace MiniBank.Web.Controllers.Accounts.Dto;

public class AccountCreateDto
{
    public Guid UserId { get; set; }
    public double Balance { get; set; }
    public Currency Currency { get; set; }
}