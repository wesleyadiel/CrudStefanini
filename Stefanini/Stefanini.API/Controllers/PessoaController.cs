using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stefanini.Data;

namespace Stefanini.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private readonly StefaniniDBContext context;

        public PessoaController(StefaniniDBContext context)
        { 
            this.context = context;
        }
        // GET: PessoaController 
        [HttpGet(Name = "ListarPessoas")]
        public List<Pessoa> Index()
        {
            var pessoas = context.Pessoas.ToList();
            return pessoas;
        }

        // GET: PessoaController/Details/5
        [HttpGet(Name = "DetalhesPessoa")]
        public ActionResult Details(int id)
        {
            var pessoa = context.Pessoas.Where(p => p.Id == id).FirstOrDefault();
            if (pessoa is null)
            {
                return BadRequest("Pessoa não encontrada");
            }

            return Ok(pessoa);
        }

        // GET: PessoaController/Save
        [HttpPost(Name = "SalvarPessoa")]
        public ActionResult Save(Pessoa pessoa)
        {
            if (pessoa.Id <= 0)
            {
                context.Pessoas.Add(pessoa);
            }
            else
            {
                context.Pessoas.Update(pessoa);
            }

            context.SaveChanges();

            return Ok("Pessoa salva com sucesso.");
        }

        // GET: PessoaController/Delete/5
        [HttpDelete(Name = "ExcluirPessoa")]
        public ActionResult Delete(int id)
        {
            var pessoa = context.Pessoas.Where(p => p.Id == id).FirstOrDefault();
            if (pessoa is null)
            {
                return BadRequest("Pessoa não encontrada");
            }

            context.Pessoas.Remove(pessoa);
            context.SaveChanges();

            return Ok("Pessoa excluida com sucesso.");
        }

    }
}
