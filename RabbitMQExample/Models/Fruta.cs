namespace RabbitMQExample.Models
{
    public class Fruta
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraSolicitacao { get; set; } = DateTime.Now;  
        public string Cor { get; set; }
    }
}
