using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaidClinicSimpleEf.Models;

namespace PaidClinicSimpleEf.Controllers;

// В конструкторе получаем доступ к контексту базы данных
// при помощи внедрения зависимости, dependency injection
public class AppointmentsController(ApplicationContext context) : Controller
{

    // GET /Appointments
    // GET /Appointments/Index
    // Вывод всех приемов
    public async Task<IActionResult> Index() {

        var appointments = await context
            .Appointments
            .AsNoTracking()
            .ToListAsync();

        return View(appointments);
    } // Index


    // Добавление записи - отправка формы клиенту
    public IActionResult Create() {
        return View();
    } // Create


    // Редактированение записи - отправка формы клиенту
    public IActionResult Edit(int id) {
        return View();
    }


    // Удаление записи, до реалиазации выводим страницу-заглушку
    public IActionResult Delete(int id) {
        return View();
    }

} // class AppointmentsController
