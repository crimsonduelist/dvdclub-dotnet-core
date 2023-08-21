
/*not yet using*/

/*namespace DvdClub.Core.Entities {
    public class ExtendedUser : IdentityUser {
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        public ICollection<Rental> Rentals { get; set; }

        *//*Additional Config For Identity*//*
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ExtendedUser> manager) {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}*/

/*not yet using*/