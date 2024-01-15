using DataService.Data;
using FHS.Entities.Dto;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;
using FHS.Resources.Logs;
using FHS.Resources.Messages;
using FHS.Services.Interfaces.Base;
using FHS.Utilities.Exceptions.Service;
using FHS.Utilities.ServicesUtilities.Crud;
using Mapper.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FHS.Services.Service.Base;

public abstract class BaseCrudService<TListModel, TModel, TEntity, TMapper> : IBaseCrudService<TListModel, TModel, TEntity>
    where TListModel : BaseListModel
    where TModel : BaseModel
    where TEntity : BaseEntity
    where TMapper : IBaseMapper<TListModel, TModel, TEntity>
{
    public readonly ILogger _logger;
    protected AppDbContext _dbContext;
    internal DbSet<TEntity> _dbSet;
    protected readonly TMapper _mapper;

    protected BaseCrudService(ILogger logger, AppDbContext dbContext, TMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TModel> GetAsync(int id, CrudResult result)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

        if (entity == null)
        {
            result.AddMessage(CrudResultMessages.GetAsync_InvalidId);
            return null;
        }

        return _mapper.MapToModel(entity);
    }

    public async Task<IEnumerable<TListModel>> GetAllAsync(CrudResult result)
    {
        var dbset = await _dbSet.ToListAsync();

        return _mapper.MapToListModels(dbset);
    }


    public async Task CreateAsync(TModel model, CrudResult result)
    {
        if (model == null)
        {
            result.AddMessage(CrudResultMessages.CreateAsync_InvalidModel);
            return;
        }

        if (!Validate(model, result))
        {
            return;
        }

        using (var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var entity = _mapper.MapToEntity(model);

                await BeforeCreateAsync(entity);

                _dbSet.Add(entity);
                _dbContext.SaveChanges();

                dbTransaction.Commit();
            }

            catch (Exception ex)
            {
                dbTransaction.Rollback();
                _logger.Error(LogMessage.Error_BaseCrudService_CreateAsync, ex);
                throw;
            }
        }
    }

    public async Task UpdateAsync(int id, TModel model, CrudResult result)
    {
        if (model == null)
        {
            result.AddMessage(CrudResultMessages.UpdateAsync_InvalidModel);
            return;
        }

        if (!Validate(model, result))
        {
            return;
        }

        using (var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var entity = _mapper.MapToEntity(model);

                await BeforeUpdateAsync(entity);

                entity.Id = id;
                _dbSet.Attach(entity);
                _dbSet.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();

                dbTransaction.Commit();
            }

            catch (Exception ex)
            {
                dbTransaction.Rollback();
                _logger.Error(LogMessage.Error_BaseCrudService_UpdateAsync, ex);
                throw;
            }
        }
    }

    public virtual async Task BeforeCreateAsync(TEntity model)
    {
        model.CratedDate = DateTime.Now;
    }

    public virtual async Task BeforeUpdateAsync(TEntity model)
    {
        model.UpdatedDate = DateTime.Now;
    }

    public async Task DeleteAsync(int id, CrudResult result)
    {

        var entity = await _dbSet.FirstOrDefaultAsync(i => i.Id == id);

        if (entity != null)
        {
            result.AddMessage(CrudResultMessages.DeleteAsync_InvalidId);
            return;
        }

        using (var dbTransaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                BeforeDeleteAsync(id, result);

                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
                dbTransaction.Commit();


            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                dbTransaction.Rollback();
                throw;
            }
        }
    }

    public virtual void BeforeDeleteAsync(int id, CrudResult result)
    {
    }

    public virtual bool Validate(TModel model, CrudResult validationResuls)
    {
        return true;
    }
}