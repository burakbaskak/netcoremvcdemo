using Data;
using Data.Model;
using Services.Base;
using Services.Interface;

namespace Services.Implement
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(DemoDbContext context) : base(context)
        {
        }
    }
}