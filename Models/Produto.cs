namespace SGPE.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime DataCriacao = DateTime.Now;
    }
}
