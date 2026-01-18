using CulinaryVault.Shared;
using Microsoft.EntityFrameworkCore;

namespace CulinaryVault.Data;

public static class SeedData
{
    public static async Task InitializeAsync(CulinaryVaultDbContext db)
    {
        if (await db.Recipes.AnyAsync())
            return;

        var recipes = new List<Recipe>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Sarmale",
                Description = "Rulouri tradiționale românești din foi de varză, umplute cu carne tocată și orez, gătite lent în sos de roșii.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromHours(3),
                Servings = 8,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Varză murată", Amount = 1, Unit = "căpățână", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Carne tocată de porc", Amount = 500, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Orez", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 2, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Bulion de roșii", Amount = 3, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Boia dulce", Amount = 1, Unit = "linguriță", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Cimbru", Amount = 1, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ceapa tăiată mărunt în puțin ulei până devine translucidă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați carnea tocată cu orezul spălat, ceapa călită, boia și condimentele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Desfaceți foile de varză și puneți câte o lingură de compoziție în fiecare foaie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Rulați sarmalele strâns și aranjați-le într-o oală mare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Adăugați bulionul diluat cu apă și gătiți la foc mic 2-3 ore." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Mici (Mititei)",
                Description = "Cârnați românești tradiționali fără membrană, preparați din carne de vită și condimente aromate, perfecti pentru grătar.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Carne tocată de vită", Amount = 800, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 6, Unit = "căței", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Bicarbonat de sodiu", Amount = 1, Unit = "linguriță", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Cimbru", Amount = 2, Unit = "lingurițe", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Chimion", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Boia iute", Amount = 0.5, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați carnea tocată cu usturoiul pisat și toate condimentele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați bicarbonatul și 100ml apă rece, frământați bine." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Lăsați compoziția la frigider peste noapte sau minimum 4 ore." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Formați cilindri de 8-10 cm lungime." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Prăjiți pe grătar sau într-o tigaie la foc mare, 3-4 minute pe fiecare parte." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ciorbă de burtă",
                Description = "Supă cremoasă și reconfortantă din burtă de vită cu smântână și usturoi, un preparat tradițional românesc.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromHours(2),
                Servings = 6,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Burtă de vită", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 400, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 3, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 8, Unit = "căței", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Oțet", Amount = 3, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ardei iute", Amount = 1, Unit = "bucată", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Curățați și spălați bine burta, apoi fierbeți-o în apă cu sare până devine moale (1.5-2 ore)." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Tăiați burta fiartă în fâșii subțiri." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați smântâna cu gălbenușurile și adăugați treptat în supă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați usturoiul pisat și oțetul după gust." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Serviți cu ardei iute și smântână suplimentară." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Papanași",
                Description = "Desert tradițional românesc din brânză de vaci, prăjit și servit cu smântână și dulceață de afine.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Brânză de vaci", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 3, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Dulceață de afine", Amount = 150, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați brânza de vaci cu ouăle, zahărul și făina până obțineți un aluat omogen." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Formați gogoși mari și faceți o adâncitură în centrul fiecăreia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Formați și bile mici care vor sta deasupra." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Prăjiți în ulei încins până devin aurii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Serviți calzi cu smântână și dulceață de afine deasupra." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Mușchi de vită la cuptor",
                Description = "Mușchi de vită fraged gătit la cuptor cu ierburi aromatice și legume de sezon.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Mușchi de vită", Amount = 800, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Rozmarin proaspăt", Amount = 3, Unit = "fire", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 4, Unit = "căței", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 50, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 2, Unit = "linguri", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Scoateți carnea din frigider cu 30 de minute înainte de preparare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Rumeniți carnea în tigaie cu ulei pe toate părțile." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Transferați într-o tavă de cuptor cu usturoiul și rozmarinul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți la 200°C pentru 25-30 minute (medium-rare)." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Lăsați să se odihnească 10 minute înainte de a tăia." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Paste Carbonara",
                Description = "Paste italiene cremoase cu ouă, parmezan, pancetta și piper negru proaspăt măcinat.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Spaghetti", Amount = 400, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Pancetta", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Parmezan", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Piper negru", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți pastele conform instrucțiunilor de pe ambalaj." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Prăjiți pancetta până devine crocantă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Bateți ouăle cu parmezanul ras și piperul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Scurgeți pastele și amestecați imediat cu pancetta (focul oprit)." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Adăugați amestecul de ouă și amestecați rapid." }
                }
            },
            // === Recipes ingested from recipies repository ===
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tarta cu praz (Quiche)",
                Description = "Tartă savuroasă în stil franțuzesc cu praz, bacon, spanac și brânză Cheddar într-un aluat fraged făcut în casă.",
                ImageUrl = "/uploads/quiche-tarta-cu-praz.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(35),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Apă rece", Amount = 6, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Bacon", Amount = 6, Unit = "felii", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 2, Unit = "căței", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Praz", Amount = 2, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Cimbru uscat", Amount = 1, Unit = "linguriță", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Baby spanac", Amount = 100, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză Cheddar", Amount = 45, Unit = "g", Order = 9 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 10 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 3, Unit = "linguri", Order = 11 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați ingredientele pentru aluat până obțineți o compoziție omogenă. Puneți în folie și dați la frigider 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Întindeți aluatul pe o suprafață tapetată cu făină, puneți în formă, înțepați cu furculița și coaceți 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Căliți baconul cu usturoiul și cimbrul, apoi adăugați prazul și gătiți acoperit la foc mic 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați spanacul peste praz și mai țineți puțin pe foc." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Amestecați brânza rasă cu ouăle și smântâna, turnați peste compoziția din tigaie, apoi peste aluat și coaceți 15 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ardei copți cu smântână",
                Description = "Ardei grași copți înăbușiți în sos de roșii cremos cu smântână și usturoi, un preparat tradițional savuros.",
                ImageUrl = "/uploads/ardei-copti-cu-smantana.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii", Amount = 4, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 2, Unit = "căței", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ardei grași copți", Amount = 5, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru gătit", Amount = 250, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mărar", Amount = 1, Unit = "legătură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ceapa tocată mărunt în puțin ulei amestecat cu apă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați roșiile și usturoiul, lăsați la gătit până roșiile devin sos." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați ardeii copți curățați și tăiați, lăsați câteva minute pe foc." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Turnați smântâna pentru gătit și măriți focul ca să se îngroașe." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "La final adăugați mărarul tocat și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Aripioare glazurate",
                Description = "Aripioare de pui glazurate cu miere și sos de roșii, servite cu piure cremos de cartofi și usturoi copt.",
                ImageUrl = "/uploads/aripioare-glazurate.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Aripioare de pui", Amount = 800, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 2, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Sirop de curmale", Amount = 1, Unit = "lingură", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Pastă de roșii", Amount = 1, Unit = "ceașcă", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Pudră de usturoi", Amount = 2, Unit = "lingurițe", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Boia", Amount = 2, Unit = "lingurițe", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Zeamă de lămâie", Amount = 3, Unit = "linguri", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi albi", Amount = 3, Unit = "bucăți", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Cartof dulce", Amount = 0.5, Unit = "bucată", Order = 9 },
                    new() { Id = Guid.NewGuid(), Name = "Căpățână de usturoi", Amount = 1, Unit = "bucată", Order = 10 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 20, Unit = "g", Order = 11 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Prefierbeți aripioarele 5 minute și amestecați ingredientele pentru glazură." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Puneți aripioarele într-o tavă termorezistentă și turnați sosul peste ele, amestecând bine." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți 20-25 minute la 200°C, amestecând la jumătatea timpului." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Fierbeți cartofii curățați. Usturoiul tăiat la vârf se înfășoară în hârtie de copt și folie, apoi se coace 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Pasați cartofii fierți cu untul și usturoiul copt pentru piure." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Arpacaș cu legume",
                Description = "Preparat sănătos de post cu arpacaș (orz decorticat) și legume călite, aromat cu chimen și busuioc.",
                ImageUrl = "/uploads/arpacas-cu-legume.png",
                PrepTime = TimeSpan.FromMinutes(180),
                CookTime = TimeSpan.FromMinutes(50),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Arpacaș", Amount = 1, Unit = "cană", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcov", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Piper", Amount = 0.5, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Chimen", Amount = 0.5, Unit = "linguriță", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Busuioc", Amount = 1, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Spălați arpacașul în mai multe ape și lăsați-l la hidratat cel puțin 3 ore, preferabil peste noapte." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Schimbați apa și puneți arpacașul la fiert cel puțin 40 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Tăiați legumele și căliți-le în puțin ulei." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Când arpacașul e fiert, puneți-l peste legume și condimentați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Amestecați bine și serviți cald." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Banana bread cu iaurt",
                Description = "Prăjitură pufoasă și aromată cu banane coapte și iaurt, perfectă pentru micul dejun sau gustare.",
                ImageUrl = "/uploads/banana-bread-cu-iaurt.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 8,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Banane coapte", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Unt topit", Amount = 60, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 150, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Făină albă", Amount = 130, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Praf de copt", Amount = 2, Unit = "lingurițe", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pasați bananele cu furculița până obțineți un piure fin." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mixați ouăle până devin spumoase, apoi adăugați pe rând untul topit și iaurtul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați piureul de banane, praful de copt și făina, mixând după fiecare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți compoziția într-o formă de guguluf sau chec." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți la 180°C cu căldură sus-jos, fără ventilație, aproximativ 40 minute sau până trece testul scobitorii." }
                }
            },
            // === Batch 2 ===
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Batoane cu mac",
                Description = "Batoane pufoase de pâine cu topping de mac, perfecte pentru micul dejun sau gustare.",
                ImageUrl = "/uploads/batoane-cu-mac.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Apă călduță", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 50, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 80, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 0.5, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie proaspătă", Amount = 20, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 500, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe de mac", Amount = 1, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați apa, zahărul și drojdia, apoi adăugați făina și frământați 3 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Lăsați aluatul să dospească până se umflă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Împărțiți în 8 părți, întindeți fiecare în dreptunghi și rulați. Lăsați la dospit 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Aplicați topping-ul (80g apă + 20g făină) și presărați mac." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți 15-20 minute la 200°C. După coacere, aplicați sirop (80g apă + 20g zahăr)." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Bavarois de căpșuni",
                Description = "Desert elegant cu mousse cremos de căpșuni și mascarpone pe un blat pufos.",
                ImageUrl = "/uploads/bavarois-de-capsuni.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 8,
                Difficulty = Difficulty.Hard,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 60, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 60, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină cu praf de copt", Amount = 60, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 500, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni", Amount = 500, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pentru mousse", Amount = 200, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Gelatină", Amount = 30, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Frișcă", Amount = 200, Unit = "g", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați ingredientele pentru blat și coaceți la 170°C timp de 15-20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mixați căpșunile cu zahărul și gătiți până se înmoaie, apoi pasați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Bateți mascarpone cu frișca până se întărește." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Dizolvați gelatina în apă caldă și adăugați în siropul de căpșuni, apoi amestecați cu mascarpone." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Turnați mousse-ul peste blatul răcit și dați la rece minimum 2 ore." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Biscuiți 100",
                Description = "Biscuiți sărați simpli cu brânză, perfecți ca aperitiv - rețetă cu proporții egale de 100g.",
                ImageUrl = "/uploads/biscuiti-100.png",
                PrepTime = TimeSpan.FromMinutes(70),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 20,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ou pentru uns", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe (chimen/susan/mac)", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Formați un aluat din unt ras, făină și brânză." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Dați la frigider minimum 1 oră." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți o foaie și decupați forme." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Ungeți cu ou și presărați semințe." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți la 180°C timp de 20-25 minute până se rumenesc." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Biscuiți cu ciocolată și portocală",
                Description = "Biscuiți fragezi cu aromă de portocală și ciocolată albă, stropiți cu sos de ciocolată neagră.",
                ImageUrl = "/uploads/biscuiti-cu-ciocolata-si-portocala.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(22),
                Servings = 15,
                Difficulty = Difficulty.Easy,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr brun", Amount = 40, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 140, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Portocală (coaja)", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată albă", Amount = 30, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână lichidă", Amount = 50, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată neagră", Amount = 30, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Mixați untul cu zahărul, adăugați coaja de portocală și făina până obțineți textură nisipoasă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați cubulețele de ciocolată albă și frământați ușor." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți aluatul în tavă tapetată, înțepați cu furculița și coaceți la 200°C timp de 22 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Pentru sosul de ciocolată, încălziți smântâna și turnați peste ciocolata neagră." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Tăiați biscuiții răciți și stropiți cu sos de ciocolată." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Biscuiți cu mascarpone și nuci",
                Description = "Biscuiți rulați aromat cu scorțișoară, nucșoară și nuci măcinate.",
                ImageUrl = "/uploads/biscuiti-cu-mascarpone-si-nuci.png",
                PrepTime = TimeSpan.FromMinutes(25),
                CookTime = TimeSpan.FromMinutes(17),
                Servings = 20,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 150, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Unt rece", Amount = 75, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone rece", Amount = 120, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 1, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Nucșoară", Amount = 0.25, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci măcinate", Amount = 2, Unit = "mâini", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați făina cu scorțișoara, nucșoara și untul rece până obțineți textură nisipoasă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Încorporați mascarpone și dați la frigider 5-10 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți o foaie de 2-3mm, distribuiți nucile și apăsați ușor cu sucitorul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Rulați strâns și tăiați felii de 8-10mm, aplatizați ușor." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți la 180°C cu ventilație timp de 15-17 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Biscuiți cu semințe",
                Description = "Biscuiți sănătoși și crocanți din făină de ovăz și mix de semințe.",
                ImageUrl = "/uploads/biscuiti-cu-seminte.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 15,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină de ovăz", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Mix semințe (chia, dovleac, pin, cânepă)", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 30, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "vârf linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați toate ingredientele până obțineți un aluat moale și ușor lipicios." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Puneți aluatul între două hârtii de copt și întindeți cât mai subțire." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Tăiați în pătrățele și așezați în tavă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți aproximativ 25 minute la 170°C." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Verificați periodic să nu se ardă." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Biscuiți cu unt fără zahăr",
                Description = "Biscuiți simpli și fragezi fără zahăr adăugat, glazurați cu puțină miere.",
                ImageUrl = "/uploads/biscuiti-cu-unt-fara-zahar.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 15,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt light", Amount = 90, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenuș", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Esență de vanilie", Amount = 1, Unit = "linguriță", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 140, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Miere pentru uns", Amount = 1, Unit = "lingură", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați untul la temperatura camerei cu gălbenușul și vanilia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina și amestecați bine." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Formați bilute de 20g și aplatizați-le cu un pahar pe tavă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți bucățele de ciocolată în mijloc (opțional)." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți 15-20 minute. După răcire, ungeți cu puțină miere." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Biscuiți inimioși",
                Description = "Biscuiți colorați natural cu sfeclă roșie și căpșuni, perfect pentru Ziua Îndrăgostiților.",
                ImageUrl = "/uploads/biscuiti-inimosi.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 25,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 360, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină de migdale", Amount = 85, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 0.5, Unit = "linguriță", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt rece", Amount = 200, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sfeclă roșie fiartă", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni", Amount = 70, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 4, Unit = "linguri", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Mixați căpșunile cu sfecla până obțineți un piure fin." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați ingredientele uscate cu untul până obțineți textură nisipoasă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Încorporați mierea și piureul de căpșuni cu sfeclă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Întindeți o foaie de 3mm și decupați în forme de inimă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți la 175°C cu ventilație: 10-12 min pentru moi, 14-15 min pentru crocanți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Blat de pizza",
                Description = "Aluat de pizza clasic, pufos și elastic, perfect pentru pizza de casă.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(90),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Apă caldă", Amount = 150, Unit = "ml", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 0.5, Unit = "linguriță", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie uscată", Amount = 1, Unit = "linguriță", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 250, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați drojdia cu 1 lingură făină, apă caldă și zahăr. Lăsați să facă spumă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Într-un castron puneți făina, adăugați amestecul de drojdie, uleiul și sarea." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Frământați bine până obțineți un aluat moale și elastic." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Acoperiți și lăsați să dospească până își dublează volumul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Întindeți aluatul în forma dorită pentru pizza." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Borș de curcan cu tăiței",
                Description = "Borș tradițional românesc cu carne de curcan, legume și tăiței de casă.",
                ImageUrl = "/uploads/bors-de-curcan-cu-taietei.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(90),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Pulpă de curcan", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 4, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Țelină", Amount = 0.5, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Gulie", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ardei roșu", Amount = 1, Unit = "bucată", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Tăiței", Amount = 100, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Borș", Amount = 400, Unit = "ml", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Mazăre", Amount = 100, Unit = "g", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Puneți pulpa de curcan la fiert și spumați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "După ce nu mai face spumă, adăugați legumele tăiate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Fierbeți borșul separat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Când legumele sunt fierte, adăugați tăiețeii și mazărea." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Turnați borșul fiert, dați un clocot, potriviți de sare și piper, adăugați verdeață." }
                }
            },
            // === Batch 3 ===
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Brioșe cu dovleac și brânză",
                Description = "Brioșe pufoase cu piure de dovleac și cremă de brânză în spirală, perfecte pentru toamnă.",
                ImageUrl = "/uploads/briose-cu-dovleac-si-branza.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 1.75, Unit = "căni", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Piure de dovleac", Amount = 1, Unit = "cană", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 1, Unit = "cană", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 0.5, Unit = "cană", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Cremă de brânză", Amount = 225, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Condimente (scorțișoară, nucșoară)", Amount = 1, Unit = "lingură", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați piureul de dovleac cu zahărul, ouăle, uleiul și vanilia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina, condimentele și praful de copt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Puneți amestecul în forme de brioșe." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați crema de brânză deasupra și amestecați cu o scobitoare pentru efect de spirală." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți 18-20 minute la 180°C. Lăsați să se răcească 10 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Brioșe cu unt de arahide",
                Description = "Deserturi cu crustă de fulgi de ovăz și unt de arahide, acoperite cu ciocolată neagră.",
                ImageUrl = "/uploads/briose-cu-unt-de-arahide.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 12,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Fulgi de ovăz", Amount = 1, Unit = "cană", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 3, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt de arahide", Amount = 4, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată neagră", Amount = 100, Unit = "g", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați fulgii de ovăz cu mierea și untul de arahide." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Puneți amestecul în forme de brioșe ca o crustă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Topiți ciocolata neagră și turnați peste crustă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați un strat de unt de arahide deasupra." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Lăsați să se întărească la frigider." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Brownie cu căpșuni fără zahăr",
                Description = "Prăjitură brownie sănătoasă îndulcită natural cu curmale și bucățele de căpșuni.",
                ImageUrl = "/uploads/brownie-cu-capsuni.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 80, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată neagră", Amount = 110, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Curmale", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 50, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 90, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Pudră de cacao", Amount = 40, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni", Amount = 50, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Topiți untul și ciocolata la bain-marie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mixați curmalele înmuiate cu laptele și ouăle în blender." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați făina și cacao în amestecul lichid." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Încorporați untul cu ciocolata și căpșunile tăiate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți la 190°C timp de 20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Budincă de chia",
                Description = "Desert sănătos și simplu cu semințe de chia, lapte și miere, decorat cu fructe proaspete.",
                ImageUrl = "/uploads/budinca-de-chia.png",
                PrepTime = TimeSpan.FromMinutes(5),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 250, Unit = "ml", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe de chia", Amount = 4, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 2, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Extract de vanilie", Amount = 1, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Fructe proaspete pentru decor", Amount = 1, Unit = "porție", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați laptele cu semințele de chia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați mierea și extractul de vanilie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați bine și lăsați la frigider peste noapte." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Amestecați din nou dimineața." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Serviți decorat cu fructe proaspete." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Budincă de tapioca de toamnă",
                Description = "Desert cald și reconfortant cu tapioca, fructe de toamnă și condimente aromate.",
                ImageUrl = "/uploads/budinca-de-tapioca.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Tapioca", Amount = 50, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 200, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Prune", Amount = 3, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Măr dulce", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Gutui", Amount = 2, Unit = "felii", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Cartof dulce/dovleac", Amount = 2, Unit = "felii", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 1, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți tapioca în lapte cu vanilia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Tăiați fructele mărunt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați tapioca cu fructele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți într-un vas tapetat cu unt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți 30 minute la 180°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Budincă Yorkshire",
                Description = "Budincă englezească sărată, pufoasă și crocantă, cu bacon și brânzeturi.",
                ImageUrl = "/uploads/budinca-yorkshire.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Englezească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 250, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 40, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Bacon", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mozzarella", Amount = 50, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză brie", Amount = 50, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Preîncălziți cuptorul la 180°C cu tigaia înăuntru." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați laptele cu ouăle, sarea și făina până obțineți o compoziție fină." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Topiți untul în tigaia încinsă și turnați compoziția." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați baconul prăjit și mozzarella, coaceți 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Scoateți și adăugați ceapă verde și felii de brie." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Burger de casă",
                Description = "Burger clasic cu carne de vită și chifle pufoase făcute în casă.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(90),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 10,
                Difficulty = Difficulty.Medium,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Carne de vită tocată", Amount = 750, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 1, Unit = "căpățână", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină (pentru chifle)", Amount = 500, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 210, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie", Amount = 25, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Emmentaler", Amount = 100, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pentru chifle: amestecați laptele, apa, uleiul și drojdia, lăsați 15 min." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina și oul, frământați. Formați 10 bile și lăsați să dospească 1 oră." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți chiflele la 200°C, 15-20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Pentru burgeri: amestecați carnea cu usturoiul, ceapa, boia și condimentele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Formați burgerii și prăjiți-i. Asamblați cu brânză și sosuri." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Butter chicken",
                Description = "Preparat indian cremos cu pui marinat în iaurt și condimente, într-un sos de roșii și smântână.",
                ImageUrl = "/uploads/butter-chicken.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Indiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Pulpe de pui dezosate", Amount = 1, Unit = "kg", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt grecesc", Amount = 250, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Garam masala", Amount = 5, Unit = "lingurițe", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Turmeric", Amount = 2, Unit = "lingurițe", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii", Amount = 400, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână lichidă", Amount = 100, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 50, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ghimbir", Amount = 1, Unit = "bucată", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Marinați puiul tăiat cuburi în iaurt cu condimente, minimum 1 oră." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți puiul până se rumenește, scoateți și păstrați la cald." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Căliți ceapa, adăugați usturoiul, ghimbirul și condimentele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați roșiile, fierbeți 15 min, pasați fin și puneți înapoi în tigaie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Adăugați puiul, fierbeți 25 min, apoi smântâna. Serviți cu orez." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Cartofi cu mozzarella la cuptor",
                Description = "Cartofi aurii la cuptor cu mozzarella filantă, șuncă și smântână.",
                ImageUrl = "/uploads/cartofi-cu-mozzarella.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 5, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Măsline", Amount = 4, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Șuncă", Amount = 4, Unit = "felii", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 100, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mozzarella", Amount = 125, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți cartofii tăiați cuburi până sunt al dente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Puneți cartofii într-un vas termorezistent." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați măslinele, șunca și bucăți de mozzarella." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Turnați smântâna amestecată cu oul și puneți felii de mozzarella deasupra." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți la 180°C timp de 20-25 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Chicken nuggets",
                Description = "Nuggets de pui sănătoși la air fryer, făcuți cu piept de pui și cartof.",
                ImageUrl = "/uploads/chicken-nuggets.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Cartof fiert", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 0.5, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 2, Unit = "linguri", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Puneți toate ingredientele în blender și mixați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Formați nuggets din amestecul obținut." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Stropiți cu puțin ulei." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți în air fryer la 200°C pentru 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Întoarceți la jumătatea timpului." }
                }
            },
            // === Batch 4 ===
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Chifle pufoase",
                Description = "Chifle de casă pufoase și moi, perfecte pentru sandvișuri sau servite cu unt.",
                ImageUrl = "/uploads/chifle-pufoase.png",
                PrepTime = TimeSpan.FromMinutes(50),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină 000", Amount = 880, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 400, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 120, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 20, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie", Amount = 30, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei/unt", Amount = 50, Unit = "ml", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Încălziți laptele cu apa la 37°C, adăugați drojdia și lăsați 10 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați restul ingredientelor și frământați 5 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Lăsați la dospit 25 minute până se dublează volumul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Formați bilute și așezați-le în tavă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți 10 min la 250°C, apoi 10 min la 200°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Chifle simple",
                Description = "Chifle clasice de casă cu ulei de măsline, ușor de preparat.",
                ImageUrl = "/uploads/chifle.png",
                PrepTime = TimeSpan.FromMinutes(120),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 10,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 75, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 25, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie", Amount = 1, Unit = "cub", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 500, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați lichidele, zahărul, sarea, făina și drojdia timp de 3 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Lăsați aluatul să crească minimum 1 oră." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Formați bilute și așezați-le în tavă tapetată." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Lăsați încă 1 oră să crească." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Ungeți cu ou, presărați semințe și coaceți la 200°C, 15-20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Chifteluțe din piure",
                Description = "Chifteluțe crocante din piure de cartofi cu cașcaval, coapte la cuptor.",
                ImageUrl = "/uploads/chiftelute-din-piure.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(22),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Piure de cartofi", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Cașcaval ras", Amount = 80, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 60, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Curcuma", Amount = 0.5, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Susan", Amount = 1, Unit = "lingură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați piureul, oul, făina, curcuma și cașcavalul ras." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Cu mâinile umezite, formați bilute de aluat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Așezați-le în tavă tapetată cu hârtie de copt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Ungeți cu gălbenuș și presărați susan." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți 20-22 minute la 190°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ciocolată de casă",
                Description = "Ciocolată de casă cu lapte praf, cacao, nuci și stafide - un desert nostalgic.",
                ImageUrl = "/uploads/ciocolata-de-casa.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(10),
                Servings = 12,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt 82%", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 100, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte praf", Amount = 350, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 40, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 50, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți apa, zahărul și untul 5-7 minute. Opriți focul și lăsați să se răcească." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Cerneți laptele praf cu cacao într-un castron." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați lichidul răcit treptat peste ingredientele solide, amestecând bine." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați nucile și stafidele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Formați un baton în folie alimentară și dați la frigider 4-5 ore." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ciorbă de măcriș",
                Description = "Ciorbă tradițională de vară cu măcriș proaspăt, orez și smântână, rețeta bunicii.",
                ImageUrl = "/uploads/ciorba-de-macris.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Măcriș", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcov", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Orez", Amount = 50, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenuș", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Lămâie", Amount = 1, Unit = "bucată", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți morcovul ras în puțină apă cu ulei." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați măcrișul curățat, orezul, usturoiul și apa." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Fierbeți până orezul e gata." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Dreseți cu smântâna amestecată cu gălbenușul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Acriți cu zeamă de lămâie și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ciulamă de ciuperci",
                Description = "Ciulamă cremoasă de ciuperci cu smântână, perfectă servită cu mămăliguță.",
                ImageUrl = "/uploads/ciulama-ciuperci.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ciuperci", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 50, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 90, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână de gătit", Amount = 100, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Supă concentrat", Amount = 1, Unit = "litru", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel", Amount = 1, Unit = "legătură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ciupercile cu sare 12 minute la 100°C." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Scoateți ciupercile și rumenițifăina 4 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați supa și gătiți 12-15 minute, apoi smântâna." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți ciupercile înapoi și amestecați 3 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Adăugați pătrunjelul tocat și serviți cu mămăliguță." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Clafoutis de banane",
                Description = "Desert franțuzesc ușor și pufos cu banane caramelizate, copt la cuptor.",
                ImageUrl = "/uploads/clafoutis-de-banane.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Banane", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt topit", Amount = 50, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 80, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte gras", Amount = 250, Unit = "ml", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Ungeți vasele cu unt și puneți feliile de banane pe fund." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați făina cu ouăle fără cocoloașe." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați untul topit și laptele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Împărțiți compoziția în vase." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți 35-40 minute la 180°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Cozonac",
                Description = "Cozonac tradițional românesc pufos cu nucă, cacao și rom, perfect pentru sărbători.",
                ImageUrl = "/uploads/cozonac.png",
                PrepTime = TimeSpan.FromMinutes(120),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 16,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină 000", Amount = 600, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 250, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 4, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt moale", Amount = 80, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 150, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie", Amount = 30, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 400, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 30, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Rom", Amount = 20, Unit = "ml", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Încălziți laptele la 37°C, adăugați drojdia și lăsați 5 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați zahărul, untul, gălbenușurile, romul și frământați 8 minute cu făina." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Lăsați să dospească până își dublează volumul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Pentru umplutură: bateți albușurile spumă, adăugați zahărul, cacaoa și nucile." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Întindeți aluatul, puneți umplutura, rulați și împletiți. Coaceți 40-45 min la 180°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Creveți cu paste",
                Description = "Paste cu creveți în sos cremos de unt, usturoi și lămâie.",
                ImageUrl = "/uploads/creveti-cu-paste.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Creveți cruzi curățați", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Paste", Amount = 500, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 12, Unit = "căței", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Lămâie (coajă și zeamă)", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Parmezan", Amount = 50, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Puneți apa la fiert pentru paste." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Topiți untul cu uleiul, adăugați usturoiul pisat și sotați 2-3 minute pe foc mic." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați creveții, zeama și coaja de lămâie, gătiți 5-6 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Strecoarați pastele al dente și adăugați în sosul de creveți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Amestecați cu parmezan ras și serviți imediat." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Empanadas",
                Description = "Plăcințele sărate cu aluat fraged din unt și smântână, umplute după preferință.",
                ImageUrl = "/uploads/empanadas.png",
                PrepTime = TimeSpan.FromMinutes(135),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Spaniolă",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt 82%", Amount = 110, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 150, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 90, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenuș pentru uns", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe (chimen, susan, mac)", Amount = 1, Unit = "lingură", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați untul rece cu făina, apoi adăugați smântâna." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Formați o bilă, acoperiți cu folie și dați la frigider 2 ore." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți aluatul la 3-4mm, decupați cercuri și umpleți cu ce doriți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Închideți și presați marginile cu furculița, ungeți cu gălbenuș." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Presărați semințe și coaceți la 200°C, 20-30 minute." }
                }
            },
            // === Batch 5 ===
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Găluște cu prune",
                Description = "Desert tradițional cu găluște pufoase din cartofi, umplute cu prune și tăvălite în pesmet prăjit.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Cartofi fierți", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Prune", Amount = 15, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 3, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Pesmet", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți cartofii în coajă, curățați-i și pisați-i." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați cu zahăr, sare și făină până se formează un aluat potrivit." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Scoateți sâmburii din prune, puneți zahăr în mijloc și înfășurați în aluat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Fierbeți găluștele în apă cu sare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Prăjiți pesmetul cu zahăr în ulei și tăvăliți găluștele." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Hummus cu roșii coapte",
                Description = "Hummus cremos cu tahini și iaurt, servit cu roșii coapte, măsline și feta.",
                ImageUrl = "/uploads/hummus-cu-rosii-coapte.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Mediteraneană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Năut", Amount = 400, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Tahini", Amount = 80, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 60, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt grecesc", Amount = 60, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii", Amount = 4, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Măsline Kalamata", Amount = 50, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Feta", Amount = 100, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Mixați năutul cu tahini, ulei, iaurt, apă și condimente până obțineți o pastă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Tăiați roșiile în jumătăți, adăugați măslinele, feta și năut." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Condimentați și coaceți la 200°C pentru 15-20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți hummusul pe farfurie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Adăugați roșiile coapte, castravete și feta deasupra." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Lasagna cu dovlecei",
                Description = "Lasagna sănătoasă cu felii de dovlecei în loc de foi de paste, cu pui și brânzeturi.",
                ImageUrl = "/uploads/lasagna-cu-dovlecei.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(50),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Dovlecei", Amount = 4, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui tocat", Amount = 1, Unit = "kg", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Sos de roșii", Amount = 500, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză de vaci", Amount = 500, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Mozzarella", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tăiați dovleceii pe lungime în felii subțiri și grilaț-i 3-4 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți ceapa, adăugați carnea de pui și sosul de roșii, fierbeți 10 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați brânza dulce cu ouăle și puțină mozzarella." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Asamblați: dovlecei, sos de brânză, carne. Repetați și terminați cu mozzarella." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Coaceți la 180°C, 40-50 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Orez mexican",
                Description = "Orez aromat cu legume și condimente mexicane, un fel principal consistent.",
                ImageUrl = "/uploads/orez-mexican.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Mexicană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Orez", Amount = 1, Unit = "cană", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Morcov", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ardei kapia", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Legume congelate", Amount = 450, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Curry", Amount = 1, Unit = "linguriță", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Garam masala", Amount = 1, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți usturoiul, ceapa, ardeiul și morcovul cu orezul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați condimentele și amestecați bine." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Puneți legumele congelate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați apa treptat, câte puțin." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Lăsați să fiarbă până se absoarbe tot lichidul." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pancakes",
                Description = "Clătite americane pufoase cu iaurt și mere, perfecte pentru micul dejun.",
                ImageUrl = "/uploads/pancakes.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt grecesc", Amount = 140, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 200, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 50, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mere", Amount = 2, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Bicarbonat", Amount = 0.5, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați ouăle cu iaurtul și laptele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați uleiul, făina și bicarbonatul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Radeți merele și adăugați în aluat cu scorțișoară." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Prăjiți în tigaie antiaderentă pe ambele părți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Serviți cu miere sau sirop de arțar." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pui cu miere și usturoi",
                Description = "Pui dulce-sărat cu miere, sos de soia și usturoi, gătit la slow cooker.",
                ImageUrl = "/uploads/pui-cu-miere-si-usturoi.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(180),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Asiatică",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Sos de soia", Amount = 120, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ketchup", Amount = 120, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 120, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 6, Unit = "căței", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Susan", Amount = 2, Unit = "linguri", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tăiați carnea cubulețe de 1cm și puneți în slow cooker." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați sosul de soia, miere, ketchup, condimente și usturoi pisat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați sosul peste carne și gătiți pe HIGH 3 ore sau LOW 5-6 ore." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați 2 linguri de amidon, amestecați și gătiți încă 30 minute pe HIGH." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Serviți cu orez, ceapă verde și susan." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Salată Caesar",
                Description = "Salată clasică cu piept de pui, crutoane crocante și dressing cremos de parmezan.",
                ImageUrl = "/uploads/salata-caesar.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Salată romaine", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Pâine pentru crutoane", Amount = 2, Unit = "felii", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Parmezan", Amount = 40, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Muștar", Amount = 1, Unit = "lingură", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 50, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Lămâie", Amount = 1, Unit = "bucată", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Preparați pieptul de pui la cuptor sau la grătar." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Faceți crutoanele din pâine cu sare, piper, ulei și usturoi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Pentru dressing: mixați muștar, zeamă de lămâie, ulei și parmezan." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Spălați și rupeți salata în bucăți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Amestecați salata cu dressingul, adăugați puiul și crutoanele." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Somon cremos toscan",
                Description = "File de somon în sos cremos cu spanac, roșii cherry și usturoi.",
                ImageUrl = "/uploads/somon-cremos-toscan.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 2,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de somon", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Spanac", Amount = 1, Unit = "cub", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 4, Unit = "căței", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Vin alb", Amount = 100, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii cherry", Amount = 6, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 20, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 100, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Prăjiți somonul în tigaie până se formează o crustă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți usturoiul zdrobit, adăugați roșiile feliate și spanacul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați vinul și lăsați 1-2 minute, apoi adăugați smântâna." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "După 3 minute puneți somonul înapoi și gătiți la foc mic 5 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Adăugați mărar și fulgi de chili și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă cremă de ciuperci",
                Description = "Supă cremă catifelată de ciuperci cu cartofi și smântână, servită cu crutoane.",
                ImageUrl = "/uploads/supa-crema-de-ciuperci.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ciuperci champignon", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 3, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 5, Unit = "căței", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 30, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 100, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ușor ceapa, apoi ciupercile 4-5 minute, usturoiul și cartofii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Condimentați și adăugați apă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Fierbeți 20-30 minute până cartofii sunt gata." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Pasați supa bine și adăugați smântâna." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Serviți cu verdeață proaspătă și crutoane." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tort de morcovi",
                Description = "Tort umed și aromat cu morcovi, nuci și scorțișoară, cu cremă de mascarpone și caramel.",
                ImageUrl = "/uploads/tort-de-morcovi.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(50),
                Servings = 12,
                Difficulty = Difficulty.Hard,
                CuisineType = "Americană",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Morcovi rași", Amount = 300, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 260, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr brun", Amount = 200, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 160, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 1.5, Unit = "linguriță", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 500, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Frișcă", Amount = 200, Unit = "ml", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați făina, praful de copt, bicarbonatul și scorțișoara." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mixați uleiul cu ouăle și zahărul, adăugați făina, morcovii și nucile." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți la 180°C timp de 50 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Pentru cremă: bateți untul cu zahăr pudră, adăugați mascarpone și frișca." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Asamblați tortul în straturi și decorați cu caramel sărat." }
                }
            },
            // Batch 6: Fasole pargalita - Mamaliga cremoasa cu legume
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Fasole pârgălită",
                Description = "Fasole frecată tradițională cu sos de boia și usturoi, un preparat de post reconfortant.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Fasole fiartă", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 3, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 1, Unit = "lingură", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Boia dulce", Amount = 1, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 4, Unit = "căței", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel", Amount = 1, Unit = "legătură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Încălziți uleiul într-o crătiță și adăugați făina, boia și usturoiul pisat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Turnați zeama de fasole și amestecați până se omogenizează." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați fasolea frecată și amestecați continuu." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Condimentați cu sare și usturoi după gust, presărați pătrunjel." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ficat și costită cu cimbru",
                Description = "Ficat de miel cu costită, cartofi și sos de roșii aromat cu cimbru.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ficat de miel", Amount = 340, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi mici", Amount = 500, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Sunca neafumată", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii conservă", Amount = 400, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Măr", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 30, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Cimbru", Amount = 1, Unit = "ramură", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți cartofii 10 minute, tăiați-i în două și prăjiți-i până devin aurii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Presărați ficatul cu sare, piper și boia, rumetiți în unt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Rumetiți costița cu ceapa și usturoiul, adăugați mărul și roșiile cu cimbru." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți cartofii în sos, aranjați ficatul deasupra și încălziți 3-4 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ficăței în sos de rodie",
                Description = "Ficăței de pui în sos de rodie cu sumac, o rețetă orientală savuroasă.",
                ImageUrl = "/uploads/ficatei-in-sos-de-rodie.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Orientală",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ficăței de pui", Amount = 800, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 6, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 6, Unit = "căței", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sirop de rodie", Amount = 8, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Sumac", Amount = 2, Unit = "lingurițe", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Opăriți ficăteii 1-2 minute în apă cu oțet și scorțișoară, apoi uscați-i bine." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți ceapa în ulei până se caramelizează, adăugați usturoiul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați ficăteii și sotați la foc mare până se rumenesc." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Turnați siropul de rodie, condimentați cu sumac și piper, gătiți 3-4 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Frigărui de miel",
                Description = "Frigărui de miel marinate în pastă de ardei cu condimente și legume, gătite pe grătar.",
                ImageUrl = "/uploads/frigarui-de-miel.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Carne de miel", Amount = 600, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ardei copți", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Chimion", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mentă", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți marinada din pastă de ardei copți, iaurt, ulei și condimente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Marinați carnea de miel peste noapte în frigider." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "A doua zi adăugați legumele pentru frigărui și amestecați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Gătiți pe grătar până se rumenesc uniform." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Fursecuri cu miere și unt de arahide",
                Description = "Fursecuri simple și sănătoase cu doar 4 ingrediente, perfecte pentru gustări.",
                ImageUrl = "/uploads/fursecuri-cu-miere-si-unt-de-arahide.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(10),
                Servings = 20,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt de arahide", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați untul de arahide cu mierea, apoi adăugați oul și făina." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Modelați aluatul în formă de semilună cu capetele mai subțiri." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți la 180°C pentru 10 minute până marginile devin aurii." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ghismana",
                Description = "Budincă sărată cu iaurt, griș și dovlecel, perfectă pentru micul dejun.",
                ImageUrl = "/uploads/ghismana.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 170, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Griș", Amount = 50, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Dovlecel", Amount = 40, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe de susan", Amount = 1, Unit = "lingură", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați iaurtul cu oul, adăugați grișul și condimentele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Turnați în tava tapetată, puneți dovlecelul și semințele de susan deasupra." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți la 180°C pentru 35-40 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Glazură la rece",
                Description = "Glazură simplă de cacao pentru prăjituri, pregătită la rece.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(5),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 1,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Apă caldă", Amount = 3, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Oțet", Amount = 2, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 3, Unit = "linguri", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați bine toate ingredientele până obțineți o glazură omogenă." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Gogoși ou de bou cu brânză",
                Description = "Gogoși pufoase tradiționale cu umplutură de brânză dulce și stafide.",
                ImageUrl = "/uploads/gogosi-ou-de-bou-cu-branza.png",
                PrepTime = TimeSpan.FromMinutes(90),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 24,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 750, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 350, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 125, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 4, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie", Amount = 30, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză de vaci", Amount = 500, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Griș", Amount = 100, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Stafide", Amount = 100, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți aluatul din lapte, drojdie, zahăr, făină și gălbenușuri, lăsați la dospit." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Pentru umplutură amestecați brânza cu ouăle, zahărul, grișul și stafidele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți aluatul, decupați discuri și formați cavități în centru." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Ungeți cu ou, umpleți cu brânză și coaceți la 170°C pentru 25 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Grisine cu dovleac",
                Description = "Grisine fragede cu dovleac și mozzarella, perfecte ca aperitiv.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 10,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Dovleac", Amount = 1, Unit = "felie", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Mozzarella", Amount = 50, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 250, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe de susan", Amount = 1, Unit = "lingură", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Topiți untul, adăugați mozzarella, uleiul și dovleacul, mărunțiți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina și frământați 4 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Modelați grisinele și coaceți la 180°C pentru 30-40 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Înghețată de căpșuni",
                Description = "Înghețată rapidă și sănătoasă cu căpșuni, banane și mascarpone.",
                ImageUrl = "/uploads/inghetata-de-capsuni.png",
                PrepTime = TimeSpan.FromMinutes(5),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Banane congelate", Amount = 80, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni congelate", Amount = 80, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 50, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sirop de arțar", Amount = 10, Unit = "g", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Puneți toate ingredientele în blender și amestecați până se omogenizează." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Lasagna cu hribi și spanac",
                Description = "Lasagna vegetariană cu sos de hribi, spanac și sos béchamel cremos.",
                ImageUrl = "/uploads/lasagna-cu-hribi-si-spanac.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Foi de lasagna", Amount = 300, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Hribi congelați", Amount = 400, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Spanac baby", Amount = 1, Unit = "caserolă", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii conservă", Amount = 760, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 500, Unit = "ml", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 50, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Mozzarella", Amount = 200, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Parmezan", Amount = 100, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți sosul béchamel din unt, făină și lapte, adăugați parmezan." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți ceapa, adăugați spanacul, hribii și roșiile, gătiți 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Asamblați lasagna în straturi: béchamel, foi, sos, mozzarella." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți acoperit la 180°C 25-30 minute, apoi descoperit la 200°C 10 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Legume de vară la cuptor",
                Description = "Legume de sezon coapte la cuptor cu usturoi, servite cu mujdei de roșii.",
                ImageUrl = "/uploads/legume-de-vara.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Dovlecei", Amount = 300, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ciuperci", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 300, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ardei kapia", Amount = 3, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Feliați legumele și sărați-le, lăsați cartofii și dovleceii să se scurgă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți ceapa și ardeii la 220°C pentru 7 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați restul legumelor și coaceți 20 minute, apoi la 200°C încă 15-20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Serviți cu mujdei de roșii (roșie rasă cu usturoi și ulei)." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Limbi de pisică",
                Description = "Biscuiți delicați din albușuri, crocanti și ușori ca fulgii.",
                ImageUrl = "/uploads/limbi-de-pisica.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 20,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Vanilie", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Spumați untul cu zahărul și vanilia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina treptat, apoi albușurile și mixați până obțineți o compoziție aerată." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți cu pușul pe tavă și coaceți la 180°C pentru 15-20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Magdalene (briose)",
                Description = "Briose spaniole pufoase cu aromă de lămâie, perfecte pentru ceai sau cafea.",
                ImageUrl = "/uploads/magdalene-briose.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 24,
                Difficulty = Difficulty.Easy,
                CuisineType = "Spaniolă",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Coajă de lămâie", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 170, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 170, Unit = "ml", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 270, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Praf de copt", Amount = 1, Unit = "plic", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Mixați zahărul cu coaja de lămâie, adăugați ouăle, laptele și uleiul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina cu praful de copt și amestecați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați în forme, presărați zahăr deasupra și coaceți la 180°C pentru 20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Mămăligă cremoasă cu legume",
                Description = "Mămăligă cremoasă cu brânză de capră servită cu legume de rădăcină coapte.",
                ImageUrl = "/uploads/mamaliga-cremoasa-cu-legume.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Mălai", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 200, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză de capră", Amount = 50, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Cartof dulce", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sfeclă", Amount = 2, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 2, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Păstârnac", Amount = 1, Unit = "bucată", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți legumele tăiate cu ulei și condimente, coaceți la 190°C pentru 40 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Fierbeți apa cu laptele, adăugați mălaiul în ploaie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Luați de pe foc, adăugați untul și brânza de capră." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Serviți mămăliga cu legumele coapte și pesto." }
                }
            },
            // Batch 7: Mancare chinezeasca - Papanasi fierti
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Mâncare chinezească",
                Description = "Pui stir-fry cu legume în sos de soia și stridii, gătit rapid în wok.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Asiatică",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 400, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Legume amestec", Amount = 400, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Sos de soia", Amount = 3, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sos de stridii", Amount = 2, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 4, Unit = "căței", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ghimbir", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Marinați puiul tăiat bucățele cu sos de soia și usturoi 20-30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți puiul în tigaia încinsă până se rumenește, dați deoparte." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați legumele în ordinea timpului de gătire." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți puiul înapoi, adăugați sosul de stridii și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Mere cremoase la cuptor",
                Description = "Desert simplu cu mere coapte în cremă de smântână și gălbenușuri.",
                ImageUrl = "/uploads/mere-cremoase.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(50),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Mere", Amount = 4, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 3, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 250, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 30, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Nucă măcinată", Amount = 30, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Curățați merele și coaceți-le 20 minute la 180°C." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați gălbenușurile cu smântâna, untul și condimentele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați crema peste mere și mai coaceți 30 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Mușchiuleț de porc cu sos de mere și pere",
                Description = "Mușchiuleț fraged de porc gătit lent cu fructe caramelizate.",
                ImageUrl = "/uploads/muschiulet-de-porc-cu-sos-de-mere-si-pere.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(100),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Mușchiuleț de porc", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Pere", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Mere", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 2, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Zeamă de lămâie", Amount = 0.5, Unit = "bucată", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ceapa și amestecați cu fructele tăiate, puneți într-o tavă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Așezați carnea condimentată peste fructe." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți acoperit la 160°C pentru 1.5 ore, apoi 10 minute descoperit la 190°C." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Pasați fructele pentru sos și serviți cu piure de cartofi." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Napolitane cu caramel și nucă",
                Description = "Desert clasic românesc cu foi de napolitană și cremă caramel cu nucă.",
                ImageUrl = "/uploads/napolitane-cu-caramel-si-nuca.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(10),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Nucă mărunțită", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr tos", Amount = 250, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 200, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 150, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Foi napolitană", Amount = 3, Unit = "bucăți", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Spumați untul cu zahăr pudră, adăugați ouăle pe rând." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Caramelizați zahărul tos și adăugați nuca." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Combinați cele două compoziții și întindeți între foile de napolitană." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Lăsați la rece câteva ore înainte de tăiere." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Nuggets de pui la Air Fryer",
                Description = "Nuggets crocante de pui făcute la air fryer, mai sănătoase decât cele prăjite.",
                ImageUrl = "/uploads/nuggets-pui.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(8),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Pesmet", Amount = 150, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Boia", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Condimentați carnea cu piper, usturoi și boia, marinați 10 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Tăvăliți prin făină, ou bătut și pesmet." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Stropiți cu ulei și gătiți la air fryer 200°C pentru 8 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Orez cu lapte egiptean",
                Description = "Orez cu lapte cremos în stil egiptean cu cocos și fructe uscate.",
                ImageUrl = "/uploads/orez-cu-lapte-egiptean.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Orientală",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Orez bob rotund", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 1.5, Unit = "l", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru frișcă", Amount = 120, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 130, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Cocos", Amount = 30, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 50, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Înmuiați orezul 15 minute în apă și scurgeți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Topiți untul, adăugați laptele, orezul, smântâna, zahărul și cocosul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Gătiți la foc mic 30 minute amestecând ocazional." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Serviți decorat cu fructe uscate după gust." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pâine în Ninja",
                Description = "Pâine de casă pregătită în multicooker Ninja, cu amestec de făină integrală.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(120),
                CookTime = TimeSpan.FromMinutes(60),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină tip 550", Amount = 300, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină integrală", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie uscată", Amount = 1, Unit = "plic", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 350, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 10, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 25, Unit = "ml", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați apa cu drojdia, adăugați făina, sarea și uleiul, frământați 4 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Lăsați aluatul să dospească 1 oră, apoi stretch and fold, încă 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Puneți în Ninja, faceți aburi 2-3 minute, apoi coaceți la 190°C 15 minute, 180°C 25 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Întoarceți și mai coaceți 15 minute la 190°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pâine integrală",
                Description = "Pâinici integrale pufoase făcute în casă cu făină din 7 cereale.",
                ImageUrl = "/uploads/paine-integrala.png",
                PrepTime = TimeSpan.FromMinutes(150),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină integrală", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie", Amount = 7, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 325, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 1, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe de susan", Amount = 2, Unit = "linguri", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați drojdia cu apa și zahărul, adăugați făina și sarea, frământați 3 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Lăsați aluatul la dospit 2 ore până își dublează volumul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Formați pâinile, presărați susan și mai lăsați 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți la 180°C pentru 30 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pâine la Air Fryer",
                Description = "Pâine fără frământare coaptă la air fryer, simplă și rapidă.",
                ImageUrl = "/uploads/paine-la-airfryer.png",
                PrepTime = TimeSpan.FromMinutes(120),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Apă călduță", Amount = 200, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie uscată", Amount = 5, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați apa cu drojdia, lăsați 15 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina și uleiul, amestecați cu spatula, lăsați la dospit 1.5-2 ore." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Transferați în vas uns, lăsați să crească din nou." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Crestați și coaceți la 180°C timp de 25-30 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pâinici crocante",
                Description = "Pâinici crocante de casă cu crustă aurie și miez pufos.",
                ImageUrl = "/uploads/painici-crocante.png",
                PrepTime = TimeSpan.FromMinutes(120),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 9,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 600, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 340, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie proaspătă", Amount = 20, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 2, Unit = "lingurițe", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați apa cu drojdia, adăugați făina și frământați 2 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Lăsați aluatul la dospit 1 oră până se dublează." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Împărțiți în 3 bucăți și lăsați încă o oră să crească." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Crestați, pudrați cu făină și coaceți la 250°C cu vas de apă, 20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pâinici naan cu brânză",
                Description = "Lipii indiene naan umplute cu brânză și usturoi.",
                ImageUrl = "/uploads/painici-naan-cu-branza.png",
                PrepTime = TimeSpan.FromMinutes(150),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Indiană",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină de pâine", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte cald", Amount = 200, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt gras", Amount = 120, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie uscată", Amount = 10, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 5, Unit = "căței", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Frământați aluatul și lăsați la dospit 45 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Stretch and fold, lăsați încă 45 minute, apoi împărțiți în 8 bile." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Aplatizați fiecare bilă, puneți brânza și sigilați bine." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Prăjiți în tigaie încinsă pe ambele părți și ungeți cu unt și pătrunjel." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pancakes cu banane și afine",
                Description = "Pancakes sănătoase cu banane, ovăz și afine, perfecte pentru micul dejun.",
                ImageUrl = "/uploads/pancakes-cu-banane-si-afine.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Banane coapte", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Fulgi de ovăz", Amount = 60, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 2, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Afine", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe de mac", Amount = 1, Unit = "lingură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pasați bananele cu furculița." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați ouăle, uleiul, semințele, ovăzul și făina." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți la foc mic în tigaie antiaderentă încinsă." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pancakes cu burduf și ceapă verde",
                Description = "Pancakes sărate cu brânză burduf, ceapă verde și mărar.",
                ImageUrl = "/uploads/pancakes-cu-burduf.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză burduf", Amount = 120, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 130, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 130, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă verde", Amount = 3, Unit = "fire", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mărar", Amount = 1, Unit = "legătură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Sfărâmați brânza și amestecați cu laptele și uleiul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina, ceapa și mărarul fără a insista prea mult." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți în tigaie antiaderentă, întoarceți când face bule." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pancakes cu sfeclă și mascarpone",
                Description = "Pancakes colorate cu sfeclă roșie servite cu cremă de mascarpone și scorțișoară.",
                ImageUrl = "/uploads/pancakes-cu-sfecla.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 50, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sfeclă roșie fiartă", Amount = 1, Unit = "mică", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați gălbenușurile cu laptele, făina și sfecla rasă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Incorporați albușurile bătute spumă cu mișcări ușoare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți în tigaie antiaderentă și serviți cu mascarpone și scorțișoară." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Papanași fierți",
                Description = "Papanași tradiționali fierți cu brânză de vaci, tăvăliți în pesmet prăjit.",
                ImageUrl = "/uploads/papanasi-fierti.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Brânză de vaci", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Griș", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 15, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Pesmet", Amount = 80, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 20, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Rumetiți pesmetul în unt, adăugați zahăr la final." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați brânza cu grișul, oul și zahărul, lăsați 20-30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Formați bile cu mâna udă și fierbeți în apă cu sare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Tăvăliți prin pesmet și serviți cu smântână și dulceață." }
                }
            },
            // Batch 8: Papanasi rapizi - Placinta cu mere si pere
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Papanași rapizi la cuptor",
                Description = "Papanași pufoși coaceți la cuptor, varianta mai sănătoasă a clasicilor prăjiți.",
                ImageUrl = "/uploads/papanasi-rapizi-la-cuptor.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză de vaci", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 5, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Griș", Amount = 4, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Unt topit", Amount = 2, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Praf de copt", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați ouăle cu brânza sfărâmată și zahărul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați grișul, untul topit, smântâna și praful de copt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Puneți compoziția în forme de brioșe și coaceți la 180°C pentru 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Serviți cu smântână și gem de căpșuni." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Paste cremoase cu sos alb",
                Description = "Paste cu bacon, capere și măsline în sos cremos de smântână și parmezan.",
                ImageUrl = "/uploads/paste-cremoase-cu-sos-alb.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Paste scurte", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Bacon cuburi", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Capere", Amount = 3, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Măsline", Amount = 5, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru gătit", Amount = 500, Unit = "ml", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Parmezan", Amount = 80, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți pastele al dente în apă cu sare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Sotați baconul, adăugați măslinele și caperele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați smântâna și parmezanul, lăsați la foc mic până se topește." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Amestecați cu pastele și serviți cu pătrunjel și parmezan extra." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Paste cu ciuperci la cuptor",
                Description = "Paste cu ciuperci coapte la cuptor, spanac și cremă de brânză.",
                ImageUrl = "/uploads/paste-cu-ciuperci-la-cuptor.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ciuperci", Amount = 400, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Cremă de brânză", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 1, Unit = "căpățână", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Paste", Amount = 300, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Spanac", Amount = 100, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Coaceți ciupercile cu ceapa, usturoiul și crema de brânză la cuptor." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Scoateți usturoiul din coajă și amestecați-l înapoi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați pastele fierte și spanacul, amestecați și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pate de fasole cu nuci și ceapă",
                Description = "Pate de post delicios din fasole albă cu nuci și ceapă caramelizată.",
                ImageUrl = "/uploads/pate-de-fasole-cu-nuci-si-ceapa.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Fasole albă conservă", Amount = 340, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 3, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Morcov", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Roșie", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 50, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Oțet balsamic", Amount = 30, Unit = "ml", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți jumătate din ceapă cu morcovul, usturoiul și roșia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați fasolea și pasați totul în blender." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Prăjiți nucile și adăugați-le în pate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Caramelizați restul de ceapă cu oțet balsamic și serviți deasupra." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pătrate cu merișoare (Cranberry Bars)",
                Description = "Prăjitură americană cu merișoare, blat sfărâmicios și topping crocant.",
                ImageUrl = "/uploads/patratele-cu-merisoare.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(55),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Merișoare", Amount = 340, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 240, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 170, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Praf de copt", Amount = 2, Unit = "lingurițe", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți merișoarele cu zahăr și apă 15 minute până se îngroașă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați făina cu zahăr, praf de copt și unt tăiat până devine sfărâmicios." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Presați jumătate din amestec în tavă, adăugați merișoarele și restul deasupra." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți la 175°C timp de 40 minute până se rumenește." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pere cremoase la cuptor",
                Description = "Desert simplu și rapid cu pere coapte în cremă de migdale.",
                ImageUrl = "/uploads/pere-cremoase.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Pere mari", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 70, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Migdale măcinate", Amount = 50, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sirop de arțar", Amount = 1, Unit = "lingură", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Curățați perele și tăiați-le cuburi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați oul cu untul topit și migdalele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați compoziția în vas, adăugați perele și coaceți la 200°C pentru 25 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Piept de pui la cuptor",
                Description = "Piept de pui condimentat bogat, copt la temperatură mare pentru o crustă perfectă.",
                ImageUrl = "/uploads/piept-de-pui-la-cuptor.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 750, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Boia dulce", Amount = 2, Unit = "lingurițe", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi granulat", Amount = 2, Unit = "lingurițe", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Chimion", Amount = 2, Unit = "lingurițe", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr brun", Amount = 3, Unit = "lingurițe", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 2, Unit = "linguri", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Scoateți pieptul de pui din frigider cu 3-4 ore înainte." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Ungeți carnea cu ulei și presărați amestecul de condimente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Preîncălziți cuptorul la 230°C și coaceți 20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pizza cu iaurt",
                Description = "Blat de pizza rapid făcut cu iaurt, perfect pentru pizza de casă rapidă.",
                ImageUrl = "/uploads/pizza-cu-iaurt.png",
                PrepTime = TimeSpan.FromMinutes(35),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 350, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 75, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie", Amount = 20, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 15, Unit = "ml", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Încălziți apa și dizolvați drojdia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați iaurtul, făina, sarea și uleiul, frământați 4 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Lăsați la dospit 25-30 minute și adăugați toppingul preferat." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pizza clasică",
                Description = "Pizza italiană autentică cu blat subțire și crocant.",
                ImageUrl = "/uploads/pizza.png",
                PrepTime = TimeSpan.FromMinutes(90),
                CookTime = TimeSpan.FromMinutes(9),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină tip 650", Amount = 300, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Drojdie uscată", Amount = 0.5, Unit = "lingură", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Apă călduță", Amount = 180, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 1.5, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați ingredientele și frământați 5-10 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Lăsați aluatul la dospit 60-90 minute până își dublează volumul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți blaturile și adăugați toppingul preferat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți la 230°C cu ventilație timp de 9 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Plăcintă cu mere și pere în aluat cu nuci",
                Description = "Plăcintă americană cu mere și pere în aluat sfărâmicios cu nuci.",
                ImageUrl = "/uploads/placinta-cu-mere-si-pere.png",
                PrepTime = TimeSpan.FromMinutes(90),
                CookTime = TimeSpan.FromMinutes(75),
                Servings = 10,
                Difficulty = Difficulty.Hard,
                CuisineType = "Americană",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci măcinate", Amount = 60, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt rece", Amount = 225, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Mere", Amount = 6, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Pere", Amount = 3, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 120, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Vanilie păstaie", Amount = 1, Unit = "bucată", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți aluatul din făină, nuci și unt, odihniți-l 45 minute la frigider." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți fructele cu zahăr și vanilie 10 minute, lăsați să se răcească." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Tapetați forma cu aluat, adăugați umplutura și decorați cu împletitură." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți la 220°C 15 minute, apoi la 190°C încă o oră." }
                }
            },
            // Batch 9: Porumb fiert - Pulpe de pui in sos gorgonzola
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Porumb fiert",
                Description = "Porumb fiert la aburi, simplu și delicios, perfect ca gustare de vară.",
                ImageUrl = "/uploads/porumb-fiert.png",
                PrepTime = TimeSpan.FromMinutes(5),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Știuleți de porumb", Amount = 6, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 1, Unit = "kg", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 30, Unit = "g", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Curățați știuleții de panușe și așezați-i la aburi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Gătiți la aburi 30 minute sau până sunt fragezi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Presărați sare, piper și unt după gust." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Prăjitură Crăiasa Zăpezii",
                Description = "Tort elegant în straturi cu cremă de vanilie, ciocolată și frișcă, decorat cu cocos.",
                ImageUrl = "/uploads/prajitura-craiasa-zapezii.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 12,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 6, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 6, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 300, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 600, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 225, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată neagră", Amount = 105, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru frișcă", Amount = 400, Unit = "ml", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Fulgi de cocos", Amount = 50, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Bateți albușurile spumă, adăugați zahărul și făina, coaceți la 160°C pentru 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Pregătiți crema din gălbenușuri, lapte și zahăr, împărțiți în două și adăugați ciocolată la jumătate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Asamblați: blat, cremă ciocolată, biscuiți, cremă vanilie, frișcă și cocos." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Prăjitură cu cremă de vișine",
                Description = "Prăjitură răcoroasă cu blat de cacao, cremă de vișine și glazură de ciocolată.",
                ImageUrl = "/uploads/prajitura-cu-crema-de-visine.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 12,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 5, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 3, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Vișine congelate", Amount = 800, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru frișcă", Amount = 500, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Gelatină", Amount = 30, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată pentru glazură", Amount = 125, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți blatul din ouă, zahăr, cacao și ulei, coaceți în două straturi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Fierbeți vișinele cu zahăr, pasați și amestecați cu gelatină și frișcă bătută." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Asamblați tortul cu blat, cremă, blat, cremă, apoi glazurați cu ciocolată." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Prăjitură cu budincă și biscuiți",
                Description = "Prăjitură stratificată cu blaturi de bezea, biscuiți și cremă fină de gălbenușuri.",
                ImageUrl = "/uploads/prajitura-cu-budinca-si-biscuiti.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 16,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 10, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 10, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 200, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Nucă de cocos", Amount = 75, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 75, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 250, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată", Amount = 300, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți două blaturi din albușuri bătute cu zahăr, făină și nucă/cocos." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Faceți crema din gălbenușuri, zahăr, lapte, unt și mascarpone." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Asamblați cu blaturi, cremă, biscuiți însiropați și ciocolată topită." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Prăjitură cu caise",
                Description = "Prăjitură tradițională cu caise sau piersici și bezea pufoasă deasupra.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Caise sau piersici", Amount = 1.5, Unit = "kg", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 350, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 250, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 10, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 400, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 5, Unit = "linguri", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți aluatul din făină, unt, zahăr și gălbenușuri, coaceți pe jumătate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Așezați feliile de fructe peste coca." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Bateți albușurile spumă cu zahăr, adăugați gălbenușurile și smântâna, turnați peste fructe." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți până se rumenește bezeaua." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Prăjitură cu mascarpone și fructe",
                Description = "Prăjitură pufoasă cu mascarpone și fructe proaspete de sezon.",
                ImageUrl = "/uploads/prajitura-cu-mascarpone.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 5, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 250, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 250, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 250, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Mere sau fructe", Amount = 3, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Coajă de lămâie", Amount = 1, Unit = "bucată", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Bateți albușurile spumă cu zahăr, adăugați gălbenușurile și mascarpone." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Incorporați făina cu mișcări ușoare de jos în sus." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați în formă, aranjați fructele feliate și coaceți la 180°C pentru 45 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Prăjitură Melba cu piersici și zmeură",
                Description = "Prăjitură elegantă cu pandișpan, cremă de iaurt grecesc, piersici și zmeură.",
                ImageUrl = "/uploads/prajitura-melba.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(12),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 190, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru frișcă", Amount = 500, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt grecesc", Amount = 500, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Piersici", Amount = 5, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Zmeură", Amount = 200, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Gelatină", Amount = 15, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Coaceți blatul de pandișpan la 180°C pentru 12 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați frișca bătută cu iaurt, fructe și gelatină." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați crema peste blat și decorați cu piersici și zmeură." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pui cu garam masala (Butter Chicken)",
                Description = "Pui indian clasic în sos cremos cu garam masala și nuci caju.",
                ImageUrl = "/uploads/pui-cu-garam-masala.png",
                PrepTime = TimeSpan.FromMinutes(120),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Indiană",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 80, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Garam masala", Amount = 2, Unit = "lingurițe", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 75, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci caju", Amount = 60, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Sos de roșii", Amount = 250, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 50, Unit = "ml", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Marinați puiul în iaurt cu condimente minimum 2 ore." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Prăjiți puiul la grătar sau tigaie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Pregătiți sosul din unt, paste de nuci caju, roșii și condimente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați smântâna și puiul, gătiți 5 minute și serviți cu orez." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pui cu lămâie (Scaloppine)",
                Description = "File de pui în stil italian cu sos de lămâie și unt.",
                ImageUrl = "/uploads/pui-cu-lamaie.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Fileuri piept de pui", Amount = 4, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Lămâi", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 40, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 75, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Supă de pui", Amount = 100, Unit = "ml", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Rozmarin", Amount = 1, Unit = "ramură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Condimentați puiul și dați-l prin făină, prăjiți în unt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Scoateți puiul și faceți sosul din unt, rozmarin, zeamă de lămâie și supă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Readăugați puiul în sos și serviți cu felii de lămâie." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pulpe de pui în sos gorgonzola",
                Description = "Pulpe de pui fragede în sos cremos de gorgonzola.",
                ImageUrl = "/uploads/pulpe-de-pui-gorgonzola.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Pulpe de pui", Amount = 8, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Frișcă", Amount = 200, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Gorgonzola", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Amidon", Amount = 2, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Condimente", Amount = 1, Unit = "lingură", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Rumetiți pulpele în tigaie, condimentați și gătiți în multicooker 40 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Diluați amidonul în frișcă și turnați peste pui." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați gorgonzola și gătiți încă 5 minute." }
                }
            },
            // Batch 10: Pulpe pui marinate - Salata cu cartofi
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Pulpe de pui marinate la Air Fryer",
                Description = "Pulpe de pui marinate în iaurt cu muștar și usturoi, crocante la air fryer.",
                ImageUrl = "/uploads/pulpe-pui-marinate-airfry.png",
                PrepTime = TimeSpan.FromMinutes(120),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Pulpe de pui superioare", Amount = 8, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt grecesc", Amount = 150, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Muștar", Amount = 2, Unit = "lingurițe", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 5, Unit = "căței", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Boia", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți marinada și acoperiți pulpele, lăsați 2-3 ore la rece." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Gătiți în multicooker 15 minute la presiune." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Finalizați 5-7 minute la air fryer pentru crustă." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Quiche cu praz",
                Description = "Quiche franțuzesc clasic cu praz, bacon și brânză cheddar.",
                ImageUrl = "/uploads/quiche-cu-praz.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(50),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Bacon", Amount = 6, Unit = "felii", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Praz", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză cheddar", Amount = 45, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 3, Unit = "linguri", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Frământați aluatul din făină și unt, odihniți 30 minute la rece." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți baconul cu prazul, amestecați ouăle cu smântâna și brânza." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Coaceți foaia de tartă 20 minute la 180°C, apoi adăugați umplutura." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți încă 15-30 minute până se coace umplutura." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Răcituri (Piftie)",
                Description = "Răcituri tradiționale românești din picioare de porc și ciolan afumat.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(120),
                Servings = 10,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Picioare de porc", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ciolan afumat", Amount = 0.5, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 1, Unit = "căpățână", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Foi de dafin", Amount = 3, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Piper boabe", Amount = 1, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Spălați bine carnea și fierbeți la presiune 5 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați condimentele și gătiți 25 minute la presiune, apoi 1 oră slow cook." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Reduceți zeama, adăugați usturoi pisat și turnați peste carne în recipiente." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ruladă cu banane",
                Description = "Ruladă de pandișpan cu cacao, cremă de mascarpone și banane.",
                ImageUrl = "/uploads/rulada-cu-banane.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(12),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 4, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 2.5, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 1.5, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru frișcă", Amount = 200, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Banane", Amount = 2, Unit = "bucăți", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Bateți gălbenușurile cu zahărul, incorporați albușurile bătute spumă, apoi făina și cacaoa." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți la 200°C pentru 10-12 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Bateți frișca cu mascarpone, întindeți peste foaie, adăugați bananele și rulați." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ruladă de bezea cu căpșuni",
                Description = "Ruladă elegantă de bezea cu cremă de mascarpone și căpșuni proaspete.",
                ImageUrl = "/uploads/rulada-de-bezea.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 10,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 6, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr tos", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 250, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru frișcă", Amount = 200, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Migdale", Amount = 50, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Bateți albușurile spumă, adăugați zahărul și continuați până obțineți bezea tare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Întindeți în tavă, presărați migdale și coaceți la 140°C pentru 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Răciți, întindeți crema de mascarpone cu frișcă, adăugați căpșunile și rulați." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ruladă de biscuiți cu cocos",
                Description = "Ruladă fără coacere din biscuiți mărunțiți cu cremă de cocos și mascarpone.",
                ImageUrl = "/uploads/rulada-de-biscuiti-cu-cocos.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 12,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Biscuiți Petit Beurre", Amount = 400, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 65, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 20, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 300, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 250, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Fulgi de cocos", Amount = 100, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Topiți untul cu laptele, zahărul și cacaoa, lăsați să se răcească." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mărunțiți biscuiții și amestecați cu compoziția lichidă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți, acoperiți cu cremă de cocos și mascarpone, rulați și răciți peste noapte." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Ruladă de porc cu gălbiori",
                Description = "Mușchiuleț de porc umplut cu gălbiori aromați, servit cu sos cremos.",
                ImageUrl = "/uploads/rulada-de-porc-cu-galbiori.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Mușchiuleț de porc", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbiori", Amount = 400, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Șalote", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel", Amount = 1, Unit = "legătură", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 150, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Fond de legume", Amount = 200, Unit = "ml", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți gălbiorii cu șalote și pătrunjel în unt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Deschideți mușchiulețul, umpleți cu gălbiori, rulați și legați cu ață." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Ungeți cu unt și coaceți la 200°C pentru 35-45 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Pentru sos, căliți gălbiori cu fond de legume și pasați cu blenderul." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Salam de biscuiți",
                Description = "Desert clasic românesc fără coacere cu biscuiți, nuci și cacao.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 12,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Biscuiți", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Margarină", Amount = 200, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 300, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 1, Unit = "lingură", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Esență de rom", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Sfărâmați biscuiții și amestecați cu nucile măcinate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Topiți margarina și amestecați cu laptele, cacaoa și esența de rom." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați peste biscuiți, amestecați și formați un rulou în celofan." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Salată cu cartofi dulci",
                Description = "Salată sățioasă cu cartofi dulci copți, quinoa, feta și dressing de miere-muștar.",
                ImageUrl = "/uploads/salata-cu-cartofi-dulci.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Cartof dulce", Amount = 1, Unit = "mare", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Quinoa", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Spanac baby", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză feta", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Muștar", Amount = 2, Unit = "lingurițe", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 2, Unit = "lingurițe", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tăiați cartoful dulce cuburi, condimentați și coaceți la 200°C pentru 40 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Fierbeți quinoa și murați ceapa în oțet." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați toate ingredientele și stropiți cu dressing de miere și muștar." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Salată cu cartofi crocanti",
                Description = "Salată de cartofi crocanti cu iaurt, verdeață și legume proaspete.",
                ImageUrl = "/uploads/salata-cu-cartofi.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 4, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Maioneză", Amount = 50, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Castravete", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 0.5, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mărar", Amount = 1, Unit = "legătură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți cartofii, tăiați-i și rumetiți-i la cuptor până devin crocanti." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați iaurtul cu maioneza, zeamă de lămâie și verdeață." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați cartofii tăiați și legumele, amestecați și serviți." }
                }
            },
            // Batch 11: Salata de avocado - Somon pe sare
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Salată de avocado cu ou",
                Description = "Salată cremoasă de avocado cu ouă fierte, bacon și cremă de brânză.",
                ImageUrl = "/uploads/salata-de-avocado-cu-ou.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(10),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă fierte", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Cremă de brânză", Amount = 1, Unit = "lingură", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Avocado", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel", Amount = 1, Unit = "legătură", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Bacon", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii", Amount = 2, Unit = "bucăți", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți ouăle tari și lăsați-le să se răcească." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Tăiați avocado și ouăle în cuburi, amestecați cu crema de brânză." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Prăjiți baconul crispy și adăugați-l peste salată împreună cu pătrunjel." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Salată de legume coapte",
                Description = "Salată caldă cu legume coapte la cuptor, năut, nuci și brânză feta.",
                ImageUrl = "/uploads/salata-de-legume-coapte.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Mediteraneană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Cartof dulce", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Sfeclă fiartă", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Morcov", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Țelină", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Năut", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 50, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză feta", Amount = 100, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Curățați legumele și tăiați-le în bucăți. Stropiți cu ulei, sare și piper." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți legumele la 180°C pentru 35-40 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați năutul, nucile, brânza feta și sosul de ulei cu usturoi și lămâie." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Șalău cu sos de capere",
                Description = "File de șalău prăjit cu sos cremos de unt, capere și lămâie.",
                ImageUrl = "/uploads/salau-cu-sos-de-capere.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 2,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de șalău", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Lămâie", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Capere", Amount = 20, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 150, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Vin alb", Amount = 100, Unit = "ml", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Mărar", Amount = 1, Unit = "legătură", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Condimentați fileurile cu sare și piper, dați-le prin făină și prăjiți-le în ulei." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Pentru sos, căliți ceapa în unt, adăugați vinul și reduceți. Încorporați restul de unt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați caperele, feliile de lămâie și mărarul. Turnați sosul peste pește." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Șalău de Nil cu sos de smântână",
                Description = "File de șalău fraged în sos cremos de smântână cu lămâie.",
                ImageUrl = "/uploads/salau-cu-sos-de-smantana.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de șalău", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 50, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână de gătit", Amount = 200, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lămâie", Amount = 1, Unit = "bucată", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Condimentați fileul cu sare și piper." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Topiți untul în tigaie și gătiți fileul 4-5 minute pe fiecare parte." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Scoateți peștele, adăugați smântâna și fierbeți 2-3 minute. Adăugați zeamă de lămâie și turnați peste pește." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Șalău de Nil la cuptor",
                Description = "File de șalău simplu și aromat, copt la cuptor cu usturoi și turmeric.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de șalău", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 3, Unit = "căței", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Turmeric", Amount = 1, Unit = "linguriță", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 1, Unit = "linguriță", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Piper", Amount = 0.5, Unit = "linguriță", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Condimentați fileul cu sare, piper, turmeric și usturoi tăiat felii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți la cuptor pentru 20 de minute la 160°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Salată Caesar",
                Description = "Salată Caesar clasică cu piept de pui, crutoane și dressing cremos de ansoa.",
                ImageUrl = "/uploads/salata-caesar.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 2,
                Difficulty = Difficulty.Medium,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Salată romaine", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Piept de pui", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Pâine pentru crutoane", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenuș", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Muștar", Amount = 1, Unit = "lingură", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Fileuri de ansoa", Amount = 5, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 50, Unit = "ml", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Parmezan", Amount = 40, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți pieptul de pui la cuptor și tăiați-l felii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Preparați crutoanele din pâine cu ulei și usturoi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați gălbenușul cu muștarul, ansoa, usturoi, ulei și parmezan pentru dressing." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Combinați salata cu dressingul, adăugați puiul și crutoanele." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Săratele cu leurdă și brânză de vaci",
                Description = "Gogoși pufoase cu leurdă proaspătă și brânză de vaci, coapte la cuptor.",
                ImageUrl = "/uploads/saratele-cu-leurda-si-branza.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Frunze de leurdă", Amount = 50, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză de vaci", Amount = 500, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 125, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 450, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Sare", Amount = 2, Unit = "lingurițe", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tocați leurda și amestecați-o cu brânza stoarsă, ouăle și untul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați făina și sarea, frământați aluatul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți aluatul în strat gros și tăiați forme rotunde." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți la 180°C pentru 30 minute până se rumenesc." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Sarmale",
                Description = "Sarmale tradiționale românești în foi de varză, cu carne tocată, orez și condimente.",
                ImageUrl = "/uploads/sarmale.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(180),
                Servings = 8,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Varză", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Carne tocată", Amount = 500, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Slănină sau carne afumată", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Orez bob rotund", Amount = 75, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Cimbru", Amount = 2, Unit = "linguri", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Boia", Amount = 1, Unit = "linguriță", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Suc de roșii", Amount = 500, Unit = "ml", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Opăriți varza în apă cu sare și oțet. Desprindeți foile de cotor." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți ceapa și amestecați-o cu carnea, orezul spălat și condimentele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Înfășurați compoziția în frunzele de varză." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Așezați sarmalele în oală cu varză tocată pe fund, adăugați carnea afumată și sucul de roșii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 5, Text = "Fierbeți la foc mic timp de 2-3 ore." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Snickers - Prăjitură cu nucă",
                Description = "Prăjitură bogată cu blat de bezea și nucă, cremă de caramel și glazură de ciocolată.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 12,
                Difficulty = Difficulty.Hard,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 8, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 320, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Nucă măcinată", Amount = 300, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 4, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 250, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Nucă tăiată și prăjită", Amount = 300, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 8, Unit = "bucăți", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată", Amount = 200, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Bateți albușurile cu zahărul pudră. Adăugați făina și nuca măcinată. Coaceți blatul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Caramelizați zahărul, adăugați nuca prăjită." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Fierbeți gălbenușurile cu untul pe abur, amestecați cu caramelul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți crema peste blat și glazurați cu ciocolată." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Somon cu salsa de mango și orez",
                Description = "Somon aromat cu miere și muștar, servit cu orez brun și salsa proaspătă de mango.",
                ImageUrl = "/uploads/somon-cu-salsa-de-mango.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 2,
                Difficulty = Difficulty.Medium,
                CuisineType = "Asiatică",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de somon", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Muștar", Amount = 1, Unit = "linguriță", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 1, Unit = "linguriță", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Sos de soia", Amount = 2, Unit = "linguri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Susan", Amount = 2, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mango", Amount = 0.5, Unit = "bucată", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Avocado", Amount = 0.5, Unit = "bucată", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 0.5, Unit = "bucată", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Orez brun", Amount = 200, Unit = "g", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați mierea cu muștarul și ungeți somonul. Presărați susan." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți somonul la 180°C pentru 20 minute. În ultimele 5 minute ungeți cu sos de soia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Pregătiți salsa: tăiați mango, avocado, ceapă, pătrunjel. Adăugați coajă și zeamă de lime." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Serviți somonul cu orezul și salsa de mango." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Somon în crustă de usturoi",
                Description = "File de somon cu crustă aromată de usturoi, pătrunjel și pesmet.",
                ImageUrl = "/uploads/somon-in-crusta.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 2,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de somon cu piele", Amount = 600, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 7, Unit = "căței", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel verde", Amount = 2, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 30, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Pesmet", Amount = 2, Unit = "linguri", Order = 5 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați usturoiul zdrobit cu pătrunjelul, uleiul și pesmetul pentru crustă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Ungeți somonul cu ulei, condimentați și aplicați crusta deasupra." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Prăjiți în tigaie cu pielea în jos 4 minute, apoi la cuptor la 200°C pentru 10 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Somon pe sare cu legume",
                Description = "Somon copt pe pat de sare grunjoasă cu legume de sezon sotate.",
                ImageUrl = "/uploads/somon-pe-sare.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Mediteraneană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de somon", Amount = 4, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Sare grunjoasă", Amount = 500, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Lămâie", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Vinete", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Zucchini", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 2, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Sparanghel", Amount = 200, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ciuperci", Amount = 200, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Rozmarin", Amount = 3, Unit = "crenguțe", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Puneți un strat gros de sare pe tavă. Așezați somonul deasupra cu felii de lămâie și rozmarin." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți la 180°C pentru 40 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Fierbeți morcovii și sparanghelul ușor, apoi sotați toate legumele în tigaie." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Serviți somonul cu legumele sotate." }
                }
            },
            // Batch 12: Sos Beurre Nantais - Tarta cu pere și alune
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Sos Beurre Nantais",
                Description = "Sos franțuzesc cremos de unt cu ceapă, lămâie și smântână, perfect pentru pește.",
                ImageUrl = "/uploads/sos-beurre-nantais.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ceapă albă", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zeamă de lămâie", Amount = 50, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 50, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână pentru frișcă", Amount = 50, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Unt 82%", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Piper alb", Amount = 1, Unit = "priză", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți ceapa rasă cu apa și zeama de lămâie până reduce la jumătate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Încorporați smântâna și fierbeți 2-3 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "La foc mic, adăugați treptat cubulețele de unt rece, amestecând continuu." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Condimentați cu piper alb și serviți călduț peste pește." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Sos din legume pentru paste",
                Description = "Sos cremos de legume coapte la cuptor, perfect pentru paste.",
                ImageUrl = "/uploads/sos-din-legume-pentru-paste.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ardei", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii", Amount = 3, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 2, Unit = "căței", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână de gătit", Amount = 100, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Oregano", Amount = 1, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Curățați și tăiați legumele în bucăți mari. Stropiți cu ulei și condimentați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți legumele la cuptor până se înmoaie și se rumenesc." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Blendeați legumele coapte cu smântâna până obțineți un sos cremos." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Spumă de căpșuni tratată termic",
                Description = "Spumă ușoară de căpșuni preparată termic, sigură pentru consum.",
                ImageUrl = "/uploads/spuma-de-capsuni-termic.png",
                PrepTime = TimeSpan.FromMinutes(5),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Piure de căpșuni", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 50, Unit = "g", Order = 3 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Bateți albușurile cu zahărul 7 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Continuați la 70°C timp de 12 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "În ultimele 2 minute adăugați piureul de căpșuni." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Spumă de căpșuni fără zahăr",
                Description = "Desert ușor de căpșuni cu mascarpone și ricotta, fără zahăr adăugat.",
                ImageUrl = "/uploads/spuma-de-capsuni-fara-zahar.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 2,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 2, Unit = "linguri", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ricotta", Amount = 2, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni mari", Amount = 10, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Banană coaptă", Amount = 1, Unit = "bucată", Order = 4 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Spălați și curățați căpșunile, tăiați-le în 4." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Puneți toate ingredientele în blender și mixați până obțineți o cremă fină." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Spumă de căpșuni",
                Description = "Spumă clasică de căpșuni cu albușuri bătute, desert românesc tradițional.",
                ImageUrl = "/uploads/spuma-de-capsuni.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(5),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 100, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni congelate", Amount = 300, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 2, Unit = "bucăți", Order = 3 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pulverizați zahărul, apoi adăugați căpșunile și mixați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați albușurile și bateți 4 minute până obțineți o spumă aerată." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă cremă de ciuperci",
                Description = "Supă cremă catifelată de ciuperci champignon cu cartofi și smântână.",
                ImageUrl = "/uploads/supa-crema-de-ciuperci.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ciuperci champignon", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 3, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 5, Unit = "căței", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 2, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 30, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 100, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ceapa ușor, apoi adăugați ciupercile 4-5 minute, usturoiul și la final cartofii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Condimentați și adăugați apă. Fierbeți 20-30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Blendeați supa bine și adăugați smântâna. Presărați verdeață proaspătă." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă cremă de leurdă și cartofi",
                Description = "Supă cremă verde și aromată de leurdă proaspătă cu cartofi.",
                ImageUrl = "/uploads/supa-crema-de-leurda.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 50, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Praz", Amount = 0.25, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi făinoși", Amount = 500, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Supă de pui", Amount = 1, Unit = "litru", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Frunze de leurdă", Amount = 200, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână de gătit", Amount = 4, Unit = "linguri", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ceapa și prazul în unt, adăugați cartofii cubulețe și supa." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Fierbeți 20 minute, adăugați leurda tăiată fâșii și fierbeți încă câteva minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Blendeați supa, adăugați smântâna și serviți cu crutoane." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă cremă de pere, mere și cartofi",
                Description = "Supă cremă dulce-sărată cu fructe de toamnă și mirodenii.",
                ImageUrl = "/uploads/supa-crema-fructe.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Praz", Amount = 2, Unit = "fire", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Pere", Amount = 1, Unit = "kg", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Mere", Amount = 200, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 50, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Supă de pui", Amount = 1.5, Unit = "litri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 2, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 1, Unit = "baton", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ghimbir", Amount = 0.5, Unit = "linguriță", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână", Amount = 200, Unit = "ml", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți prazul în unt, adăugați fructele și căliți 5 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Turnați supa, adăugați cartofii, mirodeniile și fierbeți 30 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Scoateți scorțișoara, adăugați smântâna și pasați fin." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă cremă de usturoi",
                Description = "Supă cremă aromată de usturoi cu conopidă și cartofi.",
                ImageUrl = "/uploads/supa-crema-de-usturoi.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 10, Unit = "căței", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 40, Unit = "ml", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Conopidă", Amount = 300, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 200, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 1, Unit = "litru", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Cremă de brânză", Amount = 40, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți usturoiul în ulei 5 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați apa, cartofii, conopida și fierbeți 25 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Blendeați cu crema de brânză. Serviți cu pâine prăjită." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă cremoasă de pui cu leurdă",
                Description = "Supă consistentă de pui cu legume rădăcinoase, leurdă și iaurt.",
                ImageUrl = "/uploads/supa-cu-leurda.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(60),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Carne de pui", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Păstârnac", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Țelină", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Leurdă", Amount = 100, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Salată verde", Amount = 100, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt gras", Amount = 100, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți carnea de pui cu legumele rădăcinoase și condimente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Strecurați, blendeați legumele, tocați carnea mărunt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Căliți ceapa, adăugați în supă cu salată și leurdă tocate. Serviți cu iaurt." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă de chimen",
                Description = "Supă aromată tradițională cu semințe de chimen și crutoane cu usturoi.",
                ImageUrl = "/uploads/supa-de-chimen.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel rădăcină", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 2, Unit = "litri", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Semințe de chimen", Amount = 10, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Boia dulce", Amount = 1, Unit = "linguriță", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 3, Unit = "linguri", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți legumele în apă 30 minute, apoi strecurați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Prăjiți chimenul în ulei, adăugați făina și boiaua." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați supa strecurată și fierbeți 5 minute. Serviți cu crutoane." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă de linte",
                Description = "Supă consistentă de linte roșie cu legume și condimente orientale.",
                ImageUrl = "/uploads/supa-de-linte.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Orientală",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ardei gras roșu", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 3, Unit = "căței", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 30, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Boia afumată", Amount = 1, Unit = "lingură", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Pastă de tomate", Amount = 2, Unit = "linguri", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Linte roșie", Amount = 200, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Orez", Amount = 50, Unit = "g", Order = 9 },
                    new() { Id = Guid.NewGuid(), Name = "Supă de pui", Amount = 2, Unit = "litri", Order = 10 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ceapa în unt și ulei, adăugați ardeiul și usturoiul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați condimentele, lintea, orezul și pasta de roșii. Amestecați." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați supa și fierbeți 30-40 minute. Pasați parțial sau complet." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă de roșii cu zdrențe de ou",
                Description = "Supă de roșii aromată cu zdrențe fine de ou și ierburi proaspete.",
                ImageUrl = "/uploads/supa-de-rosii.png",
                PrepTime = TimeSpan.FromMinutes(10),
                CookTime = TimeSpan.FromMinutes(25),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Pastă de roșii", Amount = 250, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Cimbru", Amount = 1, Unit = "legătură", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Busuioc", Amount = 1, Unit = "legătură", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 1, Unit = "linguriță", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți legumele în apă cu sare." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați bulionul și oul bătut în fir subțire. Puneți zahăr pentru a reduce aciditatea." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Presărați cimbru și busuioc proaspăt." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă de salată verde",
                Description = "Supă tradițională românească de salată cu zer, iaurt și mărar.",
                ImageUrl = "/uploads/supa-de-salata.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Salată", Amount = 2, Unit = "căpățâni", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă verde", Amount = 3, Unit = "fire", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 4, Unit = "căței", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zer sau lapte", Amount = 1, Unit = "litru", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Boia dulce", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 2, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 100, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Mărar", Amount = 1, Unit = "legătură", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Căliți ceapa și o parte din usturoi. Adăugați zerul și aduceți la clocot." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați salata curățată și condimentați cu boia." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați gălbenușurile cu iaurtul și usturoiul rămas. Turnați peste zeamă după ce stingeți focul." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Supă de pui cu leurdă",
                Description = "Supă hrănitoare de pui cu legume rădăcinoase și leurdă proaspătă.",
                ImageUrl = "/uploads/supa-pui-leurda.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(60),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Carne de pui", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 2, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel rădăcină", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Păstârnac", Amount = 1, Unit = "bucată", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Țelină", Amount = 100, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Leurdă", Amount = 100, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Salată", Amount = 100, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt gras", Amount = 100, Unit = "g", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți puiul cu legumele rădăcinoase și condimente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Strecurați, blendeați legumele în supă, tocați carnea." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Căliți ceapa, adăugați în supă cu salată și leurdă. La final iaurt gras." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tartă Banoffee",
                Description = "Tartă clasică engleză cu banane, dulce de leche și frișcă.",
                ImageUrl = "/uploads/tarta-banoffee.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(60),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Biscuiți digestivi", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 80, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Dulce de leche", Amount = 300, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Banane coapte", Amount = 2, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână 35%", Amount = 400, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Cremă de brânză", Amount = 100, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 50, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată", Amount = 15, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Zdrobiți biscuiții cu untul și întindeți în forma de tartă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați un strat de dulce de leche, apoi bananele feliate și restul de dulce de leche." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Bateți smântâna cu crema de brânză și zahărul. Turnați peste tartă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Radeți ciocolată deasupra și răciți minimum 20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tartă cu ceapă caramelizată și brânzeturi",
                Description = "Tartă savuroasă cu aluat fraged, ceapă caramelizată și mix de brânzeturi.",
                ImageUrl = "/uploads/tarta-ceapa-branzeturi.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Unt rece", Amount = 175, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenuș", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 3, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 1, Unit = "lingură", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mix de brânzeturi", Amount = 400, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 1, Unit = "bucată", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Chimen", Amount = 1, Unit = "linguriță", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Faceți aluatul frământând făina cu untul, gălbenușul și apă rece. Răciți 45 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Coaceți crusta oarbă la 180°C timp de 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Caramelizați ceapa cu miere. Amestecați brânzeturile cu albușul și chimenul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Umpleți crusta cu brânzeturi, puneți ceapa deasupra și coaceți încă 20 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tartă cu mere și pere în aluat cu nuci",
                Description = "Tartă de toamnă cu fructe căliți în vanilie, în aluat fraged cu nuci.",
                ImageUrl = "/uploads/tarta-mere-pere-nuci.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(75),
                Servings = 10,
                Difficulty = Difficulty.Hard,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci măcinate", Amount = 60, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt rece", Amount = 225, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Mere", Amount = 6, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Pere", Amount = 3, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 120, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Vanilie", Amount = 1, Unit = "păstaie", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Faceți aluatul din făină, nuci, zahăr și unt. Răciți 45 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți fructele cu zahăr și vanilie 10 minute, apoi adăugați făină și răciți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Întindeți aluatul în formă, adăugați umplutura și decorați cu fâșii împletite." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți 15 minute la 220°C, apoi 60 minute la 190°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tartă cu pere și alune de pădure",
                Description = "Tartă elegantă cu pere poșate, cremă de alune și sirop aromat.",
                ImageUrl = "/uploads/tarta-pere-alune.png",
                PrepTime = TimeSpan.FromMinutes(60),
                CookTime = TimeSpan.FromMinutes(65),
                Servings = 10,
                Difficulty = Difficulty.Hard,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Alune măcinate", Amount = 50, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Unt moale", Amount = 300, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 220, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Pere tari", Amount = 900, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr brun", Amount = 200, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Ghimbir pudră", Amount = 1, Unit = "linguriță", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Faceți aluatul cu alune și răciți. Coaceți oarb 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Poșați perele în sirop de zahăr brun cu anason." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Faceți crema de alune cu unt, zahăr, ouă, făină și ghimbir." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Umpleți crusta cu cremă și pere. Coaceți 45 minute la 200°C." }
                }
            },
            // Batch 13: Tarta cu spanac - Varza cu kaiser (Final batch)
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tartă cu spanac și feta în crustă de cartofi dulci",
                Description = "Tartă sănătoasă cu spanac și feta, într-o crustă crocantă de cartofi dulci.",
                ImageUrl = "/uploads/tarta-spanac-feta.png",
                PrepTime = TimeSpan.FromMinutes(25),
                CookTime = TimeSpan.FromMinutes(55),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Mediteraneană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Cartofi dulci", Amount = 2, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 1, Unit = "linguriță", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Spanac proaspăt", Amount = 150, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 125, Unit = "ml", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Albușuri", Amount = 2, Unit = "bucăți", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză feta", Amount = 50, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tăiați cartofii dulci felii subțiri și formați crusta în tavă. Coaceți 20 minute la 190°C." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți ceapa și spanacul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați ouăle cu laptele, sarea și piperul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Puneți spanacul, amestecul de ouă și feta în crustă. Coaceți 35 minute." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tartă de mere și pere",
                Description = "Tartă simplă și pufoasă cu felii de mere și pere.",
                ImageUrl = "/uploads/tarta-de-mere-si-pere.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(35),
                Servings = 8,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 60, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 100, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 150, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Vanilie", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Mere", Amount = 2, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Pere", Amount = 2, Unit = "bucăți", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Bateți ouăle cu zahărul și vanilia. Adăugați untul topit și făina." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Puneți felii de mere în tavă, turnați jumătate din compoziție." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați felii de pere și restul de compoziție." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Coaceți 30-35 minute la 180°C. Ornați cu zahăr pudră." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tartar de păstrăv",
                Description = "Tartar proaspăt de păstrăv cu capere, castravete și ulei de măsline.",
                ImageUrl = "/uploads/tartar-de-pastrav.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Franțuzească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "File de păstrăv", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă roșie", Amount = 1, Unit = "bucată", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Capere", Amount = 2, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Castraveți murați", Amount = 3, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Gogoșar roșu", Amount = 0.5, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 3, Unit = "linguri", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel", Amount = 1, Unit = "legătură", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Zeamă de lămâie", Amount = 3, Unit = "linguri", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tăiați fileul de păstrăv foarte fin." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Tocați mărunt ceapa, gogosarul, pătrunjelul, caperele și castraveții." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Amestecați toate ingredientele și condimentați cu ulei, zeamă de lămâie, sare și piper." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Serviți pe pâine prăjită cu unt." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tiramisu clasic",
                Description = "Tiramisu tradițional italian cu mascarpone, cafea și cacao.",
                ImageUrl = "/uploads/tiramisu.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 8,
                Difficulty = Difficulty.Medium,
                CuisineType = "Italiană",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ouă întregi", Amount = 3, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Gălbenușuri", Amount = 3, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 175, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 500, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Cafea espresso", Amount = 350, Unit = "ml", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Pișcoturi", Amount = 25, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Cacao", Amount = 30, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Gătiți ouăle cu zahărul pe baie de abur până ating 75°C. Răciți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Bateți mascarpone ușor și incorporați crema de ouă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Înmuiați pișcoturile în cafea și alternați straturi de pișcoturi și cremă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Răciți 6 ore și pudrați cu cacao." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tiramisu de portocale",
                Description = "Varianta proaspătă de tiramisu cu portocale și mascarpone.",
                ImageUrl = "/uploads/tiramisu-portocale.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Italiană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Portocale", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Frișcă naturală", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 200, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 100, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Coajă de portocală", Amount = 1, Unit = "bucată", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Pișcoturi", Amount = 6, Unit = "bucăți", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Ciocolată neagră", Amount = 30, Unit = "g", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tăiați o portocală cubulețe, stoarceți restul pentru suc." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mixați mascarpone cu zahărul și sucul. Adăugați frișca și bateți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Înmuiați pișcoturile în suc și aranjați straturi cu crema și bucăți de portocale." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Răciți și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tocană de legume",
                Description = "Tocană consistentă de vară cu legume proaspete și verdeață.",
                ImageUrl = "/uploads/tocana-de-legume.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Fasole verde", Amount = 200, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Cartofi", Amount = 300, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Dovlecel", Amount = 200, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Vinete", Amount = 200, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Broccoli", Amount = 150, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii", Amount = 200, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Pastă de tomate", Amount = 70, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel", Amount = 1, Unit = "legătură", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Tocați verdeața și roșiile separat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți ceapa în ulei, adăugați pasta de tomate și roșiile." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Gătiți legumele la abur sau fierbeți pe rând." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Combinați legumele cu sosul și adăugați verdeața." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tocană de miel cu măsline",
                Description = "Tocană aromată de miel cu măsline și ceapă murată, rețetă Jamie Oliver.",
                ImageUrl = "/uploads/tocana-de-miel-masline.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(120),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Mediteraneană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Rozmarin proaspăt", Amount = 15, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Spată de miel", Amount = 800, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Măsline colorate", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă murată", Amount = 280, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Roșii conservă", Amount = 800, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de măsline", Amount = 1, Unit = "lingură", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Prăjiți rozmarinul în ulei, apoi scoateți-l. Rumetiți carnea tăiată cuburi." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Adăugați măslinele și ceapa murată." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați roșiile și apă. Coaceți la 170°C timp de 2 ore." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Presărați rozmarinul crocant deasupra și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tocăniță de hribi cu mămăligă",
                Description = "Tocăniță aromată de hribi și ghebe cu mămăligă cremoasă și brânză de burduf.",
                ImageUrl = "/uploads/tocanita-hribi.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(45),
                Servings = 4,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = true,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ceapă verde", Amount = 2, Unit = "legături", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Hribi congelați", Amount = 300, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ghebe congelate", Amount = 150, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Urechi de lemn", Amount = 30, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână grasă", Amount = 2, Unit = "linguri", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 6, Unit = "căței", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Mălai", Amount = 240, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Brânză de burduf", Amount = 200, Unit = "g", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți mămăliga: amestecați mălaiul cu smântână și supă, coaceți 30 minute la 175°C, adăugați brânza și mai coaceți 15 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Hidratați urechile de lemn în apă fierbinte." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Căliți ceapa în unt și ulei, adăugați ciupercile tocate și gătiți 15 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați smântâna, usturoiul și pătrunjelul. Serviți cu mămăliga." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tocăniță de miel",
                Description = "Tocăniță fragedă de miel cu sos cremos de smântână și usturoi.",
                ImageUrl = "/uploads/tocanita-miel.png",
                PrepTime = TimeSpan.FromMinutes(20),
                CookTime = TimeSpan.FromMinutes(90),
                Servings = 6,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Carne de miel (pulpă)", Amount = 800, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Morcovi", Amount = 3, Unit = "bucăți", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă mare", Amount = 1, Unit = "bucată", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Foi de dafin", Amount = 2, Unit = "bucăți", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Smântână 30%", Amount = 400, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Amidon", Amount = 3, Unit = "linguri", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Usturoi", Amount = 1, Unit = "căpățână", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Pătrunjel", Amount = 1, Unit = "legătură", Order = 8 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți carnea cu ceapa, morcovii și dafin aproximativ 1.5 ore până se frăgezește." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați smântâna cu amidonul, usturoiul și piperul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Temperați smântâna cu supă fierbinte, apoi turnați în oală și fierbeți până se îngroașă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Adăugați pătrunjel și serviți." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tort de biscuiți cu cremă de brânză și căpșuni",
                Description = "Tort răcoritor fără coacere cu biscuiți, cremă de brânză și căpșuni.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 10,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Mascarpone", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Cremă de brânză Almette", Amount = 150, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Miere", Amount = 3, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 200, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Biscuiți", Amount = 400, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Căpșuni", Amount = 300, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați mascarpone cu crema de brânză, vanilia, zeamă de lămâie și miere." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Înmuiați biscuiții în lapte și aranjați un strat în tavă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați cremă, căpșuni și repetați straturile." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Răciți minimum 5 ore sau peste noapte." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tort de toamnă cu cremă de brânză",
                Description = "Tort aromat cu piure de mere, nuci și cremă de brânză Philadelphia.",
                ImageUrl = "/uploads/tort-de-toamna.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(40),
                Servings = 12,
                Difficulty = Difficulty.Medium,
                CuisineType = "Americană",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Făină", Amount = 320, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr brun", Amount = 250, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei", Amount = 180, Unit = "ml", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Piure de mere", Amount = 200, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 4, Unit = "bucăți", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt", Amount = 250, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Nuci", Amount = 200, Unit = "g", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Cremă de brânză Philadelphia", Amount = 350, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Unt moale", Amount = 100, Unit = "g", Order = 9 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 300, Unit = "g", Order = 10 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați ouăle, zahărul, uleiul, iaurtul, vanilia și piureul. Adăugați făina cernută cu condimente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Încorporați nucile tăiate grosier. Împărțiți în 3 tăvi și coaceți." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Pentru cremă, mixați crema de brânză cu untul și zahărul pudră." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Asamblați tortul cu straturi de blat și cremă." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tort diplomat cu iaurt și fructe",
                Description = "Tort răcoritor cu iaurt, gelatină și fructe de pădure.",
                ImageUrl = "/uploads/tort-diplomat.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 10,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Zmeură sau fructe congelate", Amount = 500, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Iaurt 10%", Amount = 1, Unit = "kg", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr pudră", Amount = 300, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Gelatină", Amount = 25, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Vanilie", Amount = 1, Unit = "linguriță", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Pișcoturi sau pandișpan", Amount = 200, Unit = "g", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Amestecați fructele cu iaurtul și zahărul." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Hidratați și topiți gelatina (max 60°C). Temperați-o cu iaurt." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați amestecul peste blatul de pandișpan din forma." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Răciți până se închegă. Decorați cu fructe." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Tort raw de mango și fructul pasiunii",
                Description = "Tort vegan fără coacere cu cremă de caju, mango și fructul pasiunii.",
                ImageUrl = "/uploads/tort-raw-mango.png",
                PrepTime = TimeSpan.FromMinutes(45),
                CookTime = TimeSpan.FromMinutes(0),
                Servings = 10,
                Difficulty = Difficulty.Medium,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Fulgi de cocos", Amount = 150, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Fulgi de ovăz", Amount = 100, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Curmale", Amount = 133, Unit = "g", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Ulei de cocos", Amount = 100, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Caju înmuiat", Amount = 300, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Suc de lămâie", Amount = 100, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Sirop de arțar", Amount = 150, Unit = "ml", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Mango proaspăt", Amount = 250, Unit = "g", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Fructul pasiunii", Amount = 60, Unit = "ml", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Mixați fulgii și curmalele pentru blat. Presați în formă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mixați cajul cu zeamă de lămâie, sirop, mango, fructul pasiunii și ulei de cocos." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Turnați crema peste blat." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Congelați și scoateți cu timp înainte de servire." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Turtă dulce cu pastă de fructe uscate",
                Description = "Turtă dulce aromată cu pastă de curmale și fructe uscate.",
                ImageUrl = "/uploads/turta-dulce.png",
                PrepTime = TimeSpan.FromMinutes(30),
                CookTime = TimeSpan.FromMinutes(10),
                Servings = 24,
                Difficulty = Difficulty.Medium,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Curmale", Amount = 16, Unit = "bucăți", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Stafide", Amount = 2, Unit = "linguri", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Merișoare", Amount = 2, Unit = "linguri", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Lapte", Amount = 300, Unit = "ml", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Făină integrală", Amount = 320, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Unt", Amount = 100, Unit = "g", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Ou", Amount = 1, Unit = "bucată", Order = 7 },
                    new() { Id = Guid.NewGuid(), Name = "Condimente turtă dulce", Amount = 2, Unit = "lingurițe", Order = 8 },
                    new() { Id = Guid.NewGuid(), Name = "Scorțișoară", Amount = 2, Unit = "lingurițe", Order = 9 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Hidratați fructele uscate în lapte, apoi blendeați pentru a obține o pastă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Topiți untul și amestecați cu restul ingredientelor." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Răciți aluatul minimum 4 ore." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Întindeți foaie de 5-6mm, decupați și coaceți 9-10 minute la 180°C." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Unt de arahide",
                Description = "Unt de arahide de casă, simplu și natural.",
                ImageUrl = "/uploads/unt-de-arahide.png",
                PrepTime = TimeSpan.FromMinutes(5),
                CookTime = TimeSpan.FromMinutes(20),
                Servings = 20,
                Difficulty = Difficulty.Easy,
                CuisineType = "Internațională",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Arahide crude", Amount = 500, Unit = "g", Order = 1 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Prăjiți arahidele la cuptor la 150°C timp de 20 minute." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Mixați 10 secunde scurt, apoi 6 minute continuu până devine cremos." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Vargabeleș",
                Description = "Desert tradițional transilvănean cu paste, ricotta și stafide.",
                ImageUrl = "",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(30),
                Servings = 6,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Ricotta", Amount = 250, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Paste", Amount = 200, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ouă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Zahăr", Amount = 120, Unit = "g", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Stafide hidratate", Amount = 50, Unit = "g", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Vanilie", Amount = 1, Unit = "linguriță", Order = 6 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Fierbeți pastele al dente." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Amestecați ouăle cu brânza, zahărul, stafidele și vanilia. Adăugați pastele." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Puneți în formă și coaceți la 170-180°C până se rumenește." }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Varză călită cu kaizer",
                Description = "Varză călită aromată cu kaizer afumat și sos de roșii.",
                ImageUrl = "/uploads/varza-cu-kaiser.png",
                PrepTime = TimeSpan.FromMinutes(15),
                CookTime = TimeSpan.FromMinutes(15),
                Servings = 4,
                Difficulty = Difficulty.Easy,
                CuisineType = "Românească",
                IsFavorite = false,
                Ingredients = new List<Ingredient>
                {
                    new() { Id = Guid.NewGuid(), Name = "Kaizer afumat", Amount = 300, Unit = "g", Order = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Varză crudă", Amount = 700, Unit = "g", Order = 2 },
                    new() { Id = Guid.NewGuid(), Name = "Ceapă", Amount = 2, Unit = "bucăți", Order = 3 },
                    new() { Id = Guid.NewGuid(), Name = "Concentrat de legume", Amount = 1, Unit = "cub", Order = 4 },
                    new() { Id = Guid.NewGuid(), Name = "Piure de tomate", Amount = 3, Unit = "lingurițe", Order = 5 },
                    new() { Id = Guid.NewGuid(), Name = "Apă", Amount = 220, Unit = "ml", Order = 6 },
                    new() { Id = Guid.NewGuid(), Name = "Mărar", Amount = 1, Unit = "legătură", Order = 7 }
                },
                Instructions = new List<Instruction>
                {
                    new() { Id = Guid.NewGuid(), StepNumber = 1, Text = "Pregătiți sosul din apă fierbinte, concentrat de legume și pastă de tomate." },
                    new() { Id = Guid.NewGuid(), StepNumber = 2, Text = "Căliți ceapa tocată și kaizerul cuburi până ceapa devine sticloasă." },
                    new() { Id = Guid.NewGuid(), StepNumber = 3, Text = "Adăugați varza tocată și sosul de roșii." },
                    new() { Id = Guid.NewGuid(), StepNumber = 4, Text = "Gătiți la presiune sau fierbeți până varza este moale. Presărați mărar." }
                }
            }
        };

        db.Recipes.AddRange(recipes);
        await db.SaveChangesAsync();
    }
}
