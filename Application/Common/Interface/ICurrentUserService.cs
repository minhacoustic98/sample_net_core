using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interface
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}
