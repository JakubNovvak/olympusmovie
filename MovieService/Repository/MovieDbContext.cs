﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MovieService.ApiModel.Movies;
using MovieService.ApiModel.Seasons;
using MovieService.Model;
using MovieService.Service.Movies;
using MovieService.Service.Seasons;
using System.Text.Json;

namespace MovieService.Repository
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Episode> Episodes { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Season> Seasons { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<ParticipantMovie> ParticipantsOfMovies { get; set; } = null!;
        public DbSet<ParticipantSeason> ParticipantsOfSeasons { get; set; } = null!;

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>();
            if (databaseCreator != null)
            {
                databaseCreator.EnsureCreated();
                if (Movies.Count() == 0)
                {
                    List<Movie> movies = GetMoviesFromJson().Select(movie => new Movie
                    {
                        Id = movie.Id,
                        Title = movie.Title,
                        Description = movie.Description,
                        ReleaseDate = new DateTime(movie.ReleaseDate.Year, movie.ReleaseDate.Month, movie.ReleaseDate.Day),
                        DurationInMinutes = movie.DurationInMinutes,
                        Cover = movie.Cover,
                        BackgroundImage = movie.BackgroundImage,
                        Thumbnail = movie.Thumbnail,
                        Trailer = movie.Trailer
                    }).ToList();
                    Movies.AddRange(movies);
                    SaveChanges();
                }
                if (Seasons.Count() == 0)
                {
                    List<Season> seasons = GetSeriesFromJson().Select(season => new Season
                    {
                        Id = season.Id,
                        Title = season.Title,
                        Description = season.Description,
                        ReleaseDate = new DateTime(season.ReleaseDate.Year, season.ReleaseDate.Month, season.ReleaseDate.Day),
                        Number = season.Number,
                        Cover = season.Cover,
                        BackgroundImage = season.BackgroundImage,
                        Thumbnail = season.Thumbnail,
                        Trailer = season.Trailer,
                    }).ToList();
                    Seasons.AddRange(seasons);
                    SaveChanges();
                }
            }
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            optionBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipantMovie>().HasKey(entity => new
            {
                entity.PersonId,
                entity.MovieId,
                entity.RoleId
            });
            modelBuilder.Entity<ParticipantSeason>().HasKey(entity => new
            {
                entity.PersonId,
                entity.SeasonId,
                entity.RoleId
            });
        }

        private List<MovieCreateEditDTO> GetMoviesFromJson()
        {

            string json = "[ { \"Id\": 0, \"Title\": \"Avatar: Istota Wody\", \"Description\": \"Pandorę znów napada wroga korporacja w poszukiwaniu cennych minerałów. Jack i Neytiri wraz z rodziną zmuszeni są opuścić wioskę i szukać pomocy u innych plemion zamieszkujących planetę.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 12, \"Day\": 16 }, \"DurationInMinutes\": 192, \"Cover\": \"https://fwcdn.pl/fpo/81/78/558178/8040495.6.jpg\", \"BackgroundImage\": \"https://lumiere-a.akamaihd.net/v1/images/image_1fbb2748.jpeg\", \"Thumbnail\": \"https://i.ytimg.com/vi/Kon7tUHWxxo/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLCFXFdsmOd7N9AgT_1MDRf-fMJEFg\", \"Trailer\": \"https://www.youtube.com/watch?v=Kon7tUHWxxo&t=1s\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Enola Holmes 2\", \"Description\": \"Po rozwiązaniu pierwszej sprawy Enola Homes (Millie Bobby Brown) Idzie w ślady swojego słynnego brata Sherlocka (Henry Cavill) i otwiera własną agencję... by szybko przekonać się, że życie kobiety detektywa to nie bułka z masłem. Akceptując surowe realia dorosłości, postanawia zamknąć swój biznes, gdy nagle zjawia się sprzedawczyni zapałek bez grosza przy duszy i daje jej pierwsze zlecenie z prawdziwego zdarzenia.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 11, \"Day\": 7 }, \"durationInMinutes\": 122, \"Cover\": \"https://fwcdn.pl/fpo/94/07/839407/7929519.6.jpg\", \"BackgroundImage\": \"https://www.kawerna.pl/wp-content/uploads/2022/08/enolaholmes2-e1665606419846.jpeg\", \"Thumbnail\": \"https://i.ytimg.com/vi/N5yZwbQWO6c/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLBd3tdHHaKVCWqDOWnzXLEuqlfdjQ\", \"Trailer\": \"https://www.youtube.com/watch?v=N5yZwbQWO6c&t=1s\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Nitram\", \"Description\": \"Hipnotyczny thriller psychologiczny z fenomenalną rolą nagrodzonego w Cannes Caleba Landry’ego Jonesa. Film inspirowany życiem Martina Bryanta, sprawcy największej masowej strzelaniny w historii Australii w 1996 roku. Nitram to pogłębiona próba zrozumienia, co sprawiło, że przeciętny, nieco oderwany od rzeczywistości chłopak wkroczył na ścieżkę zbrodni.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 12, \"Day\": 2 }, \"durationInMinutes\": 110, \"Cover\": \"https://fwcdn.pl/fpo/55/08/875508/8040669.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/fph/55/08/875508/1116001_1.1.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/IkrMMSo5kTw/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLDvJhqnIhIvOz2YUSFgU5peQoQfjA\", \"Trailer\": \"https://www.youtube.com/watch?v=IkrMMSo5kTw\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Piękny Poranek\", \"Description\": \"Sandra, młoda samotna matka, regularnie odwiedza swojego chorego ojca. Razem z rodziną walczy, by zapewnić mu odpowiednią opiekę. W tym samym czasie ponownie nawiązuje kontakt z Clémentem, dawno nie wIdzianym przyjacielem. Choć mężczyzna nie jest wolny, zaczynają namiętny romans...\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 12, \"Day\": 9 }, \"durationInMinutes\": 112, \"Cover\": \"https://fwcdn.pl/fpo/20/02/10012002/8042476.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/fph/20/02/10012002/1097303_1.1.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/gptkzQ8t_CU/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLCnaxbRJ5qVmG1o6aiu4RGF41Ffkg\", \"Trailer\": \"https://www.youtube.com/watch?v=gptkzQ8t_CU&t=1s\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Pięć diabłów\", \"Description\": \"Vicky to samotna dziewczynka mieszkająca w sennym, górskim miasteczku. Jest obdarzona osobliwym talentem: potrafi chwytać i odtwarzać wszystkie możliwe zapachy, które zbiera kolejno w starannie oznakowanych słoiczkach. Wśród nich szczególne miejsce zajmują te poświęcone zapachowi jej mamy, Joanne (znana z Życia Adeli Adèle Exarchopoulos), która jest trenerką aqua aerobiku, a po pracy pływa w jeziorze pod czujnym okiem córki.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 12, \"Day\": 2 }, \"durationInMinutes\": 93, \"Cover\": \"https://fwcdn.pl/fpo/31/87/10013187/8040016.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/fph/31/87/10013187/1116149_1.1.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/JO_hNjm1dwA/hq2.jpg?sqp=-oaymwEjCOADEI4CSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLC1Zeul-jc1Cio3dMWMf7_-Agy_Dw\", \"Trailer\": \"https://www.youtube.com/watch?v=JO_hNjm1dwA&t=1s\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Świąteczna niespodzianka\", \"Description\": \"Nie wszystkie misie zapadają w zimowy sen. A w tym, jednym naprawdę można się zakochać, szczególnie że, potrafi mówić ludzkim głosem. I to nie tylko w Wigilię. Marianna zauważa misia na loterii fantowej podczas jarmarku świątecznego. Od początku czuje z nim niesamowitą więź.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 12, \"Day\": 9 }, \"durationInMinutes\": 97, \"Cover\": \"https://fwcdn.pl/fpo/09/76/10020976/8033872.6.jpg\", \"BackgroundImage\": \"https://i.ytimg.com/vi/a_yv4M5qfL0/maxresdefault.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/a_yv4M5qfL0/hq720.jpg?sqp=-oaymwE9COgCEMoBSFryq4qpAy8IARUAAAAAGAElAADIQj0AgKJDeAHwAQH4Af4JgALQBYoCDAgAEAEYYiBlKE4wDw==&rs=AOn4CLCj1QhSEr4IPg_UwK5xJOdWzKEicw\", \"Trailer\": \"https://www.youtube.com/watch?v=a_yv4M5qfL0\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Kevin Sam w domu\", \"Description\": \"Rodzina McCallisterów zamierza spędzić Święta Bożego Narodzenia we Francji. W dzień wyjazdu omal nie spóźniają się na samolot. W wyniku małego zamieszania zapominają ze sobą zabrać Kevina (Macaulay Culkin). Ośmioletni chłopiec zostaje sam w domu, od tej pory musi sam sobie radzić ze wszystkim, w czym do tej pory wyręczali go rodzice...\", \"ReleaseDate\": { \"Year\": 1992, \"Month\": 12, \"Day\": 25 }, \"durationInMinutes\": 103, \"Cover\": \"https://rytmy.pl/wp-content/uploads/2019/08/69757dbebf8eacf13cb003b65bf8bc8b00e66e37.jpeg\", \"BackgroundImage\": \"https://fwcdn.pl/webv/76/03/57603/57603.6.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/jEDaVHmw7r4/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLDNphNuo8lyBRnxbMbEYQkpBiCqgA\", \"Trailer\": \"https://www.youtube.com/watch?v=jEDaVHmw7r4&t=10s\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Incepcja\", \"Description\": \"Światowej sławy filmowiec Christopher Nolan wyreżyserował film z gwiazdorską obsadą, który zabiera wIdzów w podróż dookoła ziemskiego globu oraz w głąb intymnego i nieskończonego świata snów. Dom Cobb (Leonardo DiCaprio) jest niezwykle sprawnym złodziejem, mistrzem w wydobywaniu wartościowych sekretów ukrytych głęboko w świadomości podczas fazy snu, kiedy umysł jest najbardziej wrażliwy.\", \"ReleaseDate\": { \"Year\": 2010, \"Month\": 7, \"Day\": 30 }, \"durationInMinutes\": 148, \"Cover\": \"https://fwcdn.pl/fpo/08/91/500891/7354571.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/fph/08/91/500891/225070.1.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/YoHD9XEInc0/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLD70FgXVNexgqpibNVRPbjqoDZLiQ\", \"Trailer\": \"https://www.youtube.com/watch?v=xeqLtIKAjDM\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Jumanji\", \"Description\": \"Historia niezwykłej gry - zwanej \\\"Jumanji\\\" - rozpoczyna się w XIX wieku, kiedy to dwaj chłopcy zakopują w lesie tajemniczą skrzynkę. Mija sto lat. Nieśmiały i zagubiony, dwunastoletni Alan Parrish znajduje pudełko, we wnętrzu którego ukryte jest \\\"Jumnaji\\\". Chłopiec opowiada o tajemniczym odkryciu swej jedynej przyjaciółce, Sarze Whittle. \", \"ReleaseDate\": { \"Year\": 1996, \"Month\": 2, \"Day\": 23 }, \"durationInMinutes\": 106, \"Cover\": \"https://fwcdn.pl/fpo/06/65/665/8023036.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/fph/06/65/665/243658.1.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/9t12j5NRNtE/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLAZLR_wIyh7FYrq63y8PVlqSDzkYQ\", \"Trailer\": \"https://www.youtube.com/watch?v=9t12j5NRNtE\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Asteriks i Obeliks: Imperium Smoka\", \"Description\": \"Jest rok 50 p.n.e. Cesarzowa Chin, w wyniku zamachu stanu przeprowadzonego przez zdradzieckiego księcia, zostaje uwięziona. Córka porwanej władczyni – księżniczka Sass-Yi, wraz ze swoim wiernym ochroniarzem i fenickim kupcem wyrusza do odległej Galii, aby szukać pomocy dla swojego kraju. Tak oto poznaje Asteriksa i Obeliksa – dwóch dzielnych bohaterów, którzy nie cofną się przed niczym, aby zaprowadzić ład i porządek wszędzie tam, gdzie zapanował chaos i bezprawie…\", \"ReleaseDate\": { \"Year\": 2023, \"Month\": 2, \"Day\": 10 }, \"durationInMinutes\": 120, \"Cover\": \"https://fwcdn.pl/fpo/24/29/842429/8040147.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/webv/31/23/63123/63123.4.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/Ywp8qkaYbQs/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLDBNmqzX_ZctFaYnobibei8kcmCqw\", \"Trailer\": \"https://www.youtube.com/watch?v=Ywp8qkaYbQs\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Skołowani\", \"Description\": \"Maks to niepoprawny kobieciarz, a zarazem notoryczny kłamca. Gdy Anna, młoda i atrakcyjna kobieta, bierze go za niepełnosprawnego, Maks brnie w kłamstwo, licząc na kolejny łatwy podryw. Anna ma jednak inny plan – przedstawia go swojej starszej siostrze, Julii, która porusza się na wózku. Niespodziewanie, cynicznie nastawionego do świata Maksa i pełną energii Julię zaczyna łączyć coś więcej, ale… kłamstwo jako fundament relacji? Czy ta miłość ma szansę?\", \"ReleaseDate\": { \"Year\": 2023, \"Month\": 2, \"Day\": 3 }, \"durationInMinutes\": 121, \"Cover\": \"https://mediakrytyk.pl/media/images/empty_dark/movie.png\", \"BackgroundImage\": \"https://gfx.dlastudenta.pl/uploads/images/4/0a/Skolowani_min_1030x578.JPG\", \"Thumbnail\": \"https://gfx.dlastudenta.pl/uploads/images/4/0a/Skolowani_min_1030x578.JPG\", \"Trailer\": \"https://gfx.dlastudenta.pl/uploads/images/4/0a/Skolowani_min_1030x578.JPG\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Masz Ci los!\", \"Description\": \"Podczas stypy po pogrzebie ukochanego dziadka rodzina orientuje się, że w loterii padły właśnie numery, którymi staruszek grał przez całe życie. Nie ma czasu na rozpacz i łzy, kiedy zwycięski kupon jest w marynarce. Trzy metry pod ziemią. Rodzina i przyjaciele nagle z wielką mocą odczuwają potrzebę zobaczenia dziadka jeszcze raz... Do gry niespodziewanie wkracza także ksiądz okolicznej parafii, który doskonale wie, co knują krewni i sam chętnie odświeżyłby kościół (i nie tylko) przy pomocy pieniędzy z wygranej.\", \"ReleaseDate\": { \"Year\": 2023, \"Month\": 2, \"Day\": 3 }, \"durationInMinutes\": 121, \"Cover\": \"https://fwcdn.pl/fpo/59/19/10015919/8049306.6.jpg\", \"BackgroundImage\": \"https://gfx.dlastudenta.pl/uploads/images/e/91/MASZ_CI_LOS_fot_Pawel_Drabik_(1)_1030x578.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/PfZmfwZNO9A/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLB-ToAQBGf2-tfZg4QXmYQdIXYERA\", \"Trailer\": \"https://www.youtube.com/watch?v=PfZmfwZNO9A\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Pukając do drzwi\", \"Description\": \"\\\"Pukając do drzwi\\\" (org. \\\"Knock at the Cabin\\\") M. Night Shyamalana to adaptacja głośnej powieści \\\"Chata na krańcu świata\\\" (org. \\\"The Cabin at the End of the World\\\") Paula G. Tremblaya. Jest to opowieść o rodzinie, której spokojne wakacje w chatce w głębi lasu, przeradzają się w koszmar, gdy czterech uzbrojonych mężcyzn bierze ich na zakładników i każe dokonań przedziwnego \\\"wyboru Zofii\\\", aby w ten sposób…zapobiec apokalipsie.\", \"ReleaseDate\": { \"Year\": 2023, \"Month\": 2, \"Day\": 1 }, \"durationInMinutes\": 113, \"Cover\": \"https://fwcdn.pl/fpo/30/38/10003038/8050969.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/webv/26/77/62677/62677.4.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/liwMSKD7J_c/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLAcSCrYkvF5LzHF2Iq7ezvDd6p1xw\", \"Trailer\": \"https://www.youtube.com/watch?v=liwMSKD7J_c\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] } ]";
            return JsonSerializer.Deserialize<List<MovieCreateEditDTO>>(json)!;

        }
        
        private List<SeasonCreateEditDTO> GetSeriesFromJson()
        {
            string json = "[ { \"Id\": 0, \"Title\": \"Stranger Things 1\", \"Number\": 12, \"Description\": \"Dwunastoletni Will Byers znika po spotkaniu z przyjaciółmi, którzy postanawiają szukać chłopca na własną rękę. Mike, Lucas i Dustin poznają wówczas Eleven, czyli dziewczynkę, która uciekła z ukrytego laboratorium.\", \"ReleaseDate\": { \"Year\": 2016, \"Month\": 7, \"Day\": 15 }, \"Cover\": \"https://fwcdn.pl/fpo/03/59/750359/7748390.6.jpg\", \"BackgroundImage\": \"https://filmozercy.com/uploads/images/747x400/stranger-things-miniaturka-4387f.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/iFfcONDGHBY/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLBGLLMcbCO5SYavTIXv3mBOQE380w\", \"Trailer\": \"https://www.youtube.com/watch?v=iFfcONDGHBY\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Breaking Bad 1\", \"Number\": 7, \"Description\": \" Walter White, nauczyciel chemii w szkole średniej dowiaduje się, że cierpi na nieoperacyjnego raka płuc. Lekarze przewIdują, że przed nim nie więcej niż dwa lata życia. Mężczyzna, aby zabezpieczyć rodzinę finansowo po swej śmierci, decyduje się wykorzystać czas na handel narkotykami.\", \"ReleaseDate\": { \"Year\": 2008, \"Month\": 1, \"Day\": 20 }, \"Cover\": \"https://fwcdn.pl/fpo/06/68/430668/7552405.6.jpg\", \"BackgroundImage\": \"https://static.wikia.nocookie.net/breakingbad/images/b/b1/BB_101_S.jpg/revision/latest?cb=20170418193804\", \"Thumbnail\": \"https://i.ytimg.com/vi/ceqOTZnhgY8/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLAD0EJ22x4dZeKWh5plUOPUXj9EmA\", \"Trailer\": \"https://www.youtube.com/watch?v=HhesaQXLuRY&t=1s\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Goście 1\", \"Number\": 8, \"Description\": \"Głównym bohaterem serialu Goście jest Richard. Ma on niezwykłego pecha, ponieważ podczas jego pierwszego dnia pracy w policji w pobliskim miasteczku dochodzi do wypadku. Gdy świeżo upieczony policjant zjawia się na miejsce, okazuje się, że rozbiły się tam dwa statki kosmiczne.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 5, \"Day\": 3 }, \"Cover\": \"https://fwcdn.pl/fpo/51/78/10015178/8019651.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/webv/17/04/61704/61704.4.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/OAn395Dz0yU/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLAE_DHS_JxhNnmrTLCw6JqwfDbXjQ\", \"Trailer\": \"https://www.youtube.com/watch?v=OAn395Dz0yU\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"WednesDay 1\", \"Number\": 8, \"Description\": \"Przepełniona zjawiskami paranormalnymi opowieść detektywistyczna osadzona w czasie, gdy WednesDay Addams pobiera nauki w Akademii Nevermore. Nasza bohaterka próbuje zapanować nad swoimi nowo odkrytymi mocami psychicznymi, powstrzymać mordercze siły terroryzujące okolicę oraz rozwiązać nadnaturalną zagadkę, której częścią przed 25 laty stali się jej rodzice.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 11, \"Day\": 23 }, \"Cover\": \"https://fwcdn.pl/fpo/77/61/877761/8032433.6.jpg\", \"BackgroundImage\": \"https://filmozercy.com/uploads/images/747x400/enna-ortega-i-emma-myers-w-serialu-wednesday.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/o17HaBfc5tY/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLB1XzY_vf6XQE-lS8fCsQ5hSg2SdA\", \"Trailer\": \"https://www.youtube.com/watch?v=o17HaBfc5tY\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Wielka Woda\", \"Number\": 6, \"Description\": \"Wielka fala powodziowa zbliża się do Wrocławia. Lokalne władze, na czele z aspirującym urzędnikiem Jakubem Marczakiem (Tomasz Schuchardt), ściągają do miasta wykwalifikowaną hydrolożkę, Jaśminę Tremer (Agnieszka Żulewska), aby za wszelką cenę uratować miasto. W tym samym czasie Andrzej Rębacz (Ireneusz Czop) wraca do rodzinnych Kęt pod Wrocławiem nieoczekiwanie stając na czele zbuntowanych mieszkańców wsi, którzy nie chcą dopuścić do zniszczenia wału przeciwpowodziowego.\", \"ReleaseDate\": { \"Year\": 2022, \"Month\": 10, \"Day\": 5 }, \"Cover\": \"https://fwcdn.pl/fpo/18/16/871816/8042652.6.jpg\", \"BackgroundImage\": \"https://fwcdn.pl/fph/18/16/871816/1094435_1.1.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/lG9YFC0Lj0A/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLBh-4VECPL17CnBwY011xTJbr1WTQ\", \"Trailer\": \"https://www.youtube.com/watch?v=lG9YFC0Lj0A&t=1s\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"The Dark 1\", \"Number\": 10, \"Description\": \"\\\"Dark\\\" to niezwykła saga rozgrywająca się we współczesnych Niemczech. Zaginięcie dwojga małych dzieci wydobywa na światło dzienne skrywane sekrety czterech rodzin i zaburzone relacje pomiędzy ich członkami. Wypadki przedstawione w dziesięciu godzinnych odcinkach przybierają nadprzyrodzony obrót niepozostający bez związku z wydarzeniami, które miały miejsce w miasteczku w 1986 r.\", \"ReleaseDate\": { \"Year\": 2017, \"Month\": 12, \"Day\": 1 }, \"Cover\": \"https://fwcdn.pl/fpo/13/83/771383/7814585.6.jpg\", \"BackgroundImage\": \"https://dark.netflix.io/share/global.png\", \"Thumbnail\": \"https://i.ytimg.com/vi/eni33Abcf3I/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLDKMBxfwhxNWF70U0SVuJJZPxqWXg\", \"Trailer\": \"https://www.youtube.com/watch?v=eni33Abcf3I\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"WednesDay 2\", \"Number\": 0, \"Description\": \"Kontyunacja pierwszego sezonu kultowego serialu z platformy Netflix - dokładana fabuła jeszcze nie jest znana.\", \"ReleaseDate\": { \"Year\": 2023, \"Month\": 11, \"Day\": 1 }, \"Cover\": \"https://fwcdn.pl/fpo/77/61/877761/8032433.6.jpg\", \"BackgroundImage\": \"https://filmozercy.com/uploads/images/747x400/enna-ortega-i-emma-myers-w-serialu-wednesDay.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/LdHp3QjkUhQ/hq720.jpg?sqp=-oaymwEjCOgCEMoBSFryq4qpAxUIARUAAAAAGAElAADIQj0AgKJDeAE=&rs=AOn4CLBsi6VLZdyJ8M0ZIEilpj5LOEl6iw\", \"Trailer\": \"https://www.youtube.com/watch?v=LdHp3QjkUhQ\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Kalejdoskop\", \"Number\": 8, \"Description\": \"Rozgrywający się na przestrzeni 24 lat ''Kalejdoskop'' to odcinkowa antologia o ekipie genialnych złodziei, którzy próbują włamać się do pozornie Idealnie zabezpieczonego skarbca, żeby zdobyć największy łup w historii. W każdym odcinku dowiadujemy się, jak za sprawą kombinacji zemsty, spisków, układów i zdrady ekipa złodziei planowała skok na strzeżony przez najpotężniejszych ochroniarzy świata i stróżów prawa cel.\", \"ReleaseDate\": { \"Year\": 2023, \"Month\": 1, \"Day\": 1 }, \"Cover\": \"https://fwcdn.pl/fpo/34/96/10023496/8049247.6.jpg\", \"BackgroundImage\": \"https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.netflix.com%2Fpl%2FTitle%2F80992058&psig=AOvVaw1so0YxfuKVyUl70nO_h7Lw&ust=1673484771974000&source=images&cd=vfe&ved=0CA0QjRxqFwoTCJiBkrqnvvwCFQAAAAAdAAAAABAD\", \"Thumbnail\": \"https://i.ytimg.com/vi/iWP60msj_SM/hq720.jpg?sqp=-oaymwEcCK4FEIIdSEbyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLAiNS8frRPLk1BvTgLWZyR8-uDlqg\", \"Trailer\": \"https://www.youtube.com/watch?v=iWP60msj_SM\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Biały Lotos 1\", \"Number\": 6, \"Description\": \"Satyra społeczna z akcją osadzoną w ekskluzywnym kurorcie na Hawajach. Serial podąża za grupą gości hotelowych, którzy w tym samym tygodniu spędzają wakacje w ekskluzywnym kurorcie, relaksując się i wypoczywając wśród rajskich krajobrazów.\", \"ReleaseDate\": { \"Year\": 2021, \"Month\": 7, \"Day\": 11 }, \"Cover\": \"https://fwcdn.pl/fpo/54/91/875491/7991163.3.jpg\", \"BackgroundImage\": \"https://www.vogue.pl/images/blog/entry/facebook-digitalsyndication-bialy-lotos-kostiumografka-alex-bovaird-o-strojach-z-ekranu-22-big-13670.png\", \"Thumbnail\": \"https://i.ytimg.com/vi/J4ukeR2ozVo/sddefault.jpg\", \"Trailer\": \"https://www.youtube.com/watch?app=desktop&v=J4ukeR2ozVo\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Gwiezdne Wojny: Parszywa Zgraja\", \"Number\": 16, \"Description\": \"Grupa elitarnych żołnierzy-klonów, Clone Force 99, znana również jako Parszywa zgraja, próbuje odnaleźć się w galaktyce po wojnach klonów.\", \"ReleaseDate\": { \"Year\": 2021, \"Month\": 5, \"Day\": 4 }, \"Cover\": \"https://fwcdn.pl/fpo/84/75/858475/8053070.6.jpg\", \"BackgroundImage\": \"https://sm.ign.com/t/ign_pl/screenshot/default/star-wars-the-bad-batch-poster-1_yp52.1280.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/yr1DVq-YS4Y/maxresdefault.jpg\", \"Trailer\": \"https://www.youtube.com/watch?app=desktop&v=jKDF8gFtwMU\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Dr. House\", \"Number\": 22, \"Description\": \"Doktor Gregory House (Hugh Laurie) ma kiepskie podejście do pacjentów. Najchętniej nie miałby go wcale - nie lubi rozmawiać z pacjentami i unika tego za wszelką cenę. Jest leniwy, brutalnie szczery, niegrzeczny i uzależniony od środków przeciwbólowych. Dr House jest równocześnie znakomitym, światowej klasy diagnostą. \", \"ReleaseDate\": { \"Year\": 2004, \"Month\": 11, \"Day\": 16 }, \"Cover\": \"https://fwcdn.pl/fpo/01/77/130177/7221239.6.jpg\", \"BackgroundImage\": \"https://rc.serialowa.pl/wpr/wp-content/uploads/2020/10/dr-house-czolo.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/MczMB8nU1sY/hq720.jpg?sqp=-oaymwEcCK4FEIIdSEbyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLBCXkx2ODMSw6RiNclNEWgygFVhmg\", \"Trailer\": \"https://www.youtube.com/watch?app=desktop&v=MczMB8nU1sY\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] }, { \"Id\": 0, \"Title\": \"Emily w Paryżu 1\", \"Number\": 10, \"Description\": \"Dwudziestoparoletnia Emily jest ambitną dyrektorką działu marketingu z Chicago, która niespodziewanie otrzymuje pracę marzeń w Paryżu. Gdy jej firma przejmuje luksusową francuską agencję marketingową, młodej kobiecie powierzone zostaje opracowanie odpowiedniej strategii w mediach społecznościowych. Nowe, paryskie życie Emily wypełniają upojne przygody i nieoczekiwane wyzwania - w tym zyskanie sympatii nowych współpracowników, nawiązanie nowych przyjaźni i odnalezienie miłości.\", \"ReleaseDate\": { \"Year\": 2020, \"Month\": 10, \"Day\": 2 }, \"Cover\": \"https://fwcdn.pl/fpo/24/25/832425/7990601.6.jpg\", \"BackgroundImage\": \"https://d-tm.ppstatic.pl/kadry/33/16/e35ae638c3cf4bfe958dfcd34e32.1000.jpg\", \"Thumbnail\": \"https://i.ytimg.com/vi/zx4J2R1Op9c/hq720.jpg?sqp=-oaymwEcCK4FEIIdSEbyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLDivTMNvmsPmA_GsiPE_xYmSCn4FQ\", \"Trailer\": \"https://www.youtube.com/watch?app=desktop&v=zx4J2R1Op9c\", \"genreIds\": [ 0 ], \"TagIds\": [ 0 ], \"participants\": [ ] } ]";
            return JsonSerializer.Deserialize<List<SeasonCreateEditDTO>>(json)!;
        }
    }
}
