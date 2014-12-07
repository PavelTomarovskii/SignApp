using Ninject;
using SignApplication.Model.DBConnection;

namespace SignApplication.Global.Repository
{
    public partial class Repository : IRepository
    {
        [Inject]
        public SignAppContext context { get; set; }
    }
}
