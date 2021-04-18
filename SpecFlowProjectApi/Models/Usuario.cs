using Bogus;

namespace SpecFlowProjectApi.Models
{
    public class Usuario
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Administrador { get; set; }

        /// <summary>
        /// Cria um usuário administrador
        /// </summary>
        /// <returns>Um usuário do tipo administrador</returns>
        public static Usuario NovoUsuarioAdministrador()
        {
            var faker = new Faker("pt_BR");

            var usuario = new Usuario
            {
                Nome = faker.Name.FullName(),
                Password = faker.Internet.Password(6),
                Administrador = "true"
            };

            usuario.Email = faker.Internet.Email(usuario.Nome);
            return usuario;
        }

        /// <summary>
        /// Cria um usuário Comum
        /// </summary>
        /// <returns>Um usuário do tipo comum</returns>
        public static Usuario NovoUsuarioComum()
        {
            var faker = new Faker("pt_BR");

            var usuario = new Usuario
            {
                Nome = faker.Name.FullName(),
                Password = faker.Internet.Password(6),
                Administrador = "false"
            };

            usuario.Email = faker.Internet.Email(usuario.Nome);
            return usuario;
        }
    }
}