using MC.Application.ModelDto.Master.Master;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Master.Document.Query.GetById
{
  public record GetByIdDocumentQuery(Guid Id) : IRequest<DocumentDetailDto>;
}
