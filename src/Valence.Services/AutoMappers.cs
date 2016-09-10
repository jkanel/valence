using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Valence.Models;
using Valence.Entities;
using Valence.Interactors;

namespace Valence
{

    public class MapKey
    {
        public MapKey() { }
        public MapKey(Type SourceType, Type DestinationType)
        {
            this.SourceType = SourceType;
            this.DestinationType = DestinationType;
        }

        public Type SourceType { get; set; }
        public Type DestinationType { get; set; }
    }

    public class MapperStore 
    {

        //private static bool _IsInitializaed = false;
        //private static Dictionary<MapKey, IMapper> _Mappers;

        //private static void Initialize()
        //{
        //    MapperStore._Mappers = new Dictionary<MapKey, IMapper>();

        //    MapperConfiguration config;

        //    // Organization >> OrganizationModel
        //    config = new MapperConfiguration(cfg => cfg.CreateMap<Organization, OrganizationModel>());
        //    _Mappers.Add(new MapKey(typeof(Organization), typeof(OrganizationModel)), config.CreateMapper());

        //    // OrganizationModel >> Organization
        //    config = new MapperConfiguration(cfg => cfg.CreateMap<OrganizationModel, Organization>());
        //    _Mappers.Add(new MapKey(typeof(OrganizationModel), typeof(Organization)), config.CreateMapper());

        //}

        //public static IMapper GetMapper(Type SourceType, Type DestinationType)
        //{
        //    if(MapperStore._Mappers == null)
        //    {
        //        MapperStore.Initialize();
        //    }

        //    return _Mappers[new MapKey(SourceType, DestinationType)];            
        //}

        //public static void Copy(object Source, object Destination)
        //{
        //    IMapper map = MapperStore._Mappers[new MapKey(Source.GetType(), Destination.GetType())];
        //    map.Map(Source, Destination);
        //}

        //public static object Create(object Source, Type DestinationType)
        //{
        //    IMapper map = MapperStore._Mappers[new MapKey(Source.GetType(), DestinationType)];
        //    return map.Map(Source, DestinationType);
        //}
    }
}
