using MC.Application.ModelDto.Master.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Master.DocumentType.Query.GetById
{
  public record GetByIdDocumentTypeQuery(Guid Id) : IRequest<DocumentTypeDetailDto>;
}
