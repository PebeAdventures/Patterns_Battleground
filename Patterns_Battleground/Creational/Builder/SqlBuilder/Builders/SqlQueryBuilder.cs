namespace Patterns_Battleground.Creational.Builder.SqlBuilder.Builders
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        private List<string> _select = new();
        private string? _from;
        private List<string> _where = new();
        private List<OrderByBuilder> _orderBy = new();

        public void From(string table)
        {
            _from = table;
        }

        public void OrderBy(params OrderByBuilder[] columns)
        {
            _orderBy.AddRange(columns);
        }

        public void Select(params string[] columns)
        {
            _select.AddRange(columns);
        }

        public void Where(params string[] condition)
        {
            _where.AddRange(condition);
        }

        public string Build()
        {
            if (_from is null || !_select.Any())
                throw new InvalidOperationException("Query must have SELECT and FROM clauses.");

            var query = $"SELECT {string.Join(", ", _select)} FROM {_from}";

            if (_where.Any())
                query += $" WHERE {string.Join(" AND ", _where)}";

            if (_orderBy.Any())
                query += $" ORDER BY {string.Join(", ", _orderBy.Select(ob => ob.Build()))}";

            return query + ";";
        }
    }
}
