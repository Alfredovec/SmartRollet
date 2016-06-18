using System.Data.Entity;
using System.Linq;
using DataAccess.Abstract;
using DataAccess.Models;

namespace DataAccess.Concrete
{
  public class RolletRepository : IRolletRepository
  {
    private readonly RolletContext _rolletContext;

    public RolletRepository()
    {
      _rolletContext = new RolletContext();
    }

    public Rollet GetRollet()
    {
      var rollet = _rolletContext.Rollets.First();
      return rollet;
    }

    public void UpdateRollet(Rollet rollet)
    {
      _rolletContext.Entry(rollet).State = EntityState.Modified;
      _rolletContext.SaveChanges();
    }
  }
}
