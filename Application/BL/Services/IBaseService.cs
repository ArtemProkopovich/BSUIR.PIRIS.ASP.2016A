using AutoMapper;
using BL.Services.Utilities;
using ORMLibrary;

namespace BL.Services
{
    public abstract class BaseService
    {
        protected AppContext Context { get; set; }
        protected IMapper Mapper { get; set; }
        protected BaseService(AppContext context)
        {
            Context = context;
            Mapper = MappingRegistrar.CreateMapperConfiguration().CreateMapper();          
        }
    }
}
