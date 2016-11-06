using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.Interface;

namespace DAL.Obsolete
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity:IEntity
    {
        private readonly SqlConnection connection;

        protected Repository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int Add(TEntity entity)
        {
            using (SqlCommand cmd = new SqlCommand(InsertQuery, connection))
            {
                InitSqlCommandParametres(cmd, entity);
                var result = cmd.ExecuteScalar();
                return (int)result;
            }
        }

        public bool Delete(int id)
        {
            using (SqlCommand cmd = new SqlCommand(DeleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public TEntity Get(int id)
        {
            using (SqlCommand cmd = new SqlCommand(SelectQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataReader.Close();
                if (dataTable.Rows.Count > 0)
                {
                    var dataRow = dataTable.Rows[0];
                    var result = GetEntityFromDataRow(dataRow);
                    return result;
                }
                return default(TEntity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (SqlCommand cmd = new SqlCommand(SelectAllQuery, connection))
            {
                SqlDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataReader.Close();
                var result = new List<TEntity>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    result.Add(GetEntityFromDataRow(dr));
                }
                return result;
            }
        }

        public void Update(TEntity entity)
        {
            using (SqlCommand cmd = new SqlCommand(UpdateQuery, connection))
            {
                InitSqlCommandParametres(cmd, entity);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.ExecuteNonQuery();
            }
        }

        protected abstract void InitSqlCommandParametres(SqlCommand cmd, TEntity entity);
        protected abstract TEntity GetEntityFromDataRow(DataRow dataRow);
        protected abstract string InsertQuery { get; }
        protected abstract string DeleteQuery { get; }
        protected abstract string UpdateQuery { get; }
        protected abstract string SelectQuery { get; }
        protected abstract string SelectAllQuery { get; }
    }
}
