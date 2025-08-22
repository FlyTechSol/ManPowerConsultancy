using MC.Application.ModelDto.Registration;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Application.Features.Registration.Training.Query.GetById
{
   public record GetTrainingByIdQuery(Guid Id) : IRequest<TrainingDetailDto>;
}
