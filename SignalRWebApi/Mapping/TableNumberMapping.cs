using AutoMapper;
using SignalR.DtoLayer.TableNumberDto;
using SignalR.EntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
    public class TableNumberMapping: Profile
    {
        public TableNumberMapping() 
        {
            CreateMap<TableNumber, ResultTableNumberDto>().ReverseMap();
            CreateMap<TableNumber, CreateTableNumberDto>().ReverseMap();
            CreateMap<TableNumber, UpdateTableNumberDto>().ReverseMap();
        }
    }
}
