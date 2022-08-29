using MediatR;
using Microsoft.EntityFrameworkCore;
using Planer.Application.Common.Exceptions;
using Planer.Application.Interfaces;

namespace Planer.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Guid> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _dbContext.Notes
                .FirstOrDefaultAsync(n => n.Id == request.Id);

            if (note == null || note.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(note), request.Id);
            }

            note.Title = request.Title;
            note.Details = request.Details;
            note.Updated = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
