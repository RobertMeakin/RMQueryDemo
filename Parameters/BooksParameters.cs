using System;

namespace RMQueryDemo.Parameters
{
    public class BooksParameters : ParametersBase
    {
        public string DateModified { get; set; }
        public DateTime? DateModifiedGreaterThan => GetDateGreaterThan(DateModified);
        public DateTime? DateModifiedLessThan => GetDateLessThan(DateModified);
    }
}