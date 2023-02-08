using Antreman.Models;
using Microsoft.EntityFrameworkCore;

namespace Antreman.Data
{
    public class antremanDBContext : DbContext
    {
        public antremanDBContext(DbContextOptions<antremanDBContext> options) : base(options)
        {
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<FitnessCenter> FitnessCenters { get; set; }
        public DbSet<FitnessCenterSubCat> FitnessCenterSubCats { get; set; }
        public DbSet<Userr> Userrs { get; set; }
        public DbSet<Rolee> Rolees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rolee>().HasData
                (
                    new Rolee { RoleeID = 1, RoleeName = "Aday" },
                    new Rolee { RoleeID = 2, RoleeName = "Uye" },
                    new Rolee { RoleeID = 3, RoleeName = "Admin" },
                    new Rolee { RoleeID = 4, RoleeName = "Supervisor" }
                );


            modelBuilder.Entity<Userr>().HasData
                (
                    new Userr { UserrID = 1, Emaill = "aday@gmail.com", Passwordd = "123456", RoleeID = 1 },
                    new Userr { UserrID = 2, Emaill = "uye@gmail.com", Passwordd = "123456", RoleeID = 2 },
                    new Userr { UserrID = 3, Emaill = "uye2@gmail.com", Passwordd = "123456", RoleeID = 2 },
                    new Userr { UserrID = 4, Emaill = "admin@gmail.com", Passwordd = "123456", RoleeID = 3 },
                    new Userr { UserrID = 5, Emaill = "supervisor@gmail.com", Passwordd = "123456", RoleeID = 4 }

                );


            modelBuilder.Entity<Gender>().HasData
                (
                   new Gender { GenderID = 1, GenderName = "Kadın" },
                   new Gender { GenderID = 2, GenderName = "Erkek" }
                );


            modelBuilder.Entity<City>().HasData
                (
                   new City { CityID = 1, CityName = "Adana" },
                   new City { CityID = 6, CityName = "Ankara" },
                   new City { CityID = 7, CityName = "Antalya" },
                   new City { CityID = 16, CityName = "Bursa" },
                   new City { CityID = 26, CityName = "Eskişehir" },
                   new City { CityID = 27, CityName = "Gaziantep" },
                   new City { CityID = 34, CityName = "İstanbul" },
                   new City { CityID = 35, CityName = "İzmir" },
                   new City { CityID = 41, CityName = "Kocaeli" },
                   new City { CityID = 33, CityName = "Mersin" },
                   new City { CityID = 48, CityName = "Muğla" },
                   new City { CityID = 54, CityName = "Sakarya" },
                   new City { CityID = 55, CityName = "Samsun" }

                );

            modelBuilder.Entity<District>().HasData
                (
                   new District { CityID = 1, DistrictID = 1, DistrictName = "Seyhan" },
                   new District { CityID = 1, DistrictID = 2, DistrictName = "Yüreğir" },
                   new District { CityID = 6, DistrictID = 3, DistrictName = "Çankaya" },
                   new District { CityID = 6, DistrictID = 4, DistrictName = "Etimesgut" },
                   new District { CityID = 6, DistrictID = 5, DistrictName = "Mamak" },
                   new District { CityID = 6, DistrictID = 6, DistrictName = "Yenimahalle" },
                   new District { CityID = 7, DistrictID = 7, DistrictName = "Kepez" },
                   new District { CityID = 7, DistrictID = 8, DistrictName = "Muratpaşa" },
                   new District { CityID = 16, DistrictID = 9, DistrictName = "Nilüfer" },
                   new District { CityID = 26, DistrictID = 10, DistrictName = "Tepebaşı" },
                   new District { CityID = 27, DistrictID = 11, DistrictName = "Şehitkamil" },
                   new District { CityID = 34, DistrictID = 12, DistrictName = "Ataşehir" },
                   new District { CityID = 34, DistrictID = 13, DistrictName = "Bahçelievler" },
                   new District { CityID = 34, DistrictID = 14, DistrictName = "Bakırköy" },
                   new District { CityID = 34, DistrictID = 15, DistrictName = "Başakşehir" },
                   new District { CityID = 34, DistrictID = 16, DistrictName = "Bayrampaşa" },
                   new District { CityID = 34, DistrictID = 17, DistrictName = "Beşiktaş" },
                   new District { CityID = 34, DistrictID = 18, DistrictName = "Beykoz" },
                   new District { CityID = 34, DistrictID = 19, DistrictName = "Beyoğlu" },
                   new District { CityID = 34, DistrictID = 20, DistrictName = "Esenyurt" },
                   new District { CityID = 34, DistrictID = 21, DistrictName = "Eyüp" },
                   new District { CityID = 34, DistrictID = 22, DistrictName = "Güngören" },
                   new District { CityID = 34, DistrictID = 23, DistrictName = "Kadıköy" },
                   new District { CityID = 34, DistrictID = 24, DistrictName = "Kağıthane" },
                   new District { CityID = 34, DistrictID = 25, DistrictName = "Kartal" },
                   new District { CityID = 34, DistrictID = 26, DistrictName = "Küçükçekmece" },
                   new District { CityID = 34, DistrictID = 27, DistrictName = "Maltepe" },
                   new District { CityID = 34, DistrictID = 28, DistrictName = "Pendik" },
                   new District { CityID = 34, DistrictID = 29, DistrictName = "Sarıyer" },
                   new District { CityID = 34, DistrictID = 30, DistrictName = "Şişli" },
                   new District { CityID = 34, DistrictID = 31, DistrictName = "Sultanbeyli" },
                   new District { CityID = 34, DistrictID = 32, DistrictName = "Sultangazi" },
                   new District { CityID = 34, DistrictID = 33, DistrictName = "Ümraniye" },
                   new District { CityID = 34, DistrictID = 34, DistrictName = "Üsküdar" },
                   new District { CityID = 35, DistrictID = 35, DistrictName = "Balçova" },
                   new District { CityID = 35, DistrictID = 36, DistrictName = "Bornova" },
                   new District { CityID = 35, DistrictID = 37, DistrictName = "Buca" },
                   new District { CityID = 35, DistrictID = 38, DistrictName = "Çiğli" },
                   new District { CityID = 35, DistrictID = 39, DistrictName = "Gaziemir" },
                   new District { CityID = 35, DistrictID = 40, DistrictName = "Konak" },
                   new District { CityID = 41, DistrictID = 41, DistrictName = "Gebze" },
                   new District { CityID = 41, DistrictID = 42, DistrictName = "İzmit" },
                   new District { CityID = 33, DistrictID = 43, DistrictName = "Yenişehir" },
                   new District { CityID = 48, DistrictID = 44, DistrictName = "Bodrum" },
                   new District { CityID = 54, DistrictID = 45, DistrictName = "Sedirvan" },
                   new District { CityID = 55, DistrictID = 46, DistrictName = "Canik" }


                );

            modelBuilder.Entity<FitnessCenter>().HasData
                (
                   new FitnessCenter { FitnessCenterID = 1, FitnessCenterName = "01 Burda", DistrictID = 1, Capacity = 250, FitnessCenterAdress = "Ahmet Remzi Yüreğir, Turhan Cemal Beriker Blv. No:1" },
                   new FitnessCenter { FitnessCenterID = 2, FitnessCenterName = "Adana Optimum", DistrictID = 2, Capacity = 200, FitnessCenterAdress = "Sinanpaşa, Hacı Sabancı Blv. No:28" },
                   new FitnessCenter { FitnessCenterID = 3, FitnessCenterName = "Konutkent", DistrictID = 3, Capacity = 200, FitnessCenterAdress = "Prof. Dr. Ahmet Taner Kışlalı, Safranbolu Cd. No:12" },
                   new FitnessCenter { FitnessCenterID = 4, FitnessCenterName = "Gordion", DistrictID = 3, Capacity = 200, FitnessCenterAdress = "Koru, Ankaralılar Cd. No:2" },
                   new FitnessCenter { FitnessCenterID = 5, FitnessCenterName = "Cepa", DistrictID = 3, Capacity = 200, FitnessCenterAdress = "Eskişehir Yolu Mustafa Kemal Mah. 2123 Sokak No: 2" },
                   new FitnessCenter { FitnessCenterID = 6, FitnessCenterName = "Panora", DistrictID = 3, Capacity = 200, FitnessCenterAdress = "Oran, Panora Alışveriş ve Yaşam Merkezi, Turan Güneş Blv. No:182 D:2" },
                   new FitnessCenter { FitnessCenterID = 7, FitnessCenterName = "Tunalı", DistrictID = 3, Capacity = 200, FitnessCenterAdress = "Yapı Kredi Koray, İş Merkezi 8/A" },
                   new FitnessCenter { FitnessCenterID = 8, FitnessCenterName = "365 AVM", DistrictID = 3, Capacity = 200, FitnessCenterAdress = "Birlik Mah. 428.Cad. No:41" },
                   new FitnessCenter { FitnessCenterID = 9, FitnessCenterName = "Eryaman", DistrictID = 4, Capacity = 200, FitnessCenterAdress = "Eryaman, Samsun 19 Mayıs Cd. No:5" },
                   new FitnessCenter { FitnessCenterID = 10, FitnessCenterName = "Nata Vega", DistrictID = 5, Capacity = 200, FitnessCenterAdress = "Akşemsettin Mah., Nata Vega Outlet" },
                   new FitnessCenter { FitnessCenterID = 11, FitnessCenterName = "AnkaMALL", DistrictID = 6, Capacity = 200, FitnessCenterAdress = "Ankamall AVM Konya Devlet Karayolu Üzeri Akköprü Mevkii" },
                   new FitnessCenter { FitnessCenterID = 12, FitnessCenterName = "Armada", DistrictID = 6, Capacity = 200, FitnessCenterAdress = "Armada AVM Eskişehir Yolu No: 6" },
                   new FitnessCenter { FitnessCenterID = 13, FitnessCenterName = "Podium", DistrictID = 6, Capacity = 200, FitnessCenterAdress = "Podium AVM Macun Mah. Bağdat Cad. No: 60" },
                   new FitnessCenter { FitnessCenterID = 14, FitnessCenterName = "Erasta", DistrictID = 7, Capacity = 200, FitnessCenterAdress = "Erasta AVM Ahatlı Mah., Dumlupınar Blv., Yanyolu No:25" },
                   new FitnessCenter { FitnessCenterID = 15, FitnessCenterName = "Lara Carrefour", DistrictID = 8, Capacity = 200, FitnessCenterAdress = "Şirinyalı Mah. İsmet Gökşen Cad. Carrefoursa Avm No:5" },
                   new FitnessCenter { FitnessCenterID = 16, FitnessCenterName = "Marka Antalya", DistrictID = 8, Capacity = 200, FitnessCenterAdress = "Tahılpazarı Mah. Kazım Özalp Cad. (Şarampol) No:84" },
                   new FitnessCenter { FitnessCenterID = 17, FitnessCenterName = "Nilüfer Carrefour", DistrictID = 9, Capacity = 200, FitnessCenterAdress = "Odunluk Mah. Bursa Carrefoursa AVM" },
                   new FitnessCenter { FitnessCenterID = 18, FitnessCenterName = "Podyum Park", DistrictID = 9, Capacity = 200, FitnessCenterAdress = "Cumhuriyet Mah. Nilüfer Hatun Cad. No:114" },
                   new FitnessCenter { FitnessCenterID = 19, FitnessCenterName = "Eskişehir", DistrictID = 10, Capacity = 200, FitnessCenterAdress = "Hoşnudiye Mah. İsmet İnönü 1 Cad. No:131 /1C-1D-1E" },
                   new FitnessCenter { FitnessCenterID = 20, FitnessCenterName = "Sankopark", DistrictID = 11, Capacity = 200, FitnessCenterAdress = "Sankopark AVM 4.Kat" },
                   new FitnessCenter { FitnessCenterID = 21, FitnessCenterName = "Brandium", DistrictID = 12, Capacity = 200, FitnessCenterAdress = "Küçükbakkalköy Mah., Dudullu Cad. 23-25" },
                   new FitnessCenter { FitnessCenterID = 22, FitnessCenterName = "Watergarden", DistrictID = 12, Capacity = 200, FitnessCenterAdress = "Barbaros Mah. Ahlat Sok." },
                   new FitnessCenter { FitnessCenterID = 23, FitnessCenterName = "Ömür Plaza", DistrictID = 13, Capacity = 200, FitnessCenterAdress = "Bahçelievler Mahallesi, Şair Orhan Veli Sok. No:22" },
                   new FitnessCenter { FitnessCenterID = 24, FitnessCenterName = "Yenibosna Koçtaş", DistrictID = 13, Capacity = 200, FitnessCenterAdress = "Yenibosna Koçtaş, Fevzi Çakmak Mah. Yıldırım Beyazıd Cad. No:1" },
                   new FitnessCenter { FitnessCenterID = 25, FitnessCenterName = "Bakırköy Migros", DistrictID = 14, Capacity = 200, FitnessCenterAdress = "Yenimahalle Mah. Yanıkses Sok.Cem Karaca Kültür Merkezi Yanı" },
                   new FitnessCenter { FitnessCenterID = 26, FitnessCenterName = "Flyinn", DistrictID = 14, Capacity = 200, FitnessCenterAdress = "Flyinn Alışveriş ve Yaşam Merkezi Şenlikköy Mah., Harman Sok. No:48" },
                   new FitnessCenter { FitnessCenterID = 27, FitnessCenterName = "Başakşehir", DistrictID = 15, Capacity = 200, FitnessCenterAdress = "Prof. Dr. Necmettin Erbakan Cad. Arterium 2. Kısım A blok" },
                   new FitnessCenter { FitnessCenterID = 28, FitnessCenterName = "Mall Of İstanbul", DistrictID = 15, Capacity = 200, FitnessCenterAdress = "Ziya Gökalp, Süleyman Demirel Blv" },
                   new FitnessCenter { FitnessCenterID = 29, FitnessCenterName = "Akaretler", DistrictID = 17, Capacity = 200, FitnessCenterAdress = "Sinanpaşa Mah. Şair Nedim Cad. No.20/A" },
                   new FitnessCenter { FitnessCenterID = 30, FitnessCenterName = "Akmerkez", DistrictID = 17, Capacity = 200, FitnessCenterAdress = "Kültür Mah. Nispetiye Cad. No:56" },
                   new FitnessCenter { FitnessCenterID = 31, FitnessCenterName = "Ortaköy Lotus", DistrictID = 17, Capacity = 200, FitnessCenterAdress = "Ulus, Lotus World No:6, Ambarlıdere Sok." },
                   new FitnessCenter { FitnessCenterID = 32, FitnessCenterName = "Zorlu", DistrictID = 17, Capacity = 200, FitnessCenterAdress = "Zorlu Center, Levazım Mah., Koru Sok. No:2" },
                   new FitnessCenter { FitnessCenterID = 33, FitnessCenterName = "Anadolu Hisarı", DistrictID = 18, Capacity = 200, FitnessCenterAdress = "Göztepe Mah. Migros AVM, Atatürk Cad." },
                   new FitnessCenter { FitnessCenterID = 34, FitnessCenterName = "İstiklal AVM", DistrictID = 19, Capacity = 200, FitnessCenterAdress = "Hüseyinağa Mah., Atıf Yılmaz Cad. No:5" },
                   new FitnessCenter { FitnessCenterID = 35, FitnessCenterName = "Akbatı", DistrictID = 20, Capacity = 200, FitnessCenterAdress = "Akbatı AVM Sanayi Mah. 1655 Sok.No:6" },
                   new FitnessCenter { FitnessCenterID = 36, FitnessCenterName = "Marmara Park", DistrictID = 20, Capacity = 200, FitnessCenterAdress = "Mevlana Mah., Çelebi Mehmet Cad. 33/A" },
                   new FitnessCenter { FitnessCenterID = 37, FitnessCenterName = "Torium", DistrictID = 20, Capacity = 200, FitnessCenterAdress = "Turgut Özal Mah. E-5 Üzeri" },
                   new FitnessCenter { FitnessCenterID = 38, FitnessCenterName = "Axis İstanbul", DistrictID = 21, Capacity = 200, FitnessCenterAdress = "Topçular Mah. Osman Gazi Cad. No:2" },
                   new FitnessCenter { FitnessCenterID = 39, FitnessCenterName = "Biz Cevahir", DistrictID = 21, Capacity = 200, FitnessCenterAdress = "Biz Cevahir Haliç AVM, Alibeyköy Mah., Vardar Blv. No:11 D:5" },
                   new FitnessCenter { FitnessCenterID = 40, FitnessCenterName = "Flat Ofis Haliç", DistrictID = 21, Capacity = 200, FitnessCenterAdress = "Defterdar Mah., Otakçılar Cad. No:78" },
                   new FitnessCenter { FitnessCenterID = 41, FitnessCenterName = "Göktürk", DistrictID = 21, Capacity = 200, FitnessCenterAdress = "Göktürk Merkez Mah., İstanbul Cad. No:30" },
                   new FitnessCenter { FitnessCenterID = 42, FitnessCenterName = "Vialand", DistrictID = 21, Capacity = 200, FitnessCenterAdress = "Yeşilpınar Mah. Girne Cad. 34065 Eyüp" },
                   new FitnessCenter { FitnessCenterID = 43, FitnessCenterName = "Kale Center", DistrictID = 22, Capacity = 200, FitnessCenterAdress = "Güven Mah., Eski Londra Asfaltı Cad. No:89" },
                   new FitnessCenter { FitnessCenterID = 44, FitnessCenterName = "Merter", DistrictID = 22, Capacity = 200, FitnessCenterAdress = "E-5 Yolu Merter Sapağı, 3M Migros Binası, 1. Kat" },
                   new FitnessCenter { FitnessCenterID = 45, FitnessCenterName = "Cadde", DistrictID = 23, Capacity = 200, FitnessCenterAdress = "Bağdat Caddesi, Göztepe Mahallesi, Birgen İş Merkezi No:226" },
                   new FitnessCenter { FitnessCenterID = 46, FitnessCenterName = "CKM", DistrictID = 23, Capacity = 200, FitnessCenterAdress = "Caddebostan, Haldun Taner Sok. No:11" },
                   new FitnessCenter { FitnessCenterID = 47, FitnessCenterName = "Göztepe BX", DistrictID = 23, Capacity = 200, FitnessCenterAdress = "Tütüncü Mehmet Efendi Cad. Göztepe Loft Plaza, Kat:2-3" },
                   new FitnessCenter { FitnessCenterID = 48, FitnessCenterName = "Kazasker", DistrictID = 23, Capacity = 200, FitnessCenterAdress = "19 Mayıs Mah. Şemsettin Günaltay Cad. No:166/1" },
                   new FitnessCenter { FitnessCenterID = 49, FitnessCenterName = "Kozzy", DistrictID = 23, Capacity = 200, FitnessCenterAdress = "Kozzy AVM Kozyatağı Mah., Bayar Cad., Buket Sok. No:14" },
                   new FitnessCenter { FitnessCenterID = 50, FitnessCenterName = "Suadiye", DistrictID = 23, Capacity = 200, FitnessCenterAdress = "Suadiye Mah., Plaj Yolu Sok. No:18" },
                   new FitnessCenter { FitnessCenterID = 51, FitnessCenterName = "Axis Kağıthane", DistrictID = 24, Capacity = 200, FitnessCenterAdress = "Merkez Mah. Cendere Cad. No:28" },
                   new FitnessCenter { FitnessCenterID = 52, FitnessCenterName = "İST Marina", DistrictID = 25, Capacity = 200, FitnessCenterAdress = "Kordonboyu Mah., Ankara Cad. No:147" },
                   new FitnessCenter { FitnessCenterID = 53, FitnessCenterName = "Kartal", DistrictID = 25, Capacity = 200, FitnessCenterAdress = "Petroliş Mah. Üsküdar Cad. No:29" },
                   new FitnessCenter { FitnessCenterID = 54, FitnessCenterName = "Arena Park", DistrictID = 26, Capacity = 200, FitnessCenterAdress = "Atakent Mah. Çiçekli Vadi No:1" },
                   new FitnessCenter { FitnessCenterID = 55, FitnessCenterName = "Hilltown", DistrictID = 27, Capacity = 200, FitnessCenterAdress = "Aydınevler Mah., Çamlıca Sitesi Yolu Sok." },
                   new FitnessCenter { FitnessCenterID = 56, FitnessCenterName = "Maltepe Ofis Park", DistrictID = 27, Capacity = 200, FitnessCenterAdress = "Ofispark, Altayçeşme Mah. E-5 Karayolu Üstü, Çam Sok." },
                   new FitnessCenter { FitnessCenterID = 57, FitnessCenterName = "Maltepe Piazza", DistrictID = 27, Capacity = 200, FitnessCenterAdress = "Cevizli, Tugay Yolu Cd. No:71" },
                   new FitnessCenter { FitnessCenterID = 58, FitnessCenterName = "Maltepe Ritim", DistrictID = 27, Capacity = 200, FitnessCenterAdress = "Ritim İstanbul, Cevizli Mah. Zuhal Cad. Füsun Sokak" },
                   new FitnessCenter { FitnessCenterID = 59, FitnessCenterName = "Neomarin", DistrictID = 28, Capacity = 200, FitnessCenterAdress = "Çarşı Mah., E-5 Karayolu Tersane Kavşağı Elka Sok. No:9" },
                   new FitnessCenter { FitnessCenterID = 60, FitnessCenterName = "42 Maslak", DistrictID = 29, Capacity = 200, FitnessCenterAdress = "42 Maslak Ahi Evran Cad. No:6" },
                   new FitnessCenter { FitnessCenterID = 61, FitnessCenterName = "İstinye", DistrictID = 29, Capacity = 200, FitnessCenterAdress = "İstinye Mah., Boğaziçi Sitesi No:2" },
                   new FitnessCenter { FitnessCenterID = 62, FitnessCenterName = "Orman Ada", DistrictID = 29, Capacity = 200, FitnessCenterAdress = "Uskumruköy Mah. Yorgancı Çiftliği Mevkii" },
                   new FitnessCenter { FitnessCenterID = 63, FitnessCenterName = "Vadi İstanbul", DistrictID = 29, Capacity = 200, FitnessCenterAdress = "Ayazağa Mah., Cendere Cad. 109/C" },
                   new FitnessCenter { FitnessCenterID = 64, FitnessCenterName = "Bomonti", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "Cumhuriyet Mah., Silahşör Cad., Yeniyol Sok. No:2" },
                   new FitnessCenter { FitnessCenterID = 65, FitnessCenterName = "Cevahir", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "Cevahir AVM 19 Mayıs Mah.,Büyükdere Cad. 136/22" },
                   new FitnessCenter { FitnessCenterID = 66, FitnessCenterName = "City's Nişantaşı", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "City’s AVM Teşvikiye Cd. No:12" },
                   new FitnessCenter { FitnessCenterID = 67, FitnessCenterName = "Fulya", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "Fulya Mah. Yeşilçimen Sok. Polat Towerside No:12/429" },
                   new FitnessCenter { FitnessCenterID = 68, FitnessCenterName = "Gmall", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "Harbiye Mah, Kadırgalar Cad. No:3" },
                   new FitnessCenter { FitnessCenterID = 69, FitnessCenterName = "Nişantaşı Lotus", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "Halaskargazi Cd. No: 38-66" },
                   new FitnessCenter { FitnessCenterID = 70, FitnessCenterName = "Özdilek Park", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "ÖzdilekPark AVM Büyükdere Cad. No:181" },
                   new FitnessCenter { FitnessCenterID = 71, FitnessCenterName = "Torun Center", DistrictID = 30, Capacity = 200, FitnessCenterAdress = "Fulya Mah., Akıncı Bayırı Sok. No:14" },
                   new FitnessCenter { FitnessCenterID = 72, FitnessCenterName = "Atlas Park", DistrictID = 31, Capacity = 200, FitnessCenterAdress = "Atlaspark AVM Abdurrahmangazi Mah. Fatih Blv., No:67" },
                   new FitnessCenter { FitnessCenterID = 73, FitnessCenterName = "Vega", DistrictID = 32, Capacity = 200, FitnessCenterAdress = "Yunus Emre Mah., Lütfi Aykaç Blv. No:81" },
                   new FitnessCenter { FitnessCenterID = 74, FitnessCenterName = "Akyaka Park", DistrictID = 33, Capacity = 200, FitnessCenterAdress = "İnkılap Mah., Küçüksu Cad." },
                   new FitnessCenter { FitnessCenterID = 75, FitnessCenterName = "Buyaka", DistrictID = 33, Capacity = 200, FitnessCenterAdress = "Buyaka AVM FSM Mah. Balkan Cad. No:56" },
                   new FitnessCenter { FitnessCenterID = 76, FitnessCenterName = "Metro Garden", DistrictID = 33, Capacity = 200, FitnessCenterAdress = "Necip Fazıl Mah. Mabeyn Cad. No:3A" },
                   new FitnessCenter { FitnessCenterID = 77, FitnessCenterName = "Çağla Plaza", DistrictID = 33, Capacity = 200, FitnessCenterAdress = "Atakent Mah., Mithatpaşa Cad. No:116" },
                   new FitnessCenter { FitnessCenterID = 78, FitnessCenterName = "Altunizade", DistrictID = 34, Capacity = 200, FitnessCenterAdress = "Altunizade Mah. Mahir İz Cad. No:9/1B" },
                   new FitnessCenter { FitnessCenterID = 79, FitnessCenterName = "Çengelköy Park", DistrictID = 34, Capacity = 200, FitnessCenterAdress = "Mehmet Akif Ersoy Mah., Bosna Blv. No:99" },
                   new FitnessCenter { FitnessCenterID = 80, FitnessCenterName = "Emaar Square", DistrictID = 34, Capacity = 200, FitnessCenterAdress = "Ünalan Mah., Libadiye Cad. No: 82F" },
                   new FitnessCenter { FitnessCenterID = 81, FitnessCenterName = "Nev Çarsı AVM", DistrictID = 34, Capacity = 200, FitnessCenterAdress = "Mimar Sinan Mah., Çavuşdere Cad. No:35" },
                   new FitnessCenter { FitnessCenterID = 82, FitnessCenterName = "Balçova Kipa", DistrictID = 35, Capacity = 200, FitnessCenterAdress = "İnciraltı, Mithatpaşa Cd. No:46" },
                   new FitnessCenter { FitnessCenterID = 83, FitnessCenterName = "Kids Mall", DistrictID = 36, Capacity = 200, FitnessCenterAdress = "Kazım Dirik Mah. 367/6 Sok. No:3/5" },
                   new FitnessCenter { FitnessCenterID = 84, FitnessCenterName = "Point Bornova", DistrictID = 36, Capacity = 200, FitnessCenterAdress = "4174 Sok. No:4 Bağburnu Mevkii" },
                   new FitnessCenter { FitnessCenterID = 85, FitnessCenterName = "Buca", DistrictID = 37, Capacity = 200, FitnessCenterAdress = "Adatepe Mah. 62/7 Sok. No:1" },
                   new FitnessCenter { FitnessCenterID = 86, FitnessCenterName = "Mavi Şehir Koçtaş", DistrictID = 38, Capacity = 200, FitnessCenterAdress = "Cahar Dudayev Blv., Koçtaş 7/201" },
                   new FitnessCenter { FitnessCenterID = 87, FitnessCenterName = "Gaziemir Optimum", DistrictID = 39, Capacity = 200, FitnessCenterAdress = "Binbaşı Reşatbey, Akçay Cad. No:101" },
                   new FitnessCenter { FitnessCenterID = 88, FitnessCenterName = "Ege Perla", DistrictID = 40, Capacity = 200, FitnessCenterAdress = "Çınarlı Mah. Ozan Abay Cad. No:8/309" },
                   new FitnessCenter { FitnessCenterID = 89, FitnessCenterName = "Kıbrıs Şehitleri", DistrictID = 40, Capacity = 200, FitnessCenterAdress = "Alsancak Mah., Kıbrıs Şehitleri Cad. No: 131" },
                   new FitnessCenter { FitnessCenterID = 90, FitnessCenterName = "Gebze Center", DistrictID = 41, Capacity = 200, FitnessCenterAdress = "Tatlıkuyu Mah., Güney Yanyol Cad. No:310" },
                   new FitnessCenter { FitnessCenterID = 91, FitnessCenterName = "41 Burda", DistrictID = 42, Capacity = 200, FitnessCenterAdress = "Körfez Mah., Ömer Türkçakal Blv." },
                   new FitnessCenter { FitnessCenterID = 92, FitnessCenterName = "Örs Plaza", DistrictID = 43, Capacity = 200, FitnessCenterAdress = "Eğriçam Mah., 2224. Sok." },
                   new FitnessCenter { FitnessCenterID = 93, FitnessCenterName = "Bodrum Midtown", DistrictID = 44, Capacity = 200, FitnessCenterAdress = "Ortakentyahşi Mah., Cumhuriyet Cad. Kemer Mevkii No:6" },
                   new FitnessCenter { FitnessCenterID = 94, FitnessCenterName = "Agora", DistrictID = 45, Capacity = 200, FitnessCenterAdress = "Agora AVM  Arabacı Alanı Mah. Kasım Paşa Cad. No:10" },
                   new FitnessCenter { FitnessCenterID = 95, FitnessCenterName = "Samsun Piazza", DistrictID = 46, Capacity = 200, FitnessCenterAdress = "Yenimahalle, Çarşamba Cd. No:52" }

                );

            modelBuilder.Entity<Category>().HasData
                (
                   new Category { CategoryID = 1, CategoryName = "Günlük Antremanlar" },
                   new Category { CategoryID = 2, CategoryName = "Programlar" }

                );


            modelBuilder.Entity<SubCategory>().HasData
                (
                   new SubCategory { CategoryID = 1, SubCategoryID = 1, SubCategoryName = "Kardiyo" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 2, SubCategoryName = "Kuvvet" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 3, SubCategoryName = "HIIT" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 4, SubCategoryName = "Karın" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 5, SubCategoryName = "Pilates" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 6, SubCategoryName = "Yoga" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 7, SubCategoryName = "Esneklik" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 8, SubCategoryName = "Dans" },
                   new SubCategory { CategoryID = 1, SubCategoryID = 9, SubCategoryName = "Cycle" },

                   new SubCategory { CategoryID = 2, SubCategoryID = 10, SubCategoryName = "Kilo Vermek" },
                   new SubCategory { CategoryID = 2, SubCategoryID = 11, SubCategoryName = "Kas Kazanmak" },
                   new SubCategory { CategoryID = 2, SubCategoryID = 12, SubCategoryName = "Formu Korumak" },
                   new SubCategory { CategoryID = 2, SubCategoryID = 13, SubCategoryName = "Dayanıklılığı Arttırmak" }


                );
        }

        public DbSet<Antreman.Models.FitnessCenterSubCat> FitnessCenterSubCat { get; set; }














    }
}
