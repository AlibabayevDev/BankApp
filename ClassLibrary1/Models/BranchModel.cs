﻿using BankApp.WebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.WebCore.Model
{
    public class BranchModel : BaseModel
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
