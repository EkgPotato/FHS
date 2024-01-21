using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Interfaces.Mapper.Features;
using Mapper.Mappers.Base;

namespace Mapper.Mappers.Features;

public sealed class DictIncomeCategoryMapper :
    BaseDictMapper<DictIncomeCategoryListModel, DictIncomeCategoryModel, DictIncomeCategory>, IDictIncomeCategoryMapper
{
}