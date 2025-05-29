using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GranShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController(AppDbContext db) : ControllerBase
{
    private readonly AppDbContext _db = db;

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_db.Categorias.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var categoria = _db.Categorias.Find(id);
        if (categoria == null)
            return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid)
            return BadRequest("Categoria informada com problemas");
        _db.Categorias.Add(categoria);
        _db.SaveChanges();
        return CreatedAtAction(nameof(Get), categoria.Id, new { categoria });
    }
    [HttpPut("{id}")]
}
