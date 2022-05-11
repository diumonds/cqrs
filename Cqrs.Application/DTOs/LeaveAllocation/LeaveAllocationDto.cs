
using Cqrs.Application.DTOs.Common;
using Cqrs.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        //public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
