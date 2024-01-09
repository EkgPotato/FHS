using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using FHS.Services.Interfaces.Base;

namespace FHS.Services.Interfaces.Dict;

public interface IDictExpenseCategoryService 
    : IBaseDictCrud<DictExpenseCategoryListModel, DictExpenseCategoryModel, DictExpenseCategory>
{
    
}