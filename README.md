# Envio e recepção de mensagens numa fila do Amazon SQS
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

### Pacotes Utilizados
```bash
1 - Install-Package Microsoft.Extensions.DependencyInjection (Para configuração das injeções de dependência)
2 - Install-Package Newtonsoft.Json (Serialização da entidade cliente para envio e recepção da fila)
3 - Install-Package Bogus (Apenas para gerar clientes aleatórios para envio para a fila)
4 - Install-Package AWSSDK.SQS (Comunicação com o SQS)
```
### Client
```CSharp
var _client = new AmazonSQSClient(Amazon.RegionEndpoint.SAEast1);
```
### Envio
```CSharp
var clientes = GerarDadosCliente(quantidade);

clientes.ForEach(async(cliente) => 
{
  
  var message = new SendMessageRequest 
  {
      QueueUrl = "URL_DA_FILA",
      MessageBody = JsonConvert.SerializeObject(cliente, Formatting.Indented)
  };

  await _client.SendMessageAsync(message);

});
```
### Recepção
```CSharp
var urllFila = "URL_DA_FILA";

var request = new ReceiveMessageRequest 
{
    QueueUrl = urllFila
};

var response = await _client.ReceiveMessageAsync(request);

foreach(var mensagem in response.Messages) 
{
    //processamento da mensagem
    System.Console.WriteLine(mensagem.Body);

    //exclusão da fila pós processamento
    await RemoverMensagemFila(urllFila, mensagem.ReceiptHandle);
}
```
### Remoção da mensagem na fila
```CSharp
await _client.DeleteMessageAsync(urlFila, handle);
```
## Tecnologias
<div style="display: inline_block"><br>
  <img align="center" alt="Jeferson-Netcore" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg">
  <img align="center" alt="Jeferson-Csharp" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg">
  <img align="center" alt="Jeferson-Aws" height="30" width="40" src="https://github.com/devicons/devicon/blob/master/icons/amazonwebservices/amazonwebservices-original-wordmark.svg">
</div>
