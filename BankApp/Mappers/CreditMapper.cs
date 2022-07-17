using BankApp.AdminPanel.Model;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Mappers
{
    public class CreditMapper : BaseMapper<Credit, CreditModel>
    {
        private readonly ClientMapper clientMapper = new ClientMapper();

        private readonly BranchMapper branchMapper = new BranchMapper();

        public override Credit Map(CreditModel model)
        {
            var credit = new Credit()
            {
                Id = model.Id,
                Amount = model.Amount,
                CreditPercent = model.CreditPercent,
                AmountReturn = model.AmountReturn,
                GiveDate = model.GiveDate,
                ReturnDate = model.ReturnDate,
                Branch = branchMapper.Map(model.Branch),
                BranchId = model.BranchId,
            };
            if (model.Client != null)
            {
                var clientMapper = new ClientMapper();

                model.Client.Credit = null;
                credit.Client = clientMapper.Map(model.Client);
                credit.Client.Credit = credit;
            }
            return credit;
        }

        public override CreditModel Map(Credit entity)
        {
            var credit = new CreditModel()
            {
                Id = entity.Id,
                Amount = entity.Amount,
                CreditPercent = entity.CreditPercent,
                AmountReturn = entity.AmountReturn,
                GiveDate = entity.GiveDate,
                ReturnDate = entity.ReturnDate,
                BranchId = entity.BranchId,
            };
            if (entity.Client != null)
            {
                var clientMapper = new ClientMapper();

                entity.Client.Credit = null;
                credit.Client = clientMapper.Map(entity.Client);
                credit.Client.Credit = credit;
            }
            if(entity.Branch != null)
            {
                credit.Branch = branchMapper.Map(entity.Branch);
            }
            return credit;
        }
    }
}
