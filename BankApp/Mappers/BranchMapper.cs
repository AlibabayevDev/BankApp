using BankApp.AdminPanel.Model;
using BankApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AdminPanel.Mappers
{
    public class BranchMapper : BaseMapper<Branch, BranchModel>
    {
        public override Branch Map(BranchModel model)
        {
            return new Branch()
            {
                Id = model.Id,
                BranchName = model.BranchName,
                Adress = model.Adress,
                BeginWorkTime = model.BeginWorkTime,
                EndWorkTime = model.EndWorkTime,
                Phone = model.Phone,
                CountWorkers = model.CountWorkers,
            };
        }

        public override BranchModel Map(Branch entity)
        {
            return new BranchModel()
            {
                Id = entity.Id,
                BranchName = entity.BranchName,
                Adress = entity.Adress,
                BeginWorkTime = entity.BeginWorkTime,
                EndWorkTime = entity.EndWorkTime,
                Phone = entity.Phone,
                CountWorkers = entity.CountWorkers,
            };
        }
    }
}
