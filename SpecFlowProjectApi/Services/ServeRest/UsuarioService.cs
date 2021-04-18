using RestSharp;
using SpecFlowProjectApi.Models;
using SpecFlowProjectApi.Utils;
using System;

namespace SpecFlowProjectApi.Services.ServeRest
{
    public class UsuarioService
    {
        private readonly string BaseUrl = "https://serverest.dev/";

        private readonly string route = "Usuarios";

        public IRestResponse Requisicao(string metodo)
        {
            return Requisicao(metodo, null);
        }

        public IRestResponse Requisicao(string metodo, string param = "", Usuario usuario = null)
        {
            RestClient restClient = null;

            if (!string.IsNullOrWhiteSpace(param))
                restClient = CreateRestClient(string.Concat(route, $"/{param}"));
            else
                restClient = CreateRestClient(route);

            var restRequest = Request(metodo);

            if (usuario is not null)
                restRequest.AddJsonBody(JsonHelper.EntidadeParaJson(usuario));

            return restClient.Execute(restRequest);
        }

        private RestRequest Request(string metodo)
        {
            return (metodo.ToUpper()) switch
            {
                "GET" => new RestRequest(Method.GET) { RequestFormat = DataFormat.Json },
                "POST" => new RestRequest(Method.POST) { RequestFormat = DataFormat.Json },
                "PUT" => new RestRequest(Method.PUT) { RequestFormat = DataFormat.Json },
                _ => throw new ArgumentException($"O metodo de requeste informado {metodo} não existe."),
            };
        }

        private RestClient CreateRestClient(string route)
        {
            return new RestClient(BaseUrl + route);
        }
    }
}