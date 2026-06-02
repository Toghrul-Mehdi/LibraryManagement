using FluentValidation;
using LibraryManagement.Application.DTOs.Book;

namespace LibraryManagement.Application.Validators.Book;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Kitabın adı boş ola bilməz.")
            .MaximumLength(200).WithMessage("Kitabın adı maksimum 200 simvol ola bilər.");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Müəllif adı boş ola bilməz.")
            .MaximumLength(100).WithMessage("Müəllif adı maksimum 100 simvol ola bilər.");

        RuleFor(x => x.Year)
            .GreaterThan(0).WithMessage("İl 0-dan böyük olmalıdır.")
            .LessThanOrEqualTo(DateTime.UtcNow.Year).WithMessage("İl cari ildən böyük ola bilməz.")
            .InclusiveBetween(1000, DateTime.UtcNow.Year)
            .WithMessage($"İl 1000 ilə {DateTime.UtcNow.Year} arasında olmalıdır.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Qiymət boş ola bilməz.")
            .InclusiveBetween(0.01m, 10000m).WithMessage("Qiymət 0.01 ilə 10,000 arasında olmalıdır.");
    }
}