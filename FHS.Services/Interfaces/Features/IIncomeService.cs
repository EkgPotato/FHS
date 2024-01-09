using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Services.Interfaces.Base;

namespace FHS.Services.Interfaces.Features;

public interface IIncomeService : IBaseCrudService<IncomeListModel, IncomeModel, Income>
{
    
}