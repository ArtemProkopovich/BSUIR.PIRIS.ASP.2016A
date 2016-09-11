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
    public class MartialStatusRepository : Repository<MartialStatus>
    {
        protected override string SelectQuery { get; } = "SELECT * FROM MartialStatus WHERE Id=@Id";
        protected override string SelectAllQuery { get; } = "SELECT * FROM MartialStatus";
        protected override string InsertQuery { get; }
        protected override string DeleteQuery { get; }
        protected override string UpdateQuery { get; }

        public MartialStatusRepository(SqlConnection connection) : base(connection)
        {
        }

        protected override void InitSqlCommandParametres(SqlCommand cmd, MartialStatus entity)
        {
            cmd.Parameters.AddWithValue("@Status", entity.Status);
        }

        protected override MartialStatus GetEntityFromDataRow(DataRow dataRow)
        {
            var result = new MartialStatus();
            result.Id = Convert.ToInt32(dataRow["Id"]);
            result.Status = dataRow["Status"] as string;
            return result;
        }
    }
}
