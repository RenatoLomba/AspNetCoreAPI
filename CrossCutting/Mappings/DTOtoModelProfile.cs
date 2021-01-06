using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.DTOs.Cep;
using Domain.DTOs.Municipio;
using Domain.DTOs.Uf;
using Domain.DTOs.User;
using Services.Models;

namespace CrossCutting.Mappings
{
    //CLASSE DE MAPEAMENTO DE DTOS PARA MODELS
    public class DTOtoModelProfile : Profile
    {
        public DTOtoModelProfile()
        {
            CreateMap<UserDTOEntry, UserModel>();
            //CreateMap<UfDTO, UfModel>();
            CreateMap<MunicipioDTOEntry, MunicipioModel>();
            CreateMap<CepDTOEntry, CepModel>();
        }
    }
}
