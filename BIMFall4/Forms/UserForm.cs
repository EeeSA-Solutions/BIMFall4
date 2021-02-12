using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFall4.Forms
{
    public class UserForm : User, IForm
    {
        private string _erroMessage = "";
        public string ErrorMessage { get { return _erroMessage; } }

        public bool isValid()
        {
            //if(!this.Email_isValid())
            //{
            //    this._erroMessage = "This email is already in use";
            //    return false;
            //}
            //else if(!this.Password_isValid())
            //{
            //    this._erroMessage = "Password must be more than 8 characters";
            //    return false;
            //}
            return true;
        }

        bool Email_isValid()
        {
            return true;
        }

        bool Password_isValid()
        {
            if (Password.Length < 8)
                return false;
            return true;
        }
    }
}