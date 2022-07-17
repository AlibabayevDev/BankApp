using BankApp.Core.Domain.Entities;
using BankApp.WebAdminPanel.Models;

namespace BankApp.AdminPanel.Mappers
{
    public abstract class BaseMapper<TEntity, TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        public abstract TEntity Map(TModel model);
        public abstract TModel Map(TEntity entity);
    }
}
