using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Cqrs.Application.Persistance.Contracts;
using Cqrs.Application.DTOs.LeaveAllocation.Validators;
using Cqrs.Domain;
using Cqrs.Application.Features.LeaveAllocations.Requests.Commands;
using Cqrs.Application.Responses;

namespace Cqrs.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leave;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leave,ILeaveTypeRepository leaveTypeRepository,
           //IUnitOfWork unitOfWork,
           // IUserService userService,
            IMapper mapper)
        {
            //this._unitOfWork = unitOfWork;
            //this._userService = userService;
            _leave = leave;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Allocations Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var leaveType = await _leaveTypeRepository.Get(request.LeaveAllocationDto.LeaveTypeId);
                //var employees = await _userService.GetEmployees();
                var period = DateTime.Now.Year;
                var allocations = new List<LeaveAllocation>();
                //foreach (var emp in employees)
                //{
                //    if (await _leave.AllocationExists(/*emp.Id,*/ leaveType.Id, period))
                //        continue;
                //    allocations.Add(new LeaveAllocation
                //    {
                //        EmployeeId = emp.Id,
                //        LeaveTypeId = leaveType.Id,
                //        NumberOfDays = leaveType.DefaultDays,
                //        Period = period
                //    });
                //}

                await _leave.AddAllocations(allocations);
                //await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Allocations Successful";
            }


            return 1;
        }
    }
}
