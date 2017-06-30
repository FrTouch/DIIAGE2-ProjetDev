using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.Model;
using System.Web.Http;

namespace ProjetWeb.API.Controllers
{
    public class TypeController : ApiController
    {
        // on instancie un TypeBL pour utiliser les méthodes
        private TypeBL BLType = new TypeBL();
        // GET: Type
        public List<TypeModel> Get()
        {
            //On appelle la fonction GetLesType
            return BLType.GetLesType();
        }
        public TypeModel Get(int id)
        {
            //On appelle la fonction GetUnTypeById
            return BLType.GetUnTypeById(id);
        }
    }
}