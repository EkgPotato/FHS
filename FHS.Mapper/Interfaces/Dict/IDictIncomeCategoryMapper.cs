using FHS.Entities.Dto.Dict;
using FHS.Entities.ListModel.Dict;
using FHS.Entities.Model.Dict;
using Mapper.Interfaces.Base;

namespace Mapper.Interfaces.Features;

public interface
    IDictIncomeCategoryMapper : IBaseDictMapper<DictIncomeCategoryListModel, DictIncomeCategoryModel, DictIncomeCategory>
{
}