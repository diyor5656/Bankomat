using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Models
{
    public class CashWallet
    {
        public int Id { get; set; }
        public DateTime DateTime { get; internal set; }
        public int Cash { get; set; }

    }
}
