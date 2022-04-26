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
    public class GetLeaveTypeListHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>  
    {
        private readonly ILeaveTypeRepository _leaveRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListHandler(ILeaveTypeRepository leaveRepository,IMapper mapper)
        {
            _leaveRepository = leaveRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeList = await _leaveRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypeList);
        }
    }
}
