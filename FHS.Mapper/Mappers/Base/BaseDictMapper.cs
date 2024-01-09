using FHS.Entities.Dto;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;
using Mapper.Interfaces.Base;
using Mapster;

namespace Mapper.Mappers.Base;

public abstract class BaseDictMapper<TDictListModel, TDictModel, TDictEntity> 
    : BaseMapper<TDictListModel, TDictModel, TDictEntity>,
        IBaseDictMapper<TDictListModel, TDictModel, TDictEntity>
    where TDictListModel : BaseDictListModel
    where TDictModel : BaseDictModel
    where TDictEntity : BaseDictEntity
{
}