using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;

namespace DAL
{
    public class CitizenshipRepository : Repository<Citizenship>
    {
        public CitizenshipRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override string InsertQuery { get; } = "";

        protected override string DeleteQuery { get; } = "";

        protected override string UpdateQuery { get; } = "";

        protected override string SelectQuery { get; } = "SELECT * FROM Citizenship WHERE Id=@Id";

        protected override string SelectAllQuery { get; }= "SELECT * FROM Citizenship";

        protected override void InitSqlCommandParametres(SqlCommand cmd, Citizenship entity)
        {
            cmd.Parameters.AddWithValue("@Country", entity.Country);
        }

        protected override Citizenship GetEntityFromDataRow(DataRow dataRow)
        {
            Citizenship result = new Citizenship();
            result.Id = Convert.ToInt32(dataRow["Id"]);
            result.Country = dataRow["Country"] as string;
            return result;
        }
    }
}
