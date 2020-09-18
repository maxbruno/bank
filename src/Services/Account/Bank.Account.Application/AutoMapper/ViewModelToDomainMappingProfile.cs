using AutoMapper;
using Bank.Account.Application.ViewModels;

namespace Bank.Account.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AccountViewModel, Domain.Models.Account>();
            CreateMap<TransactionViewModel, Domain.Models.Transaction>();
            CreateMap<TransactionInputViewModel, Domain.Models.Transaction>();
            
        }
    }
}