using GerenciadorDeTarefa.Model;
using GerenciadorDeTarefa.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefa.Controller;

[Route("[api/controller]")]
[ApiController]
public class TarefaController: ControllerBase
{
    private readonly IServiceTarefa _service;

    public TarefaController(IServiceTarefa service)
    {
        _service = service; 
    }

    [HttpGet("retornarTarefas")]
    public async Task<IActionResult> GetAll()
    {
        var tarefas = await _service.RetornarTodasTarefas();
        return Ok(tarefas);
    }

    [HttpGet("retornarTarefaId")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tarefaEncontrada = await _service.ObterTarefaPorId(id);
        if(tarefaEncontrada == null) return NotFound();
        else return Ok(tarefaEncontrada);
    }

    [HttpPost("cadastrarTarefa")]
    public async Task<IActionResult> PostCadastrarTarefa([FromBody] Tarefa novaTarefa)
    {
        if (novaTarefa == null) return BadRequest("Campos não podem ser nulos");
        try
        {
            novaTarefa.Id = Guid.NewGuid();
            var tarefaCriada = await _service.CriarTarefa(novaTarefa);
            return CreatedAtAction(nameof(GetById), new { id = tarefaCriada.Id }, tarefaCriada);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("atualizarTarefa")]
    public async Task<IActionResult> PutAtualizacaoTarefa([FromBody] Tarefa tarefaAtualizada)
    {
        if(tarefaAtualizada == null) return BadRequest("Erro ao encaminhar tarefa para API");

        try
        {
            int linhasAlteradas = await _service.AtualizarTarefa(tarefaAtualizada);
            return (linhasAlteradas > 0) ? Ok(linhasAlteradas) : BadRequest();
        }
        catch (Exception ex) 
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpDelete("deleteTarefa/{id}")]
    public async Task<IActionResult> DeleteTarefa(Guid id)
    {
        try
        {
            var tarefaEncontrada = await _service.ObterTarefaPorId(id);
            if (tarefaEncontrada == null) { return BadRequest("Tarefa não encontrada"); }

            await _service.DeletarTarefa(id);
            return NoContent();

        }
        catch(Exception ex) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
