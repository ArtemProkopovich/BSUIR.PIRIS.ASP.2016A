using ORMLibrary;

namespace BL.Services
{
    public abstract class BaseService
    {
        protected AppContext Context { get; set; }
        protected BaseService(AppContext context)
        {
            Context = context;
        }
    }
}
