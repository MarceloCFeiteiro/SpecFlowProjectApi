using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using SpecFlowProjectApi.Models;
using SpecFlowProjectApi.Utils;
using System;
using System.Collections;
using TechTalk.SpecFlow;

namespace SpecFlowProjectApi.Steps
{
    [Binding]
    public class BaseSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public readonly ScenarioContext _scenarioContext;

        public IRestResponse RestResponse;

        public Type ClassType;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"o statusCode deve ser (.*)")]
        protected void EntaoOStatusCodeDeveSer(int statusCode)
        {
            RestResponse = ResponseHelper.RestResponse;
            RestResponse.StatusCode.Should().Be(statusCode);
        }

        [Then(@"uma mensagem deve ser retornada '(.*)'")]
        public void EntaoUmaMensagemDeveSerRetornada(string mensagem)
        {
            var dic = JsonHelper.JsonParaDicionario(RestResponse.Content);

            dic["message"].Should().Be(mensagem);
        }

        [Then(@"uma lista deve ser preenchida")]
        public void EntaoUmaListaDeveSerPreenchida()
        {
            IList lista = null;
            ClassType = TypeHelper.ClassType;

            switch (ClassType.Name.ToUpper())
            {
                case "USUARIOVIEWMODEL":
                    var usuarios = JsonHelper.JsonParaEntidade<UsuarioTransport>(RestResponse.Content).Usuarios;
                    lista = usuarios;
                    break;

                default:
                    break;
            }
            CollectionAssert.IsNotEmpty(lista, "A requisição não retornou uma lista preenchida");

            CollectionAssert.AllItemsAreInstancesOfType(lista, typeof(UsuarioViewModel));
        }
    }
}