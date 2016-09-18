using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using project.Models;
namespace project.Controllers
{

   
    public class valuesController : ApiController
    {

        readonly static IProjectRepository projectRespository = new PaylasimlarRepository();

        [AcceptVerbs("GET", "POST")]
        [HttpGet]
        public IQueryable<Paylasimlar> All()
        {
            return projectRespository.All();
        }
    }
}
