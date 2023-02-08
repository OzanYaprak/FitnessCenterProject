using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Antreman.Migrations
{
    /// <inheritdoc />
    public partial class bir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Rolees",
                columns: table => new
                {
                    RoleeID = table.Column<byte>(type: "tinyint", nullable: false),
                    RoleeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolees", x => x.RoleeID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictID);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Userrs",
                columns: table => new
                {
                    UserrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emaill = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Passwordd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleeID = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userrs", x => x.UserrID);
                    table.ForeignKey(
                        name: "FK_Userrs_Rolees_RoleeID",
                        column: x => x.RoleeID,
                        principalTable: "Rolees",
                        principalColumn: "RoleeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessCenters",
                columns: table => new
                {
                    FitnessCenterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessCenterName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DistrictID = table.Column<int>(type: "int", nullable: false),
                    FitnessCenterAdress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCenters", x => x.FitnessCenterID);
                    table.ForeignKey(
                        name: "FK_FitnessCenters_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
                        principalColumn: "DistrictID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessCenterSubCat",
                columns: table => new
                {
                    FitnessCenterSubCatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessCenterID = table.Column<int>(type: "int", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessCenterSubCat", x => x.FitnessCenterSubCatID);
                    table.ForeignKey(
                        name: "FK_FitnessCenterSubCat_FitnessCenters_FitnessCenterID",
                        column: x => x.FitnessCenterID,
                        principalTable: "FitnessCenters",
                        principalColumn: "FitnessCenterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessCenterSubCat_SubCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Günlük Antremanlar" },
                    { 2, "Programlar" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 6, "Ankara" },
                    { 7, "Antalya" },
                    { 16, "Bursa" },
                    { 26, "Eskişehir" },
                    { 27, "Gaziantep" },
                    { 33, "Mersin" },
                    { 34, "İstanbul" },
                    { 35, "İzmir" },
                    { 41, "Kocaeli" },
                    { 48, "Muğla" },
                    { 54, "Sakarya" },
                    { 55, "Samsun" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderID", "GenderName" },
                values: new object[,]
                {
                    { 1, "Kadın" },
                    { 2, "Erkek" }
                });

            migrationBuilder.InsertData(
                table: "Rolees",
                columns: new[] { "RoleeID", "RoleeName" },
                values: new object[,]
                {
                    { (byte)1, "Aday" },
                    { (byte)2, "Uye" },
                    { (byte)3, "Admin" },
                    { (byte)4, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "DistrictID", "CityID", "DistrictName" },
                values: new object[,]
                {
                    { 1, 1, "Seyhan" },
                    { 2, 1, "Yüreğir" },
                    { 3, 6, "Çankaya" },
                    { 4, 6, "Etimesgut" },
                    { 5, 6, "Mamak" },
                    { 6, 6, "Yenimahalle" },
                    { 7, 7, "Kepez" },
                    { 8, 7, "Muratpaşa" },
                    { 9, 16, "Nilüfer" },
                    { 10, 26, "Tepebaşı" },
                    { 11, 27, "Şehitkamil" },
                    { 12, 34, "Ataşehir" },
                    { 13, 34, "Bahçelievler" },
                    { 14, 34, "Bakırköy" },
                    { 15, 34, "Başakşehir" },
                    { 16, 34, "Bayrampaşa" },
                    { 17, 34, "Beşiktaş" },
                    { 18, 34, "Beykoz" },
                    { 19, 34, "Beyoğlu" },
                    { 20, 34, "Esenyurt" },
                    { 21, 34, "Eyüp" },
                    { 22, 34, "Güngören" },
                    { 23, 34, "Kadıköy" },
                    { 24, 34, "Kağıthane" },
                    { 25, 34, "Kartal" },
                    { 26, 34, "Küçükçekmece" },
                    { 27, 34, "Maltepe" },
                    { 28, 34, "Pendik" },
                    { 29, 34, "Sarıyer" },
                    { 30, 34, "Şişli" },
                    { 31, 34, "Sultanbeyli" },
                    { 32, 34, "Sultangazi" },
                    { 33, 34, "Ümraniye" },
                    { 34, 34, "Üsküdar" },
                    { 35, 35, "Balçova" },
                    { 36, 35, "Bornova" },
                    { 37, 35, "Buca" },
                    { 38, 35, "Çiğli" },
                    { 39, 35, "Gaziemir" },
                    { 40, 35, "Konak" },
                    { 41, 41, "Gebze" },
                    { 42, 41, "İzmit" },
                    { 43, 33, "Yenişehir" },
                    { 44, 48, "Bodrum" },
                    { 45, 54, "Sedirvan" },
                    { 46, 55, "Canik" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryID", "CategoryID", "SubCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Kardiyo" },
                    { 2, 1, "Kuvvet" },
                    { 3, 1, "HIIT" },
                    { 4, 1, "Karın" },
                    { 5, 1, "Pilates" },
                    { 6, 1, "Yoga" },
                    { 7, 1, "Esneklik" },
                    { 8, 1, "Dans" },
                    { 9, 1, "Cycle" },
                    { 10, 2, "Kilo Vermek" },
                    { 11, 2, "Kas Kazanmak" },
                    { 12, 2, "Formu Korumak" },
                    { 13, 2, "Dayanıklılığı Arttırmak" }
                });

            migrationBuilder.InsertData(
                table: "Userrs",
                columns: new[] { "UserrID", "Emaill", "Passwordd", "RoleeID" },
                values: new object[,]
                {
                    { 1, "aday@gmail.com", "123456", (byte)1 },
                    { 2, "uye@gmail.com", "123456", (byte)2 },
                    { 3, "uye2@gmail.com", "123456", (byte)2 },
                    { 4, "admin@gmail.com", "123456", (byte)3 },
                    { 5, "supervisor@gmail.com", "123456", (byte)4 }
                });

            migrationBuilder.InsertData(
                table: "FitnessCenters",
                columns: new[] { "FitnessCenterID", "Capacity", "DistrictID", "FitnessCenterAdress", "FitnessCenterName" },
                values: new object[,]
                {
                    { 1, 250, 1, "Ahmet Remzi Yüreğir, Turhan Cemal Beriker Blv. No:1", "01 Burda" },
                    { 2, 200, 2, "Sinanpaşa, Hacı Sabancı Blv. No:28", "Adana Optimum" },
                    { 3, 200, 3, "Prof. Dr. Ahmet Taner Kışlalı, Safranbolu Cd. No:12", "Konutkent" },
                    { 4, 200, 3, "Koru, Ankaralılar Cd. No:2", "Gordion" },
                    { 5, 200, 3, "Eskişehir Yolu Mustafa Kemal Mah. 2123 Sokak No: 2", "Cepa" },
                    { 6, 200, 3, "Oran, Panora Alışveriş ve Yaşam Merkezi, Turan Güneş Blv. No:182 D:2", "Panora" },
                    { 7, 200, 3, "Yapı Kredi Koray, İş Merkezi 8/A", "Tunalı" },
                    { 8, 200, 3, "Birlik Mah. 428.Cad. No:41", "365 AVM" },
                    { 9, 200, 4, "Eryaman, Samsun 19 Mayıs Cd. No:5", "Eryaman" },
                    { 10, 200, 5, "Akşemsettin Mah., Nata Vega Outlet", "Nata Vega" },
                    { 11, 200, 6, "Ankamall AVM Konya Devlet Karayolu Üzeri Akköprü Mevkii", "AnkaMALL" },
                    { 12, 200, 6, "Armada AVM Eskişehir Yolu No: 6", "Armada" },
                    { 13, 200, 6, "Podium AVM Macun Mah. Bağdat Cad. No: 60", "Podium" },
                    { 14, 200, 7, "Erasta AVM Ahatlı Mah., Dumlupınar Blv., Yanyolu No:25", "Erasta" },
                    { 15, 200, 8, "Şirinyalı Mah. İsmet Gökşen Cad. Carrefoursa Avm No:5", "Lara Carrefour" },
                    { 16, 200, 8, "Tahılpazarı Mah. Kazım Özalp Cad. (Şarampol) No:84", "Marka Antalya" },
                    { 17, 200, 9, "Odunluk Mah. Bursa Carrefoursa AVM", "Nilüfer Carrefour" },
                    { 18, 200, 9, "Cumhuriyet Mah. Nilüfer Hatun Cad. No:114", "Podyum Park" },
                    { 19, 200, 10, "Hoşnudiye Mah. İsmet İnönü 1 Cad. No:131 /1C-1D-1E", "Eskişehir" },
                    { 20, 200, 11, "Sankopark AVM 4.Kat", "Sankopark" },
                    { 21, 200, 12, "Küçükbakkalköy Mah., Dudullu Cad. 23-25", "Brandium" },
                    { 22, 200, 12, "Barbaros Mah. Ahlat Sok.", "Watergarden" },
                    { 23, 200, 13, "Bahçelievler Mahallesi, Şair Orhan Veli Sok. No:22", "Ömür Plaza" },
                    { 24, 200, 13, "Yenibosna Koçtaş, Fevzi Çakmak Mah. Yıldırım Beyazıd Cad. No:1", "Yenibosna Koçtaş" },
                    { 25, 200, 14, "Yenimahalle Mah. Yanıkses Sok.Cem Karaca Kültür Merkezi Yanı", "Bakırköy Migros" },
                    { 26, 200, 14, "Flyinn Alışveriş ve Yaşam Merkezi Şenlikköy Mah., Harman Sok. No:48", "Flyinn" },
                    { 27, 200, 15, "Prof. Dr. Necmettin Erbakan Cad. Arterium 2. Kısım A blok", "Başakşehir" },
                    { 28, 200, 15, "Ziya Gökalp, Süleyman Demirel Blv", "Mall Of İstanbul" },
                    { 29, 200, 17, "Sinanpaşa Mah. Şair Nedim Cad. No.20/A", "Akaretler" },
                    { 30, 200, 17, "Kültür Mah. Nispetiye Cad. No:56", "Akmerkez" },
                    { 31, 200, 17, "Ulus, Lotus World No:6, Ambarlıdere Sok.", "Ortaköy Lotus" },
                    { 32, 200, 17, "Zorlu Center, Levazım Mah., Koru Sok. No:2", "Zorlu" },
                    { 33, 200, 18, "Göztepe Mah. Migros AVM, Atatürk Cad.", "Anadolu Hisarı" },
                    { 34, 200, 19, "Hüseyinağa Mah., Atıf Yılmaz Cad. No:5", "İstiklal AVM" },
                    { 35, 200, 20, "Akbatı AVM Sanayi Mah. 1655 Sok.No:6", "Akbatı" },
                    { 36, 200, 20, "Mevlana Mah., Çelebi Mehmet Cad. 33/A", "Marmara Park" },
                    { 37, 200, 20, "Turgut Özal Mah. E-5 Üzeri", "Torium" },
                    { 38, 200, 21, "Topçular Mah. Osman Gazi Cad. No:2", "Axis İstanbul" },
                    { 39, 200, 21, "Biz Cevahir Haliç AVM, Alibeyköy Mah., Vardar Blv. No:11 D:5", "Biz Cevahir" },
                    { 40, 200, 21, "Defterdar Mah., Otakçılar Cad. No:78", "Flat Ofis Haliç" },
                    { 41, 200, 21, "Göktürk Merkez Mah., İstanbul Cad. No:30", "Göktürk" },
                    { 42, 200, 21, "Yeşilpınar Mah. Girne Cad. 34065 Eyüp", "Vialand" },
                    { 43, 200, 22, "Güven Mah., Eski Londra Asfaltı Cad. No:89", "Kale Center" },
                    { 44, 200, 22, "E-5 Yolu Merter Sapağı, 3M Migros Binası, 1. Kat", "Merter" },
                    { 45, 200, 23, "Bağdat Caddesi, Göztepe Mahallesi, Birgen İş Merkezi No:226", "Cadde" },
                    { 46, 200, 23, "Caddebostan, Haldun Taner Sok. No:11", "CKM" },
                    { 47, 200, 23, "Tütüncü Mehmet Efendi Cad. Göztepe Loft Plaza, Kat:2-3", "Göztepe BX" },
                    { 48, 200, 23, "19 Mayıs Mah. Şemsettin Günaltay Cad. No:166/1", "Kazasker" },
                    { 49, 200, 23, "Kozzy AVM Kozyatağı Mah., Bayar Cad., Buket Sok. No:14", "Kozzy" },
                    { 50, 200, 23, "Suadiye Mah., Plaj Yolu Sok. No:18", "Suadiye" },
                    { 51, 200, 24, "Merkez Mah. Cendere Cad. No:28", "Axis Kağıthane" },
                    { 52, 200, 25, "Kordonboyu Mah., Ankara Cad. No:147", "İST Marina" },
                    { 53, 200, 25, "Petroliş Mah. Üsküdar Cad. No:29", "Kartal" },
                    { 54, 200, 26, "Atakent Mah. Çiçekli Vadi No:1", "Arena Park" },
                    { 55, 200, 27, "Aydınevler Mah., Çamlıca Sitesi Yolu Sok.", "Hilltown" },
                    { 56, 200, 27, "Ofispark, Altayçeşme Mah. E-5 Karayolu Üstü, Çam Sok.", "Maltepe Ofis Park" },
                    { 57, 200, 27, "Cevizli, Tugay Yolu Cd. No:71", "Maltepe Piazza" },
                    { 58, 200, 27, "Ritim İstanbul, Cevizli Mah. Zuhal Cad. Füsun Sokak", "Maltepe Ritim" },
                    { 59, 200, 28, "Çarşı Mah., E-5 Karayolu Tersane Kavşağı Elka Sok. No:9", "Neomarin" },
                    { 60, 200, 29, "42 Maslak Ahi Evran Cad. No:6", "42 Maslak" },
                    { 61, 200, 29, "İstinye Mah., Boğaziçi Sitesi No:2", "İstinye" },
                    { 62, 200, 29, "Uskumruköy Mah. Yorgancı Çiftliği Mevkii", "Orman Ada" },
                    { 63, 200, 29, "Ayazağa Mah., Cendere Cad. 109/C", "Vadi İstanbul" },
                    { 64, 200, 30, "Cumhuriyet Mah., Silahşör Cad., Yeniyol Sok. No:2", "Bomonti" },
                    { 65, 200, 30, "Cevahir AVM 19 Mayıs Mah.,Büyükdere Cad. 136/22", "Cevahir" },
                    { 66, 200, 30, "City’s AVM Teşvikiye Cd. No:12", "City's Nişantaşı" },
                    { 67, 200, 30, "Fulya Mah. Yeşilçimen Sok. Polat Towerside No:12/429", "Fulya" },
                    { 68, 200, 30, "Harbiye Mah, Kadırgalar Cad. No:3", "Gmall" },
                    { 69, 200, 30, "Halaskargazi Cd. No: 38-66", "Nişantaşı Lotus" },
                    { 70, 200, 30, "ÖzdilekPark AVM Büyükdere Cad. No:181", "Özdilek Park" },
                    { 71, 200, 30, "Fulya Mah., Akıncı Bayırı Sok. No:14", "Torun Center" },
                    { 72, 200, 31, "Atlaspark AVM Abdurrahmangazi Mah. Fatih Blv., No:67", "Atlas Park" },
                    { 73, 200, 32, "Yunus Emre Mah., Lütfi Aykaç Blv. No:81", "Vega" },
                    { 74, 200, 33, "İnkılap Mah., Küçüksu Cad.", "Akyaka Park" },
                    { 75, 200, 33, "Buyaka AVM FSM Mah. Balkan Cad. No:56", "Buyaka" },
                    { 76, 200, 33, "Necip Fazıl Mah. Mabeyn Cad. No:3A", "Metro Garden" },
                    { 77, 200, 33, "Atakent Mah., Mithatpaşa Cad. No:116", "Çağla Plaza" },
                    { 78, 200, 34, "Altunizade Mah. Mahir İz Cad. No:9/1B", "Altunizade" },
                    { 79, 200, 34, "Mehmet Akif Ersoy Mah., Bosna Blv. No:99", "Çengelköy Park" },
                    { 80, 200, 34, "Ünalan Mah., Libadiye Cad. No: 82F", "Emaar Square" },
                    { 81, 200, 34, "Mimar Sinan Mah., Çavuşdere Cad. No:35", "Nev Çarsı AVM" },
                    { 82, 200, 35, "İnciraltı, Mithatpaşa Cd. No:46", "Balçova Kipa" },
                    { 83, 200, 36, "Kazım Dirik Mah. 367/6 Sok. No:3/5", "Kids Mall" },
                    { 84, 200, 36, "4174 Sok. No:4 Bağburnu Mevkii", "Point Bornova" },
                    { 85, 200, 37, "Adatepe Mah. 62/7 Sok. No:1", "Buca" },
                    { 86, 200, 38, "Cahar Dudayev Blv., Koçtaş 7/201", "Mavi Şehir Koçtaş" },
                    { 87, 200, 39, "Binbaşı Reşatbey, Akçay Cad. No:101", "Gaziemir Optimum" },
                    { 88, 200, 40, "Çınarlı Mah. Ozan Abay Cad. No:8/309", "Ege Perla" },
                    { 89, 200, 40, "Alsancak Mah., Kıbrıs Şehitleri Cad. No: 131", "Kıbrıs Şehitleri" },
                    { 90, 200, 41, "Tatlıkuyu Mah., Güney Yanyol Cad. No:310", "Gebze Center" },
                    { 91, 200, 42, "Körfez Mah., Ömer Türkçakal Blv.", "41 Burda" },
                    { 92, 200, 43, "Eğriçam Mah., 2224. Sok.", "Örs Plaza" },
                    { 93, 200, 44, "Ortakentyahşi Mah., Cumhuriyet Cad. Kemer Mevkii No:6", "Bodrum Midtown" },
                    { 94, 200, 45, "Agora AVM  Arabacı Alanı Mah. Kasım Paşa Cad. No:10", "Agora" },
                    { 95, 200, 46, "Yenimahalle, Çarşamba Cd. No:52", "Samsun Piazza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityID",
                table: "Districts",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCenters_DistrictID",
                table: "FitnessCenters",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCenterSubCat_FitnessCenterID",
                table: "FitnessCenterSubCat",
                column: "FitnessCenterID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessCenterSubCat_SubCategoryID",
                table: "FitnessCenterSubCat",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryID",
                table: "SubCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Userrs_RoleeID",
                table: "Userrs",
                column: "RoleeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessCenterSubCat");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Userrs");

            migrationBuilder.DropTable(
                name: "FitnessCenters");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Rolees");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
