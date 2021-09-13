using Amazon.SQS;
using Amazon.SQS.Model;
using System.Threading.Tasks;

namespace AwsSqs.Consumidor
{
    public class Startup
    {
        private readonly AmazonSQSClient _client;

        public Startup(AmazonSQSClient client)
        {
            _client = client;
        }
        public async Task LerMensagensFila()
        {
            var urllFila = "URL DA FILA";

            var request = new ReceiveMessageRequest
            {
                QueueUrl = urllFila
            };

            var response = await _client.ReceiveMessageAsync(request);

            foreach (var mensagem in response.Messages)
            {
                //processamento da mensagem
                System.Console.WriteLine(mensagem.Body);


                //exclusão da fila pós processamento
                await RemoverMensagemFila(urllFila, mensagem.ReceiptHandle);
            }
        }

        public async Task RemoverMensagemFila(string urlFila, string handle)
        {
            await _client.DeleteMessageAsync(urlFila, handle);
        }
    }
}
