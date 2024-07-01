using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Features.Searching
{
    public interface ISearch<T>
    {
        bool IsSatisfiedBy(T entity);
        Expression<Func<T, bool>> ToExpression(dynamic arguments);
        ISearch<T> And(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right);
    }
}
