using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ER.Application.Services;
using ER.Application.ViewModels;
using ER.MVC.Controllers;
using NToastNotify;
using ER.Domain.Interfaces;

namespace ER.MVC
{
    public class RecordsController : MainController
    {
        private readonly IRecordAppService _recordService;

        public RecordsController(IRecordAppService recordService,
                                IToastNotification toastNotification,
                                INotifier notifier) : base(notifier, toastNotification)
        {
            _recordService = recordService;
        }

        public override async Task<IActionResult> Index()
        {
            return View(await _recordService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecordViewModel recordVM)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _recordService.Create(recordVM);
            return CustomResponse(recordVM);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var record = await _recordService.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RecordViewModel recordVM)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _recordService.Update(recordVM);
            return CustomResponse(recordVM);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var record = await _recordService.GetById(id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _recordService.Delete(id);
            return CustomResponse();
        }
    }
}
