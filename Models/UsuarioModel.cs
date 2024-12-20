﻿namespace Api.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string FotoUsuario { get; set; } = string.Empty;

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioCpf { get; set; } = string.Empty;

        public string UsuarioEndereco { get; set; } = string.Empty;

        public string UsuarioTelefone { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public string UsuarioSenha { get; set; } = string.Empty;

        public static implicit operator List<object>(UsuarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
