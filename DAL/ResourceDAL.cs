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

    public IEnumerable<ORBDTO> GetOrbsByCounty(int stateID, int countyId)
    {
        var orbs = new List<ORBDTO>();
        using (var connection = GetConnection())
        {
            connection.Open();
            var cmd = new MySqlCommand("GetOrbsByCounty", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_StateID", stateID);
            cmd.Parameters.AddWithValue("@p_CountyID", countyId);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orbs.Add(new ORBDTO
                {
                    StateId = reader.GetInt32("StateID"),
                    CountyId = reader.GetInt32("CountyID"),
                    ORBId = reader.GetInt32("Id"),
                    LastUpdate = reader.GetDateTime("last_update"),
                    CountyHomePage = reader.GetString("county_homepage"),
                    Comments = reader.GetString("comments")
                });
            }
        }
        return orbs;
    }

}
