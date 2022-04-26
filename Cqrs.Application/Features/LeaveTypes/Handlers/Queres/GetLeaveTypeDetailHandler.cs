using AutoMapper;
using Cqrs.Application.DTOs;
using Cqrs.Application.Features.LeaveTypes.Requests;
using Cqrs.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Application.Features.LeaveTypes.Handlers.Queres
{
    public class GetLeaveTypeDetailHandler : IRequestHandler<GetleaveTypeDetailRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _ileavetyperepository;
        private readonly IMapper _imapper;

        public GetLeaveTypeDetailHandler(ILeaveTypeRepository ileavetyperepository,IMapper imapper)
        {
            _ileavetyperepository = ileavetyperepository;
            _imapper = imapper;
        }
        public async Task<LeaveTypeDto> Handle(GetleaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = _ileavetyperepository.Get(request.Id);
            return _imapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
