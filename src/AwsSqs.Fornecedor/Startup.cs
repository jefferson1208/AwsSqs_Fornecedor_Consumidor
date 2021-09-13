using Amazon.SQS;
using Amazon.SQS.Model;
using AwsSqs.Fornecedor.Entities;
using Bogus;
using Bogus.Extensions.Brazil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AwsSqs.Fornecedor
{
    public class Startup
    {
        private readonly AmazonSQSClient _client;

        public Startup(AmazonSQSClient client)
        {
            _client = client;
        }

        public void PublicarMensagemNaFila(int quantidade = 1)
        {
            var clientes = GerarDadosCliente(quantidade);

            clientes.ForEach(async(cliente) =>
            {
                var message = new SendMessageRequest
                {
                    QueueUrl = "URL_DA_FILA",
                    MessageBody = JsonConvert.SerializeObject(cliente, Formatting.Indented),

                };

                await _client.SendMessageAsync(message);

            });

        }

        private List<Cliente> GerarDadosCliente(int quantidade)
        {
            //Dados gerados com pacote nuget BOGUS (apenas teste)

            var clientes = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(p => new Cliente(
                    p.Person.FirstName,
                    p.Person.LastName,
                    p.Person.Cpf(),
                    DateTime.Now,
                    p.Person.Phone, ""))
                .RuleFor(p => p.Email, (v, p) => v.Internet.Email(p.Nome, p.SobreNome));

            return clientes.Generate(quantidade);
        }
    }
}
