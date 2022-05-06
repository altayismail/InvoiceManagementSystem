using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OdemeSistemi.Application.OdemeOperation.Queries;
using OdemeSistemi.Concrete;
using OdemeSistemi.Entities;
using System.Linq;

namespace OdemeSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdemeController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public OdemeController(IMapper mapper, Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetOdemeList()
        {
            GetOdemeQuery query = new GetOdemeQuery(_context, _mapper);
            var odemeler = query.Handle();
            return Ok(odemeler);
        }
        [HttpPost]
        public IActionResult AddOdeme(Odeme odeme)
        {
            _context.Add(odeme);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetOdeme(int id)
        {
            GetOdemeByIdQuery query = new GetOdemeByIdQuery(_context, _mapper);
            query.OdemeId = id;
            var odeme = query.Handle();
            return Ok(odeme);
        }
    }
}
