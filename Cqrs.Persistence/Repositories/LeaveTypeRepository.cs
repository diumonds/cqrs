
using Cqrs.Application.Persistance.Contracts;
using Cqrs.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cqrs.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
 