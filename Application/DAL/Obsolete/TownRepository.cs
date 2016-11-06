using System;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface.Entity;

namespace DAL.Obsolete
{
    public class TownRepository : Repository<Town>
    {
        protected override string SelectQuery { get; } = "SELECT * FROM Town WHERE Id=@Id";
        protected override string SelectAllQuery { get; } = "SELECT * FROM Town";
        protected override string InsertQuery { get; }
        protected override string DeleteQuery { get; }
        protected override string UpdateQuery { get; }

        public TownRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override void InitSqlCommandParametres(SqlCommand cmd, Town entity)
        {
            cmd.Parameters.AddWithValue("@Name", entity.Name);
        }

        protected override Town GetEntityFromDataRow(DataRow dataRow)
        {
            var result = new Town();
            result.Id = Convert.ToInt32(dataRow["Id"]);
            result.Name = dataRow["Name"] as string;
            return result;
        }
    }
}
