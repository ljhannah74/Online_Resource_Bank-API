using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace orb_api.DTO;
public class DbConnection
{
    private string connectionString = "server=localhost;user=lewisjhannah;database=orb_db;password=precious5;";

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}

