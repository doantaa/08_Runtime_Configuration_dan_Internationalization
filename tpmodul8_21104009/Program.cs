using System;

class Program
{
    static void Main()
    {
        CovidConfig config = CovidConfig.GetInstance();

        // Menampilkan konfigurasi saat ini
        Console.WriteLine("\nKonfigurasi Saat Ini:");
        Console.WriteLine($"Satuan Suhu: {config.SatuanSuhu}");
        Console.WriteLine($"Batas Hari Demam: {config.BatasHariDemam}");
        Console.WriteLine($"Pesan Ditolak: {config.PesanDitolak}");
        Console.WriteLine($"Pesan Diterima: {config.PesanDiterima}");

        // Mengubah konfigurasi satuan suhu
        Console.Write("\nUbah satuan suhu (Celsius/Fahrenheit): ");
        string newSatuanSuhu = Console.ReadLine();
        config.SatuanSuhu = newSatuanSuhu;

        // Simpan perubahan ke file JSON
        config.SaveConfig();
        Console.WriteLine("Konfigurasi telah diperbarui dan disimpan!");

        // Menanyakan suhu badan pengguna
        Console.Write($"\nBerapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhuBadan = Convert.ToDouble(Console.ReadLine());

        // Menanyakan hari terakhir mengalami demam
        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        // Mengevaluasi kondisi
        
        bool suhuNormal = (config.SatuanSuhu.ToLower() == "celsius" && suhuBadan >= 36.5 && suhuBadan <= 37.5) ||
                          (config.SatuanSuhu.ToLower() == "fahrenheit" && suhuBadan >= 97.7 && suhuBadan <= 99.5);

        
        bool hariDemamAman = hariDemam < config.BatasHariDemam;


        // 🏁 Output keputusan
        if (suhuNormal && hariDemamAman)
        {
            Console.WriteLine($"\n{config.PesanDiterima}");
        }
        else
        {
            Console.WriteLine($"\n{config.PesanDitolak}");
        }
    }
}