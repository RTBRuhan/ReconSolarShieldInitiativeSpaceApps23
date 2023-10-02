﻿using Newtonsoft.Json;
using RSSI_webAPI.Models;
using RSSI_webAPI.Repositories.Contracts;

namespace RSSI_webAPI.Repositories;

public class SatelliteDataRepository : ISatelliteDataRepository
{
    private readonly HttpClient _client;
    
    public SatelliteDataRepository(IHttpClientFactory cf)
    {
        _client = cf.CreateClient();
    }

    public async Task<SatelliteDataModel> GetDscovrRealtimeData()
    {
        SatelliteDataModel model = new();

        string url = @"https://services.swpc.noaa.gov/products/solar-wind/mag-5-minute.json";

        HttpResponseMessage response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            var solarWindData = JsonConvert.DeserializeObject<object[][]>(responseBody);

            var len = solarWindData.Length;
            model = new SatelliteDataModel
            {
                Time = DateTime.Parse(solarWindData[len-1][0].ToString()).AddHours(6),
                Bt = Convert.ToDouble(solarWindData[len-1][6]),
                BxGSM = Convert.ToDouble(solarWindData[len][1]),
                ByGSM = Convert.ToDouble(solarWindData[len][2]),
                BzGSM = Convert.ToDouble(solarWindData[len][3]),
            };

        }

        return model;
    }

    public async Task<SatelliteDataModel> GetAceRealtimeData()
    {
        SatelliteDataModel model = new();

        string url = @"https://services.swpc.noaa.gov/text/ace-magnetometer.txt";

        HttpResponseMessage response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            string[] lines = responseBody.Split('\n');

            string line = lines[lines.Length-2].Trim();

            string[] fields = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (fields.Length == 13)
            {
                int year = int.Parse(fields[0]);
                int month = int.Parse(fields[1]);
                int day = int.Parse(fields[2]);
                // Extract hours from HHMM
                int hour = int.Parse(fields[3].Substring(0, 2));
                // Extract minutes from HHMM
                int minute = int.Parse(fields[3].Substring(2, 2));
                double bx = double.Parse(fields[7]);
                double by = double.Parse(fields[8]);
                double bz = double.Parse(fields[9]);
                double bt = double.Parse(fields[10]);

                model = new SatelliteDataModel
                {
                    Time = new DateTime(year, month, day, hour, minute, 0, DateTimeKind.Utc)
                    .AddHours(6),
                    Bt = bt,
                    BxGSM = bx,
                    ByGSM = by,
                    BzGSM = bz
                };
            }
        }
        return model;
    }

}
