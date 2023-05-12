using ApiProyectoTienda.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PyoyectoNugetTienda;

namespace ApiProyectoTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private RepositoryArtista repo;

        public ArtistaController(RepositoryArtista repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<DatosArtista> GetArtistas()
        {
            return this.repo.GetArtistas();
        }

        [HttpGet("{id}")]
        public ActionResult<DatosArtista> DetallesArtista(int id)
        {
            return this.repo.DetailsArtista(id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> BorrarProductoPorArtista(int id)
        {
            await this.repo.DeleteInfoArteAsync(id);
            return Ok();
        }
    }
}
