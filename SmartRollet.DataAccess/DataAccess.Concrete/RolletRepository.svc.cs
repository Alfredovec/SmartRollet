using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Script.Serialization;
using DataAccess.Abstract;
using DataAccess.Models.Entities;
using DataAccess.Models.External;

namespace DataAccess.Concrete
{
    public class RolletRepository : IRolletRepository
    {
        private readonly RolletContext _rolletContext;

        public RolletRepository()
        {
            _rolletContext = new RolletContext();
        }

        public IEnumerable<Rollet> GetRollets(string email)
        {
            var user =
                _rolletContext
                    .Users
                    .Include(u => u.Rollets)
                    .Include(u => u.Rollets.Select(r => r.Lighter))
                    .SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                return Enumerable.Empty<Rollet>();
            }

            var rollets = user.Rollets;
            rollets.ToList().ForEach(r => r.RolletState = GetState(r));
            rollets.ToList().ForEach(r => r.LighterState = GetState(r.Lighter));

            return rollets;
        }



        public void UpdateRollet(Rollet rollet)
        {
            _rolletContext.Entry(rollet).State = EntityState.Modified;
            _rolletContext.SaveChanges();
        }

        public void ChangePosition(int id, int change)
        {
            using (var httpClient = new HttpClient())
            {
                var url = $"http://rollet-emulator.com/api/rollet/{id}?change={change}";
                var response = httpClient.PutAsync(url, null).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        private int GetState(Rollet rollet)
        {
            using (var httpClient = new HttpClient())
            {
                var url = "http://rollet-emulator.com/api/rollet/" + rollet.Id;
                var response = httpClient.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var jsonSerializer = new JavaScriptSerializer();
                var rolletModel = jsonSerializer.Deserialize<RolletState>(responseString);

                return rolletModel.OpenedPart;
            }
        }

        private int GetState(Lighter lighter)
        {
            using (var httpClient = new HttpClient())
            {
                var url = "http://lighter-emulator.com/api/lighter/" + lighter.Id;
                var response = httpClient.GetAsync(url).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var jsonSerializer = new JavaScriptSerializer();
                var lighterModel = jsonSerializer.Deserialize<LighterState>(responseString);

                return lighterModel.Value;
            }
        }
    }
}
