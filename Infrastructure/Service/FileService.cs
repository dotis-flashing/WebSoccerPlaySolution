using Application.Common.Model.Request.RequestFile;
using Application.Common.Model.Response.ResponseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface FileService
    {
        Task<Stream> Get(string name);

        Task<ResponseFile> UploadFile(RequestFile file);
    }
}
