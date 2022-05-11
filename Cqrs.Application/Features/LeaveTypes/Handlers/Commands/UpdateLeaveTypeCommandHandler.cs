using AutoMapper;
using Cqrs.Application.DTOs.LeaveType.Validators;
using Cqrs.Application.Features.LeaveTypes.Requests.Commands;
using Cqrs.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveType;

        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveType, IMapper mapper)
        {
            //_unitOfWork = unitOfWork;
            _leaveType = leaveType;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            ////var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            //if (validationResult.IsValid == false)
            //    throw new ValidationException(validationResult);

            var leaveType = await _leaveType.Get(request.LeaveTypeDto.Id);

            //if (leaveType is null)
            //    throw new NotFoundException(nameof(leaveType), request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, leaveType);

            await _leaveType.Update(leaveType);
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
