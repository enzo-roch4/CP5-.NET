using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQExample.Models;

namespace RabbitMQExample.Receivers
{
    public class ReceiverUsuario
    {
        public static void ReceberUsuarios()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "usuarios",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var usuario = JsonSerializer.Deserialize<Usuario>(message);
                Console.WriteLine($"[x] Recebido Usuario: {usuario?.Nome}");
            };

            channel.BasicConsume(queue: "usuarios",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine("Pressione [enter] para sair.");
            Console.ReadLine();
        }
    }
}
