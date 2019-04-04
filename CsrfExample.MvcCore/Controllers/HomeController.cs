using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CsrfExample.MvcCore.Models;
using CsrfExamples.Data;

namespace CsrfExample.MvcCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new IndexViewModel(DataStore.Instance);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(ProcessTransferViewModel transfer)
        {
            DataStore.Instance.TransferFunds(transfer.FromAccount, transfer.ToAccount, transfer.Amount);

            var viewModel = new IndexViewModel(DataStore.Instance);
            return View(viewModel);
        }
    }
}
