using RSSI_webAPI.Models;
using RSSI_webAPI.Repositories.Contracts;

namespace RSSI_webAPI.Repositories;

public class EarthDataRepository : IEarthDataRepository
{
    public Task<GeoMagnetDataModel> GetGeoMagneticDataAtLagrangianPointOne()
    {
        throw new NotImplementedException();
    }
}
