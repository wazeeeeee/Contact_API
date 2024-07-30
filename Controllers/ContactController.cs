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
    #region Update
    [HttpPut]
    public async Task<IActionResult> UpdContact(API_Model.Contact updContact)
    {
        var contactDb = await _context.Contact.FindAsync(updContact.Id);
        contactDb.Nom = updContact.Nom;
        contactDb.Prenom = updContact.Prenom;
        contactDb.Nom_Complet = updContact.Nom_Complet;
        contactDb.Sexe = updContact.Sexe;
        contactDb.Date_Naissance = updContact.Date_Naissance;
        contactDb.Avatar = updContact.Avatar;
        
        await _context.SaveChangesAsync();
        return Ok(updContact);
    }
    #endregion
}
