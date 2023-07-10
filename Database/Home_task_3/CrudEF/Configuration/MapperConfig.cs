using AutoMapper;
using CrudEF.Model;
using CrudEF.ModelMapper.AddressDto;
using CrudEF.ModelMapper.ArtisianDto;
using CrudEF.ModelMapper.BankDetail;
using CrudEF.ModelMapper.CategoryDto;
using CrudEF.ModelMapper.ContactArtisianDto;
using CrudEF.ModelMapper.ContactCustomerDto;
using CrudEF.ModelMapper.CustomerDiscountDto;
using CrudEF.ModelMapper.CustomerDto;
using CrudEF.ModelMapper.DataArtisianDto;
using CrudEF.ModelMapper.DeliveryOrderDto;
using CrudEF.ModelMapper.DeliveryProviderDto;
using CrudEF.ModelMapper.DepartmentManufactoryDto;
using CrudEF.ModelMapper.DepartmentProductDto;
using CrudEF.ModelMapper.EmployeeDto;
using CrudEF.ModelMapper.ManufactoryHub;
using CrudEF.ModelMapper.NetworkArtisian;
using CrudEF.ModelMapper.OrderDto;
using CrudEF.ModelMapper.OrderItem;
using CrudEF.ModelMapper.PaymentDto;
using CrudEF.ModelMapper.PaymentMethodDto;
using CrudEF.ModelMapper.ProductCatalog;
using CrudEF.ModelMapper.ProductPriceDto;
using CrudEF.ModelMapper.ReceiptDto;
using CrudEF.ModelMapper.Rewiew;

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

            CreateMap<CustomerDiscountGetDto, CustomerDiscount>().ReverseMap();
            CreateMap<CustomerDiscountPostDto, CustomerDiscount>().ReverseMap();

            CreateMap<CustomerGetDto, Customer>().ReverseMap();
            CreateMap<CustomerPostDto, Customer>().ReverseMap();

            CreateMap<NetworkArtisianGetDto, NetworkArtisian>().ReverseMap();
            CreateMap<NetworkArtisianPostDto, NetworkArtisian>().ReverseMap();

            CreateMap<DataArtisianGetDto, DataArtisian>().ReverseMap();
            CreateMap<DataArtisianPostDto, DataArtisian>().ReverseMap();

            CreateMap<DeliveryProviderGetDto, DeliveryProvider>().ReverseMap();
            CreateMap<DeliveryProviderPostDto, DeliveryProvider>().ReverseMap();

            CreateMap<DeliveryOrderGetDto, DeliveryOrder>().ReverseMap();
            CreateMap<DeliveryOrderPostDto, DeliveryOrder>().ReverseMap();

            CreateMap<OrderGetDto, Order>().ReverseMap();
            CreateMap<OrderPutDto, Order>().ReverseMap();
            CreateMap<OrderPostDto, Order>().ReverseMap();

            CreateMap<OrderItemGetDto, OrderItem>().ReverseMap();
            CreateMap<OrderItemPostDto, OrderItem>().ReverseMap();

            CreateMap<PaymentMethodGetDto, PaymentMethod>().ReverseMap();
            CreateMap<PaymentMethodPostDto, PaymentMethod>().ReverseMap();

            CreateMap<PaymentGetDto, Payment>().ReverseMap();
            CreateMap<PaymentPutDto, Payment>().ReverseMap();
            CreateMap<PaymentPostDto, Payment>().ReverseMap();

            CreateMap<ReceiptGetDto, Receipt>().ReverseMap();
            CreateMap<ReceiptPostDto, Receipt>().ReverseMap();

            CreateMap<RewiewGetDto, Rewiew>().ReverseMap();
            CreateMap<RewiewPostDto, Rewiew>().ReverseMap();

            CreateMap<EmployeeGetDto, Employee>().ReverseMap();
            CreateMap<EmployeePostDto, Employee>().ReverseMap();

            CreateMap<ManufactoryHubGetDto, ManufactoryHub>().ReverseMap();
            CreateMap<ManufactoryHubPostDto, ManufactoryHub>().ReverseMap();

            CreateMap<DepartmentManufactoryGetDto, DepartmentManufactory>().ReverseMap();
            CreateMap<DepartmentManufactoryPostDto, DepartmentManufactory>().ReverseMap();

            CreateMap<ProductPriceGetDto, ProductPrice>().ReverseMap();
            CreateMap<ProductPricePutDto, ProductPrice>().ReverseMap();
            CreateMap<ProductPricePostDto, ProductPrice>().ReverseMap();

            CreateMap<ProductCatalogGetDto, ProductCatalog>().ReverseMap();
            CreateMap<ProductCatalogPostDto, ProductCatalog>().ReverseMap();

            CreateMap<DepartmentProductGetDto, DepartmentProduct>().ReverseMap();
            CreateMap<DepartmentProductPostDto, DepartmentProduct>().ReverseMap();
        }
        
    }
}
