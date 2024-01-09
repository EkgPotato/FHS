using FHS.Entities.Dto.Dict;
using FHS.Entities.Dto.Features;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.ListModel.Features;
using FHS.Entities.Model.Dict;
using FHS.Entities.Model.Features;
using Mapper.Interfaces.Base;

namespace Mapper.Interfaces.Features;

public interface IDictExpenseCategoryMapper : IBaseDictMapper<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory>
{
    
}