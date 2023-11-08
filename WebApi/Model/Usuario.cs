﻿namespace WebApi.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

    public class UsuarioDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
