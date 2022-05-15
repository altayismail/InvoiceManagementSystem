using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OdemeSistemi.Concrete;

namespace OdemeSistemi.Tests.TestSetup
{
    public class CommonTestFixture
    {
        public Context Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseSqlServer("server=ISMAILALTAY; database=OdemeSistemiDB; integrated security=true;").Options;

            Context = new Context(options);
            Context.Database.EnsureCreated();
            Context.SaveChanges();
            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile.MappingProfile>(); }).CreateMapper();
        }
    }
}
