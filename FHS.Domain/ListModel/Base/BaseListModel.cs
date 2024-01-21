using FHS.Entities.Interfaces.ListModel.Base;

namespace FHS.Entities.ListModel.Base;

public abstract class BaseListModel : IBaseListModel
{
    public int Id { get; set; }
}