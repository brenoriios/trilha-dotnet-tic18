using AutoMapper;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Application.AutoMapper;
public class ConfigurationMapping : Profile
{
    public ConfigurationMapping()
    {
        CreateMap<NewEnderecoInputModel, Endereco>();
        CreateMap<Endereco, EnderecoViewModel>();

        CreateMap<NewClienteInputModel, Cliente>();
        CreateMap<Cliente, ClienteViewModel>();

        CreateMap<NewPrestadorDeServicoInputModel, PrestadorDeServico>();
        CreateMap<PrestadorDeServico, PrestadorDeServicoViewModel>();

        CreateMap<NewServicoInputModel, Servico>();
        CreateMap<Servico, ServicoViewModel>();

        CreateMap<NewPagamentoInputModel, Pagamento>();
        CreateMap<Pagamento, PagamentoViewModel>();

        CreateMap<NewServicoOrdemServicoInputModel, ServicoOrdemServico>();
        CreateMap<ServicoOrdemServico, ServicoOrdemServicoViewModel>();

        CreateMap<NewOrdemServicoInputModel, OrdemServico>();
        CreateMap<OrdemServico, OrdemServicoViewModel>();
    }
}
