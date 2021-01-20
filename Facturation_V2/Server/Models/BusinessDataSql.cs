using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Facturation_V2.Shared;
using Dapper;

namespace Facturation_V2.Server.Models
{
    public class BusinessDataSql : IBusinessData, IDisposable
    {
        private SqlConnection cnct;

        public BusinessDataSql(string connectionString)
        {
            cnct = new SqlConnection(connectionString);
        }
        public IEnumerable<Facture> lesFactures => cnct.Query<Facture>("SELECT * FROM Facture ORDER BY DateReglement DESC");

        public void Add(Facture facture)
        {
            var query = @"INSERT INTO 
                Facture(Client, Numero, DateEmission, DateReglement, MontantDu, MontantRegle)
                VALUES(@Client, @Numero, @DateEmission, @DateReglement, @MontantDu, @MontantRegle);
                SELECT CAST(SCOPE_IDENTITY() as int);";
            cnct.ExecuteScalar<int>(query, facture);
        }

        public void Dispose()
        {
            cnct.Dispose();
        }

        public Facture GetByNumero(string numero)
        {
            var query = "SELECT * FROM Facture WHERE Numero = @numero";
            return cnct.QueryFirstOrDefault<Facture>(query, new { numero = numero });
        }
    }
}
