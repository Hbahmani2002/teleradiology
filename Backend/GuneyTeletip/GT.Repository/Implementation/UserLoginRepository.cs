using GT.Persistance.Domain.Models;
using GT.Repository.Conditions;
using GT.Repository.Models.View;
using MEDLIFE.PERSISTANCE;
using MEDLIFE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Implementation
{
    public class UserLoginRepository : AbstractTableRepository<UsrUserLogin>
    {
        public UserLoginRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }

        public override UsrUserLogin GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public UsrUserLogin GetByID(long id)
        {
            return Single(o => o.Pk == id);
        }

        public IQueryable<UserViewModel> Query(UserConditionFilter filter)
        {
            var exp = UserLoginCondition.Get(filter);
            return Query(exp);
        }

        public IQueryable<UserViewModel> Query(Expression<Func<UsrUserLogin, bool>> exp)
        {
            var userLogin = _AbstractWorkspace.Query<UsrUserLogin>(exp);
            var list = from u in userLogin
                       select new UserViewModel
                       {
                           EmailAdress=u.EmailAdress,
                           Name=u.Name,
                           Password=u.Password,
                           Pk=u.Pk,
                           RecordType=u.RecordType,
                           Surname=u.Surname,
                           TimeCreated=u.TimeCreated,
                           TimeDelete=u.TimeDelete,
                           UserFk=u.UserFk,
                           UserName=u.UserName,
                           UserFkLastModfiead=u.UserFkLastModfiead
                       };
            return list;
        }
    }
}
