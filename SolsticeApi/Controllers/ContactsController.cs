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
        public IHttpActionResult Get()
        {
            var list = _contacRepository.GetAll();
            var contacts = list;
            return Ok(contacts);
        }

        // GET api/Contacts/81bfdb81-2369-40f5-b25f-df99f5a2bc58
        public IHttpActionResult Get(Guid id)
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
        public IHttpActionResult Post([FromBody]Contact value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contacRepository.AddContact(value);

            return Ok();

        }

        // PUT api/Contacts/81bfdb81-2369-40f5-b25f-df99f5a2bc58
        public IHttpActionResult Put(Guid id, [FromBody]Contact value)
        {
            _contacRepository.UpdateContact(id, value);

            return Ok();
        }

        // DELETE api/Contacts/5
        public IHttpActionResult Delete(Guid id)
        {
            var contact = _contacRepository.GetById(id);
            if (contact == null)
            {
                return NotFound();

            }

            _contacRepository.DeleteContact(contact);
            return Ok();
        }

        // GET api/Contacts/?email={email}
        [HttpGet]
        public IHttpActionResult GetByMail([FromUri]string email)
        {
            var contact = _contacRepository.GetByMail(email);
            if (contact != null)
            {
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }
        
        // GET api/Contacts/?email={email}
        [HttpGet]
        public IHttpActionResult GetByPhone([FromUri]string phoneNumber)
        {
            var contact = _contacRepository.GetByPhone(phoneNumber);
            if (contact != null)
            {
                return Ok(contact);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
