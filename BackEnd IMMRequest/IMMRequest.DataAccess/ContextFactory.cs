using Microsoft.EntityFrameworkCore;

namespace IMMRequest.DataAccess
{
    public class ContextFactory
    {
        public static IMMRequestContext GetMemoryContext(string nameBd) { //BD EN MEMORIA
            var builder = new DbContextOptionsBuilder<IMMRequestContext>();
            return new IMMRequestContext(GetMemoryConfig(builder, nameBd));
        }

        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder, string nameBd) {
            builder.UseInMemoryDatabase(nameBd);
            return builder.Options;
        }

        public static IMMRequestContext GetSqlContext() { //BD EN SQL
            var builder = new DbContextOptionsBuilder<IMMRequestContext>();
            return new IMMRequestContext(GetSqlConfig(builder));
        }

        private static DbContextOptions GetSqlConfig(DbContextOptionsBuilder builder) {
            builder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=IMMRequestDB;
                Trusted_Connection=True;MultipleActiveResultSets=True;");
            return builder.Options;
        }
    }
}