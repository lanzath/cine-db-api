using FluentValidation;

namespace CineDb.Domain.Command.Commands.Movies.Create;

public sealed class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(property => property.Title).NotNull().MinimumLength(2).MaximumLength(100);
        RuleFor(property => property.Genre).NotNull().IsInEnum();
        RuleFor(property => property.Year).NotNull();
        RuleFor(property => property.Director).NotNull().ChildRules(director =>
        {
            director.RuleFor(property => property.Name).NotNull().MinimumLength(3).MaximumLength(100);
            director.RuleFor(property => property.Age).NotNull().GreaterThan(0);
            director.RuleFor(property => property.OriginCountry).NotNull().MinimumLength(3).MaximumLength(100);
        });
    }
}