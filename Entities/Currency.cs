using System.ComponentModel.DataAnnotations;
using WebApi.Commons;

namespace WebApi.Entities;

public class Currency : BaseEntity
{
    [MaxLength(10)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(2)]
    public string Symbol { get; set; } = string.Empty;
}