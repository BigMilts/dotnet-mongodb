using System;
using Api.Data.collections;
using System.Collections.Generic;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        InfectadoService _infectadoService;

        public InfectadoController(InfectadoService infectadoService)
        {
            _infectadoService = infectadoService;
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDTO dto)
        {
            bool result = _infectadoService.CreateObject(dto);
            if(result) {
                return StatusCode(201, "Infectado adicionado com sucesso");
            }
            return StatusCode(500, "Erro ao adicionar Infectado");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            List<Infectado> infectados = _infectadoService.GetAll();
            return Ok(infectados);
        }

        [HttpPut]
        public ActionResult AtualizarInfectado([FromBody] InfectadoDTO dto)
        {
            bool result = _infectadoService.Update(dto);
            if(result) {
                return StatusCode(201, "Infectado atualizado com sucesso");
            }
            return StatusCode(500, "Erro ao atualizar Infectado");
        }

        [HttpDelete("{dataNasc}")]
        public ActionResult DeletarInfectado(DateTime dataNasc)
        {
            bool result = _infectadoService.Delete(dataNasc);
             if(result) {
               return Ok("Objeto Deletado Com Sucesso");
            }  
             return StatusCode(500, "Erro ao deletar Infectado");
        }
    }
}