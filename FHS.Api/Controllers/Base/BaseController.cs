using FHS.Domain.Interfaces.Dto.Base;
using FHS.Entities.Interfaces.ListModel.Base;
using FHS.Entities.Interfaces.Model.Base;
using FHS.Interfaces.Api.Controllers.Base;
using FHS.Interfaces.Services.Base;
using FHS.Resources.Exceptions;
using FHS.Utilities.Common.Crud;
using Microsoft.AspNetCore.Mvc;

namespace FHS.Api.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TListModel, TModel, TEntity, TService> : ControllerBase,
    IBaseController<TListModel, TModel> where TListModel : IBaseListModel
    where TModel : class, IBaseModel
    where TEntity : class, IBaseEntity
    where TService : IBaseCrudService<TListModel, TModel, TEntity>
{
    private protected readonly ILogger _logger;
    private protected readonly TService _service;

    protected BaseController(ILogger logger, TService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TModel>> GetAsync(int id)
    {
        try
        {
            var result = new CrudResult();

            var item = await _service.GetAsync(id, result);

            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(result.Messages);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method}: {exception}", nameof(GetAsync), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TListModel>>> GetList()
    {
        try
        {
            var result = new CrudResult();

            var item = await _service.GetAllAsync(result);

            if (item != null)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method}: {exception}", nameof(GetList), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] TModel entity)
    {
        try
        {
            var result = new CrudResult();

            await _service.CreateAsync(entity, result);

            if (result.Succeed())
            {
                return CreatedAtAction(nameof(CreateAsync), entity);
            }
            else
            {
                return base.UnprocessableEntity(entity);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method} on entity {entity}: {exception} ", nameof(CreateAsync), entity.ToString(), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TModel entity)
    {
        try
        {
            var result = new CrudResult();

            await _service.UpdateAsync(id, entity, result);

            if (result.Succeed())
            {
                return CreatedAtAction(nameof(CreateAsync), entity);
            }
            else
            {
                return base.UnprocessableEntity(entity);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method} on entity {entity}: {exception} ", nameof(UpdateAsync), entity.ToString(), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            var result = new CrudResult();

            await _service.DeleteAsync(id, result);

            if (result.Succeed())
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in method {method}: {exception}", nameof(DeleteAsync), ex);
            return StatusCode(500, ControllerExceptionMessages.Internal_Server_Error);
        }
    }
}