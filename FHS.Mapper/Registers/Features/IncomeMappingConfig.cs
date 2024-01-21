using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using Mapster;

namespace Mapper.Registers.Features;

public class IncomeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Income, IncomeListModel>()
            .Map(dest => dest.CategoryName, src => src.DictIncomeCategory != null ? src.DictIncomeCategory.Name : "");
    }
}