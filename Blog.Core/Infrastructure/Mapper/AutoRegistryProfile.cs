﻿using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Blog.Core.Infrastructure.Orm;
using YH.Arch.Infrastructure.Extension;
using YH.Arch.Infrastructure.ORM;

namespace Blog.Core.Infrastructure.Mapper
{
    public class AutoRegistryProfile : Profile
    {
        public AutoRegistryProfile()
        {
            var mappers = getMappers(
                typeof(Repository).Assembly,
                typeof(BlogRepository).Assembly);

            foreach (var mapperElement in mappers)
            {
                CreateMap(mapperElement.SourceType, mapperElement.DestinationType).ConvertUsing(mapperElement.Converter);
            }
        }

        private IEnumerable<MapperElement> getMappers(params Assembly[] assemblies)
        {
            var elements = new List<MapperElement>();

            foreach (var assembly in assemblies)
            {
                var mappers = assembly.GetMapperElements();
                elements.AddRange(mappers);
            }

            return elements;
        }
    }
}