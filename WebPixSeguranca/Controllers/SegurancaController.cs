using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPixSeguranca.Model;
using SegurancaBO;
using Entity;
using WebPixSeguranca.Helper.Auxiliares;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using WebPixSeguranca.Helper.Extensions;

namespace WebPixSeguranca.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class SegurancaController : Controller
    {
        // POST: api/Seguranca
        [HttpPost("{aux}/{acao}/{idcliente}/{idusuario}")]
        [RequestSizeLimit(valueCountLimit: 999999999)] // e.g. 2 GB request limit
        public async Task<JsonResult> Post(string aux, string acao, int idcliente, int idusuario, [FromBody]Object conteudo)
        {
            //Colhe informações do motor que o usuario esta tentado acessar
            var MotorAux = await Auxiliares.GetInfoMotorAux(aux, idcliente);
            AcaoViewModel acoesUsuario = MotorAux.Acoes.Where(x => x.Nome == acao).FirstOrDefault();

            //Verifica as permissões do usuario naquele motor
            if (await Auxiliares.verificaPermissaoAsync(acoesUsuario, idusuario, idcliente))
            {
                //Gera o token para acessar o motor auxiliar
                Token token = new Token { idCliente = idcliente, idUsuario = idusuario };
                string Guid = TokenBO.GerateTokenValido(token);

                //envia as informações para o motor aux
                Object retorno = await Auxiliares.GetRetornoAuxAsync(MotorAux, acoesUsuario, token, conteudo,idcliente);

                return Json(retorno);
            }
            else
                return Json(new { error = "Houve um erro ou sem permissao" });
        }
        // GET: api/Seguranca
        [HttpGet("{aux}/{acao}/{idcliente}/{idusuario}")]
        public async Task<JsonResult> Get(string aux, string acao, int idcliente, int idusuario)
        {
            //Colhe informações do motor que o usuario esta tentado acessar
            var MotorAux = await Auxiliares.GetInfoMotorAux(aux, idcliente);
            AcaoViewModel acoesUsuario = MotorAux.Acoes.Where(x => x.Nome == acao).FirstOrDefault();



            //Verifica as permissões do usuario naquele motor
            if (await Auxiliares.verificaPermissaoAsync(acoesUsuario, idusuario, idcliente))
            {
                //Gera o token para acessar o motor auxiliar
                Token token = new Token { idCliente = idcliente, idUsuario = idusuario };
                string Guid = TokenBO.GerateTokenValido(token);


                //envia as informações para o motor aux
                Object retorno = await Auxiliares.GetRetornoAuxAsync(MotorAux, acoesUsuario, token, null, idcliente);

                return Json(retorno);
            }
            else
                return Json(new { error = "Houve um erro ou sem permissao" });
        }
    }

}
