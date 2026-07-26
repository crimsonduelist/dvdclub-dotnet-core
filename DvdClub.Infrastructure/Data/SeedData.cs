using DvdClub.Domain.Entities;
using DvdClub.Domain.Enumeration;
using Microsoft.AspNetCore.Identity;

namespace DvdClub.Infrastructure.Data {
    public static class SeedData {
        public static async Task SeedAsync(DvdClubDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
            db.Database.EnsureCreated();

            if (!db.Roles.Any()) {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            if (!db.Users.Any())
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@dvdclub.gr",
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(admin, "admin");
                await userManager.AddToRoleAsync(admin, "Admin");

                var nick = new ApplicationUser
                {
                    UserName = "nick",
                    Email = "nick@dvdclub.gr",
                    FirstName = "Nick",
                    LastName = "Papadopoulos",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(nick, "pass123");
                await userManager.AddToRoleAsync(nick, "Employee");

                var maria = new ApplicationUser
                {
                    UserName = "maria",
                    Email = "maria@dvdclub.gr",
                    FirstName = "Maria",
                    LastName = "Georgiou",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(maria, "pass123");
                await userManager.AddToRoleAsync(maria, "Employee");

                var user = new ApplicationUser {
                    UserName = "user",
                    Email = "user@dvdclub.gr",
                    FirstName = "User",
                    LastName = "Account",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "user");
                await userManager.AddToRoleAsync(user, "Employee");
            }


            if (!db.Customers.Any()) {
                var customers = new List<Customer> {
                    new Customer("Giorgos Papadopoulos", "giorgos@mail.gr", "6971234567", MembershipType.Regular),
                    new Customer("Eleni Christou", "eleni@mail.gr", "6972345678", MembershipType.Premium),
                    new Customer("Dimitris Ioannou", "dimitris@mail.gr", "6973456789", MembershipType.Regular),
                    new Customer("Sofia Andreou", "sofia@mail.gr", "6974567890", MembershipType.Premium),
                    new Customer("Nikos Papas", "nikos@mail.gr", "6975678901", MembershipType.Regular),
                    new Customer("Anna Voulgaris", "anna@mail.gr", "6976789012", MembershipType.Regular),
                    new Customer("Kostas Michailidis", "kostas@mail.gr", "6977890123", MembershipType.Premium),
                    new Customer("Maria Lamprou", "maria.l@mail.gr", "6978901234", MembershipType.Regular),
                    new Customer("Petros Georgakopoulos", "petros@mail.gr", "6979012345", MembershipType.Regular),
                    new Customer("Zoe Karvouni", "zoe@mail.gr", "6970123456", MembershipType.Premium),
                };
                db.Customers.AddRange(customers);
                db.SaveChanges();
            }

            if (!db.Movies.Any()) {
                var movies = new List<Movie> {
                    // Drama (12)
                    new Movie("The Shawshank Redemption", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", Genre.DRAMA),
                    new Movie("The Godfather", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", Genre.DRAMA),
                    new Movie("The Dark Knight", "When the menace known as the Joker wreaks havoc on Gotham, Batman must face one of the greatest psychological tests.", Genre.DRAMA),
                    new Movie("Schindler's List", "In German-occupied Poland during World War II, Oskar Schindler becomes concerned for his Jewish workforce.", Genre.DRAMA),
                    new Movie("Forrest Gump", "The story of a man with a low IQ who accomplished great things in his life and was present during historic events.", Genre.DRAMA),
                    new Movie("Inception", "A thief who steals corporate secrets through dream-sharing technology is given the task of planting an idea.", Genre.DRAMA),
                    new Movie("The Matrix", "A computer programmer discovers that reality as he knows it is a simulation created by machines.", Genre.DRAMA),
                    new Movie("Goodfellas", "The story of Henry Hill and his life in the mob, covering his relationship with his wife and his mob partners.", Genre.DRAMA),
                    new Movie("Fight Club", "An insomniac office worker and a devil-may-care soap maker form an underground fight club.", Genre.DRAMA),
                    new Movie("The Departed", "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang.", Genre.DRAMA),
                    new Movie("Gladiator", "A former Roman General sets out to exact vengeance against the emperor who murdered his family.", Genre.DRAMA),
                    new Movie("Saving Private Ryan", "Following the Normandy landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper.", Genre.DRAMA),
                    // Comedy (12)
                    new Movie("Superbad", "Two co-dependent high school seniors are forced to deal with separation anxiety after their plan to stage a party goes awry.", Genre.COMEDY),
                    new Movie("The Hangover", "Three buddies wake up from a bachelor party in Las Vegas with no memory of the previous night and the bachelor missing.", Genre.COMEDY),
                    new Movie("Step Brothers", "Two aimless middle-aged losers still living at home are forced against their will to become roommates when their parents marry.", Genre.COMEDY),
                    new Movie("Bridesmaids", "Competition between the maid of honor and a bridesmaid threatens to upend the life of an out-of-work pastry chef.", Genre.COMEDY),
                    new Movie("The Grand Budapest Hotel", "A writer encounters the owner of an aging high-class hotel, who tells of his early years serving as a lobby boy.", Genre.COMEDY),
                    new Movie("Groundhog Day", "A weatherman finds himself inexplicably living the same day over and over again.", Genre.COMEDY),
                    new Movie("Monty Python and the Holy Grail", "King Arthur and his knights embark on a absurd, comic quest for the Holy Grail.", Genre.COMEDY),
                    new Movie("The Big Lebowski", "Jeff 'The Dude' Lebowski is mistaken for a millionaire, and two thugs urinate on his rug.", Genre.COMEDY),
                    new Movie("Shaun of the Dead", "A man decides to turn his moribund life around by winning back his former girlfriend, but it's complicated by a zombie outbreak.", Genre.COMEDY),
                    new Movie("Mrs. Doubtfire", "A divorced actor disguises himself as a female housekeeper to spend time with his children.", Genre.COMEDY),
                    new Movie("The Nice Guys", "A private eye investigates the apparent suicide of a fading porn star in 1970s Los Angeles.", Genre.COMEDY),
                    new Movie("What We Do in the Shadows", "A documentary-style comedy about the lives of vampire roommates living in New Zealand.", Genre.COMEDY),
                    // Romance (12)
                    new Movie("When Harry Met Sally", "Harry and Sally have known each other for years, and are very good friends, but they fear sex would ruin the friendship.", Genre.ROMANCE),
                    new Movie("The Notebook", "A poor yet passionate young man falls in love with a rich young woman, giving her a sense of freedom.", Genre.ROMANCE),
                    new Movie("La La Land", "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations.", Genre.ROMANCE),
                    new Movie("Crazy Rich Asians", "An American-born Chinese economics professor accompanies her boyfriend to Singapore for his best friend's wedding.", Genre.ROMANCE),
                    new Movie("Pride and Prejudice", "Sparks fly when spirited Elizabeth Bennet meets single, rich, and proud Mr. Darcy.", Genre.ROMANCE),
                    new Movie("50 First Dates", "A guy meets a woman who has short-term memory loss and must win her over each day.", Genre.ROMANCE),
                    new Movie("The Princess Bride", "A bedridden boy's grandfather reads him the story of a farmboy-turned-pirate who encounters numerous obstacles.", Genre.ROMANCE),
                    new Movie("Before Sunrise", "A young man and woman meet on a train in Europe and end up spending one evening together in Vienna.", Genre.ROMANCE),
                    new Movie("Eternal Sunshine of the Spotless Mind", "When their relationship turns sour, a couple undergoes a medical procedure to have each other erased from their memories.", Genre.ROMANCE),
                    new Movie("Amelie", "Amelie is an innocent and naive girl in Paris with her own sense of justice, who decides to help those around her.", Genre.ROMANCE),
                    new Movie("Titanic", "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", Genre.ROMANCE),
                    new Movie("The Proposal", "A pushy boss forces her young assistant to marry her in order to keep her Visa status in the U.S.", Genre.ROMANCE),
                };

                db.Movies.AddRange(movies);
                db.SaveChanges();

                foreach (var movie in movies) {
                    var numCopies = movie.Genre == Genre.DRAMA ? 3 : 2;
                    for (int i = 0; i < numCopies; i++) {
                        db.Copies.Add(new Copy { MovieId = movie.Id, Availability = true });
                    }
                }
                db.SaveChanges();

                var rentedMovieTitles = new List<string> {
                    "The Shawshank Redemption",
                    "The Godfather",
                    "The Dark Knight",
                    "Superbad",
                    "The Hangover"
                };

                foreach (var title in rentedMovieTitles) {
                    var copy = db.Copies.FirstOrDefault(c => c.Movie.Title == title && c.Availability);
                    if (copy != null) {
                        copy.Availability = false;
                    }
                }
                db.SaveChanges();

                var customers = db.Customers.ToList();
                var unavailableCopies = db.Copies.Where(c => !c.Availability).ToList();
                var rentals = new List<Rental>();
                int dayOffset = -1;
                int customerIndex = 0;
                foreach (var copy in unavailableCopies) {
                    var customer = customers[customerIndex % customers.Count];
                    rentals.Add(new Rental {
                        CopyId = copy.Id,
                        CustomerId = customer.Id,
                        DateRented = DateTime.Now.AddDays(dayOffset),
                        ExpectedReturnDate = DateTime.Now.AddDays(dayOffset + 14),
                        State = State.ACTIVE,
                        Comments = "Regular rental"
                    });
                    dayOffset -= 3;
                    customerIndex++;
                }

                var matrixCopy = db.Copies.FirstOrDefault(c => c.Movie.Title == "The Matrix");
                if (matrixCopy != null) {
                    rentals.Add(new Rental {
                        CopyId = matrixCopy.Id,
                        CustomerId = customers[0].Id,
                        DateRented = DateTime.Now.AddDays(-25),
                        ExpectedReturnDate = DateTime.Now.AddDays(-11),
                        ActualReturnDate = DateTime.Now.AddDays(-10),
                        State = State.RETURNED,
                        Comments = "Returned on time"
                    });
                }

                db.Rentals.AddRange(rentals);
                db.SaveChanges();
            }
        }
    }
}
