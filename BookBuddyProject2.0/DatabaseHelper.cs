using System;
using System.Data.SqlClient;

public static class DatabaseHelper
{
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(
            @"Server=(localdb)\MSSQLLocalDB;Database=BookBuddyDB;Trusted_Connection=True;");
    }
}