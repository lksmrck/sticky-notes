﻿using Domain.Note;
using FluentValidation.Results;
using Notes.Validation.Services.Interfaces;
using Notes.Validation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Validation.Services
{
    public class NoteValidationService : INoteValidationService
    {
        private readonly NoteValidator _noteValidator;

        public NoteValidationService(NoteValidator noteValidator)
        {
            _noteValidator = noteValidator;
        }
        public ValidationResult ValidateNote(Note note)
        {
            var validationResult = _noteValidator.Validate(note);

            return validationResult;
        }
    }
}
