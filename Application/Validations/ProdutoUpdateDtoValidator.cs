using FluentValidation;

public class ProdutoUpdateDtoValidator : AbstractValidator < ProdutoUpdateDto >
{
    public ProdutoUpdateDtoValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty()
            .WithMessage("Nome do produto é obrigatorio") 
            .MaximumLength(200)
            .WithMessage("O nome do produto nao pode ter mais de 200 caracteres")
            .Must(nome => !string.IsNullOrWhiteSpace(nome))
            .WithMessage("O nome do produto nao pode ter espaço em branco");
        
    }
} 