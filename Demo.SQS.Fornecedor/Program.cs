using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Demo.SQS.Fornecedor
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando...");

            var client = new AmazonSQSClient(RegionEndpoint.SAEast1);
            for (int i = 1; i <= 3; i++)
            {
                var request = new SendMessageRequest
                {
                    QueueUrl = "https://sqs.sa-east-1.amazonaws.com/653342422270/demosqs",
                    MessageBody = $"Mensagem nº{i}"                    
                };

                Console.WriteLine($"Enviando mensagem {i} para fila.");
                await client.SendMessageAsync(request);
                Console.WriteLine("Mensagem enviada.");
            }           
        }
    }
}