using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.CourseQuery
{
    public class GetCourseByIdQuery : IRequest<CourseResponse>
    {
        public GetCourseByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
