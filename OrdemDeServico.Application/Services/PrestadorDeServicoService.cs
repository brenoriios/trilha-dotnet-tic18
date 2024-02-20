using AutoMapper;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class PrestadorDeServicoService : IPrestadorDeServicoService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IEnderecoService _enderecoService;
    private readonly IMapper _mapper;
    public PrestadorDeServicoService(OrdemDeServicoContext context, IMapper mapper, IEnderecoService enderecoService)
    {
        _context = context;
        _mapper = mapper;
        _enderecoService = enderecoService;
    }
    public int Create(NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServico = _mapper.Map<PrestadorDeServico>(prestadorDeServico);
        _context.PrestadoresDeServico.Add(_prestadorDeServico);
        _context.SaveChanges();

        return _prestadorDeServico.PrestadorDeServicoId;
    }

    public void Delete(int id)
    {
        var _prestadorDeServicoDb = _context.PrestadoresDeServico.Find(id);

        if (_prestadorDeServicoDb is not null)
        {
            _context.PrestadoresDeServico.Remove(_prestadorDeServicoDb);
            _context.SaveChanges();
        }
    }

    public void Update(int id, NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        var _prestadorDeServicoDb = _context.PrestadoresDeServico.Find(id);

        if (_prestadorDeServicoDb is null)
        {
            return;
        }

        _prestadorDeServicoDb.Nome = prestadorDeServico.Nome;
        _prestadorDeServicoDb.Especialidade = prestadorDeServico.Especialidade;
        _prestadorDeServicoDb.Telefone = prestadorDeServico.Telefone;
        _enderecoService.Update(_prestadorDeServicoDb.EnderecoId, prestadorDeServico.Endereco);
        _prestadorDeServicoDb.UpdatedAt = DateTime.UtcNow;

        _context.PrestadoresDeServico.Update(_prestadorDeServicoDb);
        _context.SaveChanges();
    }

    public ICollection<PrestadorDeServicoViewModel> GetAll()
    {
        var _prestadoresDeServico = _mapper.ProjectTo<PrestadorDeServicoViewModel>(_context.PrestadoresDeServico).ToList();

        return _prestadoresDeServico;
    }

    public PrestadorDeServicoViewModel? GetById(int id)
    {
        var _prestadorDeServicoDb = _context.PrestadoresDeServico.Find(id);

        if (_prestadorDeServicoDb is null)
        {
            return null;
        }

        var _endereco = _enderecoService.GetById(_prestadorDeServicoDb.EnderecoId);

        if (_endereco is null)
        {
            return null;
        }

        var _prestadorDeServico = _mapper.Map<PrestadorDeServicoViewModel>(_prestadorDeServicoDb);
        return _prestadorDeServico;
    }
    public List<PrestadorDeServicoViewModel> GetByEspecialidade(string especialidade)
    {
        var _prestadoresDeServico = _mapper.ProjectTo<PrestadorDeServicoViewModel>(_context.PrestadoresDeServico).Where(prestadorDeServico => prestadorDeServico.Especialidade == especialidade).ToList();

        return _prestadoresDeServico;
    }
}
