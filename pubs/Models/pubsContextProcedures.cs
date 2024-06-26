﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pubs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace pubs.Models
{
    public partial class pubsContext
    {
        private IpubsContextProcedures _procedures;

        public virtual IpubsContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new pubsContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IpubsContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<byroyaltyResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<reptq1Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<reptq2Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<reptq3Result>().HasNoKey().ToView(null);
        }
    }

    public partial class pubsContextProcedures : IpubsContextProcedures
    {
        private readonly pubsContext _context;

        public pubsContextProcedures(pubsContext context)
        {
            _context = context;
        }

        public virtual async Task<List<byroyaltyResult>> byroyaltyAsync(int? percentage, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "percentage",
                    Value = percentage ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<byroyaltyResult>("EXEC @returnValue = [dbo].[byroyalty] @percentage", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<reptq1Result>> reptq1Async(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<reptq1Result>("EXEC @returnValue = [dbo].[reptq1]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<reptq2Result>> reptq2Async(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<reptq2Result>("EXEC @returnValue = [dbo].[reptq2]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<reptq3Result>> reptq3Async(decimal? lolimit, decimal? hilimit, string type, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "lolimit",
                    Precision = 19,
                    Scale = 4,
                    Value = lolimit ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Money,
                },
                new SqlParameter
                {
                    ParameterName = "hilimit",
                    Precision = 19,
                    Scale = 4,
                    Value = hilimit ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Money,
                },
                new SqlParameter
                {
                    ParameterName = "type",
                    Size = 12,
                    Value = type ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<reptq3Result>("EXEC @returnValue = [dbo].[reptq3] @lolimit, @hilimit, @type", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
