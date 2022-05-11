
using Cqrs.Application.DTOs.Common;
using Cqrs.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        //public Employee Employee { get; set; }
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
    }
}
