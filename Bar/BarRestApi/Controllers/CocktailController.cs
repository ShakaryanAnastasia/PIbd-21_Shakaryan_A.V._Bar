using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BarRestApi.Controllers
{
    public class CocktailController : ApiController
    {
        private readonly ICocktailService _service;

        public CocktailController(ICocktailService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(CocktailBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdElement(CocktailBindingModel model)
        {
            _service.UpdElement(model);
        }

        [HttpPost]
        public void DelElement(CocktailBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
