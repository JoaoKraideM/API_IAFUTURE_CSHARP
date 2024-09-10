namespace Models
{
    public class InteracaoCliente
    {
        public int IdInteracao { get; set; }
        public DateOnly DataInteracao { get; set; }
        public string Tipo { get; set; }
        public string Canal { get; set; }
    }
}
