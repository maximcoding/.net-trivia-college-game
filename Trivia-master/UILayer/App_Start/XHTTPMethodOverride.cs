// --------------------------------------------------------------------------------------------------------------------
//  <summary>
//   Class to handle the X-HTTP-Method-Override header
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TriviaGame.App_Start
{
    #region

    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    /// <summary>
    ///     Class to handle the X-HTTP-Method-Override header
    /// </summary>
    public class XHTTPMethodOverride : DelegatingHandler
    {
        #region Constants and Fields

        /// <summary>
        ///     The header to look for in the request header collection
        /// </summary>
        private const string Header = "X-HTTP-Method-Override";

        /// <summary>
        ///     Supported methods to re-write too.
        /// </summary>
        private readonly string[] Methods = {"DELETE", "HEAD", "PUT"};

        #endregion

        #region Methods

        /// <summary>
        /// Handle the async request
        /// </summary>
        /// <param name="request">
        /// The request object
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// A Task which processes the request
        /// </returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Check for HTTP POST with the X-HTTP-Method-Override header.
            if (request.Method == HttpMethod.Post && request.Headers.Contains(Header))
            {
                // Check if the header value is in our methods list.
                var method = request.Headers.GetValues(Header).FirstOrDefault();
                if (this.Methods.Contains(method, StringComparer.InvariantCultureIgnoreCase))
                {
                    // Change the request method.
                    request.Method = new HttpMethod(method);
                }
            }

            return base.SendAsync(request, cancellationToken);
        }

        #endregion
    }
}