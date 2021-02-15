using BIMFall4.Manager;
using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Forms
{
    public class UserForm : IForm
    {
        private User user;
        private string _errorMessage = "";
        

        public string ErrorMessage { get { return _errorMessage; } }


        public UserForm(User user)
        {
            this.user = user;
        }

        public bool isValid()
        {
            if(!Email_isValid())
            {
                _errorMessage = "This email is already in use";
                return false;
            }
            else if(!Password_isValid())
            {
                _errorMessage = "Password must be more than 8 characters";
                return false;
            }
            return true;
        }

        bool Email_isValid()
        {
            if (UserManager.GetUserByEmail(user.Email) != null)
                return false;
            return true;
        }

        bool Password_isValid()
        {
            if(user.Password.Length < 8)
                return false;
            return true;
        }
    }
}