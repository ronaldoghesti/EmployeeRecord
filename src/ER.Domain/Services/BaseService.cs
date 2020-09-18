using ER.Domain.Interfaces;
using ER.Domain.Models;
using ER.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace ER.Domain.Services
{
    public class BaseService
    {
        private readonly INotifier _notificador;

        protected BaseService(INotifier notificador)
        {
            _notificador = notificador;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
