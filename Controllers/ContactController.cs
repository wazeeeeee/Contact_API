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
}
