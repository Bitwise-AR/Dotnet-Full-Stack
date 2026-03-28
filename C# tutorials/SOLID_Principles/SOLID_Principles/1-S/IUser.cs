using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.SRP
{
    interface IUser
    {
        bool Login(string username, string password);
        bool Register(string username, string password, string email);
    }

    interface ILogger
    {
        void LogError(string error);
    }

    interface IEmail
    {
        bool SendEmail(string emailContent);
    }
}
