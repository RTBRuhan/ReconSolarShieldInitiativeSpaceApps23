﻿using Newtonsoft.Json.Linq;
using RSSI_webAPI.Models;
using RSSI_webAPI.Repositories.Contracts;

namespace RSSI_webAPI.Repositories;

public class EarthDataRepository : IEarthDataRepository
{
    private readonly ILogger _log;
    private readonly HttpClient _client;
    public EarthDataRepository(IHttpClientFactory cf, ILogger<SatelliteDataRepository> lg)
    {
        _log = lg;
        _client = cf.CreateClient();
    }
    public async Task<GeoMagnetDataModel?> GetGeoMagneticDataAtLagrangianPointOne()
    {
        GeoMagnetDataModel? data = null;

        double northMagPoleLat = 86.50;
        double northMagPoleLon = 164.04;
        var date = DateTime.UtcNow.AddHours(-6);

        string url = $"http://geomag.bgs.ac.uk/web_service/GMModels/igrf/13/?latitude={northMagPoleLat}&longitude={northMagPoleLon}&altitude=0&date={date.Year}-{date.Month}-{date.Day}&format=json";

        HttpResponseMessage response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            JObject jsonObject = JObject.Parse(responseBody);

            if (jsonObject.TryGetValue("geomagnetic-field-model-result", out JToken geomagneticFieldModelResultToken) && geomagneticFieldModelResultToken is JObject geomagneticFieldModelResult)
            {
                if (geomagneticFieldModelResult.TryGetValue("field-value", out JToken fieldValueToken) && fieldValueToken is JObject fieldValue)
                {
                    var fieldValues = fieldValue.Properties()
                        .Select(p => new object[]
                        {
                        p.Name,
                        p.Value["value"].ToObject<double>()
                        })
                        .ToArray();

                    // Now, fieldValues is a multi-dimensional array with name and value pairs

                    data = new GeoMagnetDataModel 
                    {
                        Intensity = fieldValue["total-intensity"]["value"].ToObject<double>(),
                        Declination = fieldValue["declination"]["value"].ToObject<double>(),
                        Inclination = fieldValue["inclination"]["value"].ToObject<double>(),
                        North = fieldValue["north-intensity"]["value"].ToObject<double>(),
                        East = fieldValue["east-intensity"]["value"].ToObject<double>(),
                        Vertical = fieldValue["vertical-intensity"]["value"].ToObject<double>(),
                        Horizontal = fieldValue["horizontal-intensity"]["value"].ToObject<double>(),
                        Time = date,
                        Latitude = northMagPoleLat,
                        Longitude = northMagPoleLon,
                        Altitude = 0.00
                    };

                }
            }

        }

        return data;
    }
}
