using MediatR;
using Microsoft.EntityFrameworkCore;
using Planer.Application.Common.Exceptions;
using Planer.Application.Interfaces;
using Planer.Domain;

namespace Planer.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public DeleteNoteCommandHandler(INotesDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<Guid> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _dbContext.Notes.Remove(entity);
            return entity.Id;
        }
    }
}
