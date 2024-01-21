using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Dto;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Common.Crud;

namespace FHS.Interfaces.Services.Base;

public interface IBaseCrudService<TListModel, TModel, TEntity>
    where TListModel : IBaseListModel
    where TModel : IBaseModel
    where TEntity : IBaseEntity
{
    Task<TModel?> GetAsync(int id, ICrudResult result);
    Task<IEnumerable<TListModel>> GetAllAsync(ICrudResult result);
    Task CreateAsync(TModel model, ICrudResult result);
    Task UpdateAsync(int id, TModel model, ICrudResult result);
    Task DeleteAsync(int id, ICrudResult result);
}