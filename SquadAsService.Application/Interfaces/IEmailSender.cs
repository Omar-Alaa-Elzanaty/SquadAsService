﻿using Fiker.Domain.Dtos;

namespace Fiker.Application.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendNewMarketEmail(string marketName, List<string> email);
        Task<bool> SendNewTechnologyEmail(string technologyName, List<string> email);
        Task<bool> SendNewAreaEmail(string areaName, List<string> email);
        Task<bool> SendNewProfileEmail(string profileName, List<string> email);
        Task<bool> SendForgetPasswordEmailAsync(string email, string name, int otp);
        Task<bool> SendEmailConfirmationAsync(string email, int otp);
        Task<bool> SendOrderReportEmailAsync(string email, string copmany, MediaFormFileDto attachmentReport);
    }
}
