using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using VerificationProvider.Services;

namespace VerificationProvider.Functions;

public class GenerateVerificationCode(ILogger<GenerateVerificationCode> logger, IVerificationService verificationServicd)
{
    private readonly ILogger<GenerateVerificationCode> _logger = logger;
    private readonly IVerificationService _verificationServicd = verificationServicd;


    [Function(nameof(GenerateVerificationCode))]
    [ServiceBusOutput("email-request", Connection = "ServiceBusConnection")]
    public async Task<string> Run([ServiceBusTrigger("verification_request", Connection = "ServiceBusConnection")] ServiceBusReceivedMessage message, ServiceBusMessageActions messageActions)
    {
        try
        {
            var verificationRequest = _verificationServicd.UnpackVerificationRequest(message);
            if (verificationRequest != null)
            {
                var code = _verificationServicd.GenerateCode();
                if (!string.IsNullOrEmpty(code))
                {
                    var result = await _verificationServicd.SaveVerificationRequest(verificationRequest, code);
                    if (result)
                    {
                        var emailRequest = _verificationServicd.GenerateEmailRequest(verificationRequest, code);
                        if (emailRequest != null)
                        {
                            var payload = _verificationServicd.GenerateServiceBusEmailRequest(emailRequest);
                            if (!string.IsNullOrEmpty(payload))
                            {
                                await messageActions.CompleteMessageAsync(message);
                                return payload;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"ERROR : GenerateVerificationCode.Run() :: {ex.Message}");
        }

        return null!;
    }



}
