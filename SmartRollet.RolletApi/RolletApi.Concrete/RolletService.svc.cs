using RolletApi.Abstract;
using RolletApi.Concrete.RolletManager;
using RolletApi.Models;

namespace RolletApi.Concrete
{
    public class RolletService : IRolletService
    {
        private readonly IRolletManager _rolletManager;

        public RolletService()
        {
            _rolletManager = new RolletManagerClient();
        }

        public RolletDto GetRolletDto()
        {
            var rollet = _rolletManager.GetRollet(1);

            return new RolletDto()
            {
                Height = rollet.Height,
                Id = rollet.Id,
                Width = rollet.Width
            };
        }
    }
}
