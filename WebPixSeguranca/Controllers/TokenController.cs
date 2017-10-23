using Microsoft.AspNetCore.Mvc;
using Entity;
using SegurancaBO;

namespace WebPixSeguranca.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class TokenController : Controller
    {
        // GET: api/Token
        [HttpPost]
        public string GerarToken([FromBody]object objToken)
        {
            dynamic obj = objToken;
            Token token = new Token();

            token.idCliente = obj.idCliente;
            token.idUsuario = obj.idUsuario;
            token.IP = "127.0.0.1"; //reavaliar
            token.UrlCliente = obj.UrlCliente;

            var validade = TokenBO.GerateTokenValido(token);
            return validade;
        }

        [HttpGet("{guid}")]
        public bool ValidaToken(string guid,int acao, int aux)
        {
            var validade = TokenBO.ValidaToken(guid,acao,aux);
            return validade;
        }
        
    }
}
