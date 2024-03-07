﻿using Application.Common.Enum;
using Application.Common.Model.Request.RequestAccount;
using Application.Common.Model.Response.ResponseAccount;
using AutoMapper;
using Domain;
using Infrastructure.IUnitofwork;
using Infrastructure.Security.HashPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Imp
{
    public class CustomerImplement : CustomerService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerImplement(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseAccountCustomer> CreateCustomer(RequestAccountCustomer request)
        {
            var customer = _mapper.Map<Customer>(request);
            customer.Status = ACCOUNTENUM.ACTIVE.ToString();
            customer.Account.Role = ROLEENUM.CUSTOMER.ToString();
            customer.Account.Password = _passwordHasher.HashPassword(request.Password);
            _unitOfWork.Customer.Add(customer);
            _unitOfWork.Account.Add(customer.Account);
            _unitOfWork.Save();
            return _mapper.Map<ResponseAccountCustomer>(customer);
        }
    }
}
