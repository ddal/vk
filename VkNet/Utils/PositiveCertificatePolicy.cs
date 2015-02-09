using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VkNet.Utils
{
    public class PositiveCertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(
            ServicePoint srvPoint,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            WebRequest request,
            int certificateProblem)
        {
            // We always know than https://vk.com is a good one.
            return true;
        }

        public bool ServerCertificateValidationCallback(
            object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            // We always know than https://vk.com is a good one.
            return true;
        }
    }
}
