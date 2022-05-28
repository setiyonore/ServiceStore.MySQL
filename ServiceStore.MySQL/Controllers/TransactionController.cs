using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using ServiceStore.MySQL.FormatterRequest;
using ServiceStore.Data;
using ServiceStore.Models;

namespace ServiceStore.MySQL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ServiceStoreContext _context;
    public TransactionController(ServiceStoreContext context)
    {
        _context = context;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetTransaction(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);

        if (transaction == null)
        {
            return NotFound();
        }
        return Ok(transaction);
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
    [HttpPost("/checkout/send")]
    public async Task<ActionResult>PostTransactions(Checkout.products checkout)
    {
        
        var data = new Transaction();
        data.Date = DateTime.Now;
        data.TotalPrice = checkout.total_price;
        data.ShippingCost = checkout.shipping_cost;
        data.AmountProductsPrice = checkout.amount_products_price;
        data.InvoiceCode = GenerateNoInvoice();
        data.ShippingAddress = checkout.shipping_adress;
        data.ProvinceId = checkout.province_id;
        data.CityId = checkout.city_id;
        data.PaymentStatus = "pending";
        data.UserId = 4;
        _context.Transactions.Add(data);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTransaction",new {id = data.Id},data);

    }

}