namespace BookHive.Application.Parametres.ResponseParametres
{
    public record SuccessResult : Result
    {
        public SuccessResult(string message)
        {
            Success = true;
            Message = message;
        }
    }
}
