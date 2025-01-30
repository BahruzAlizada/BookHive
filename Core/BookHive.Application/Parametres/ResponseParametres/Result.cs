namespace BookHive.Application.Parametres.ResponseParametres
{
    public record Result
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
