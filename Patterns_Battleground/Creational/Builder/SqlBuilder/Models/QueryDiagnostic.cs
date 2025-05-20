namespace Patterns_Battleground.Creational.Builder.SqlBuilder.Models
{
    public class QueryDiagnostic
    {
        public string? TableName { get; set; }
        public int SelectedColumnCount { get; set; }
        public int WhereClauseCount { get; set; }
        public bool HasOrdering { get; set; }

        public override string ToString()
        {
            return $"Table: {TableName ?? "undefined"}\n" +
               $"Columns selected: {SelectedColumnCount}\n" +
               $"Where conditions: {WhereClauseCount}\n" +
               $"Ordering: {(HasOrdering ? "Yes" : "No")}";
        }
    }
}
