using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Abstract
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
    }
}
