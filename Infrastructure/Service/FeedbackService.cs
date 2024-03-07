using Application.Common.Model.Request.RequestFeedback;
using Application.Common.Model.Response.ResponseFeedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface FeedbackService
    {
        Task<ResponseFeedback> CreateFeedBack(RequestFeedback requestFeedback);

        Task<List<ResponseFeedback>> GetFeedBackByLandId(Guid landId);
    }
}
