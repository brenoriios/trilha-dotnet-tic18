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
    }
}
