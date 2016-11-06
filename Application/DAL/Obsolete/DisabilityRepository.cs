using System;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface.Entity;

namespace DAL.Obsolete
{
    public class DisabilityRepository : Repository<Disability>
    {
        public DisabilityRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override string SelectQuery { get; } = "SELECT * FROM Disability WHERE Id=@Id";
        protected override string SelectAllQuery { get; } = "SELECT * FROM Disability";

        protected override string InsertQuery { get; }

        protected override string DeleteQuery { get; }

        protected override string UpdateQuery { get; }

        protected override void InitSqlCommandParametres(SqlCommand cmd, Disability entity)
        {
            cmd.Parameters.AddWithValue("@Status", entity.Status);
        }

        protected override Disability GetEntityFromDataRow(DataRow dataRow)
        {
            Disability result = new Disability();
            result.Id = Convert.ToInt32(dataRow["Id"]);
            result.Status = dataRow["Status"] as string;
            return result;
        }
    }
}
