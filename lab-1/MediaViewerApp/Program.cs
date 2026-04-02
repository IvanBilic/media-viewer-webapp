using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaViewerApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Media Management & Viewer Web App ===\n");

            // Inicijalizacija podataka
            var users = InitializeUsers();
            var libraries = InitializeLibraries(users);
            var allMedia = InitializeMedia(libraries);
            var tags = InitializeTags(allMedia);
            var playlists = InitializePlaylists(users, allMedia);

            // Ispis glavnih objekata
            PrintMainObjects(users, libraries, playlists);

            // LINQ upiti
            Console.WriteLine("\n=== LINQ UPITI ===\n");
            ExecuteLINQQueries(allMedia, users, libraries, tags);

            // Async-await demo
            Console.WriteLine("\n=== ASYNC/AWAIT DEMO ===\n");
            await AsyncDemo(allMedia);

            Console.WriteLine("\nPritisnite bilo koju tipku za izlaz...");
            Console.ReadKey();
        }

        /// <summary>
        /// Inicijalizacija 3 korisnika
        /// </summary>
        static List<User> InitializeUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "ivan@example.com",
                    FirstName = "Ivan",
                    LastName = "Horvat",
                    RegisteredDate = new DateTime(2023, 1, 15),
                    LastLoginDate = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    Email = "marko@example.com",
                    FirstName = "Marko",
                    LastName = "Marković",
                    RegisteredDate = new DateTime(2022, 6, 20),
                    LastLoginDate = DateTime.UtcNow.AddDays(-2)
                },
                new User
                {
                    Id = 3,
                    Email = "ana@example.com",
                    FirstName = "Ana",
                    LastName = "Anić",
                    RegisteredDate = new DateTime(2024, 3, 10),
                    LastLoginDate = DateTime.UtcNow.AddHours(-5)
                }
            };

            return users;
        }

        /// <summary>
        /// Inicijalizacija 3 biblioteke medija
        /// </summary>
        static List<MediaLibrary> InitializeLibraries(List<User> users)
        {
            var libraries = new List<MediaLibrary>
            {
                new MediaLibrary
                {
                    Id = 1,
                    Name = "Godišnji odmor 2024",
                    UserId = users[0].Id,
                    CreatedDate = new DateTime(2024, 7, 1)
                },
                new MediaLibrary
                {
                    Id = 2,
                    Name = "Fotografije prirode",
                    UserId = users[1].Id,
                    CreatedDate = new DateTime(2023, 5, 10)
                },
                new MediaLibrary
                {
                    Id = 3,
                    Name = "Video tečajevi",
                    UserId = users[2].Id,
                    CreatedDate = new DateTime(2024, 1, 15)
                }
            };

            return libraries;
        }

        /// <summary>
        /// Inicijalizacija medija (slike i videa)
        /// </summary>
        static List<Media> InitializeMedia(List<MediaLibrary> libraries)
        {
            var media = new List<Media>();

            // Slike za prvu biblioteku
            media.Add(new Image
            {
                Id = 1,
                Title = "Plaža u Dalmaciji",
                Description = "Lijepa plaža sa kristalno čistom vodom",
                Format = MediaFormat.Jpg,
                FileSizeBytes = 5242880, // 5 MB
                CreatedDate = new DateTime(2024, 7, 15),
                ModifiedDate = new DateTime(2024, 7, 20),
                Width = 4000,
                Height = 3000,
                DpiResolution = 300,
                CameraModel = "Canon EOS R5",
                IsHdr = true,
                MediaLibraryId = libraries[0].Id
            });

            media.Add(new Image
            {
                Id = 2,
                Title = "Закат на мизiм",
                Description = "Prekrasan zalazak sunca",
                Format = MediaFormat.Png,
                FileSizeBytes = 8388608, // 8 MB
                CreatedDate = new DateTime(2024, 7, 16),
                ModifiedDate = new DateTime(2024, 7, 21),
                Width = 3840,
                Height = 2160,
                DpiResolution = 72,
                CameraModel = "Sony A7IV",
                IsHdr = false,
                MediaLibraryId = libraries[0].Id
            });

            media.Add(new Image
            {
                Id = 3,
                Title = "Planinska šuma",
                Description = "Šuma u jesenjim bojama",
                Format = MediaFormat.WebP,
                FileSizeBytes = 3145728, // 3 MB
                CreatedDate = new DateTime(2023, 9, 10),
                ModifiedDate = new DateTime(2023, 9, 15),
                Width = 5000,
                Height = 3333,
                DpiResolution = 300,
                CameraModel = "Nikon Z9",
                IsHdr = true,
                MediaLibraryId = libraries[1].Id
            });

            media.Add(new Image
            {
                Id = 4,
                Title = "Grad noću",
                Description = "Urbani pejzaž s svjetlima",
                Format = MediaFormat.Jpg,
                FileSizeBytes = 6291456, // 6 MB
                CreatedDate = new DateTime(2023, 12, 1),
                ModifiedDate = new DateTime(2023, 12, 5),
                Width = 3840,
                Height = 2160,
                DpiResolution = 72,
                CameraModel = "iPhone 15 Pro",
                IsHdr = true,
                MediaLibraryId = libraries[1].Id
            });

            // Videa
            media.Add(new Video
            {
                Id = 5,
                Title = "C# Uvod u LINQ",
                Description = "Video tečaj - Osnove LINQ upita",
                Format = MediaFormat.Mp4,
                FileSizeBytes = 314572800, // 300 MB
                CreatedDate = new DateTime(2024, 2, 1),
                ModifiedDate = new DateTime(2024, 2, 10),
                DurationSeconds = 1800, // 30 minuta
                Width = 1920,
                Height = 1080,
                FrameRate = 30,
                Bitrate = 5000,
                MediaLibraryId = libraries[2].Id
            });

            media.Add(new Video
            {
                Id = 6,
                Title = "Async-Await u praksi",
                Description = "Video tečaj - Napredni koncepti asinkronog programiranja",
                Format = MediaFormat.WebM,
                FileSizeBytes = 419430400, // 400 MB
                CreatedDate = new DateTime(2024, 3, 5),
                ModifiedDate = new DateTime(2024, 3, 15),
                DurationSeconds = 2700, // 45 minuta
                Width = 1920,
                Height = 1080,
                FrameRate = 60,
                Bitrate = 8000,
                MediaLibraryId = libraries[2].Id
            });

            media.Add(new Video
            {
                Id = 7,
                Title = "Moj prvi dokumentarac",
                Description = "Kratka dokumentarna serija o putesima",
                Format = MediaFormat.Mp4,
                FileSizeBytes = 629145600, // 600 MB
                CreatedDate = new DateTime(2024, 5, 20),
                ModifiedDate = new DateTime(2024, 6, 1),
                DurationSeconds = 3600, // 60 minuta
                Width = 3840,
                Height = 2160,
                FrameRate = 24,
                Bitrate = 12000,
                MediaLibraryId = libraries[0].Id
            });

            // Dodaj mediju u biblioteke
            foreach (var lib in libraries)
            {
                var libMedia = media.Where(m => m.MediaLibraryId == lib.Id).ToList();
                lib.MediaItems.AddRange(libMedia);
            }

            return media;
        }

        /// <summary>
        /// Inicijalizacija N-N relacija (tagovi)
        /// </summary>
        static List<Tag> InitializeTags(List<Media> media)
        {
            var tags = new List<Tag>
            {
                new Tag { Id = 1, Name = "Putovanja", Color = "#FF6B6B" },
                new Tag { Id = 2, Name = "Priroda", Color = "#51CF66" },
                new Tag { Id = 3, Name = "Video", Color = "#4C6EF5" },
                new Tag { Id = 4, Name = "Образаване", Color = "#FFD43B" },
                new Tag { Id = 5, Name = "Premium", Color = "#A78BFA" }
            };

            // Dodaj N-N relacije
            media[0].Tags.Add(tags[0]); // Plaža -> Putovanja
            media[0].Tags.Add(tags[1]); // Plaža -> Priroda
            media[2].Tags.Add(tags[1]); // Šuma -> Priroda
            media[2].Tags.Add(tags[4]); // Šuma -> Premium
            media[4].Tags.Add(tags[2]); // Vid1 -> Video
            media[4].Tags.Add(tags[3]); // Vid1 -> Obrazaване
            media[5].Tags.Add(tags[2]); // Vid2 -> Video
            media[5].Tags.Add(tags[3]); // Vid2 -> Образаване

            return tags;
        }

        /// <summary>
        /// Inicijalizacija playlistova
        /// </summary>
        static List<Playlist> InitializePlaylists(List<User> users, List<Media> media)
        {
            var playlists = new List<Playlist>
            {
                new Playlist
                {
                    Id = 1,
                    Name = "Likošceni video materijal",
                    Description = "Moji omiljeni videa za učenje",
                    UserId = users[2].Id,
                    CreatedDate = new DateTime(2024, 2, 15),
                    ModifiedDate = new DateTime(2024, 3, 20)
                },
                new Playlist
                {
                    Id = 2,
                    Name = "Putne uspomene",
                    Description = "Fotografije s putovanja",
                    UserId = users[0].Id,
                    CreatedDate = new DateTime(2024, 6, 1),
                    ModifiedDate = new DateTime(2024, 7, 25)
                },
                new Playlist
                {
                    Id = 3,
                    Name = "Prirodne scene",
                    Description = "Najljepše fotografije prirode",
                    UserId = users[1].Id,
                    CreatedDate = new DateTime(2023, 5, 20),
                    ModifiedDate = DateTime.UtcNow
                }
            };

            // Dodaj mediju u playlistove
            playlists[0].MediaItems.AddRange(media.Where(m => m is Video).Take(2));
            playlists[1].MediaItems.AddRange(media.Where(m => m is Image && m.MediaLibraryId == 1).Take(3));
            playlists[2].MediaItems.AddRange(media.Where(m => m is Image && m.MediaLibraryId == 2).Take(2));

            return playlists;
        }

        /// <summary>
        /// Ispis glavnih objekata
        /// </summary>
        static void PrintMainObjects(List<User> users, List<MediaLibrary> libraries, List<Playlist> playlists)
        {
            Console.WriteLine("=== GLAVNI OBJEKTI ===\n");

            Console.WriteLine("KORISNICI:");
            foreach (var user in users)
            {
                Console.WriteLine($"  {user}");
            }

            Console.WriteLine("\nBIBLIOTEKE MEDIJA:");
            foreach (var lib in libraries)
            {
                Console.WriteLine($"  {lib}");
            }

            Console.WriteLine("\nPLAYLISTOVI:");
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"  {playlist}");
            }
        }

        /// <summary>
        /// LINQ upiti
        /// </summary>
        static void ExecuteLINQQueries(List<Media> media, List<User> users, List<MediaLibrary> libraries, List<Tag> tags)
        {
            // Upit 1: Sve slike sortirane po veličini datoteke
            var largeImages = media
                .OfType<Image>()
                .Where(img => img.FileSizeBytes > 5000000)
                .OrderByDescending(img => img.FileSizeBytes)
                .ToList();

            Console.WriteLine("Upit 1: Velike slike (>5MB) sortirane po veličini:");
            foreach (var img in largeImages)
            {
                Console.WriteLine($"  - {img.Title}: {img.FileSizeBytes / 1048576} MB");
            }

            // Upit 2: Videa dulja od 30 minuta
            var longVideos = media
                .OfType<Video>()
                .Where(v => v.DurationSeconds > 1800)
                .OrderByDescending(v => v.DurationSeconds)
                .ToList();

            Console.WriteLine("\nUpit 2: Videa dulja od 30 minuta:");
            foreach (var video in longVideos)
            {
                var minutes = video.DurationSeconds / 60;
                Console.WriteLine($"  - {video.Title}: {minutes} minuta");
            }

            // Upit 3: Mediji po formatu
            var mediaByFormat = media
                .GroupBy(m => m.Format)
                .Select(g => new { Format = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            Console.WriteLine("\nUpit 3: Mediji po formatu:");
            foreach (var group in mediaByFormat)
            {
                Console.WriteLine($"  - {group.Format}: {group.Count} datoteka");
            }

            // Upit 4: Mediji sa 'Priroda' tagom
            var natureMedia = media
                .Where(m => m.Tags.Any(t => t.Name == "Priroda"))
                .OrderBy(m => m.Title)
                .ToList();

            Console.WriteLine("\nUpit 4: Mediji sa 'Priroda' tagom:");
            foreach (var item in natureMedia)
            {
                Console.WriteLine($"  - {item.Title}");
            }

            // Upit 5: Najnoviji mediji
            var recentMedia = media
                .OrderByDescending(m => m.CreatedDate)
                .Take(3)
                .ToList();

            Console.WriteLine("\nUpit 5: Tri najnovija medija:");
            foreach (var item in recentMedia)
            {
                Console.WriteLine($"  - {item.Title} ({item.CreatedDate:yyyy-MM-dd})");
            }

            // Upit 6: Biblioteke po broju medija
            var librariesByCount = libraries
                .Select(lib => new { 
                    Library = lib.Name, 
                    Count = lib.MediaItems.Count,
                    TotalSize = lib.MediaItems.Sum(m => m.FileSizeBytes)
                })
                .OrderByDescending(x => x.Count)
                .ToList();

            Console.WriteLine("\nUpit 6: Biblioteke po broju medija:");
            foreach (var lib in librariesByCount)
            {
                var sizeGb = lib.TotalSize / 1073741824;
                Console.WriteLine($"  - {lib.Library}: {lib.Count} medija ({sizeGb:F2} GB)");
            }

            // Upit 7: Slike sa HDR-om
            var hdrImages = media
                .OfType<Image>()
                .Where(img => img.IsHdr)
                .Count();

            Console.WriteLine($"\nUpit 7: Broje slika sa HDR-om: {hdrImages}");

            // Upit 8: Koristi First/Single/FirstOrDefault
            var firstVideo = media.OfType<Video>().FirstOrDefault();
            Console.WriteLine($"\nUpit 8: Prvi video: {firstVideo?.Title ?? "Nema videa"}");

            // Upit 9: Mediji s više od 2 taga
            var taggedMedia = media
                .Where(m => m.Tags.Count > 1)
                .Select(m => new { Media = m.Title, TagCount = m.Tags.Count })
                .OrderByDescending(x => x.TagCount)
                .ToList();

            Console.WriteLine("\nUpit 9: Mediji s više od 2 taga:");
            foreach (var item in taggedMedia)
            {
                Console.WriteLine($"  - {item.Media}: {item.TagCount} tagova");
            }

            // Upit 10: Slika sa najvećom rezolucijom
            var highestResImage = media
                .OfType<Image>()
                .OrderByDescending(img => img.Width * img.Height)
                .FirstOrDefault();

            Console.WriteLine($"\nUpit 10: Slika sa najvećom rezolucijom: {highestResImage?.Title} ({highestResImage?.Width}x{highestResImage?.Height})");
        }

        /// <summary>
        /// Async-await demo
        /// </summary>
        static async Task AsyncDemo(List<Media> media)
        {
            Console.WriteLine("Započinjem asinkrione operacije...");

            var task1 = SimulateMediaProcessingAsync(media[0], 2);
            var task2 = SimulateMediaProcessingAsync(media[1], 1);
            var task3 = SimulateMediaProcessingAsync(media[4], 3);

            await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("Sve asinkrione operacije su završene!");
        }

        /// <summary>
        /// Asinkrona simulacija obrade medija
        /// </summary>
        static async Task SimulateMediaProcessingAsync(Media media, int delaySeconds)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Započeta obrada: {media.Title}");
            await Task.Delay(delaySeconds * 1000);
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Završena obrada: {media.Title}");
        }
    }
}
