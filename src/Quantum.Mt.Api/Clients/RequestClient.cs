// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using MassTransit;
//
// namespace Quantum.Mt.Sample.Clients
// {
//     public class RequestClient<TRequest, TResponse>
//         where TRequest: class
//         where TResponse: class
//     {
//         public RequestClient(IRequestClient<TRequest> client)
//         {
//             _client = client ?? throw new ArgumentNullException(nameof(client));
//         }
//         
//         public Task<Response<TResponse>> GetResponse(
//             TRequest message,
//             CancellationToken cancellationToken = new CancellationToken(),
//             RequestTimeout timeout = new RequestTimeout())
//         {
//             return _client.GetResponse<TResponse>(message, cancellationToken, timeout);
//         }
//
//         private readonly IRequestClient<TRequest> _client;
//     }
// }