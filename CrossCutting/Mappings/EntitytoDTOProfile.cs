using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.DTOs.User;
using Domain.Entities;
using Services.Models;

namespace CrossCutting.Mappings
{
    public class EntitytoDTOProfile : Profile
    {
        public EntitytoDTOProfile()
        {
            CreateMap<UserEntity, UserDTO>();
        }
    }
}
