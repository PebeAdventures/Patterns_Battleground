namespace Patterns_Battleground.Creational.Builder.SqlBuilder.Builders
{
    public interface IQueryBuilder
    {
        void Select(params string[] columns);
        void From(string table);
        void Where(params string[] columns);
        void OrderBy(params OrderByBuilder[] columns);
    }
}
