namespace RMQueryDemo.Parameters
{
    public interface IParametersBase {
        int? rpp { get; set; }
        int Page { get; set; }
        string SearchQuery { get; set; }
    }
}