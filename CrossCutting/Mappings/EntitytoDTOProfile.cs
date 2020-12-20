using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.DTOs.User;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    //MAPEAMENTO DE ENTITY PARA DTO
    public class EntitytoDTOProfile : Profile
    {
        public EntitytoDTOProfile()
        {
            CreateMap<UserDTOSelectResult, UserEntity>().ReverseMap();
            CreateMap<UserDTOCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDTOUpdateResult, UserEntity>().ReverseMap();
        }
    }
}
