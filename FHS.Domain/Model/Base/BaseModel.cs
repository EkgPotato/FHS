using System.Reflection;
using System.Text;
using FHS.Entities.Interfaces.Model.Base;

namespace FHS.Entities.Model;

public abstract class BaseModel : IBaseModel
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    //public override string ToString()
    //{
    //    Type type = this.GetType();

    //    PropertyInfo[] properties = type.GetProperties();

    //    StringBuilder sb = new StringBuilder();

    //    foreach (PropertyInfo property in properties)
    //    {
    //        string name = property.Name;

    //        object? value = property.GetValue(this);

    //        sb.Append(name + ": " + value + "; ");
    //    }

    //    // Return the output as a string
    //    return sb.ToString();
    //}
}