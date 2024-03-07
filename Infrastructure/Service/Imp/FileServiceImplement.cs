﻿using Application.Common.Model.Request.RequestFile;
using Application.Common.Model.Response.ResponseFile;
using AutoMapper;
using Azure.Storage.Blobs;
using Domain;
using Infrastructure.IUnitofwork;
using Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class FileServiceImplement : FileService
    {
        private readonly AppConfiguration _appConfiguration;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FileServiceImplement(BlobServiceClient blobServiceClient, AppConfiguration appConfiguration, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _blobServiceClient = blobServiceClient;
            _appConfiguration = appConfiguration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Stream> Get(string name)
        {
            var containerInstance = _blobServiceClient.GetBlobContainerClient(_appConfiguration.ContainerName);

            var blobInstance = containerInstance.GetBlobClient(name);

            var downloadContent = await blobInstance.DownloadAsync();
            return downloadContent.Value.Content;
        }

        public async Task<ResponseFile> UploadFile(RequestFile file)
        {
            var pitchI = _mapper.Map<PitchImage>(file);
            await _unitOfWork.Land.GetLandByIdLand(pitchI.LandId);
            //get container instance
            var containerInstance = _blobServiceClient.GetBlobContainerClient(_appConfiguration.ContainerName);
            // get file name from request and upload to azure blob storage
            var blobName = $"{Guid.NewGuid()}";
            // local file path
            var blobInstance = containerInstance.GetBlobClient(blobName);

            // upload file to azure blob storage
            await blobInstance.UploadAsync(file.ImageLogo.OpenReadStream());
            pitchI.Name = blobInstance.Uri.AbsoluteUri;
            _unitOfWork.PitchImage.Add(pitchI);
            _unitOfWork.Save();
            return _mapper.Map<ResponseFile>(pitchI);
        }
    }
}
