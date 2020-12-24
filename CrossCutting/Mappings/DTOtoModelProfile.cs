using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.DTOs.User;
using Services.Models;

namespace CrossCutting.Mappings
{
    //CLASSE DE MAPEAMENTO DE DTOS PARA MODELS
    public class DTOtoModelProfile : Profile
    {
        public DTOtoModelProfile()
        {
            CreateMap<UserModel, UserDTOEntry>();
        }
    }
}
