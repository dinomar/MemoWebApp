using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MemoWebAppDAL.Repos;
using MemoWebAppDAL.Models;
using AutoMapper;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace MemoWebApi.Controllers
{
    [RoutePrefix("api/Memos")]
    public class MemosController : ApiController
    {
        private readonly MemosRepo _repo = new MemosRepo();

        // GET: api/Memos
        [HttpGet, Route("")]
        public IEnumerable<Memo> Get()
        {
            var memos = _repo.GetAll();
            return Mapper.Map<List<Memo>, List<Memo>>(memos);
        }

        // GET: api/Memos/5
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(Memo))]
        public async Task<IHttpActionResult> Get(int id)
        {
            Memo memo = await _repo.GetOneAsync(id);
            if (memo == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Memo, Memo>(memo));
        }

        // POST: api/Memos
        [HttpPost, Route("")]
        [ResponseType(typeof(Memo))]
        public async Task<IHttpActionResult> Post(Memo memo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repo.AddAsync(memo);
            }
            catch (Exception ex)
            {
                //return BadRequest();
                throw;
            }
            return CreatedAtRoute("DisplayRoute", new { id = memo.Id }, memo);
        }

        // PUT: api/Memos

        // Delete: api/Memos

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}