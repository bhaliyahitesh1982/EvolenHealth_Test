using EvolentHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvolentHealth.Controllers
{

    //[Authorize]  -- Can be manage Authrntication or Authorization using Filter attribute.
    public class ListItemsController : ApiController
    {
        private static List<CustomListItem> _listItems { get; set; } = new List<CustomListItem>();

        // GET api/<controller>
        public IEnumerable<CustomListItem> Get()
        {
            return _listItems;
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var item = _listItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            // can return actual values object of get in jason format
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] CustomListItem model)
        {
            if (string.IsNullOrEmpty(model?.Name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var maxId = 0;
            if (_listItems.Count > 0)
            {
                maxId = _listItems.Max(x => x.Id);
            }
            model.Id = maxId + 1;
            _listItems.Add(model);
            return Request.CreateResponse(HttpStatusCode.Created, model);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] CustomListItem model)
        {
            if (string.IsNullOrEmpty(model?.Name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var item = _listItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                // Update *all* of the item's properties
                item.Name = model.Name;

                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var item = _listItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _listItems.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}