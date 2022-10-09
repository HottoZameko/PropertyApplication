using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataAccessLayer
    {
        static string ConString = "Data Source= localhost; Initial Catalog = PropertyDB; Integrated Security = true;";
        SqlConnection dbConn = new SqlConnection(ConString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        public int InsertPropertyTypes(PropertyTypes propertyTypes)
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertPropertyType", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyTypeDescription", propertyTypes.PropertyTypeDescr);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetPropertyTypes()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetPropertyType", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertProvinces(Provinces provinces)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertProvince", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Description", provinces.Description);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetProvinces()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetProvince", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InserCities(Cities cities)
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertCities", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@CityDescription", cities.CityDescr);
            dbComm.Parameters.AddWithValue("@ProvinceID", cities.ProvinceID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetCities()
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetCities", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertProperties(Property properties)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertProperty", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Description", properties.Description);
            dbComm.Parameters.AddWithValue("@Price", properties.Price);
            dbComm.Parameters.AddWithValue("@Image", properties.Image);
            dbComm.Parameters.AddWithValue("@PropertyTypeID", properties.PropertyTypeID);
            dbComm.Parameters.AddWithValue("@Status", properties.Status);
            dbComm.Parameters.AddWithValue("@SurbubID", properties.SuburbID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int UpdateProperties(Property properties)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_UpdateProperty", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyID", properties.PropertyID);
            dbComm.Parameters.AddWithValue("@Price", properties.Price);
            dbComm.Parameters.AddWithValue("@PropertyTypeID", properties.PropertyTypeID);
            dbComm.Parameters.AddWithValue("@Status", properties.Status);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int DeleteProperties(Property properties)
        {
             
            dbConn.Open();

            dbComm = new SqlCommand("sp_DeleteProperty", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyID", properties.PropertyID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetProperties()
        {
            dbConn.Open();
            
            dbComm = new SqlCommand("sp_GetProperty", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);

            dt = new DataTable();
            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertSuburbs(Suburbs suburbs)
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertSuburb", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@SurbubDescription", suburbs.SurbubDescription);
            dbComm.Parameters.AddWithValue("@PostalCode", suburbs.PostalCode);
            dbComm.Parameters.AddWithValue("@CityID", suburbs.CityID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetSuburbs()
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetSuburb", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertAgencies(Agencies agencies)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertAgencies", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgencyName", agencies.AgencyName);
            dbComm.Parameters.AddWithValue("@SurbubID", agencies.SurbubID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int DeleteAgencies(Agencies agencies)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_DeleteAgencies", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgencyID", agencies.AgencyID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetAgencies()
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetAgencies", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertAgent(Agent agent)
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", agent.Name);
            dbComm.Parameters.AddWithValue("@Surname", agent.Surname);
            dbComm.Parameters.AddWithValue("@Email", agent.Email);
            dbComm.Parameters.AddWithValue("@Password", agent.Password);
            dbComm.Parameters.AddWithValue("@Phone", agent.Phone);
            dbComm.Parameters.AddWithValue("@Status", agent.Status);
            dbComm.Parameters.AddWithValue("@AgencyID", agent.AgencyID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int UpdateAgent(Agent agent)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_UpdateAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgentID", agent.AgentID);

            dbComm.Parameters.AddWithValue("@Email", agent.Email);
            dbComm.Parameters.AddWithValue("@Phone", agent.Phone);
            dbComm.Parameters.AddWithValue("@Status", agent.Status);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int DeleteAgent(Agent agent)
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_DeleteAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgentID", agent.AgentID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetAgent()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertPropertyAgent(PropertyAgent propertyAgent)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertPropertyAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyID", propertyAgent.PropertyID);
            dbComm.Parameters.AddWithValue("@AgentID", propertyAgent.AgentID);
            dbComm.Parameters.AddWithValue("@Date", propertyAgent.Date);

            int i = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return i;
        }
        public int UpdatePropertyAgent(PropertyAgent propertyAgent)
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_UpdatePropertAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyID", propertyAgent.PropertyID);
            dbComm.Parameters.AddWithValue("@AgentID", propertyAgent.AgentID);
            dbComm.Parameters.AddWithValue("@Date", propertyAgent.Date);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable GetPropertyAgent()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetPropertyAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertRental(Rentals rentals)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertRentals", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyAgentID", rentals.PropertyAgentID);
            dbComm.Parameters.AddWithValue("@TenantID", rentals.TenantID);
            dbComm.Parameters.AddWithValue("@StartDate", rentals.StartDate);
            dbComm.Parameters.AddWithValue("@EndDate", rentals.EndDate);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int UpdateRentals(Rentals rentals)
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_UpdateRentals", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@RentalID", rentals.RentalID);

            dbComm.Parameters.AddWithValue("@StartDate", rentals.StartDate);
            dbComm.Parameters.AddWithValue("@EndDate", rentals.EndDate);

            int i = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return i;
        }
        public DataTable GetRentals()
        {
            
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetRental", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertTenant(Tenants tenants)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertTenant", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", tenants.Name);
            dbComm.Parameters.AddWithValue("@Surname", tenants.Surname);
            dbComm.Parameters.AddWithValue("@Email", tenants.Email);
            dbComm.Parameters.AddWithValue("@Password", tenants.Password);
            dbComm.Parameters.AddWithValue("@Phone", tenants.Phone);
            dbComm.Parameters.AddWithValue("@Status", tenants.Status);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int UpdateTenant(Tenants tenants)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_UpdateTenant", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TenantID", tenants.TenantID);

            dbComm.Parameters.AddWithValue("@Email", tenants.Email);
            dbComm.Parameters.AddWithValue("@Phone", tenants.Phone);
            dbComm.Parameters.AddWithValue("@Status", tenants.Status);
           

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }
        public int DeleteTenant(Tenants tenants)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_DeleteTenant", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TenantID", tenants.TenantID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }
        public DataTable GetTenants()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetTenant", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public int InsertAdmin(Admin admin)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_InsertAdministrator", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", admin.Name);
            dbComm.Parameters.AddWithValue("@Surname", admin.Surname);
            dbComm.Parameters.AddWithValue("@Email", admin.Email);
            dbComm.Parameters.AddWithValue("@Password", admin.Password);
            dbComm.Parameters.AddWithValue("@Status", admin.Status);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }
        public DataTable GetAdmin()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetAdmin", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable GetPropertiesByPrice(Price p)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_SearchByPrice", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Price", p.price);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable GetEndedRental()
        {

            dbConn.Open();

            dbComm = new SqlCommand("sp_GetEndedRentals", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable GetCitySurbubProvince()
        {

            dbConn.Open();

            dbComm = new SqlCommand("sp_GetCityProvinceSurbub", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable GetPopular()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_GetAgentWithManyProperties", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable PropertyAndPropertyType()
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_PropertyAndPropertyType", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable RentalsAndAgents()
        {

            dbConn.Open();

            dbComm = new SqlCommand("sp_RentalsAndAgents", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable AdminLog(string Email, string Password)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_LoginAdmin", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Password", Password);
            dbComm.Parameters.AddWithValue("@Email", Email);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable TenantLog(string Email, string Password)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_LoginTenant", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Password", Password);
            dbComm.Parameters.AddWithValue("@Email", Email);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
        public DataTable AgentLog(string Email, string Password)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_LoginAgent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Password", Password);
            dbComm.Parameters.AddWithValue("@Email", Email);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();

            dbAdapter.Fill(dt);

            dbConn.Close();

            return dt;
        }
    }
}
