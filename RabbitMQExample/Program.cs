using RabbitMQExample.Senders;
using RabbitMQExample.Receivers;
using RabbitMQExample.Models;

namespace RabbitMQExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Enviar Usuario");
            Console.WriteLine("2 - Enviar Fruta");
            Console.WriteLine("3 - Receber Usuarios");
            Console.WriteLine("4 - Receber Frutas");
            Console.Write("Opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var usuario = new Usuario
                    {
                        Nome = "Enzo Franco",
                        Email = "enzo@exemplo.com"
                    };
                    await SenderUsuario.EnviarUsuarioAsync(usuario);
                    Console.WriteLine("Usuario enviado com sucesso!");
                    break;

                case "2":
                    var fruta = new Fruta
                    {
                        Nome = "Maçã",
                        Cor = "Vermelha"
                    };
                    await SenderFruta.EnviarFrutaAsync(fruta);
                    Console.WriteLine("Fruta enviada com sucesso!");
                    break;

                case "3":
                    Console.WriteLine("Aguardando usuarios...");
                    await ReceiverUsuario.ReceberUsuariosAsync();
                    break;

                case "4":
                    Console.WriteLine("Aguardando frutas...");
                    await ReceiverFruta.ReceberFrutasAsync();
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
