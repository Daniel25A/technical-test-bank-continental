﻿namespace WebApi.Models.Response;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}