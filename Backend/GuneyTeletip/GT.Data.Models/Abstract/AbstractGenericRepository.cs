using Gt.PERSISTANCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GT.REPOSITORY
{
    public abstract class AbstractRepository
    {
        protected IAbstractWorkspace _AbstractWorkspace;
        public AbstractRepository(IAbstractWorkspace workspace)
        {
            _AbstractWorkspace = workspace;
        }
    }
    public abstract class AbstractMultiTableRepository<T1,T2,T3>: AbstractRepository
    {
        public IQueryable<T1> T1s { get; set; }
        public IQueryable<T2> T2s { get; set; }
        public AbstractMultiTableRepository(IAbstractWorkspace workspace) : base(workspace)
        {
            
        }
        
    }
    public abstract class AbstractTableRepository<T> : AbstractRepository where T : class
    {
        public AbstractTableRepository(IAbstractWorkspace workspace) : base(workspace)
        {
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> exp = null)
        {
            return _AbstractWorkspace.Query(exp);
        }

        public T Single(Expression<Func<T, bool>> exp)
        {
            return _AbstractWorkspace.Single(exp);
        }



        public void Add(T item)
        {
            _AbstractWorkspace.Add(item);
        }

        public void Update(T item)
        {
            _AbstractWorkspace.Update(item);
        }

        public void Delete(T item)
        {
            _AbstractWorkspace.Delete(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                _AbstractWorkspace.Add(item);
            }

        }

        public abstract T GetByID(long id);

    }
}