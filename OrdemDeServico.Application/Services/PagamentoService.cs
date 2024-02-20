using AutoMapper;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services;

public class PagamentoService : IPagamentoService
{
    private readonly OrdemDeServicoContext _context;
    private readonly IMapper _mapper;

    public PagamentoService(OrdemDeServicoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public int Create(NewPagamentoInputModel pagamento)
    {
        var _ordemServico = _context.OrdensServico.Find(pagamento.OrdemServicoId) ?? throw new OrdemServicoNotFoundException();
        var _pagamento = _mapper.Map<Pagamento>(pagamento);
        _context.Pagamentos.Add(_pagamento);
        _context.SaveChanges();

        return _pagamento.PagamentoId;

    }

    public ICollection<PagamentoViewModel> GetAll()
    {
        var _pagamentos = _mapper.ProjectTo<PagamentoViewModel>(_context.Pagamentos).ToList();

        return _pagamentos;
    }

    public PagamentoViewModel? GetById(int id)
    {
        var _pagamento = _context.Pagamentos.Find(id);

        if (_pagamento is null)
        {
            return null;
        }

        var _pagamentoViewModel = _mapper.Map<PagamentoViewModel>(_pagamento);

        return _pagamentoViewModel;
    }

    public void Update(int id, NewPagamentoInputModel pagamento)
    {
        var _pagamento = _context.Pagamentos.Find(id);

        if (_pagamento is not null)
        {
            _pagamento.Valor = pagamento.Valor;
            _pagamento.DataPagamento = pagamento.DataPagamento;
            _pagamento.MetodoPagamento = pagamento.MetodoPagamento;
            _pagamento.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var pagamentoDb = _context.Pagamentos.Find(id);

        if (pagamentoDb is not null)
        {
            _context.Pagamentos.Remove(pagamentoDb);
            _context.SaveChanges();
        }
    }

    public List<PagamentoViewModel> GetPagamentoByMetodo(string metodoDePagamento)
    {
        var _pagamentos = _mapper.ProjectTo<PagamentoViewModel>(_context.Pagamentos).Where(pagamento => pagamento.MetodoPagamento == metodoDePagamento).ToList();
        
        return _pagamentos;
    }
}
