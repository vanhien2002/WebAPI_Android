using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Android.Models;
using WebAPI_Android.Models.Entities;
using WebAPI_Android.Models.DTO;

namespace WebAPI_Android.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ThucUongController : ControllerBase
    {
        private readonly QlQuanCafeContext _context;
        public ThucUongController(QlQuanCafeContext ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Thucuong> lstThucUong = _context.Thucuongs.ToList();
            
            return Ok(_context.Thucuongs.ToList());
        }
        [HttpPost]
        [Route("UploadThucUong")]
        public IActionResult Create(ThucUong_DTO thucuong)
        {
            Thucuong tu = new Thucuong();
            tu.Manuoc = thucuong.Manuoc;
            tu.Tennuoc = thucuong.Tennuoc;
            tu.Maloai = thucuong.Maloai;
            tu.Gia = thucuong.Gia;
            tu.Size = thucuong.Size;
            tu.Trangthai = thucuong.Trangthai;
            _context.Thucuongs.Add(tu);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        [Route("Search")]
        public IActionResult GetByID(String id)
        {
            return Ok(_context.Thucuongs.Where(m => m.Manuoc == id));
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult DeleteByID(string ID)
        {
            Thucuong tu = _context.Thucuongs.Single(m => m.Manuoc == ID);
            _context.Remove(tu);
            _context.SaveChanges();
            return  Ok();
        }
    }
}
