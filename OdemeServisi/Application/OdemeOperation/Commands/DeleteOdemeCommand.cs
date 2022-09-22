using OdemeSistemi.Concrete;
using System;
using System.Linq;

namespace OdemeSistemi.Application.OdemeOperation.Commands
{
    public class DeleteOdemeCommand
    {
        private readonly Context _context;
        public DeleteOdemeCommand(Context context)
        {
            _context = context;
        }
        public int OdemeId { get; set; }

        public void Handle()
        {
            var odeme = _context.Odemeler.SingleOrDefault(x => x.OdemeId == OdemeId);

            if (odeme is null)
                throw new InvalidOperationException("İlgili ID'ye sahip ödeme bulunamadı");

            _context.Odemeler.Remove(odeme);
            _context.SaveChanges();
        }
    }
}
