using Clients.Data;
using Clients.Models;
using Microsoft.EntityFrameworkCore;

namespace Clients.Controllers;

public sealed class ClientManager : IClientManager
{
    private readonly ClientContext context;
    private Dictionary<int, Client> cache = new Dictionary<int, Client>();

    public ClientManager(ClientContext context)
    {
        this.context = context;
    }

    public async Task<int> Delete(int _Id)
    {
        return await Delete(new Client { Id = _Id });
    }

    public async Task<int> Delete(Client client)
    {
        context.Remove(client);
        if (cache.ContainsKey(client.Id)) cache.Remove(client.Id);

        return await context.SaveChangesAsync();
    }

    public async Task<Client?> Get(int Id)
    {
        if (cache.ContainsKey(Id))
        {
            return cache[Id];
        }

        Task<Client?> task = context.Clients.FirstOrDefaultAsync(x => x.Id == Id);

        await task.ContinueWith(Client =>
        {
            if (Client.Result != null) cache[Client.Result.Id] = Client.Result;
        });

        return await task;
    }

    public async Task<int> Insert(Client client)
    {

        if (cache.ContainsKey(client.Id)) return 0;

        cache[client.Id] = client;
        context.Clients.Add(client);

        return await context.SaveChangesAsync();
    }

    public async Task<int> Update(Client client)
    {
        cache[client.Id] = client;

        context.Clients.Update(client);

        return await context.SaveChangesAsync();

    }

    public async Task<List<Client>> GetAll()
    {
        return await context.Clients.ToListAsync();
    }

    public List<Client> GetAllCache()
    {
        return cache.Values.ToList();
    }

    public void Migrate()
    {
        context.Database.Migrate();
    }

}