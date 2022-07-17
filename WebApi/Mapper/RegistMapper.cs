using BankApp.Domain.Entities;
using BankApp.WebApi.Model;

namespace BankApp.WebApi.Mapper
{
    public class RegistMapper
    {
        public RegistModel Map(Regist entity)
        {
            var user = new RegistModel()
            {
                email = entity.email,
                password = entity.password,
            };
            return user;
        }

        public Regist Map(RegistModel model)
        {
            var user = new Regist()
            {
                email = model.email,
                password = model.password,
            };
            return user;
        }
    }
}
