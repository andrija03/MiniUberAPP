using MediatR;

namespace SharedKernel.Queries
{
    public class GetRequestByIdQuery : IRequest<Request> 
    {
        public Guid Id { get; set; }
    }
}
