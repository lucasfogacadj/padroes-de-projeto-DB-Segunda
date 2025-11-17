using Application.DTOs;
using FluentValidation;
public class ProdutoCreateDtoValidator : AbstractValidator<ProdutoCreateDto>
{
    public ProdutoCreateDtoValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .WithMessage("Nome do produto é obrigatório.")
            .MaximumLength(200)
            .WithMessage("O nome do produto não pode ter mais de 200 caracteres.")
            .Must(nome => !string.IsNullOrWhiteSpace(nome))
            .WithMessage("O nome do produto não pode conter apenas espaços em branco.");

        RuleFor(p => p.Descricao)
            .MaximumLength(1000)
            .WithMessage("A descrição não pode ter mais de 1000 caracteres")
            .When(p => !string.IsNullOrWhiteSpace(p.Descricao));
            
        RuleFor(p => p.Preco)
            .GreaterThan(0)
            .WithMessage("Preço deve de ser maior que zero")
            .PrecisionScale(10, 2, ignoreTrailingZeros: true)
            .WithMessage("Preço deve ter no maixmo duas casas decimais e conter dez digitos no total");

        RuleFor(p => p.Estoque)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O estoque não pode ser negativo");
    }
}