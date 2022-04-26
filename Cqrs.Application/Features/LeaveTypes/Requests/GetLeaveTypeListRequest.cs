﻿using Cqrs.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveTypeListRequest:IRequest<List<LeaveTypeDto>>
    {

    }
}
