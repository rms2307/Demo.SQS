using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Demo.SQS.Consumidor
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var queueUrl = "https://sqs.sa-east-1.amazonaws.com/653342422270/demosqs";

            Console.WriteLine("Iniciando...");

            var client = new AmazonSQSClient(RegionEndpoint.SAEast1);
            var request = new ReceiveMessageRequest
            {
                QueueUrl = queueUrl
            };

            while (true)
            {
                var response = await client.ReceiveMessageAsync(request);
                foreach (var message in response.Messages)
                {
                    Console.WriteLine("Recebendo mensagem.");
                    Console.WriteLine(message.Body);
                    await client.DeleteMessageAsync(queueUrl, message.ReceiptHandle);
                }
            }
        }
    }
}