using SisMed.Domain.Entities;

namespace SisMed.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        void DesativarLock(string id);
    }
}
