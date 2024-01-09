using DataService.Data;
using FHS.Entities.Dto;
using FHS.Entities.ListModel;
using FHS.Entities.ListModel.Base;
using FHS.Entities.Model;
using FHS.Services.Interfaces.Base;
using Mapper.Interfaces.Base;
using Mapper.Mappers.Base;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FHS.Services.Service.Base;

public abstract class BaseDictCrudService<TDictListModel, TDictModel, TDictEntity, TDictMapper> 
    : BaseCrudService<TDictListModel, TDictModel, TDictEntity, TDictMapper>, IBaseDictCrud<TDictListModel, TDictModel, TDictEntity>
    where TDictListModel : BaseDictListModel
    where TDictModel : BaseDictModel
    where TDictEntity : BaseDictEntity
    where TDictMapper : IBaseDictMapper<TDictListModel, TDictModel, TDictEntity>
{
    protected BaseDictCrudService(ILogger logger, AppDbContext dbContext, TDictMapper mapper) : base(logger, dbContext, mapper)
    {
    }
}