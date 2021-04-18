using System.Collections.Generic;

namespace SpecFlowProjectApi.Models
{
    public class UsuarioTransport
    {
        public int Quantidade { get; set; }

        public List<UsuarioViewModel> Usuarios { get; set; }
    }
}