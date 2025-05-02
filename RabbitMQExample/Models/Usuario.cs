namespace RabbitMQExample.Models
{
    public class Usuario
    {
        public string Endereco { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataHoraRegistro { get; set; } = DateTime.Now;
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
