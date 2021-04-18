using SpecFlowProjectApi.Models;
using SpecFlowProjectApi.Services.ServeRest;
using SpecFlowProjectApi.Utils;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProjectApi.Hooks
{
    [Binding]
    public sealed class HooksTest
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private ScenarioContext _scenarioContext;
        private readonly UsuarioService _usuarioService;

        public HooksTest(ScenarioContext scenarioContext, UsuarioService usuarioService)
        {
            _scenarioContext = scenarioContext;
            _usuarioService = usuarioService;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Entrando para todos");

            // #region Conversor de Json
            //        var settings = new JsonSerializerSettings
            //        {
            //            ContractResolver = new DefaultContractResolver
            //            {
            //                NamingStrategy = new SnakeCaseNamingStrategy()
            //            }
            //        };

            //        var response = JsonConvert.DeserializeObject<ResponseContainer<UsersModel>>(restResponse.Content, settings);

            //        var user = response.Data;
            //#endregion
            //    public class ResponseContainer<T>
            //    {
            //        public T Data { get; set; }
            //  }
        }

        [BeforeScenario("UsuarioNull")]
        public void BeforeScenarioUsuarioNull()
        {
            _scenarioContext["Usuario"] = null;
        }

        [BeforeScenario("CadastraUsuario")]
        public void BeforeScenarioCadastraUsuario()
        {
            var usuario = Usuario.NovoUsuarioAdministrador();
            var restResponse = _usuarioService.Requisicao("POST", null, usuario);
            var dic = JsonHelper.JsonParaDicionario(restResponse.Content);

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel(dic["_id"]
               , usuario.Nome
               , usuario.Email
               , usuario.Password
               , usuario.Administrador);

            ManipularArquivoHelper.SalvarNoArquivoEmFormatoJson(usuarioViewModel);
        }

        [BeforeScenario("TagGet")]
        public void BeforeScenarioGet()
        {
            Console.WriteLine("Demonstrando a execução antes do teste GET");
        }

        [BeforeScenario("TagPost")]
        public void BeforeScenarioPost()
        {
            Console.WriteLine("Demonstrando a execução antes do teste POST");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Saindo para todos");
        }
    }
}