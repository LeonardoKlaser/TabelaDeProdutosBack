using FluentValidation;
using APIweb.Models;

namespace APIweb.Validations
{
    public class ValidateProduct : AbstractValidator<Produto>
    {
        public ValidateProduct()
        {
            RuleFor(x => x.nomeProduto).NotEmpty().WithMessage("O campo nome é obrigatório")
                .MaximumLength(15).MinimumLength(3).WithMessage("Numero de caracteres invalido");
        }
    }
}
