using BankApp.Core.Domain.Entities;
using BankApp.WebCore.Models;

namespace BankApp.WebCore.Mappers
{
    public abstract class BaseMapper<TEntity, TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        public abstract TEntity Map(TModel model);
        public abstract TModel Map(TEntity entity);
    }
}
