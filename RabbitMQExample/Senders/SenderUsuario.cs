using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using System.Threading.Tasks;
using RabbitMQExample.Models;

namespace RabbitMQExample.Senders
{
    public class SenderUsuario
    {
        public static async Task EnviarUsuarioAsync(Usuario usuario)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "usuarios",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = JsonSerializer.Serialize(usuario);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "usuarios",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($"[x] Usuario enviado: {usuario.Nome}");

        }
    }
}
