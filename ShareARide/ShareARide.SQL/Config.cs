namespace ShareARide.SQL;
public static class Config
{
    public static string ConnectionString = @"Server=W-LP-0798;Database=ShareARide;Trusted_Connection=True;";
    public static string updatecarpool = "UPDATE Carpools SET DriverUserID = @driveruserid, RouteStart =@routestart, StartTime =@starttime, RouteEnd = @routeend, EndTime =@endtime, Seats =@seats WHERE CarpoolID =@id";

}