using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace web_api_cursos.Controller
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CursosController : ApiController
    {
        private readonly Repository.CursoRepository repository;
        private readonly Logger.Log logger;
        public CursosController()
        {
            repository = new Repository.CursoRepository(Webconfig.WebConfig.GetConnectionString());
            logger = new Logger.Log(HttpContext.Current.Server.MapPath(Webconfig.WebConfig.GetLogFullPath()));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            try
            {
                //bool isOk = await repository.DeleteAsync(id);

                //if (!isOk)
                //    return NotFound();

                //return StatusCode(System.Net.HttpStatusCode.NoContent);

                bool isOK = await repository.DeleteAsync(id);

                if (isOK)
                    return StatusCode(System.Net.HttpStatusCode.NoContent);

                Model.Curso curso = await repository.ReadAsync(id);

                if (curso != null)
                    return BadRequest("Não é possivel excluir um curso ativo");

                return NotFound();
            }
            catch (Exception ex)
            {
               await logger.WriteAsync(ex);
               return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {
            try
            {
                return Ok(await repository.ReadAsync());
            }
            catch (Exception ex)
            {
                await logger.WriteAsync(ex);
                return InternalServerError();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            try
            {
                Model.Curso curso = await repository.ReadAsync(id);

                if (curso == null)
                    return NotFound();

                return Ok(curso);
            }
            catch (Exception ex) 
            {
                await logger.WriteAsync(ex);
                return InternalServerError();
            }
            
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] Model.Curso curso)
        {
            try
            {

                if (curso == null)
                    return BadRequest("requisição inválida");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Content(System.Net.HttpStatusCode.Created, await repository.CreateAsync(curso));
            }
            catch (Exception ex)
            {
                await logger.WriteAsync(ex);
                return InternalServerError();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAsync(int id, [FromBody] Model.Curso curso)
        {
            try 
            {
                if (curso == null)
                    return BadRequest("Os dados não foram enviados");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != curso.Id)
                    return BadRequest("O id da rota é diferente");

                bool isOk = await repository.UpdateAsync(curso);

                if (!isOk)
                    return NotFound();

                return Ok(curso);
            } 
            catch (Exception ex) 
            {
                await logger.WriteAsync(ex);
                return InternalServerError();
            }
        }
    }
}