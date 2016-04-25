using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFramework.Extensions;

namespace CMS.Models
{
    using Migrations;
    using Common;

    public class ModelContext : DbContext
    {
        public static readonly DateTime DbVersion = new DateTime(2016, 2, 25);

        public DbSet<AppException> AppExceptions { get; set; }
        public DbSet<AppInformation> AppInformations { get; set; }
        public DbSet<Article> Articles { get; set; }

        public ModelContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        //static ModelContext()
        //{
        //    var db = new ModelContext();
        //    //Database.SetInitializer(new DbUpgrade());
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 4));

            base.OnModelCreating(modelBuilder);
        }

        public Pagination<TEntity> Page<TEntity>(
            int pageSize, int page,
            Expression<Func<TEntity, bool>> condition,
            Expression<Func<TEntity, object>> sortField,
            SortDirection sortDirection,
            params Expression<Func<TEntity, dynamic>>[] includes
            ) where TEntity : class
        {
            var result = new Pagination<TEntity>(pageSize, page);

            var set = Set<TEntity>();
            var query = set.AsQueryable();

            if (condition != null)
            {
                result.RecordCount = query.Count(condition);
                query = query.Where(condition);
            }
            else
                result.RecordCount = set.Count();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            switch (sortDirection)
            {
                case SortDirection.ASC:
                    query = query.OrderBy(sortField);
                    break;
                case SortDirection.DESC:
                    query = query.OrderByDescending(sortField);
                    break;

            }

            result.Data = query.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return result;
        }


        public void Delete<TEntity>(Expression<Func<TEntity, bool>> filterExpression)
            where TEntity : class
        {
            this.Set<TEntity>().Where(filterExpression).Delete();
        }
    }


    public enum SortDirection
    {
        ASC,
        DESC
    }
}
