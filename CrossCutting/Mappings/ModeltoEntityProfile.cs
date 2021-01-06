using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Entities;
using Services.Models;

namespace CrossCutting.Mappings
{
    //MAPEAMENTO DE MODEL PARA ENTITY
    public class ModeltoEntityProfile : Profile
    {
        public ModeltoEntityProfile()
        {
            CreateMap<UserModel, UserEntity>();
            CreateMap<UfModel, UfEntity>();
            CreateMap<MunicipioModel, MunicipioEntity>();
            CreateMap<CepModel, CepEntity>();
        }
    }
}
