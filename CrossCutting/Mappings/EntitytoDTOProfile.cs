using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
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
            CreateMap<UfEntity, UfDTO>();
            CreateMap<MunicipioEntity, MunicipioDTO>();
            CreateMap<MunicipioEntity, MunicipioDTOCompleto>();
            CreateMap<CepEntity, CepDTO>();
        }
    }
}
