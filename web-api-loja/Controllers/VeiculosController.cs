using System;
using System.Web.Http;

namespace web_api_loja.Controllers
{
    public class VeiculosController : ApiController
    {
        private readonly Repositories.SQLServer.Veiculo repositorioVeiculo;
        
        public VeiculosController()
        {
            this.repositorioVeiculo = new Repositories.SQLServer.Veiculo(Configurations.Database.getConnectionString());
        }

        // GET: api/Veiculos
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(this.repositorioVeiculo.Select());
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // GET: api/Veiculos/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Veiculo veiculo = this.repositorioVeiculo.Select(id);

                if (veiculo is null)
                    return NotFound();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }            
        }

        // GET: api/Veiculos?nome=Captur
        [HttpGet]
        public IHttpActionResult Get(string nome)
        {
            try
            {
                if (nome.Length < 3)
                    return BadRequest("O nome deve ter no mínimo 3 caracteres.");

                return Ok(this.repositorioVeiculo.Select(nome));
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // POST: api/Veiculos
        [HttpPost]
        public IHttpActionResult Post(Models.Veiculo veiculo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Dados obrigatórios Marca, Nome, Ano Modelo e Data de fabricação do veículo não foram enviados.");

                if (!this.repositorioVeiculo.Insert(veiculo))
                    return InternalServerError();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // PUT: api/Veiculos/5
        [HttpPut]
        public IHttpActionResult Put(int id, Models.Veiculo veiculo)
        {
            try
            {
                if (id != veiculo.Id)
                    return BadRequest("O id da requisição não coincide com o id do veiculo");

                if (!ModelState.IsValid)
                    return BadRequest("Dados obrigatórios Marca, Nome, Ano Modelo e Data de Fabricação do veículo não foram enviados.");

                if (!this.repositorioVeiculo.Update(veiculo))
                    return NotFound();

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }

        // DELETE: api/Veiculos/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!repositorioVeiculo.Delete(id))
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Logger.WriteException(Configurations.Logger.GetFullPath(), ex);

                return InternalServerError();
            }
        }
    }
}
