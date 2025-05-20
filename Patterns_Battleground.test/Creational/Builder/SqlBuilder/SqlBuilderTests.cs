

using Patterns_Battleground.Creational.Builder.SqlBuilder.Builders;
using Xunit;

namespace Patterns_Battleground.Creational.Builder.SqlBuilder
{
    public class SqlBuilderTests
    {

        [Fact]
        public void When_OrderByClauseAreEmpty_ShouldReturnInvalidOperationException()
        {
            //arrange
            var orderByBuilder = new OrderByBuilder();

            //assert
            Assert.Throws<InvalidOperationException>(() => orderByBuilder.Build());
        }

        [Fact]
        public void Build_WhenQueryIsValid_ReturnsCorrectSql()
        {
            //arrange
            var builder = new SqlQueryBuilder();
            builder.Select("Name", "Age");
            builder.From("OnlyFolks");
            builder.Where("Age > 18");
            builder.OrderBy(new OrderByBuilder().Column("Name").Asc());
            
            //act
            var sql = builder.Build();
            var expectedSql = "SELECT Name, Age FROM OnlyFolks WHERE Age > 18 ORDER BY Name ASC;";
            //assert
            Assert.Equal(expectedSql, sql);

        }

        [Fact]
        public void Build_WithMultipleOrderByClauses_ReturnsCorrectSql()
        {
            //arrange
            var builder = new SqlQueryBuilder();
            builder.Select("Name", "Age");
            builder.From("OnlyFolks");
            builder.Where("Age > 18");
            builder.OrderBy(
                new OrderByBuilder().Column("Name").Asc(),
                new OrderByBuilder().Column("Size").Desc());

            //act
            var sql = builder.Build();
            var expectedSql = "SELECT Name, Age FROM OnlyFolks WHERE Age > 18 ORDER BY Name ASC, Size DESC;";

            //assert
            Assert.Equal(expectedSql, sql);

        }
        [Fact]
        public void Build_WhenThereIsNoSelectStatement_ShouldReturnInvalidOperationException()
        {
            //arrange
            var builder = new SqlQueryBuilder();
            builder.From("OnlyFolks");
            builder.Where("Age > 18");
            builder.OrderBy(new OrderByBuilder().Column("Name").Asc());


            //assert
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Fact]
        public void Build_WhenThereIsNoFromStatement_ShouldReturnInvalidOperationException()
        {
            //arrange
            var builder = new SqlQueryBuilder();
            builder.Select("Name", "Age");
            builder.Where("Age > 18");
            builder.OrderBy(new OrderByBuilder().Column("Name").Asc());


            //assert
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

     

    }
}
