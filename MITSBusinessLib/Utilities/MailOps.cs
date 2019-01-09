﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MITSBusinessLib.Utilities
{

    public interface IMailOps
    {
       void Send(string toAddress, int registrationId, string QRCode);
    }

    public class MailOps : IMailOps
    {
        private readonly string _server;
        private readonly int _port;
        private readonly string _userName;
        private readonly string _pasword;

        public MailOps(IConfiguration config )
        {
           _server = config.GetSection("EmailConfiguration:Server").Value;
           _port = int.Parse(config.GetSection("EmailConfiguration:Port").Value);
           _userName = config.GetSection("EmailConfiguration:Username").Value;
           _pasword = config.GetSection("EmailConfiguration:Password").Value;
        }

        public void Send(string toAddress, int registrationId, string QRCode)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("John Smith", "enderjs@gmail.com"));
            message.From.Add(new MailboxAddress("MITS 2019", "AFCEAMITS2019@gmail.com"));
            message.Subject = "This is the subject";

            var builder = new BodyBuilder();

            builder.HtmlBody = string.Format(@"
            Hello,

You have successfully registered

 <img alt=""Embedded QR Code"" height=""200px"" width=""200px"" src=""data: image / jpeg; base64, {0}"" />

                ", QRCode);

            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(_server, _port);
                client.Authenticate(_userName, _pasword);
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                client.Send(message);
                client.Disconnect(true);
            }

        }
        
    }
}
