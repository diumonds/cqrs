using AutoMapper;
using Cqrs.Application.DTOs.LeaveRequest.Validators;
using Cqrs.Application.Features.LeaveRequests.Requests.Commands;
using Cqrs.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leave;

        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leave,
            //IUnitOfWork unitOfWork,
             IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leave = leave;
            //this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            //if(leaveRequest is null)
            //    throw new NotFoundException(nameof(leaveRequest), request.Id);

            if (request.LeaveRequestDto != null)
            {
                var validator = new UpdateLeaveRequestDtoValidator(_leave);
                //var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
                //if (validationResult.IsValid == false)
                //    throw new ValidationException(validationResult);

                _mapper.Map(request.LeaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
                //await _unitOfWork.Save();
            }
            else if(request.ChangeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
                //if (request.ChangeLeaveRequestApprovalDto.Approved)
                //{
                //    //var allocation = await _unitOfWork.LeaveAllocationRepository.GetUserAllocations(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                //    int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

                //    allocation.NumberOfDays -= daysRequested;

                //    await _unitOfWork.LeaveAllocationRepository.Update(allocation);
                //}

                //await _unitOfWork.Save();
            }

            return Unit.Value;
        }
    }
}
