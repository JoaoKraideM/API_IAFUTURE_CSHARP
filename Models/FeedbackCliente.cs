namespace Models
{
    public class FeedbackCliente
    {
        public int IdFeedback { get; set; }
        public DateOnly DataFeedback { get; set; }
        public string Comentario { get; set; }
        public int Avaliacao { get; set; }
    }
}
