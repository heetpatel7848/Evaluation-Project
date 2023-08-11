using AutoMapper;
using PracticalTask.Models;
using PracticalTask.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Services.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Item, ItemDTO>();
            CreateMap<ItemDTO, Item>();

            CreateMap<PriceChange, PriceChangeDTO>().ReverseMap();
        }
    }
}
