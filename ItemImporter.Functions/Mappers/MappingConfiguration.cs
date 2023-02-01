using AutoMapper;
using ItemImporter.Functions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemImporter.Functions.Mappers
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Item, ConvertedItem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(dest => dest.Title))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(dest => dest.Available));
        }
    }
}
