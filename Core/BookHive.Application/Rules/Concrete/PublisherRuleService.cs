using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rules.Abstract;

namespace BookHive.Application.Rules.Concrete
{
    public class PublisherRuleService : IPublisherRuleService
    {
        private readonly IPublisherReadRepository publisherReadRepository;
        public PublisherRuleService(IPublisherReadRepository publisherReadRepository)
        {
            this.publisherReadRepository = publisherReadRepository;
        }


        public Result CheckIfNameExisted(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var publisherExist = publisherReadRepository.GetAll(false).Any(x => x.Name == name && x.Id != id);

                if (publisherExist)
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
                var publisherExist = publisherReadRepository.GetAll(false).Any(x => x.Name == name);
                if (publisherExist)
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
