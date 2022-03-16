﻿using MiniBank.Core.Tools;

namespace MiniBank.Web.Dtos;

public class UserDto
{
    private string _login = string.Empty;
    private string _email= string.Empty;

    public Guid Id { get; set; }

    public string Login
    {
        get => _login;
        set => _login = value ?? throw new ValidationException("Login is null");
    }

    public string Email
    {
        get => _email;
        set => _email = value ?? throw new ValidationException("Email is null");
    }

    public int AccountsAmount { get; set; }
}