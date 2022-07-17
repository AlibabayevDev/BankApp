using BankApp.Core.Domain.Entities;
using BankApp.WebAzBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.WebAzBank.Mappers
{
    public abstract class BaseMapper<TEntity, TModel> where TEntity : BaseEntity where TModel : BaseModel
    {
        public abstract TEntity Map(TModel model);
        public abstract TModel Map(TEntity entity);
    }
}
