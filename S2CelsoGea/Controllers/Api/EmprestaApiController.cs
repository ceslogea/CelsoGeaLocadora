using S2CelsoGea.Context;
using S2CelsoGea.Context.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace S2CelsoGea.Controllers.Api
{
    public class EmprestaApiController : ApiController
    {

        S2CelsoGeaContext db;
        Repo<Jogo> repo;
        public EmprestaApiController()
        {
            db = new S2CelsoGeaContext();
        }

        
        public HttpResponseMessage Get()
        {
            var errors = new List<string>();
            var jogosList = db.Jogos.Include("WithUser").ToList();

            return Request.CreateResponse(HttpStatusCode.OK, new { Lista = jogosList }); ;
        }

        
        public HttpResponseMessage Post(int jogoId, int userId)
        {
            var errors = new List<string>();

            try
            {
                var jogoEmprestado = repo.First(jogoId);
                jogoEmprestado.WithUser_Id = userId;
                repo.Save(jogoEmprestado);
            }
            catch (Exception e)
            {
                errors.Add("Não foi possível confirmar o empréstimo: " + e.Message);
            }

            if (errors.Count() > 0)
                return Request.CreateResponse(HttpStatusCode.OK, new { errors });

            return Get();
        }


    }
}
