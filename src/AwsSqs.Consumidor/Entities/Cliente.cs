using System;

namespace AwsSqs.Consumidor.Entities
{
    public class Cliente : Entity
    {
        protected Cliente() { }
        public Cliente(string nome, string sobrenome, string cpf, DateTime dataNascimento, string telefone, string email)
        {
            Nome = nome;
            SobreNome = sobrenome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
        }

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
    }
}
