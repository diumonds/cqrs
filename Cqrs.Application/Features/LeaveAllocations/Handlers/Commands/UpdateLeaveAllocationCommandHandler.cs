using AutoMapper;
using Cqrs.Application.DTOs.LeaveAllocation.Validators;
using Cqrs.Application.Features.LeaveAllocations.Requests.Commands;
using Cqrs.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leave;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leave, ILeaveTypeRepository leaveTypeRepository,
            //IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            //_unitOfWork = unitOfWork;
            _leave = leave;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            //var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);

            var leaveAllocation = await _leave.Get(request.LeaveAllocationDto.Id);

            //if (leaveAllocation is null)
            //    throw new NotFoundException(nameof(leaveAllocation), request.LeaveAllocationDto.Id);

            _mapper.Map(request.LeaveAllocationDto, leaveAllocation);

            await _leave.Update(leaveAllocation);
            //await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
