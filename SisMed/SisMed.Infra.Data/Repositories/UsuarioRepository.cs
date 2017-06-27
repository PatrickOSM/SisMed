using SisMed.Domain.Entities;
using SisMed.Domain.Interfaces.Repositories;

namespace SisMed.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public void DesativarLock(string id)
        {
            Db.Usuarios.Find(id).LockoutEnabled = false;
            Db.SaveChanges();
        }
    }
}
