using FHS.Entities.Dto;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;

namespace Mapper.Interfaces.Base;

public interface IBaseDictMapper<TDictListModel, TDictModel, TDictEntity> 
    : IBaseMapper<TDictListModel, TDictModel, TDictEntity>
where TDictListModel : BaseDictListModel
where TDictModel : BaseDictModel
where TDictEntity : BaseDictEntity
{

}