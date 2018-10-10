using AutoMapper;
using CarSystem.Models;
using CarSystem.Web.Models.CarsMod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSystem.Web.App_Start
{
    public class DomainProfile:Profile
    {
        
        public DomainProfile()
        {
            CreateMap<Car, CarViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(t => t.CarModels.Brand.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(t => t.CarModels.Brand.BrandName))
                //.ForMember(dest => dest.Brand, opt => opt.MapFrom(t => t.CarModels.Brand.BrandName))
                .ForMember(dest => dest.Engine, opt => opt.MapFrom(t => t.Engine))
                .ForMember(dest => dest.Mileage, opt => opt.MapFrom(t => t.Mileage))
                .ForMember(dest => dest.CarModelsId, opt => opt.MapFrom(t => t.CarModelsId))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(t => t.CarModels.ModelName))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(t => t.Color))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(t => t.Price))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(t => t.DateOfManufacturer))
                .ForMember(dest => dest.PicturePath, opt => opt.MapFrom(t => t.PicturePath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(t => t.Description))                
                ;

            CreateMap<CarViewModel, Car>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(t => t.Id))                               
                .ForMember(dest => dest.Engine, opt => opt.MapFrom(t => t.Engine))
                .ForMember(dest => dest.Mileage, opt => opt.MapFrom(t => t.Mileage))
                //.ForMember(dest => dest.CarModelsId, opt => opt.MapFrom(t => t.CarModelsId))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(t => t.Color))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(t => t.Price))
                .ForMember(dest => dest.DateOfManufacturer, opt => opt.MapFrom(t => t.Year))
                .ForMember(dest => dest.PicturePath, opt => opt.MapFrom(t => t.PicturePath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(t => t.Description));

            CreateMap<Car, AddCarViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(t => t.CarModels.Brand.Id))
               // .ForMember(dest => dest.Brand, opt => opt.MapFrom(t => t.CarModels.Brand.BrandName))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(t => t.CarModels.Brand.BrandName))
                .ForMember(dest => dest.Engine, opt => opt.MapFrom(t => t.Engine))
                .ForMember(dest => dest.Mileage, opt => opt.MapFrom(t => t.Mileage))
                .ForMember(dest => dest.CarModelsId, opt => opt.MapFrom(t => t.CarModelsId))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(t => t.CarModels.ModelName))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(t => t.Color))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(t => t.Price))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(t => t.DateOfManufacturer))
                .ForMember(dest => dest.PicturePath, opt => opt.MapFrom(t => t.PicturePath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(t => t.Description))
                ;

            CreateMap<AddCarViewModel, Car>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(dest => dest.Engine, opt => opt.MapFrom(t => t.Engine))
               // .ForPath(dest => dest.CarModels.Brand.Id, opt => opt.MapFrom(t => t.BrandId))
                .ForPath(dest => dest.CarModelsId, opt => opt.MapFrom(t => t.CarModelsId))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(t => t.Color))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(t => t.Price))
                .ForMember(dest => dest.DateOfManufacturer, opt => opt.MapFrom(t => t.Year))
                .ForMember(dest => dest.PicturePath, opt => opt.MapFrom(t => t.PicturePath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(t => t.Description));

        }
        public static void Run()
        {
            Mapper.Initialize(a =>
            {
                a.AddProfile<DomainProfile>();
            });
        }
    }
}