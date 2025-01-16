using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;

namespace BookHive.Application.Rules.Concrete
{
    public class GenreRuleService : IGenreRuleService
    {
        private readonly IGenreReadRepository genreReadRepository;
        public GenreRuleService(IGenreReadRepository genreReadRepository)
        {
            this.genreReadRepository = genreReadRepository;
        }


        public Result CheckIfNameExisted(string name, Guid categoryId, Guid? id = null)
        {
            if (id.HasValue)
            {
                var genreExist = genreReadRepository.GetAll(false).Any(x => x.Name == name && x.CategoryId == categoryId && x.Id != id);

                if (genreExist)
                {
                    return new Result
                    {
                        Success = false,
                        Message = Messages.CheckIfNameExisted
                    };
                }
            }
            else
            {
                var genreExist = genreReadRepository.GetAll(false).Any(x => x.Name == name && x.CategoryId == categoryId);
                if (genreExist)
                {
                    return new Result
                    {
                        Success = false,
                        Message = Messages.CheckIfNameExisted
                    };
                }
            }

            return new Result
            {
                Success = true,
            };
        }
    }
}
