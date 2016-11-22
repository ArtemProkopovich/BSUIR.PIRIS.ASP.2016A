using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Common.Model
{
    public class SystemVariableModel
    {
        public int Id { get; set; }
        public int CurrentBankDay { get; set; }
        public int StartBankDay { get; set; }
        public DateTime StartDate { get; set; }
    }
}
