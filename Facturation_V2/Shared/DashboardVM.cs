using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation_V2.Shared
{
    public class DashboardVM
    {
        public DashboardVM(IEnumerable<Facture> factures)
        {
            TotalDu = factures.Sum(f => f.MontantDu);
            TotalRegle = factures.Sum(f => f.MontantRegle);
            ResteARecevoir = TotalDu - TotalRegle;
        }

        public decimal TotalDu { get; set; }
        public decimal TotalRegle { get; set; }
        public decimal ResteARecevoir { get; set; }
        public DashboardVM() { }
        
    }
}
