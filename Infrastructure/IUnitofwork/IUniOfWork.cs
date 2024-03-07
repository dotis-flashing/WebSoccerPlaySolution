using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IUnitofwork
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        IAdminRepository Admin { get; }
        IBookingRepository Booking { get; }
        ICustomerRepository Customer { get; }
        IFeedBackRepository FeedBack { get; }
        ILandRepository Land { get; }
        IOwnerRepository Owner { get; }
        IPitchRepository Pitch { get; }
        IPitchImageRepository PitchImage { get; }
        IPriceRepository Price { get; }
        IScheduleRepository Schedule { get; }

        void Save();
    }
}
