using System.ComponentModel.DataAnnotations;
using MediatR;
using Shared.Common.Models.Dto;
using Shared.Common.Models.DTO.Base;

namespace ServerNode.Application.Models.Dto.File.Requests;

public class FileDownloadCommand : IRequest<OkOutDto>, IInDto
{
    [Required] public Uri Uri { get; set; }
    public string Path { get; set; }
}