﻿namespace ProjetoWeb.DTO
{
    public class JwtAuthentication
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}