using FHS.Entities.Interfaces.ListModel.Base;

namespace FHS.Entities.ListModel.Base;

public abstract class BaseDictListModel : BaseListModel, IBaseDictListModel
{
    public string? Name { get; set; }
}