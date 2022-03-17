﻿using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Entities;
using MiniBank.Core.Services.Interfaces;
using MiniBank.Web.Dtos;

namespace MiniBank.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("GetAccountById")]
    public AccountDto GetAccountById([FromQuery] Guid id)
    {
        var account = _accountService.GetById(id);

        return new AccountDto
        {
            Id = account.Id,
            UserId = account.UserId,
            Balance = account.Balance,
            Currency = account.Currency,
            IsActive = account.IsActive,
            DateOpened = account.DateOpened,
            DateClosed = account.DateClosed
        };
    }

    [HttpGet("GetAllAccounts")]
    public IEnumerable<AccountDto> GetAllAccounts()
    {
        var accounts = _accountService.GetAll();

        return accounts.Select(a => new AccountDto
        {
            Id = a.Id,
            UserId = a.UserId,
            Balance = a.Balance,
            Currency = a.Currency,
            IsActive = a.IsActive,
            DateOpened = a.DateOpened,
            DateClosed = a.DateClosed
        });
    }

    [HttpPost("CreateAccount")]
    public Guid CreateAccount([FromQuery] AccountInfoDto accountInfoDto)
    {
        var account = new Account
        {
            UserId = accountInfoDto.UserId,
            Balance = accountInfoDto.Balance,
            Currency = accountInfoDto.Currency,
            DateClosed = accountInfoDto.DateClosed
        };

        return _accountService.CreateAccount(account);
    }

    [HttpPut("CloseAccount")]
    public void CloseAccount(Guid id)
    {
        _accountService.CloseAccount(id);
    }

    [HttpGet("CalculateCommission")]
    public double CalculateCommission(
        [FromQuery] double amount,
        [FromQuery] Guid fromAccountId,
        [FromQuery] Guid toAccountId)
    {
        return _accountService.CalculateCommission(amount, fromAccountId, toAccountId);
    }

    [HttpPost("MakeTransaction")]
    public Guid MakeTransaction(
        [FromQuery] double amount,
        [FromQuery] Guid fromAccountId,
        [FromQuery] Guid toAccountId)
    {
        return _accountService.MakeTransaction(amount, fromAccountId, toAccountId);
    }
}