using FHS.Entities.Dto;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;

namespace Mapper.Interfaces.Base;

public interface IBaseMapper<TListModel, TModel, TEntity> 
where TListModel : BaseListModel
where TModel : BaseModel
where TEntity : BaseEntity
{
    TModel MapToModel(TEntity? source);
    TEntity MapToEntity(TModel? source);
    IEnumerable<TListModel> MapToListModels(IEnumerable<TEntity> sourceEnumerable);
}