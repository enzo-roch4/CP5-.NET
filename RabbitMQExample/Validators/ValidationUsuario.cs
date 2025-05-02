using System;
using RabbitMQExample.Models;

namespace RabbitMQExample.Validators
{
    public class ValidationUsuario
    {
        public bool Validar(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome) ||
                string.IsNullOrWhiteSpace(usuario.RG) ||
                string.IsNullOrWhiteSpace(usuario.CPF))
            {
                Console.WriteLine(" [!] Usuario inválido.");
                return false;
            }
            Console.WriteLine(" [✓] Usuario validado com sucesso.");
            return true;
        }
    }
}
