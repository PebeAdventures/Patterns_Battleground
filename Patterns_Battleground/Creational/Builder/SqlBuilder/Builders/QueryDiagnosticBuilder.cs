using Patterns_Battleground.Creational.Builder.SqlBuilder.Models;

namespace Patterns_Battleground.Creational.Builder.SqlBuilder.Builders
{
    public class QueryDiagnosticBuilder : IQueryBuilder
    {
        private QueryDiagnostic _diagnostic = new();
        public void From(string table)
        {
            _diagnostic.TableName = table;
        }

        public void OrderBy(params OrderByBuilder[] columns)
        {
            if (columns.Length > 0)
            {
                _diagnostic.HasOrdering = true;
            }
        }

        public void Select(params string[] columns)
        {
            _diagnostic.SelectedColumnCount += columns.Length;
        }

        public void Where(params string[] columns)
        {
            _diagnostic.WhereClauseCount += columns.Length;
        }

        public QueryDiagnostic GetReport()
        {
            return _diagnostic;
        }
    }
}
