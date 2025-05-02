using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using System.Threading.Tasks;
using RabbitMQExample.Models;

namespace RabbitMQExample.Senders
{
    public class SenderFruta
    {
        public static async Task EnviarFrutaAsync(Fruta fruta)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "frutas",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = JsonSerializer.Serialize(fruta);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "frutas",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($"[x] Fruta enviada: {fruta.Nome}");

        }
    }
}
