using Clients.Models;

namespace Clients.Controllers;

public interface IClientManager
{
    public Task<int> Delete(int _Id);

    public Task<int> Delete(Client client);

    public Task<Client?> Get(int Id);

    public Task<int> Insert(Client client);

    public Task<int> Update(Client client);

    public Task<List<Client>> GetAll();

    public List<Client> GetAllCache();

    public void Migrate();
}