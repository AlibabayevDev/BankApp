using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core.Domain.Entities
{
    public class Branch : BaseEntity
    {
        public string BranchName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string BeginWorkTime { get; set; }
        public string EndWorkTime { get; set; }
        public int CountWorkers { get; set; }
        public bool IsDeleted { get; set; }
    }
}
