namespace RSSI_webAPI.Models;

public class SupervisedDataModel
{
    // Time
    public int Year { get; set; }
    public int Month { get; set; }
    // Satellite
    public double BxGSM { get; set; }
    public double ByGSM { get; set; }
    public double BzGSM { get; set; }
    // Target
    public double Bt { get; set; }
    // Geo-magnetism
    public double Intensity { get; set; }
    public double Declination { get; set; }
    public double Inclination { get; set; }
    public double North { get; set; }
    public double East { get; set; }
    public double Vertical { get; set; }
    public double Horizontal { get; set; }
}
