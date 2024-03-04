using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TarefaNinja.DAL.Abstracts;

internal static class SoftDeleteQueryExtension
{
    public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
    {
        var methodToCall = typeof(SoftDeleteQueryExtension)
            .GetMethod(nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static)
            ?.MakeGenericMethod(entityData.ClrType);

        if (methodToCall is null)
        {
            return;
        }

        var filter = methodToCall.Invoke(null, Array.Empty<object>());

        entityData.SetQueryFilter(filter as LambdaExpression);
    }

    private static LambdaExpression GetSoftDeleteFilter<TEntity>()
        where TEntity : class, ISoftDelete
    {
        return (Expression<Func<TEntity, bool>>)(x => x.Deleted == null);
    }
}
