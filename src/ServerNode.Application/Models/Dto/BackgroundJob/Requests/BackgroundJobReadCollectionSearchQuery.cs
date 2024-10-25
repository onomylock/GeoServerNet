using MediatR;

namespace ServerNode.Application.Models.Dto.BackgroundJob.Requests;

public class BackgroundJobReadCollectionSearchQuery : 
    BackgroundJobReadCollectionSearchInDto,
    IRequest<BackgroundJobReadCollectionOutDto>;