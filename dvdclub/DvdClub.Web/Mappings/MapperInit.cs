using AutoMapper;
using DvdClub.Web.Mappings.Profile;

namespace DvdClub.Web.Mappings {
    public class MapperInit {   //This is my service
        public static MapperConfiguration Init() {
            var configuration = new MapperConfiguration(config => {
                //add the profiles
                config.AddProfile<MovieProfile>();
                //config.AddProfile<MemberProfile>();
                //config.AddProfile<RentalsProfile>();

            });
            configuration.AssertConfigurationIsValid();
            //var mapper = configuration.CreateMapper();
            return configuration;
        }
    }
}