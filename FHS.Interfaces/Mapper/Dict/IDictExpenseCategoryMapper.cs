using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Interfaces.Mapper.Base;

namespace FHS.Interfaces.Mapper.Features;

public interface IDictExpenseCategoryMapper : IBaseDictMapper<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory>
{

}