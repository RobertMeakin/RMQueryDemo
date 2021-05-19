namespace RMQueryDemo.Parameters
{
    public class ParametersBase : ParametersValueComparison, IParametersBase
    {
        private int _maxRecordsPerPage = 100;
        private int _defaultRecordsPerPage = 50;

        public int Page { get; set; } = 1;

        private int? _rpp;
        ///<summary> 
        ///Records per page.
        ///</summary>
        public int? rpp {
            get {
                if (_rpp == null) return _defaultRecordsPerPage;
                return (_rpp < 0) ? _defaultRecordsPerPage : _rpp;
            }

            set {
                if (value == null) _rpp = 1;
                if (value < 0) return;
                _rpp = (value.Value <= _maxRecordsPerPage) ? value.Value : _maxRecordsPerPage;
            }
        }

        public string SearchQuery { get; set; }

        public string SearchQueryLowerCase
            => SearchQuery.ToLowerInvariant();
    }
}