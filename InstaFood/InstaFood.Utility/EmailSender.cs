/*
    Description: EmailSender class
    
    Author: WarOfDevil          Date: 06-03-2020
*/

using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Threading.Tasks;

namespace InstaFood.Utility
{
    /// <summary>
    /// Email sender class, handle async send email for user registration
    /// </summary>
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// Method invoked when a new user register and an email need to be sended for confirmation
        /// </summary>
        /// <param name="email">User target email</param>
        /// <param name="subject">Email subject</param>
        /// <param name="htmlMessage">Email HTML format message</param>
        /// <returns>Return a task</returns>
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
