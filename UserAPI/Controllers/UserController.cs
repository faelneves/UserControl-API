using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Data;
using UserAPI.Data.Dtos;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
    public class UserController : ControllerBase
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult addUser([FromBody] AddUserDto userDto)
        {
            User user = new User
            {
                Nome = userDto.Nome,
                DataNascimento = userDto.DataNascimento,
                Email = userDto.Email,
                Senha = userDto.Senha,
                Ativo = userDto.Ativo,
                SexoId = userDto.SexoId
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getUserById), new { Id = user.UsuarioId }, user);
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            return Ok(_context.Users);
        }

        [HttpGet("{id}")]
        public IActionResult getUserById(int id)
        {
            User usuario =  _context.Users.FirstOrDefault(user => user.UsuarioId == id);
            if(usuario != null)
            {
                return Ok(usuario);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult setUser(int id, [FromBody] AddUserDto userDto)
        {
            User usuario = _context.Users.FirstOrDefault(user => user.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nome = userDto.Nome;
            usuario.DataNascimento = userDto.DataNascimento;
            usuario.Email = userDto.Email;
            usuario.Senha = userDto.Senha;
            usuario.Ativo = userDto.Ativo;
            usuario.SexoId = userDto.SexoId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id)
        {
            User usuario = _context.Users.FirstOrDefault(user => user.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Remove(usuario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
