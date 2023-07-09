using AutoMapper;
using CrudEF.Model;
using CrudEF.ModelMapper.AddressDto;
using CrudEF.ModelMapper.ArtisianDto;
using CrudEF.ModelMapper.BankDetail;
using CrudEF.ModelMapper.CategoryDto;
using CrudEF.ModelMapper.ContactArtisianDto;
using CrudEF.ModelMapper.ContactCustomerDto;

namespace CrudEF.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AddressGetDto, Address>().ReverseMap();
            CreateMap<AddressPostDto, Address>().ReverseMap();

            CreateMap<ArtisianGetDto, Artisian>().ReverseMap();
            CreateMap<ArtisianPostDto, Artisian>().ReverseMap();

            CreateMap<BankDetailGetDto, BankDetail>().ReverseMap();
            CreateMap<BankDetailPostDto, BankDetail>().ReverseMap();

            CreateMap<CategoryGetDto, Category>().ReverseMap();
            CreateMap<CategoryPostDto, Category>().ReverseMap();

            CreateMap<ContactArtisianGetDto, ContactArtisian>().ReverseMap();
            CreateMap<ContactArtisianPostDto, ContactArtisian>().ReverseMap();

            CreateMap<ContactCustomerGetDto, ContactCustomer>().ReverseMap();
            CreateMap<ContactCustomerPostDto, ContactCustomer>().ReverseMap();

        }
        
    }
}
