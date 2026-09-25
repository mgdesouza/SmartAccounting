using Microsoft.AspNetCore.Identity;

namespace SmartAccounting.Infrastructure.Data;

public class ApplicationRole : IdentityRole<Guid>
{
    public string? Description { get; set; }
}
