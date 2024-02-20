using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class ClienteService : IClienteService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IMapper _mapper;
    private readonly IEnderecoService _enderecoService;
    public ClienteService(OrdemDeServicoContext context, IEnderecoService enderecoService, IMapper mapper)
    {
        _context = context;
        _enderecoService = enderecoService;
        _mapper = mapper;
    }
    public int Create(NewClienteInputModel cliente)
    {
        var _cliente = _mapper.Map<Cliente>(cliente);

        _context.Clientes.Add(_cliente);
        _context.SaveChanges();

        return _cliente.ClienteId;
    }

    public ICollection<ClienteViewModel> GetAll()
    {
        var _clientes = _mapper.ProjectTo<ClienteViewModel>(_context.Clientes).ToList();

        return _clientes;
    }

    public ClienteViewModel? GetById(int id)
    {
        var _cliente = _context.Clientes.Find(id);

        if (_cliente is null)
        {
            return null;
        }

        var _endereco = _enderecoService.GetById(_cliente.EnderecoId);

        if (_endereco is null)
        {
            return null;
        }

        return _mapper.Map<ClienteViewModel>(_cliente);
    }

    public void Update(int id, NewClienteInputModel cliente)
    {
        var _clienteDb = _context.Clientes.Find(id);

        if (_clienteDb is not null)
        {
            _clienteDb.Nome = cliente.Nome;
            _clienteDb.Email = cliente.Email;
            _clienteDb.Telefone = cliente.Telefone;
            _enderecoService.Update(_clienteDb.EnderecoId, cliente.Endereco);
            _clienteDb.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var _clienteDb = _context.Clientes.Find(id);

        if (_clienteDb is not null)
        {
            _context.Clientes.Remove(_clienteDb);
            _context.SaveChanges();
        }
    }

    public List<ClienteViewModel> GetByTelefone(string telefone)
    {
        var clientes = _context.Clientes
            .Where(cliente => cliente.Telefone == telefone)
            .Select(cliente => _mapper.Map<ClienteViewModel>(cliente)).ToList();

        return clientes;
    }
}
