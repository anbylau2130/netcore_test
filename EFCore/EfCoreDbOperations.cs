using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using ZSpitz.Util;
using static System.Linq.Expressions.Expression;

namespace EFCore
{
    public class EfCoreDbOperations<TContext, TEntity> where TContext : DbContext where TEntity : class
    {
        private readonly TContext _context;

        public EfCoreDbOperations(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }


        /// <summary>
        /// 分页功能，如果实体只是为了显示，可以使用AsNoTracking减少内存占用
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public List<TEntity> Pager(Func<TEntity, bool> where, int pageIndex, int pageSize, out long totalCount, out long pageCount)
        {
            var data = _context.Set<TEntity>().AsQueryable().AsNoTracking().Where(where);
            var items = data.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            totalCount = data.LongCount();
            pageCount = (long)Math.Ceiling(totalCount * 1.0 / pageSize);
            return items.ToList<TEntity>();
        }

        /// <summary>
        /// 执行非查询语句(Insert,update,delete,truncate)等语句
        /// </summary>
        /// <param name="sqlStr">sql语句：@$"update t set a= {name}"</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<int> NoQuerySqlAsync(FormattableString sqlStr)
        {
            if (sqlStr == null)
                throw new ArgumentNullException();
            if (string.IsNullOrEmpty(sqlStr.ToString()))
                throw new ArgumentNullException();

            var result = await _context.Database.ExecuteSqlInterpolatedAsync(sqlStr);
            return result;
        }


        /// <summary>
        /// 执行可将查询结果转换为实体的语句
        /// 1.必须返回实体的所有列
        /// 2.结果集中的列名必须与实体的列名完全一致
        /// 3.只能进行单表查询，不能使用join语句进行关联，但可以使用Include来进行关联数据的获取
        /// </summary>
        /// <param name="sqlStr">sql语句：@$"select {name}"</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IQueryable<TEntity> QueryBySql(FormattableString sqlStr)
        {
            if (sqlStr == null)
                throw new ArgumentNullException();
            if (string.IsNullOrEmpty(sqlStr.ToString()))
                throw new ArgumentNullException();

            IQueryable<TEntity> result = _context.Set<TEntity>().FromSqlInterpolated(sqlStr);

            return result;
        }

        /// <summary>
        /// 执行原生的SQL语句（不推荐），推荐使用Dapper
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public async Task ExecOriginalSql(string sqlStr, List<DbParameter>? paramList)
        {
            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = sqlStr;
                if (paramList is { Count: > 0 })
                {
                    cmd.Parameters.AddRange(paramList.ToArray());
                }

                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        //var col1=reader.GetString(0);
                        //var col2=reader.GetString(1);
                    }
                }
            }
        }

        /// <summary>
        /// 原生SQL查询方法。推荐使用
        /// </summary>
        /// <param name="sqlStr">原生的SQL语句select * from table</param>
        /// <param name="paramObj">new {id=1}</param>
        /// <returns></returns>
        public async Task<List<TEntity>> ExecOriginalSql(string sqlStr, object paramObj)
        {
            DbConnection connection = _context.Database.GetDbConnection();
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            var result = await connection.QueryAsync<TEntity>(sqlStr, paramObj);

            return result.ToList();
        }


        /// <summary>
        /// 更新实体属性，使用New创建实体对象(不从数据库中使用查询)，并修改保存到数据库(必须为主键Id赋值)
        /// (不推荐)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="colNames">要保存到数据库的修改列名</param>
        /// <returns></returns>
        public async Task ModifyEntityWithNoQuery(TEntity entity, params string[] colNames)
        {
            var entry = _context.Entry(entity);
            foreach (var col in colNames)
            {
                entry.Property(col).IsModified = true;
            }
            // Console.WriteLine(entry.DebugView.LongView);
            await _context.SaveChangesAsync(); 
        }

        /// <summary>
        /// 删除实体，使用New创建实体对象(不从数据库中使用查询)，并修改保存到数据库(必须为主键Id赋值)
        /// (不推荐)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public async Task DeleteEntityWithNoQuery(List<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
                var entry = _context.Entry(entity);
                entry.State = EntityState.Deleted;
            }
            // Console.WriteLine(entry.DebugView.LongView);
            await _context.SaveChangesAsync();
        }


        public void DeleteEntity(Func<TEntity,bool> where)
        {
            // _context.Set<TEntity>().Where(where).AsQueryable().ExecuteDelete();
        }

        /// <summary>
        /// 通过单列名查询指定实体的值
        ///QuerySingColumn("Name","C#")
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<TEntity> QuerySingColumn(string propertyName, object value, params string[] propertyNames)
        {
             return _context.Set<TEntity>().Where(this.WhereExpression(propertyName, value)).ToList();
        }




        Expression<Func<TEntity, bool>> WhereExpression(string propertyName, object value)
        {
            Type valueType = typeof(TEntity).GetProperty(propertyName).PropertyType;
            
            Expression<Func<TEntity, bool>> express;

            var parameter = Parameter(typeof(TEntity), "parameter");
            var left = MakeMemberAccess(parameter, typeof(TEntity).GetProperty(propertyName));
            var right = Constant(System.Convert.ChangeType(value, valueType));
            Expression body;
            if (valueType.IsPrimitive)
            {
                body = MakeBinary(ExpressionType.Equal, left, right);
            }
            else
            {
                body = Equal(left, right);
            }
            express = Lambda<Func<TEntity, bool>>(body, parameter);
            return express;
        }



        Expression<Func<TEntity, object[]>> SelectExpression(params string[] columns)
        {
            var parameter = Parameter(
                typeof(TEntity),
                "parameter"
            );
            List<Expression> members = new List<Expression>();
            foreach (var column in columns)
            {
                var member = MakeMemberAccess(parameter, typeof(TEntity).GetProperty(column));
                members.Add(Convert(member, typeof(object)));
            }
            var express = Lambda<Func<TEntity, object[]>>(NewArrayInit(typeof(object), members), parameter);
            return express;
        }
    }
}
