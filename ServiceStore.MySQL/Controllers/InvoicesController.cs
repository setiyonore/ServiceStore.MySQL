#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using RestSharp.Authenticators;
using ServiceStore.Data;
using ServiceStore.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using ServiceStore.MySQL.DataTransferObejct;
namespace ServiceStore.MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ServiceStoreContext _context;
        public InvoicesController(ServiceStoreContext context)
        {
            _context = context;
        }
        [HttpGet("countCost")]
        public async Task<IActionResult> countCost()
        {
           var  _client = new RestClient("https://reqres.in/");
           var request = new RestRequest("api/users");
           var response = await _client.ExecuteGetAsync(request);
            var userList = JsonSerializer.Deserialize<UserList>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Ok(userList.Data);

        }
        [HttpGet("generateNoInvoice")]
        public string GenerateNoInvoice()
        {
            //INV220412xxxx
            var date = DateTime.Now;
            //tahun
            var year = date.ToString("yy");
            //bulan
            var month = date.ToString("MM");
            //hari
            var day = date.ToString("dd");
            //jam
            var hours = date.ToString("HH");
            //menit
            var minutes = date.ToString("mm");
            //second
            var seconds = date.ToString("ss");
            //milisecond
            var milis = date.ToString("fff");
            var noInvoice = "INV"+year+month+day+hours+minutes+seconds+milis;
            return noInvoice;

        }
        /*
        [HttpGet("countInvoice")]
        public int CountInvoice(DateTime date)
        { //count invoice in this date
            //var count = _context.Invoices.Where(x => x.Date == date).Count();
            return _context.Invoices.Where(x => x.Date == date).Count();
        }
        */
        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            //return await _context.Invoices.ToListAsync();
            return  Ok(_context.Invoices);
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void StoreInvoice(int id_produk)
        {
            var tgl = DateTime.Now;
            var noInvoice = GenerateNoInvoice();
            var dataInvoice = new Invoice();
            dataInvoice.Id = 0;
            dataInvoice.UserId = 4;
            dataInvoice.Date = tgl;
            dataInvoice.InvoiceCode = noInvoice;
            dataInvoice.ShippingCost = "35000";
            dataInvoice.TotalPrice = "750000";
            dataInvoice.ShippingAddress = "Jl raya diponegoro no 25";
            dataInvoice.ProvinceId = 35;
            dataInvoice.CityId = 15;
            dataInvoice.PaymentStatus = "Pending";

            _context.Invoices.Add(dataInvoice);
            _context.SaveChanges();


        }
        /*[HttpGet("PostInvoice")]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }
        */
       
        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
