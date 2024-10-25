using Shared.Application.Services.Base;
using File = Shared.Domain.Entity.File;

namespace ServerNode.Application.Services.Data;

public interface IFileEntityService : IEntityServiceBase<File>;