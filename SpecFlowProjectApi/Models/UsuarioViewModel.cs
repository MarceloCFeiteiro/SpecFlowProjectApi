using Newtonsoft.Json;

namespace SpecFlowProjectApi.Models
{
    public class UsuarioViewModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Administrador { get; set; }

        public UsuarioViewModel()
        {
        }

        public UsuarioViewModel(string id, string nome, string email, string password, string administrador)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Password = password;
            Administrador = administrador;
        }
    }
}