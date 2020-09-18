using ER.Domain.Interfaces;
using ER.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NToastNotify;
using System.Linq;
using System.Threading.Tasks;

namespace ER.MVC.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly INotifier _notifier;
        private readonly IToastNotification _toastNotification;

        public MainController(INotifier notifier, IToastNotification toastNotification)
        {
            _notifier = notifier;
            _toastNotification = toastNotification;
        }

        public abstract Task<IActionResult> Index();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
            {
                return RedirectToAction(nameof(Index));
            }

            return View(result);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorModelViewInvalid(modelState);
            return CustomResponse();
        }
        protected void NotifyErrorModelViewInvalid(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool IsValid()
        {
            if (_notifier.HasNotifications())
            {
                foreach (var erro in _notifier.GetNotifications())
                {
                    _toastNotification.AddErrorToastMessage(erro.Message);
                }

                return false;
            }

            return true;
        }
    }
}
