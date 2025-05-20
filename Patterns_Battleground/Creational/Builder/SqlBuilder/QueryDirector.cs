
using Patterns_Battleground.Creational.Builder.SqlBuilder.Builders;

namespace Patterns_Battleground.Creational.Builder.SqlBuilder
{
    public class QueryDirector
    {

        public void BuildActiveusersQuery(IQueryBuilder queryBuilder)
        {
            queryBuilder.Select("Id", "Name", "Age");
            queryBuilder.From("Users");
            queryBuilder.Where("Active = true");
            queryBuilder.OrderBy(
                new OrderByBuilder().Column("Name").Asc()
                );
        }

        public void BuildTopCustomersQuery(IQueryBuilder queryBuilder)
        {
            queryBuilder.Select("CustomerId", "FullName", "TotalSpent");
            queryBuilder.From("Customers");
            queryBuilder.Where("TotapSpend > 1000");
            queryBuilder.OrderBy(
                new OrderByBuilder().Column("Category").Desc(),
                new OrderByBuilder().Column("Price").Asc()
                );


        }
    }
}
