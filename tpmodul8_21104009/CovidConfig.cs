using Newtonsoft.Json;

public class CovidConfig
{
    private static CovidConfig instance;
    private static readonly string configPath = "/Users/doanta/Documents/Dev/KPL/KPL_DOANTA-ALOYCIUS-GINTING_21104009_SE-06-01/08_Runtime_Configuration_dan_Internationalization/tpmodul8_21104009/covid_config.json";

    public string SatuanSuhu { get; set; }
    public int BatasHariDemam { get; set; }
    public string PesanDitolak { get; set; }
    public string PesanDiterima { get; set; }

    // Private constructor untuk Singleton
    private CovidConfig() { }

    // Menggunakan Singleton untuk memastikan hanya satu instance
    public static CovidConfig GetInstance()
    {
        if (instance == null)
        {
            instance = LoadConfig();
        }
        return instance;
    }

    // Memuat konfigurasi dari file JSON
    private static CovidConfig LoadConfig()
    {
        if (!File.Exists(configPath))
        {
            Console.WriteLine("File konfigurasi tidak ditemukan. Membuat konfigurasi default...");
            var defaultConfig = new CovidConfig
            {
                SatuanSuhu = "Celsius",
                BatasHariDemam = 3,
                PesanDitolak = "Akses ditolak. Silakan periksa kesehatan Anda.",
                PesanDiterima = "Akses diterima. Tetap jaga kesehatan!"
            };
            defaultConfig.SaveConfig();
            return defaultConfig;
        }

        string json = File.ReadAllText(configPath);
        return JsonConvert.DeserializeObject<CovidConfig>(json);
    }

    // Menyimpan konfigurasi ke file JSON
    public void SaveConfig()
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(configPath, json);
    }
}