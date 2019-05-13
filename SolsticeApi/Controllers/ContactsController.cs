using System.Collections.Generic;
using System.Web.Http;

namespace SolsticeApi.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using SolsticeData;

    public class ContactsController : ApiController
    {
        private readonly IContacRepository _contacRepository;

       public ContactsController(IContacRepository contactRepository)
        {
            _contacRepository = contactRepository;
        }

        // GET api/Contacts
        /// <summary>
        /// Retrieve a list of all Contacts.
        /// Use querystring parameter email or phoneNumber to find Contacts by these attributes.
        /// </summary>
        /// <param name="phoneNumber">Optional querystring parameter to filter by Phone Number.</param>
        /// <param name="email">Optional querystring parameter to filter by email address.</param>
        /// <returns></returns>
        public IHttpActionResult Get([FromUri]string phoneNumber="", [FromUri]string email="")
        {
            var list = _contacRepository.Find(phoneNumber, email);
            var contacts = list;
            return Ok(contacts);
        }

        /// <summary>
        /// Retrieve a Contact by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        // GET api/Contacts/81bfdb81-2369-40f5-b25f-df99f5a2bc58
        [HttpGet]
        public IHttpActionResult GetById(Guid id)
        {
            var contact = _contacRepository.GetById(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/Contacts
        /// <summary>
        /// Create a new contact.
        /// </summary>
        /// <param name="value">The contact information.</param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]Contact value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contacRepository.AddContact(value);
            
            var targetUri = new Uri(Request.RequestUri, value.Id.ToString());
            return Created(targetUri, value);
        }

        // PUT api/Contacts/81bfdb81-2369-40f5-b25f-df99f5a2bc58
        /// <summary>
        /// Update the specified contact.
        /// </summary>
        /// <param name="id">The contact identifier.</param>
        /// <param name="value">The updated contact information.</param>
        /// <returns></returns>
        public IHttpActionResult Put(Guid id, [FromBody]Contact value)
        {
            var existing = _contacRepository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            _contacRepository.UpdateContact(id, value);

            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        // DELETE api/Contacts/5
        /// <summary>
        /// Deletes a specific contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IHttpActionResult Delete(Guid id)
        {
            var contact = _contacRepository.GetById(id);
            if (contact == null)
            {
                return NotFound();

            }

            _contacRepository.DeleteContact(contact);
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
        }
    }
}
