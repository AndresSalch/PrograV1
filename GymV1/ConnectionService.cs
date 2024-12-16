using Microsoft.Maui.Networking;
using System.Threading.Tasks;

public class ConnectionService
{
    public bool IsConnectedToNetwork()
    {
        return Connectivity.NetworkAccess == NetworkAccess.Internet;
    }

    public bool IsConnectionExpensive()
    {
        return Connectivity.ConnectionProfiles.Contains(ConnectionProfile.Cellular);
    }

    public async Task<string> GetConnectionTypeAsync()
    {
        var profiles = Connectivity.ConnectionProfiles;
        if (profiles.Contains(ConnectionProfile.WiFi))
        {
            return "WiFi";
        }
        else if (profiles.Contains(ConnectionProfile.Cellular))
        {
            return "Cellular";
        }
        else
        {
            return "No Connection";
        }
    }
}
