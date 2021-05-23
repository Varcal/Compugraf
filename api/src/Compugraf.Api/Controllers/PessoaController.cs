using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Compugraf.Api.Extensions;
using Compugraf.Api.Models;
using Compugraf.Dominio.Entidade;
using Compugraf.Dominio.ObjetoDeValor;
using Compugraf.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;


namespace Compugraf.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IUnitOfWork unitOfWork, IPessoaRepositorio pessoaRepositorio)
        {
            _unitOfWork = unitOfWork;
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(PessoaDetalhesModel), 201)]
        public async Task<IActionResult> Post(PessoaModel model)
        {

            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var cpfExiste = await _pessoaRepositorio.CpfJaExiste(new Cpf(model.Cpf));
                if (cpfExiste) return BadRequest(new ResponseModel<string>(HttpStatusCode.BadRequest, "", "Cpf já cadastrado"));

                var pessoa = model.ParaPessoa();

                var resultado = await _pessoaRepositorio.Inserir(pessoa);
                await _unitOfWork.SaveChanges();

                var response = new ResponseModel<PessoaDetalhesModel>(HttpStatusCode.Created, new PessoaDetalhesModel(resultado), "Pessoa casdastrado com sucesso.");
                return Created(string.Empty, response);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel<PessoaModel>(HttpStatusCode.BadRequest, null, e.Message));
            }

        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(PessoaDetalhesModel), 200)]
        public async Task<IActionResult> Put(int id, PessoaModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var pessoa = await _pessoaRepositorio.ObterPorId(id);

                var nomeCompleto = new NomeCompleto(model.Nome, model.Sobrenome);
                var cpf = new Cpf(model.Cpf);
                var email = new Email(model.Email);
                var telefone = new Telefone(model.Telefone);
                var endereco = new Endereco(model.Cep, model.Estado, model.Cidade, model.Logradouro);


                pessoa.Alterar(nomeCompleto, cpf, model.Nacionalidade, email, telefone, endereco);
                _pessoaRepositorio.Alterar(pessoa);
                await _unitOfWork.SaveChanges();

                var response = new ResponseModel<PessoaDetalhesModel>(HttpStatusCode.OK, new PessoaDetalhesModel(pessoa), "Pessoa alterada com sucesso");

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel<PessoaModel>(HttpStatusCode.BadRequest, null, e.Message));
            }

        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(PessoaDetalhesModel), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var pessoa = await _pessoaRepositorio.ObterPorId(id);
            _pessoaRepositorio.Excluir(pessoa);
            await _unitOfWork.SaveChanges();

            var response = new ResponseModel<PessoaDetalhesModel>(HttpStatusCode.OK, new PessoaDetalhesModel(pessoa), "Pessoa excluída com sucesso");

            return Ok(response);
        }


        [HttpGet]
        [Route("{skip?}/{take?}")]
        [ProducesResponseType(typeof(IList<PessoaDetalhesModel>), 200)]
        public async Task<IActionResult> Get(int? skip, int? take)
        {
            var pessoas = await _pessoaRepositorio.SelecionarTodos(skip, take);

            if (!(pessoas ?? Array.Empty<Pessoa>()).Any()) return NoContent();

            var response = new ResponseModel<IList<PessoaDetalhesModel>>(HttpStatusCode.OK, pessoas.Select(x => new PessoaDetalhesModel(x)).ToList(), string.Empty);

            return Ok(response);
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PessoaDetalhesModel), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var pessoa = await _pessoaRepositorio.ObterPorId(id);
            if (pessoa == null) return NoContent();

            var response = new ResponseModel<PessoaDetalhesModel>(HttpStatusCode.OK, new PessoaDetalhesModel(pessoa), string.Empty);

            return Ok(response);
        }
    }
}
