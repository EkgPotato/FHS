using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using Mapster;

namespace Mapper.Registers.Features;

public class ExpenseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Expense, ExpenseListModel>()
            .Map(dest => dest.CategoryName, src => src.DictExpenseCategory != null ? src.DictExpenseCategory.Name : "");
    }
}