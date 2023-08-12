using Domain.Note;
using Notes.Validation.Models;

namespace Notes.Validation.Services.Interfaces
{
    public interface INoteValidationService
    {
        ValidationResult[] ValidateNote(Note note);
    }
}
