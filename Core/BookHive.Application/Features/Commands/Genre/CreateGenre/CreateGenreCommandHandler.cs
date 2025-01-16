
using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.GenreValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Genre.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommandRequest, CreateGenreCommandResponse>
    {
        private readonly IGenreWriteRepository genreWriteRepository;
        private readonly IGenreRuleService genreRuleService;
        private readonly IMapper mapper;
        public CreateGenreCommandHandler(IGenreWriteRepository genreWriteRepository, IGenreRuleService genreRuleService, IMapper mapper)
        {
            this.genreWriteRepository = genreWriteRepository;
            this.genreRuleService = genreRuleService;
            this.mapper = mapper;
        }


        public async Task<CreateGenreCommandResponse> Handle(CreateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new GenreAddValidator().ValidateAsync(request.GenreAddDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                return new CreateGenreCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(genreRuleService.CheckIfNameExisted(request.GenreAddDto.Name, request.GenreAddDto.CategoryId));
            if (!result.Success)
            {
                return new CreateGenreCommandResponse
                {
                    Result = result
                };
            }

            BookHive.Domain.Entities.Genre genre = mapper.Map<BookHive.Domain.Entities.Genre>(request.GenreAddDto);
            
            await genreWriteRepository.AddAsync(genre);
            await genreWriteRepository.SaveAsync();

            return new CreateGenreCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessAdded
                }
            };

        }
    }
}
