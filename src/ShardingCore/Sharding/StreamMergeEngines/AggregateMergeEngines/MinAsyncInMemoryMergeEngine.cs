﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShardingCore.Extensions;
using ShardingCore.Sharding.Abstractions;
using ShardingCore.Sharding.StreamMergeEngines.Abstractions;
using ShardingCore.Sharding.StreamMergeEngines.Abstractions.AbstractGenericExpressionMergeEngines;

namespace ShardingCore.Sharding.StreamMergeEngines.AggregateMergeEngines
{
    /*
    * @Author: xjm
    * @Description:
    * @Date: 2021/8/18 14:40:06
    * @Ver: 1.0
    * @Email: 326308290@qq.com
    */
    public class MinAsyncInMemoryMergeEngine<TEntity,TSelect> : AbstractGenericMethodCallSelectorInMemoryAsyncMergeEngine<TEntity,TSelect>
    {
        public MinAsyncInMemoryMergeEngine(MethodCallExpression methodCallExpression, IShardingDbContext shardingDbContext) : base(methodCallExpression, shardingDbContext)
        {
        }

        public override TResult MergeResult<TResult>()
        {
            var result =  base.Execute( queryable =>  ((IQueryable<TResult>)queryable).Min());
            return result.Min();
        }

        public override async Task<TResult> MergeResultAsync<TResult>(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.ExecuteAsync( queryable =>  ((IQueryable<TResult>)queryable).MinAsync(cancellationToken), cancellationToken);
            return result.Min();
        }
    }
}
