using System;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface.Entity;

namespace DAL.Obsolete
{
    public class MartialStatusRepository : Repository<MaritalStatus>
    {
        protected override string SelectQuery { get; } = "SELECT * FROM MartialStatus WHERE Id=@Id";
        protected override string SelectAllQuery { get; } = "SELECT * FROM MartialStatus";
        protected override string InsertQuery { get; }
        protected override string DeleteQuery { get; }
        protected override string UpdateQuery { get; }

        public MartialStatusRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override void InitSqlCommandParametres(SqlCommand cmd, MaritalStatus entity)
        {
            cmd.Parameters.AddWithValue("@Status", entity.Status);
        }

        protected override MaritalStatus GetEntityFromDataRow(DataRow dataRow)
        {
            var result = new MaritalStatus();
            result.Id = Convert.ToInt32(dataRow["Id"]);
            result.Status = dataRow["Status"] as string;
            return result;
        }
    }
}
