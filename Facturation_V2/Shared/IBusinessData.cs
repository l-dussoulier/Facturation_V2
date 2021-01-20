using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturation_V2.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Facture> lesFactures { get; }
        public void Add(Facture facture);
        public Facture GetByNumero(string numero);
    }
}
