using System;
using Newtonsoft.Json;

namespace RMQueryDemo.Parameters
{
    public class ParametersValueComparison
    {


        internal DateTime? GetDateGreaterThan(string value)
        {
            if (value == null) return null;
            value = value.Replace("(", "{").Replace(")", "}").Replace("=", ":");

            try
            {
                var vc = JsonConvert.DeserializeObject<ParametersValueComparison>(value);
                if (vc == null) return null;

                if (vc.Gt != null)
                {

                    if (DateTime.TryParse(vc.Gt.ToString(), out DateTime result))
                        return DateTime.SpecifyKind(result, DateTimeKind.Utc);
                    else
                        return null;

                }
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString() + "; " + ex.InnerException?.Message?.ToString());
                System.Console.WriteLine("Error in GetDateGreaterThan parsing {0}", value);
            }
            return null;
        }

        internal DateTime? GetDateLessThan(string value)
        {
            if (value == null) return null;
            value = value.Replace("(", "{").Replace(")", "}").Replace("=", ":");

            try
            {
                var vc = JsonConvert.DeserializeObject<ParametersValueComparison>(value);
                if (vc == null) return null;

                if (vc.Lt != null)
                {

                    if (DateTime.TryParse(vc.Lt.ToString(), out DateTime result))
                        return DateTime.SpecifyKind(result, DateTimeKind.Utc);
                    else
                        return null;

                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Error in GetDateLessThan parsing {0}", value);
            }

            return null;
        }

        public object Gt { get; set; }
        public object Lt { get; set; }

    }
}