using System;
using RabbitMQExample.Models;

namespace RabbitMQExample.Validators
{
    public class ValidationFruta
    {
        public bool Validar(Fruta fruta)
        {
            if (string.IsNullOrWhiteSpace(fruta.Nome) || string.IsNullOrWhiteSpace(fruta.Descricao))
            {
                Console.WriteLine(" [!] Fruta inválida.");
                return false;
            }
            Console.WriteLine(" [✓] Fruta validada com sucesso.");
            return true;
        }
    }
}
