using System.ComponentModel.DataAnnotations;

namespace GeoServerNet.Server.DAL.Entities.Base;

public abstract record EntityBase
{
    [Key]
    public int Id { get; set; }
    
    public bool IsNew()
    {
        return Id == default;
    }
}