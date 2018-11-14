using System;

namespace Sistema.Cadastro.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Count { get; set; }
    }
}