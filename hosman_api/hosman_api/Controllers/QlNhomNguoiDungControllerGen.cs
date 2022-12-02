//using hosman_api.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace hosman_api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class QlNhomNguoiDungControllerGen : ControllerBase
//    {
//        private readonly Hosman123Context _context;

//        public QlNhomNguoiDungControllerGen(Hosman123Context context)
//        {
//            _context = context;
//        }

//        // GET: api/QlNhomNguoiDung
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<QlNhomNguoiDung>>> GetQlNhomNguoiDungs()
//        {
//            return await _context.QlNhomNguoiDungs.ToListAsync();
//        }

//        // GET: api/QlNhomNguoiDung/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<QlNhomNguoiDung>> GetQlNhomNguoiDung(string id)
//        {
//            var qlNhomNguoiDung = await _context.QlNhomNguoiDungs.FindAsync(id);

//            if (qlNhomNguoiDung == null)
//            {
//                return NotFound();
//            }

//            return qlNhomNguoiDung;
//        }

//        // PUT: api/QlNhomNguoiDung/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutQlNhomNguoiDung(string id, QlNhomNguoiDung qlNhomNguoiDung)
//        {
//            if (id != qlNhomNguoiDung.MaNhom)
//            {
//                return BadRequest();
//            }

//            _context.Entry(qlNhomNguoiDung).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!QlNhomNguoiDungExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/QlNhomNguoiDung
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<QlNhomNguoiDung>> PostQlNhomNguoiDung(QlNhomNguoiDung qlNhomNguoiDung)
//        {
//            _context.QlNhomNguoiDungs.Add(qlNhomNguoiDung);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (QlNhomNguoiDungExists(qlNhomNguoiDung.MaNhom))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetQlNhomNguoiDung", new { id = qlNhomNguoiDung.MaNhom }, qlNhomNguoiDung);
//        }

//        // DELETE: api/QlNhomNguoiDung/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteQlNhomNguoiDung(string id)
//        {
//            var qlNhomNguoiDung = await _context.QlNhomNguoiDungs.FindAsync(id);
//            if (qlNhomNguoiDung == null)
//            {
//                return NotFound();
//            }

//            _context.QlNhomNguoiDungs.Remove(qlNhomNguoiDung);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool QlNhomNguoiDungExists(string id)
//        {
//            return _context.QlNhomNguoiDungs.Any(e => e.MaNhom == id);
//        }
//    }
//}
