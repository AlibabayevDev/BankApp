using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.WebAzBank.Model
{
    public class BranchViewModel
    {
        public List<BranchModel> Branches { get; set; }
        public string Message { get; set; }
    }
}
