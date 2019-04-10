using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersManagerService.Models;
using OrdersManagerService.Services;

namespace OrdersManager.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly IOrdersManagerService orderManagerService;

        public OrderItemsController(IOrdersManagerService context)
        {
            orderManagerService = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            return View(await orderManagerService.GetAllItemsAsync());
        }

        // GET: OrderItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await orderManagerService.GetAsync(id.Value);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Count,Weight")] OrderItem orderItem)
        {
            orderItem.Status = 0;

            if (ModelState.IsValid)
            {
                await orderManagerService.Create(orderItem);
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await orderManagerService.GetAsync(id.Value);
            if (orderItem == null)
            {
                return NotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,QuantityId,Count,Weight")] OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await orderManagerService.Update(orderItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await OrderItemExists(orderItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await orderManagerService.GetAsync(id.Value);
            if (orderItem == null)
            {
                return NotFound();
            }


            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await orderManagerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OrderItemExists(int id)
        {
            return (await orderManagerService.GetAllItemsAsync()).ToList().Any(e => e.Id == id);
        }

        public async Task<IActionResult> DeleteOrder()
        {
            await orderManagerService.ClearList();
            return RedirectToAction(nameof(Index));
        }
    }
}
