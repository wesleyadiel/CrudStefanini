using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Data;

namespace Stefanini.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : Controller
    {
        private readonly StefaniniDBContext context;

        public CidadeController(StefaniniDBContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "ListarCidades")]
        public List<Cidade> Index()
        {
            var cidades = context.Cidades.ToList();
            return cidades;
        }

        [HttpGet(Name = "DetalhesCidade")]
        public ActionResult Details(int id)
        {
            var cidade = context.Cidades.Where(p => p.Id == id).FirstOrDefault();
            if (cidade is null)
            {
                return BadRequest("Cidade não encontrada");
            }

            return Ok(cidade);
        }

        [HttpPost(Name = "SalvarCidade")]
        public ActionResult Save(Cidade cidade)
        {
            if (cidade.Id <= 0)
            {
                context.Cidades.Add(cidade);
            }
            else
            {
                context.Cidades.Update(cidade);
            }

            context.SaveChanges();

            return Ok("Pessoa salva com sucesso.");
        }

        [HttpDelete(Name = "ExcluirCidade")]
        public ActionResult Delete(int id)
        {
            var cidade = context.Cidades.Where(p => p.Id == id).FirstOrDefault();
            if (cidade is null)
            {
                return BadRequest("Cidade não encontrada");
            }

            context.Cidades.Remove(cidade);
            context.SaveChanges();

            return Ok("Cidade excluida com sucesso.");
        }
    }
}
