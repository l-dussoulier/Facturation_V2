using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation_V2.Shared
{
    public class Facture
    {
        public Facture(string client, string numero, string dateEmission, string dateReglement, decimal montantDu, decimal montantRegle)
        {
            if (DateTime.TryParse(dateEmission, out DateTime dtEmission) && DateTime.TryParse(dateReglement, out DateTime dtReglement))
            {
                Client = client;
                Numero = numero;
                DateEmission = dtEmission;
                DateReglement = dtReglement;
                MontantDu = montantDu;
                MontantRegle = montantRegle;
                ResteARecevoir = montantDu - montantRegle;
            }
        }
        public string Client { get; set; }
        public string Numero { get; set; }
        public DateTime? DateEmission { get; set; }
        public DateTime? DateReglement { get; set; }
        public decimal MontantDu { get; set; }
        public decimal MontantRegle { get; set; }
        public decimal ResteARecevoir { get; set; }
        public Facture() { }

    }
}
