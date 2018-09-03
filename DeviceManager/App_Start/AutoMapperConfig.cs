using System;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.Models;
using DeviceManager.Models.ViewModels;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DeviceManager.App_Start.AutoMapperConfig))]

namespace DeviceManager.App_Start
{
    public class AutoMapperConfig
    {
        public void Configuration(IAppBuilder app)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Delivery, DeliveryViewModel>();
                cfg.CreateMap<DeliveryDetail, DeliveryDetailViewModel>();
                cfg.CreateMap<DeliveryViewModel, Delivery>();
                cfg.CreateMap<DeliveryDetailViewModel, DeliveryDetail>();
                cfg.CreateMap<Category, ViewModelBase>();
                cfg.CreateMap<Unit, ViewModelBase>();
                cfg.CreateMap<Status, ViewModelBase>();
                cfg.CreateMap<Device, DeviceViewModel>();
                cfg.CreateMap<Receipt, ReceiptViewModel>();
                cfg.CreateMap<DeviceViewModel, DeviceEditViewModel>();
                cfg.CreateMap<DeviceEditViewModel, DeviceViewModel>();
            });
        }
    }
}
