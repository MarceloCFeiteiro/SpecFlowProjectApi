using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using SpecFlowProjectApi.Models;
using SpecFlowProjectApi.Services.ServeRest;
using SpecFlowProjectApi.Utils;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowProjectApi.Features
{
    [Binding]
    public class UsuarioSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly UsuarioService _usuarioService;

        public IRestResponse RestResponse { get; set; }

        public UsuarioSteps(ScenarioContext scenarioContext, UsuarioService usuarioService)
        {
            _scenarioContext = scenarioContext;
            _usuarioService = usuarioService;
        }

        [Given(@"que o usuário foi criado")]
        public void DadoQueOUsuarioFoiCriado()
        {
            _scenarioContext["Usuario"] = Usuario.NovoUsuarioAdministrador();
        }

        [Given(@"que já exista um usuário")]
        public void DadoQueJaExistaUmUsuario()
        {
            _scenarioContext["Usuario"] = ManipularArquivoHelper.LerDeUmArquivoQueEstaNoFormatoJson<Usuario>();
        }

        [Given(@"os dados desse usuário foram atualizados")]
        public void OsDadosDesseUsuarioForamAtualizados()
        {
            _scenarioContext["Usuario"] = ManipularArquivoHelper.LerDeUmArquivoQueEstaNoFormatoJson<UsuarioViewModel>();
            var novosDadosUsuaio = Usuario.NovoUsuarioComum();

            (_scenarioContext["Usuario"] as UsuarioViewModel).Nome += " atualizado";
            (_scenarioContext["Usuario"] as UsuarioViewModel).Administrador = novosDadosUsuaio.Administrador;

            var usuario = AutoMapperGenericsHelper<UsuarioViewModel, Usuario>.ModelSourceToDestination(_scenarioContext["Usuario"] as UsuarioViewModel);

            _scenarioContext["Usuario"] = usuario;
        }

        [When(@"eu faço um '(.*)' para o endpoint de usuários")]
        public void QuandoEuFacoUmParaOEndpointDeUsuarios(string metodo)
        {
            VerificaMetodo(metodo);

            RestResponse = _usuarioService.Requisicao(metodo, null, _scenarioContext["Usuario"] as Usuario);

              ResponseHelper.RestResponse = RestResponse;
        }

        [Then(@"uma mensagem de sucesso e o id do usuarios são retornados")]
        public void EntaoUmaMensagemDeSucessoEOIdDoUsuariosSaoRetornados()
        {
            var dic = JsonHelper.JsonParaDicionario(RestResponse.Content);

            SalvarUsuario(dic);

            Assert.AreEqual(dic["message"], "Cadastro realizado com sucesso", "O usuario enviado não foi cadastrado");

            dic.Keys.Should().Contain("_id");
        }

        private void SalvarUsuario(Dictionary<string, string> dic)
        {
            UsuarioViewModel usuario = new UsuarioViewModel(dic["_id"]
                , (_scenarioContext["Usuario"] as Usuario).Nome
                , (_scenarioContext["Usuario"] as Usuario).Email
                , (_scenarioContext["Usuario"] as Usuario).Password
                , (_scenarioContext["Usuario"] as Usuario).Administrador);

            ManipularArquivoHelper.SalvarNoArquivoEmFormatoJson(usuario);
        }

        private static void VerificaMetodo(string metodo)
        {
            if (metodo.ToUpper().Equals("GET"))
                TypeHelper.ClassType = typeof(UsuarioViewModel);
            else
                TypeHelper.ClassType = typeof(Usuario);
        }
    }
}