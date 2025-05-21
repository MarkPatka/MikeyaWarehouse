using FluentValidation;

namespace MikeyaWarehouse.Application.Inventory.Queries.PalletExpires;

public class GetPalletExpiresQueryValidator 
    : AbstractValidator<GetPalletExpiresQuery>
{
    public GetPalletExpiresQueryValidator()
    {
        RuleFor(x => x.Pallets).NotEmpty();
        RuleFor(x => x.Direction)
            .Must(dir => dir != null && 
                 (dir.Equals("ASC", StringComparison.OrdinalIgnoreCase) || dir.Equals("DESC", StringComparison.OrdinalIgnoreCase)))
            .WithMessage("Direction can be either 'ASC' or 'DESC'.");
    }
}
