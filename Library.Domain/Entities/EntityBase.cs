using System.ComponentModel.DataAnnotations;

namespace Library.Domain;

public abstract class EntityBase
{
    [Key] public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}