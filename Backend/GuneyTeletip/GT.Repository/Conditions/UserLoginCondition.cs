using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using GT.Persistance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GT.Repository.Conditions
{
    public class UserConditionFilter
    {
        public long? Pk { get; set; }
        public string EmailAdress { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public DateTime? TimeCreated { get; set; }
        public DateTime? TimeDelete { get; set; }
        public long? UserFk { get; set; }
        public string UserName { get; set; }
        public long? UserFkLastModfiead { get; set; }
        public short? RecordType { get; set; }
    }
    public class UserLoginCondition
    {
        public static Expression<Func<UsrUserLogin, bool>> Get(UserConditionFilter filter)
        {
            var exp = PredicateBuilder.True<UsrUserLogin>();
            if (!string.IsNullOrEmpty(filter.EmailAdress))
            {
                exp = exp.And(o => o.EmailAdress.Contains(filter.EmailAdress));
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                exp = exp.And(o => o.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.Surname))
            {
                exp = exp.And(o => o.Surname.Contains(filter.Surname));
            }
            if (!string.IsNullOrEmpty(filter.Password))
            {
                exp = exp.And(o => o.Password.Contains(filter.Password));
            }
            if (!string.IsNullOrEmpty(filter.UserName))
            {
                exp = exp.And(o => o.UserName.Contains(filter.UserName));
            }
            if (filter.Pk.HasValue)
            {
                exp = exp.And(o => o.Pk == filter.Pk.Value);
            }
            if (filter.TimeCreated.HasValue)
            {
                exp = exp.And(o => o.TimeCreated == filter.TimeCreated.Value);
            }
            if (filter.TimeDelete.HasValue)
            {
                exp = exp.And(o => o.TimeDelete == filter.TimeDelete.Value);
            }
            if (filter.UserFk.HasValue)
            {
                exp = exp.And(o => o.UserFk == filter.UserFk.Value);
            }
            if (filter.UserFkLastModfiead.HasValue)
            {
                exp = exp.And(o => o.UserFkLastModfiead == filter.UserFkLastModfiead.Value);
            }
            if (filter.RecordType.HasValue)
            {
                exp = exp.And(o => o.RecordType == filter.RecordType.Value);
            }
            return exp;
        }
    }
}
