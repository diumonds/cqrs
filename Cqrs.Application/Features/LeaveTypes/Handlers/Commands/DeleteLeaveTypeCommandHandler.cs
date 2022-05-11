using AutoMapper;
using Cqrs.Application.Features.LeaveTypes.Requests.Commands;
using Cqrs.Application.Persistance.Contracts;
using Cqrs.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leave;

        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(/*IUnitOfWork unitOfWork*/ILeaveTypeRepository leave, IMapper mapper)
        {
            _leave = leave;
            //_unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leave.Get(request.Id);

            //if (leaveType == null)
            //    throw new NotFoundException(nameof(LeaveType), request.Id);

            await _leave.Delete(leaveType);
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
