using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPixPrincipalRepository;

namespace WebPixPrincipalAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class PerfilController : Controller
    {
        [ActionName("SavePerfil")]
        [HttpPost]
        public string SavePerfil([FromBody]Perfil perfil)
        {
            if (perfil.idCliente != 0)
            {
                if (PerfilDAO.Save(perfil))
                {
                    return "Perfil salva com sucesso";
                }
                else
                {
                    return "Encontramos algum problema ao salvar o Perfil. Entre em contato com o suporte";
                }
            }
            else
                return "Encontramos algum problema ao salvar o Perfil. Entre em contato com o suporte";
        }

        [ActionName("GetAllPerfil")]
        [HttpGet("{idCliente:int}")]
        public IEnumerable<Perfil> GetAllPerfil([FromRoute]int idCliente)
        {
            return PerfilDAO.GetAll().Where(x => x.idCliente == idCliente).ToList();      
        }

        [ActionName("GetPerfilByID")]
        [HttpGet("{id:int}")]
        public Perfil GetPerfilByID([FromRoute]int id)
        {
            return PerfilDAO.GetById(id);
        }

        [ActionName("SaveUsuarioXPerfil")]
        [HttpPost]
        public UsuarioXPerfil SaveUsuarioXPerfil([FromBody]UsuarioXPerfil usuarioXPerfil)
        {
            return PerfilDAO.SaveUsuarioXPerfil(usuarioXPerfil);
        }

        [ActionName("GetPerfilByUsuario")]
        [HttpGet("{idUsuario:int}")]
        public UsuarioXPerfil GetUsuarioXPerfil([FromRoute]int idUsuario)
        {
            return PerfilDAO.GetPerfilByUsuario(idUsuario);
        }

        [ActionName("GetUsuariosXPerfis")]
        [HttpPost]
        public IEnumerable<UsuarioXPerfil> GetUsuariosXPerfis([FromBody]IEnumerable<int> idsUsuarios)
        {
            return PerfilDAO.GetPerfisByUsuarios(idsUsuarios);
        }

        [ActionName("DesvincularPerfil")]
        [HttpPost]
        public IActionResult DesvincularPerfil([FromBody]UsuarioXPerfil usuarioXPerfil)
        {
            try
            {
                PerfilDAO.DesvinculaPerfil(usuarioXPerfil);

                return Ok("Desvinculado com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Não foi possível desvincular o perfil do usuário.");
            }
        }
    }
}