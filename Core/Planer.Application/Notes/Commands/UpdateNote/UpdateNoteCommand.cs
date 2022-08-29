using MediatR;

namespace Planer.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? Updated { get; set; }
    }
}
