using AutoMapper;
using MultiShop.Catalog.Dtos.AboutUsFooter;
using MultiShop.Catalog.Dtos.BrandVendor;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.GeneralOfferDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.ServiceCardDtos;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;
namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping :Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product,ProductResultWithCategoryDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            CreateMap<FeatureSlider,ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider,CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider,UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider,GetByIdFeatureSliderDto>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

            CreateMap<ServiceCard, ResultServiceCardDto>().ReverseMap();
            CreateMap<ServiceCard, CreateServiceCardDto>().ReverseMap();
            CreateMap<ServiceCard, UpdateServiceCardDto>().ReverseMap();
            CreateMap<ServiceCard, GetByIdServiceCardDto>().ReverseMap();

            CreateMap<GeneralOffer, ResultGeneralOfferDto>().ReverseMap();
            CreateMap<GeneralOffer,CreateGeneralOfferDto>().ReverseMap();
            CreateMap<GeneralOffer, UpdateGeneralOfferDto>().ReverseMap();
            CreateMap<GeneralOffer, GetByIdGeneralOfferDto>().ReverseMap();

            CreateMap<BrandVendor, ResultBrandVendorDto>().ReverseMap();
            CreateMap<BrandVendor, CreateBrandVendorDto>().ReverseMap();
            CreateMap<BrandVendor, UpdateBrandVendorDto>().ReverseMap();
            CreateMap<BrandVendor, GetByIdBrandVendorDto>().ReverseMap();

            CreateMap<AboutUsFooter, ResultAboutUsFooterDto>().ReverseMap();
            CreateMap<AboutUsFooter, CreateAboutUsFooterDto>().ReverseMap();
            CreateMap<AboutUsFooter, UpdateAboutUsFooterDto>().ReverseMap();
            CreateMap<AboutUsFooter,GetByIdAboutUsFooterDto>().ReverseMap();

            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact,CreateContactDto>().ReverseMap();
            CreateMap<Contact,UpdateContactDto>().ReverseMap();
            CreateMap<Contact,GetContactByIdDto>().ReverseMap();
        }

    }
}
