using System;
using AutoMapper;
using CrossCutting.Mappings;
using Xunit;

namespace ServiceTest
{
    public abstract class BaseServiceTest
    {
        public IMapper _mapper { get; set; }
        public BaseServiceTest()
        {
            _mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile(new DTOtoModelProfile());
                    cfg.AddProfile(new EntitytoDTOProfile());
                    cfg.AddProfile(new ModeltoEntityProfile());
                });
                return config.CreateMapper();
            }
            public void Dispose()
            {
                
            }
        }
    }
}
