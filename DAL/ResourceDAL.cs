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
            var cmd = new MySqlCommand("SELECT * FROM State", connection);
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
            var cmd = new MySqlCommand("SELECT * FROM County WHERE StateID = @StateID", connection);
            cmd.Parameters.AddWithValue("@StateID", stateId);
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

}
