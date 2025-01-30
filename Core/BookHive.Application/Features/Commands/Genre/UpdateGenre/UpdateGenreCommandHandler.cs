using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.GenreValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Genre.UpdateGenre
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest, UpdateGenreCommandResponse>
    {
        private readonly IGenreWriteRepository genreWriteRepository;
        private readonly IGenreRuleService genreRuleService;
        private readonly IMapper mapper;
        public UpdateGenreCommandHandler(IGenreWriteRepository genreWriteRepository, IGenreRuleService genreRuleService, IMapper mapper)
        {
            this.genreWriteRepository = genreWriteRepository;
            this.genreRuleService = genreRuleService;   
            this.mapper = mapper;
        }


        public async Task<UpdateGenreCommandResponse> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new GenreUpdateValidator().ValidateAsync(request.GenreUpdateDto);
            if(!validationResult.IsValid)
            {
                return new UpdateGenreCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(genreRuleService.CheckIfNameExisted(request.GenreUpdateDto.Name, request.GenreUpdateDto.CategoryId, request.GenreUpdateDto.Id));
            if (!result.Success)
            {
                return new UpdateGenreCommandResponse
                {
                    Result = result
                };
            }

            BookHive.Domain.Entities.Genre genre = mapper.Map<BookHive.Domain.Entities.Genre>(request.GenreUpdateDto);

            genreWriteRepository.Update(genre);
            await genreWriteRepository.SaveAsync();

            return new UpdateGenreCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessUpdated
                }
            };

        }
    }
}
