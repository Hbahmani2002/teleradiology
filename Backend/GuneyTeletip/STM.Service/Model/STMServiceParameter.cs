namespace Teletip.SorgulamaServis
{
    public class STMServiceParameter
    {
        public string ServiceName { get; set; }
        public string ParameterName { get; set; }
        public string HttpMethod { get; set; }
        public STMServiceParameter(string serviceName, string parameterName = "parameter", string httpMethod = "GET")
        {
            ServiceName = serviceName;
            ParameterName = parameterName;
            HttpMethod = httpMethod;
        }
    }

}
