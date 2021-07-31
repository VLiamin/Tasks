using Homework5.Data.Models;
using Homework5.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.Mappers
{
    public class UserViewModelMapper
    {
        public UserViewModel Transform(User user, UserViewModel userViewModel)
        {
            userViewModel.User = user;

            return userViewModel;
        }
    }
}
