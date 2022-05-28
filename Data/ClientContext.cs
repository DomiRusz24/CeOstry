using Clients.Models;
using Microsoft.EntityFrameworkCore;

namespace Clients.Data;

public partial class ClientContext : DbContext
{

    public ClientContext(DbContextOptions<ClientContext> contextOptions) : base(contextOptions)
    {
        Database.Migrate();
    }

    public virtual DbSet<Client> Clients { get; set; }


}