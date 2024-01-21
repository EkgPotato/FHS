using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Features;
using FHS.Interfaces.Mapper.Features;
using Mapper.Mappers.Base;

namespace Mapper.Mappers.Features;

public sealed class IncomeMapper : BaseMapper<IncomeListModel, IncomeModel, Income>, IIncomeMapper
{
}