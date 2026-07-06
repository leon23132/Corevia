
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Corevia.Domain.Identity;

public class ApplicationRole : IdentityRole
{
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
}