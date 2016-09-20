using ContractsApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContractsApp.Models
{
    public class ContractMinData
    {
        public string Name { get; set; }

        public JobPosition Position { get; set; }

        public uint Experience { get; set; }
    }
}