using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharedKernel.Infrastructure.Pagination
{
    public class PagedResult<IEntity>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IList<IEntity> Items { get; set; }
    }
}
