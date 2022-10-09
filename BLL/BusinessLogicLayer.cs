using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BusinessLogicLayer
    {
        DataAccessLayer dal = new DataAccessLayer();

        public int InsertPropertyTypes(PropertyTypes propertyTypes)
        {
            return dal.InsertPropertyTypes(propertyTypes);
        }
        public DataTable GetPropertyTypes()
        {
            return dal.GetPropertyTypes();
        }
        public int InsertProvince(Provinces provinces)
        {
            return dal.InsertProvinces(provinces);
        }
        public DataTable GetProvinces()
        {
            return dal.GetProvinces();
        }
        public int InsertCities(Cities cities)
        {
            return dal.InserCities(cities);
        }
        public DataTable GetCities()
        {
            return dal.GetCities();
        }
        public int InsertProperties(Property properties)
        {
            return dal.InsertProperties(properties);
        }
        public int UpdateProperties(Property properties)
        {
            return dal.UpdateProperties(properties);
        }
        public int DeleteProperties(Property properties)
        {
            return dal.DeleteProperties(properties);
        }
        public DataTable GetProperties()
        {
            return dal.GetProperties();
        }
        public int InsertSuburbs(Suburbs suburbs)
        {
            return dal.InsertSuburbs(suburbs);
        }
        public DataTable GetSuburbs()
        {
            return dal.GetSuburbs();
        }
        public int InsertAgencies(Agencies agencies)
        {
            return dal.InsertAgencies(agencies);
        }
        public int DeleteAgencies(Agencies agencies)
        {
            return dal.DeleteAgencies(agencies);
        }
        public DataTable GetAgencies()
        {
            return dal.GetAgencies();
        }
        public int InsertAgent(Agent agent)
        {
            return dal.InsertAgent(agent);
        }
        public int UpdateAgent(Agent agent)
        {
            return dal.UpdateAgent(agent);
        }
        public int DeleteAgent(Agent agent)
        {
            return dal.DeleteAgent(agent);
        }
        public DataTable GetAgent()
        {
            return dal.GetAgent();
        }
        public int InsertPropertyAgent(PropertyAgent propertyAgent)
        {
            return dal.InsertPropertyAgent(propertyAgent);
        }
        public int UpdatePropertyAgent(PropertyAgent propertyAgent)
        {
            return dal.UpdatePropertyAgent(propertyAgent);
        }
        public DataTable GetPropertyAgent()
        {
            return dal.GetPropertyAgent();
        }
        public int InsertRentals(Rentals rentals)
        {
            return dal.InsertRental(rentals);
        }
        public int UpdateRentals(Rentals rentals)
        {
            return dal.UpdateRentals(rentals);
        }
        public DataTable GetRentals()
        {
            return dal.GetRentals();
        }
        public int InsertTenant(Tenants tenants)
        {
            return dal.InsertTenant(tenants);
        }
        public int UpdateTenant(Tenants tenants)
        {
            return dal.UpdateTenant(tenants);
        }
        public int DeleteTenant(Tenants tenants)
        {
            return dal.DeleteTenant(tenants);
        }
        public DataTable GetTenant()
        {
            return dal.GetTenants();
        }
        public int InsertAdmin(Admin admin)
        {
            return dal.InsertAdmin(admin);
        }
        public DataTable GetAdmin()
        {
            return dal.GetAdmin();
        }

        public DataTable SeacrhByPrice(Price p)
        {
            return dal.GetPropertiesByPrice(p);
        }
        public DataTable GetEndedRentals()
        {
            return dal.GetEndedRental();
        }
        public DataTable GetCityProvinceSurbub()
        {
            return dal.GetCitySurbubProvince();
        }
        public DataTable PopularAgent()
        {
            return dal.GetPopular();
        }
        public DataTable PropertyPropertyType()
        {
            return dal.PropertyAndPropertyType();
        }
        public DataTable RentalsAndAgents()
        {
            return dal.RentalsAndAgents();
        }
        public DataTable AdminLog(string Em, string Pass)
        {
            return dal.AdminLog(Em, Pass);
        }
        public DataTable AgentLog(string Em, string Pass)
        {
            return dal.AgentLog(Em, Pass);
        }
        public DataTable TenantLog(string Em, string Pass)
        {
            return dal.TenantLog(Em, Pass);
        }
    }
}
