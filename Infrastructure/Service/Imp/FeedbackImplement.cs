using Application.Common.Model.Request.RequestFeedback;
using Application.Common.Model.Response.ResponseFeedback;
using AutoMapper;
using Domain;
using Infrastructure.IUnitofwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class FeedbackImplement : FeedbackService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackImplement(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseFeedback> CreateFeedBack(RequestFeedback requestFeedback)
        {
            var booking = await _unitOfWork.Booking.GetBookingByCustomerId(requestFeedback.CustomerId);
            if (booking == false)
            {
                throw new Exception("Bạn không thể đánh giá sân bóng này !");
            }
            var feedBack = _mapper.Map<Feedback>(requestFeedback);
            feedBack.Date = DateTime.Now;
            _unitOfWork.FeedBack.Add(feedBack);
            _unitOfWork.Save();
            return _mapper.Map<ResponseFeedback>(feedBack);
        }

        public async Task<List<ResponseFeedback>> GetFeedBackByLandId(Guid landId)
        {
            var feedBacks = await _unitOfWork.FeedBack.GetByFeedBackLandId(landId);
            var response = _mapper.Map<List<ResponseFeedback>>(feedBacks);
            return response;
        }
    }
}
