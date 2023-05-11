using ApiProyectoTienda.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProyectoTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private RepositoryCliente repo;

        public ClienteController(RepositoryCliente repo)
        {
            this.repo = repo;
        }


    }
}
