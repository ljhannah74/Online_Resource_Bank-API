using System;
using MySqlConnector;
using orb_api.DTO;

namespace orb_api.DAL;

public class ResourceDAL : DbConnection
{
    public IEnumerable<StateDTO> GetAllStates()
    {
        var states = new List<StateDTO>();
        using (var connection = GetConnection())
        {
            connection.Open();
            var cmd = new MySqlCommand("GetStates", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                states.Add(new StateDTO
                {
                    StateId = reader.GetInt32("StateId"),
                    StateName = reader.GetString("StateName")
                });
            }
        }
        return states;
    }

    public IEnumerable<CountyDTO> GetCountiesByState(int stateId)
    {
        var counties = new List<CountyDTO>();
        using (var connection = GetConnection())
        {
            connection.Open();
            var cmd = new MySqlCommand("GetCountiesByState", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_StateID", stateId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                counties.Add(new CountyDTO
                {
                    StateId = reader.GetInt32("StateId"),
                    CountyId = reader.GetInt32("CountyId"),
                    CountyName = reader.GetString("CountyName")
                });
            }
        }
        return counties;
    }

    public ORBDTO GetOrbByCounty(int stateID, int countyId)
    {
        var orb = new ORBDTO();
        using (var connection = GetConnection())
        {
            connection.Open();
            var cmd = new MySqlCommand("GetOrbByCounty", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_StateID", stateID);
            cmd.Parameters.AddWithValue("@p_CountyID", countyId);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                orb = new ORBDTO
                {
                    StateId = reader.GetInt32("StateID"),
                    CountyId = reader.GetInt32("CountyID"),
                    ORBId = reader.GetInt32("Id"),
                    LastUpdate = reader.GetDateTime("last_update"),
                    CountyHomePage = reader.GetString("county_homepage"),
                    Comments = reader.GetString("comments")
                };

                orb.Resources = GetResourcesByORB(orb.ORBId).ToList();

            
            }
        }
        return orb;
    }

    public IEnumerable<ResourceDTO> GetResourcesByORB(int orbId)
    {
        var resources = new List<ResourceDTO>();
        using (var connection = GetConnection())
        {
            connection.Open();
            var cmd = new MySqlCommand("GetResourcesByOrb", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_ORBID", orbId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resources.Add(new ResourceDTO
                {
                    ResourceID = reader.GetInt32("ResourceID"),
                    ORBId = reader.GetInt32("ORBId"),
                    ResourceTypeID = reader.GetInt32("ResourceTypeID"),
                    URL = reader.IsDBNull(reader.GetOrdinal("URL")) ? String.Empty : reader.GetString("URL"),
                    Username = reader.IsDBNull(reader.GetOrdinal("Username")) ? String.Empty : reader.GetString("Username"),
                    Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? String.Empty : reader.GetString("Password"),
                    IndexDate = reader.IsDBNull(reader.GetOrdinal("IndexDate")) ? DateTime.MinValue : reader.GetDateTime("IndexDate"),
                    ImageDate = reader.IsDBNull(reader.GetOrdinal("ImageDate")) ? DateTime.MinValue : reader.GetDateTime("ImageDate"),
                    Source = reader.IsDBNull(reader.GetOrdinal("Source")) ? String.Empty : reader.GetString("Source"),
                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? String.Empty : reader.GetString("Address"),
                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? String.Empty : reader.GetString("City"),
                    State = reader.IsDBNull(reader.GetOrdinal("State")) ? String.Empty : reader.GetString("State"),
                    Zip = reader.IsDBNull(reader.GetOrdinal("Zip")) ? String.Empty : reader.GetString("Zip"),
                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? String.Empty : reader.GetString("Phone"),
                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? String.Empty : reader.GetString("Email")
                });
            }
        }
        return resources;
    }

    public void AddOrUpdateResourceByOrb(ResourceDTO resourceDTO)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var cmd = new MySqlCommand("AddOrUpdateResourceByOrb", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_ResourceID", resourceDTO.ResourceID);
            cmd.Parameters.AddWithValue("@p_ORBID", resourceDTO.ORBId == 0 ? DBNull.Value : (object)resourceDTO.ORBId);
            cmd.Parameters.AddWithValue("@p_ResourceTypeID", resourceDTO.ResourceTypeID == 0 ? DBNull.Value : (object)resourceDTO.ResourceTypeID);
            cmd.Parameters.AddWithValue("@p_URL", string.IsNullOrEmpty(resourceDTO.URL) ? DBNull.Value : (object)resourceDTO.URL);
            cmd.Parameters.AddWithValue("@p_Username", string.IsNullOrEmpty(resourceDTO.Username) ? DBNull.Value : (object)resourceDTO.Username);
            cmd.Parameters.AddWithValue("@p_Password", string.IsNullOrEmpty(resourceDTO.Password) ? DBNull.Value : (object)resourceDTO.Password);
            cmd.Parameters.AddWithValue("@p_IndexDate", resourceDTO.IndexDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@p_ImageDate", resourceDTO.ImageDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@p_Source", string.IsNullOrEmpty(resourceDTO.Source) ? DBNull.Value : (object)resourceDTO.Source);
            cmd.Parameters.AddWithValue("@p_Address", string.IsNullOrEmpty(resourceDTO.Address) ? DBNull.Value : (object)resourceDTO.Address);
            cmd.Parameters.AddWithValue("@p_City", string.IsNullOrEmpty(resourceDTO.City) ? DBNull.Value : (object)resourceDTO.City);
            cmd.Parameters.AddWithValue("@p_State", string.IsNullOrEmpty(resourceDTO.State) ? DBNull.Value : (object)resourceDTO.State);
            cmd.Parameters.AddWithValue("@p_Zip", string.IsNullOrEmpty(resourceDTO.Zip) ? DBNull.Value : (object)resourceDTO.Zip);
            cmd.Parameters.AddWithValue("@p_Phone", string.IsNullOrEmpty(resourceDTO.Phone) ? DBNull.Value : (object)resourceDTO.Phone);
            cmd.Parameters.AddWithValue("@p_Email", string.IsNullOrEmpty(resourceDTO.Email) ? DBNull.Value : (object)resourceDTO.Email);

            cmd.ExecuteNonQuery();
        }
    }

    public IEnumerable<SubscriptionDTO> GetSubscriptionsByOrb(int orbId)
    {
        var subscriptions = new List<SubscriptionDTO>();
        using (var connection = GetConnection())
        {
            connection.Open();
            var cmd = new MySqlCommand("GetSubscriptionsByOrb", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_ORBID", orbId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                subscriptions.Add(new SubscriptionDTO
                {
                    SubscriptionID = reader.GetInt32("SubscriptionID"),
                    ORBId = reader.GetInt32("ORBId"),
                    ResourceID = reader.GetInt32("ResourceID"),
                    SubNeeded = reader.GetBoolean("SubNeeded"),
                    WeSubscribe = reader.GetBoolean("WeSubscribe"),
                    SubTerms = reader.IsDBNull(reader.GetOrdinal("SubTerms")) ? String.Empty : reader.GetString("SubTerms"),
                    SubFee = reader.IsDBNull(reader.GetOrdinal("SubFee")) ? String.Empty : reader.GetString("SubFee")
                });
            }
        }
        return subscriptions;
    }
}
