using API_Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Controller;

    [Route("api/[controller]")]
    [ApiController]
public class Contact : ControllerBase
{
    private readonly DataContext _context;

    public Contact(DataContext context)
    {
        _context = context;
    }
    
    #region GetALL
    [HttpGet]
    public async Task<IActionResult> GetContact()
    {
        var contacts = await _context.Contact.ToListAsync();
        return Ok(contacts);
    }
    #endregion
    #region Add
    [HttpPost]
    public async Task<IActionResult> AddContact([FromBody] API_Model.Contact objContact) 
    {
        if (!ModelState.IsValid)
        {
            return new JsonResult("Error While Creating New Contact");
        }
        _context.Contact.Add(objContact);
        await _context.SaveChangesAsync();

        return new JsonResult("Contact Created Successfully");
    }
    #endregion
}
