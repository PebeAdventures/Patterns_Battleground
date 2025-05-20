namespace Patterns_Battleground.Creational.Builder.SqlBuilder.Builders
{
    public class OrderByBuilder
    {
        private string? _column;
        private string _currentDirection = "ASC";
        public OrderByBuilder Asc()
        {
            _currentDirection = "ASC";
            return this;
        }

        public OrderByBuilder Desc()
        {
            _currentDirection = "DESC";
            return this;
        }

        public OrderByBuilder Column(string column) 
        { 
            _column = column;
            return this;
        }

        public string Build()
        {
            if (string.IsNullOrWhiteSpace(_column))
            {
                throw new InvalidOperationException("Column name cannot be empty");
            }
            return $"{_column} {_currentDirection}";
        }
    }
}
