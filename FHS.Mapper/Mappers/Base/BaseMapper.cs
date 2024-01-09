using FHS.Entities.Dto;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;
using Mapper.Interfaces.Base;
using Mapster;

namespace Mapper.Mappers.Base;

public abstract class BaseMapper<TListModel, TModel, TEntity> : IBaseMapper<TListModel, TModel, TEntity>
    where TListModel : BaseListModel
    where TModel : BaseModel
    where TEntity : BaseEntity
{
    public TModel MapToModel(TEntity? source)
    {
        return source.Adapt<TModel>();
    }

    public TEntity MapToEntity(TModel? source)
    {
        return source.Adapt<TEntity>();
    }

    public IEnumerable<TListModel> MapToListModels(IEnumerable<TEntity> sourceEnumerable)
    {
        return sourceEnumerable.Adapt<IEnumerable<TListModel>>();
    }
}