using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TazeBlog.Core.DataAccess.Abstract;
using TazeBlog.Core.Entities;

namespace TazeBlog.Core.DataAccess.Concrete.Dapper
{
    public abstract class DapEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : class, IContext, new()
    {
        private string TableName { get; set; }
        private string Colums { get; set; }
        private string Params { get; set; }

        public DapEntityRepositoryBase(string tableName, string colums, string parameters)
        {
            TableName = tableName;
            Colums = colums;
            Params = parameters;
        }

        private const string INSERT_QUERY = "INSERT INTO {0} ({1}) VALUES ({2}) SELECT * FROM {0} WHERE [{0}].Id = @@IDENTITY";
        private const string UPDATE_QUERY = "UPDATE {0} SET {1} WHERE [{0}].Id = @Id";
        private const string DELETE_QUERY = "DELETE FROM {0} WHERE [{0}].Id = @Id";
        private const string SELECT_ALL_QUERY = "SELECT * FROM {0}";
        private const string SELECT_FIRST_QUERY = "SELECT * FROM {0} WHERE [{0}].Id=@Id";
        private const string SELECT_CUSTOM_WHERE_QUERY = "SELECT * FROM {0} WHERE [{0}].{1}";
        private const string COUNT_QUERY = "SELECT COUNT(Id) FROM {0};";

        private SqlConnection connection = new SqlConnection("SERVER=.;Database=TazeBlog;Trusted_Connection=true");

        public TEntity Add(TEntity entity)
        {
            if (entity is EntityBase)
            {
                (entity as EntityBase).CreatedOn = DateTime.Now;
                (entity as EntityBase).Status = Entities.Enums.RowStatus.New;
            }
            TEntity addedEntity = connection.QueryFirstOrDefault<TEntity>(string.Format(INSERT_QUERY, TableName, Colums, Params), entity);
            return addedEntity;
        }

        public int Delete(TEntity entity)
        {
            var affectedRow = connection.Execute(string.Format(DELETE_QUERY, TableName), entity);
            return affectedRow;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity is EntityBase)
            {
                (entity as EntityBase).Status = Entities.Enums.RowStatus.Updated;
            }
            var updateCmd = string.Join(",", Colums.Split(',').Select(x => string.Format("[{0}].[{1}] = @{1}", TableName, x)));
            var entityList = connection.Query<TEntity>(string.Format(UPDATE_QUERY, TableName, updateCmd), entity);

            return GetById(entity.Id);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            List<TEntity> entityList = connection.Query<TEntity>(string.Format(SELECT_ALL_QUERY, TableName)).ToList();
            return entityList;
        }

        public TEntity GetById(int entityId)
        {
            var entity = connection.QueryFirstOrDefault<TEntity>(string.Format(SELECT_FIRST_QUERY, TableName), new { Id = entityId });
            return entity;
        }
        public TEntity Get(string filter)
        {
            var entity = connection.QueryFirstOrDefault<TEntity>(string.Format(SELECT_CUSTOM_WHERE_QUERY, TableName, filter));
            return entity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(string filter)
        {
            var entity = connection.Query<TEntity>(string.Format(SELECT_CUSTOM_WHERE_QUERY, TableName, filter)).ToList();
            return entity;
        }
        public int Count()
        {
            return connection.ExecuteScalar<int>(string.Format(COUNT_QUERY, TableName));
        }
    }
}
