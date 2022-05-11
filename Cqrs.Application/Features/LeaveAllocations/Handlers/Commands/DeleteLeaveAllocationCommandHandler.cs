using AutoMapper;
using Cqrs.Application.Features.LeaveAllocations.Requests.Commands;
using Cqrs.Application.Persistance.Contracts;
using Cqrs.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ILeaveAllocationRepository _leave;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leave, IMapper mapper)
        {
            //_unitOfWork = unitOfWork;
            _leave = leave;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leave.Get(request.Id);

            //if (leaveAllocation == null)
            //    throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            await _leave.Delete(leaveAllocation);
            //await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
