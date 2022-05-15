using AutoMapper;
using FluentAssertions;
using OdemeSistemi.Application.OdemeOperation.Commands;
using OdemeSistemi.Concrete;
using OdemeSistemi.Tests.TestSetup;
using System;
using Xunit;

namespace OdemeSistemi.Tests.Application.OdemeOperation.Commands
{
    public class AddOdemeCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public AddOdemeCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.Context;
            _mapper = commonTestFixture.Mapper;
        }

        [InlineData("123","1","2","124","Aasdas AAasd")]
        [Theory]
        public void WhenInvalidKrediKartıInfoIsGiven_InvalidOperationException_ShouldBeThrown(string kartNumarası, string sonKullanımAy, string sonKullanımYıl, string CVV, string kartUzerindekiIsim)
        {
            AddOdemeCommand command = new AddOdemeCommand(_context, _mapper);
            command.Model = new AddOdemeViewModel
            {
                OdemeKartNumarası = kartNumarası,
                OdemeKartNumarasıSonKullanımAy = sonKullanımYıl,
                OdemeKartNumarasıSonKullanımYıl = sonKullanımAy,
                OdemeKrediKartıCVV = CVV,
                OdemeKrediKartıUzerindekiIsim = kartUzerindekiIsim,
                OdemeNetTutarı = 150,
                OdemeParaBirimi = "TL",
                OdemeTarihi = DateTime.Now,
                OdemeYapanKullancıIpAdresi = "192.168.1.1",
                OdemeYapanKullanıcıId = 1,
                OdemeYapanKullanıcıEmail = "ismailaltay@mail.com",
                OdemeYapanKullanıcıIsim = "İsmail",
                OdemeYapanKullanıcıSoyisim = "Altay",
                OdemeYapanKullanıcıSehir = "İzmir",
                OdemeYapanKullanıcıTCNo = "12341234123",
                OdemeYapanKullanıcıUlke = "Türkiye"
            };

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And
                .Message.Should().Be("Girdiğiniz kart bilgileri hatalı.");
        }
    }
}
