using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Rule
{
    public class BusinessRules
    {
        public static Result Run(params Result[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return new Result { Success = true};
        }
    }
}
