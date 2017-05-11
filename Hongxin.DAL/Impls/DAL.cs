using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.DAL.Impls
{
    public abstract class DAL<T> : IDAL<T>
    {
        private static Database _database = null;
        public abstract string TableName { get; }
        public abstract string Key { get; }
        public Database DataBase { 
            get 
            {
                if (_database == null) 
                {
                    _database = DBFactory.CreateDatabase();
                }
                return _database;
            }
        }

        public void BeginTransaction()
        {
            DataBase.BeginTransaction();
        }
        public void CompleteTransaction()
        {
            DataBase.CompleteTransaction();
        }
        public void AbortTransaction()
        {
            DataBase.AbortTransaction();
        }
        public int Add(T t)
        {
            int id = Convert.ToInt32(DataBase.Insert(TableName, t));
            return id;
        }

        public int Update(T t)
        {
            int rows = DataBase.Update(TableName, Key, t);
            return rows;
        }

        public int Delete(T t)
        {
            int rows = DataBase.Delete(TableName, Key, t);
            return rows;
        }

        public IEnumerable<T> Query()
        {
            string sql = string.Format("select * from {0}", TableName);
            return DataBase.Query<T>(sql, TableName);
        }

        public T Query(int id)
        {
            string sql = string.Format("select * from {0} where {1} = @0", TableName, Key);
            return DataBase.Single<T>(sql, id);
        }
        public Page<T> Page(long pageIndex, long pageSize)
        {
            string sql = string.Format("select * from {0}", TableName);
            return DataBase.Page<T>(pageIndex, pageSize, sql);
        }
        public IEnumerable<T> Query(Core.JqGridPager jp)
        {
            string sql = string.Format("select * from {0}", TableName);
            var page = DataBase.Page<T>(jp.page, jp.rows, sql);
            jp.records = Convert.ToInt32(page.TotalItems);
            return page.Items;
        }
    }
}
