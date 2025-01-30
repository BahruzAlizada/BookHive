namespace BookHive.Application.Parametres.ResponseParametres
{
    public record ErrorResult : Result
    {
        public ErrorResult(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
