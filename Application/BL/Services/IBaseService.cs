using ORMLibrary;

namespace BL.Services
{
    public abstract class BaseService
    {
        protected AppContext Context { get; set; }
        protected BaseService(AppContext context)
        {
            this.Context = context;
        }
    }
}
