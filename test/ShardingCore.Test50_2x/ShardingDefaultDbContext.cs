﻿using System;
using Microsoft.EntityFrameworkCore;
using ShardingCore.Sharding;
using ShardingCore.Test50_2x.Domain.Maps;

namespace ShardingCore.Test50_2x
{
    /*
    * @Author: xjm
    * @Description:
    * @Date: 2021/8/15 10:21:03
    * @Ver: 1.0
    * @Email: 326308290@qq.com
    */
    public class ShardingDefaultDbContext:AbstractShardingDbContext<DefaultDbContext>
    {
        public ShardingDefaultDbContext(DbContextOptions<ShardingDefaultDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SysUserModMap());
            modelBuilder.ApplyConfiguration(new SysUserSalaryMap());
        }

        public override Type ShardingDbContextType => this.GetType();
    }
}
