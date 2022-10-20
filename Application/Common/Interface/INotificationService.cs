using Application.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
