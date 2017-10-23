using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Repository;
using System.Linq;

namespace SegurancaBO
{
    public static class TokenBO
    {
        public static string GerateTokenValido(Token guidpassado)
        {
           
            string GuidGerado = "";
            bool seguranca = false;
            GuidGerado = Guid.NewGuid().ToString();
            guidpassado.GuidSec = GuidGerado;

            //Token token = TokenDAO.GetAll().Where(x => x.GuidSec == guid).FirstOrDefault();
            while(seguranca)
            {
                Token token = TokenDAO.GetAll().Where(x => x.GuidSec == GuidGerado).FirstOrDefault();
                if (token != null || token.ID != 0)
                    GuidGerado = Guid.NewGuid().ToString();
                else
                    break;
            }



            guidpassado.DataCriacao = DateTime.Now;
            guidpassado.DateAlteracao = DateTime.Now;
            guidpassado.DataExpiracao = DateTime.Now.AddHours(2);
            
            if(guidpassado.idUsuario == 0 || guidpassado.idCliente == 0)
            {
                return "Não foi possivel gerar um Token valido";
            }
            else
            {
                TokenDAO.Save(guidpassado);
                return GuidGerado;
            }
        }
        public static bool ValidaToken(string tokenPass,int Acao,int idAux)
        {
            Token token = TokenDAO.GetAll().Where(x => x.GuidSec == tokenPass).FirstOrDefault();

            try
            {
                if (token != null || token.ID != 0)
                    if (token.DataExpiracao > DateTime.Now)
                        return true;
                    else
                        return false;
                else
                    return false;
            }catch(Exception e)
            {
                return false;
            }

        }
    }
}
