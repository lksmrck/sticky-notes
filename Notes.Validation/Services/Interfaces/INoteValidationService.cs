using Domain.Note;
using FluentValidation.Results;

namespace Notes.Validation.Services.Interfaces
{
    public interface INoteValidationService
    {
        ValidationResult ValidateNote(Note note);
    }
}
