using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ATMMvc.Models
{
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly List<T> list = new List<T>();

        public FakeDbSet()
        {
            list = new List<T>();
        }

        public FakeDbSet(IEnumerable<T> contents) {
            this.list = contents.ToList();
        }

        #region IDbSet<T> Members

        public T Add(T entity)
        {
            this.list.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            this.list.Add(entity);
            return entity;
        }

        public TDerivedEntity Create <TDerivedEntity>() where TDerivedEntity : class ,T
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<T> Local {
            get {
                throw new NotImplementedException();
            }
        }

        public T Remove(T entity)
        {
            this.list.Remove(entity);
            return entity;
        }

        #endregion


        public Expression Expression => throw new NotImplementedException();

        public Type ElementType => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        

        public T Create()
        {
            throw new NotImplementedException();
        }

        

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        

        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}