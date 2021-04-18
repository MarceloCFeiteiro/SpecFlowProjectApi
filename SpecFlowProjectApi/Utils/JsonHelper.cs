using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpecFlowProjectApi.Utils
{
    public class JsonHelper
    {
        public static T JsonParaEntidade<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

        public static string EntidadeParaJson(object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            return json;
        }

        public static Dictionary<string, string> JsonParaDicionario(string json)
        {
            var dicionario = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return dicionario;
        }
    }
}