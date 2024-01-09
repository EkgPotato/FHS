using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using Mapper.Interfaces.Features;
using Mapper.Mappers.Base;

namespace Mapper.Mappers.Features;

public sealed class DictExpenseCategoryMapper :
    BaseDictMapper<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory>, IDictExpenseCategoryMapper
{
}