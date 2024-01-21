using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Interfaces.Services.Base;

namespace FHS.Interfaces.Services.Dict;

public interface IDictExpenseCategoryService 
    : IBaseDictCrud<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory>
{
    
}