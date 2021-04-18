using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectApi.Utils
{
    public class AutoMapperGenericsHelper<TSource, TDestination>
    {
        public static TDestination ModelSourceToDestination(TSource model)
        {
            var mapper = Mapper();
            return mapper.Map<TDestination>(model);
        }

        private static Mapper Mapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            return new Mapper(configuration);
        }
    }
}