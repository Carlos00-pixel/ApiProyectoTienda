using ApiProyectoTienda.Repositories;
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
        //[Route("[action]")]
        public ActionResult<DatosArtista> DetallesArtista(int id)
        {
            return this.repo.DetailsArtista(id);
        }

        //[HttpPost]
        //public async Task<ActionResult> RegistrarArtista(Artista artista)
        //{
        //    return await this.repo.RegistrarArtistaAsync
        //        (artista.Nombre, artista.Apellidos, artista.Nick, artista.Descripcion,
        //        artista.Email, artista.Password, artista.Imagen);
        //}


    }
}
