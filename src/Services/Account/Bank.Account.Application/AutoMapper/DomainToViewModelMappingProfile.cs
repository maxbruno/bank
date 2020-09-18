using AutoMapper;
using Bank.Account.Application.ViewModels;

namespace Bank.Account.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.Models.Account, AccountViewModel>();
            CreateMap<Domain.Models.Transaction, TransactionViewModel>();
        }
    }
}