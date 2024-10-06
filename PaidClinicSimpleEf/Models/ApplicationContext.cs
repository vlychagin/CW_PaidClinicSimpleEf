using Microsoft.EntityFrameworkCore;

namespace PaidClinicSimpleEf.Models;

// База данных приложения
public class ApplicationContext : DbContext
{
    // Таблица базы данных

    // врачебные приемы
    public DbSet<Appointment> Appointments => Set<Appointment>();


    // конструктор / конструкторы
    // !!! Критически важно !!!
    // Создание конструктора с параметром - опциями 
    // Делали только конструктор по умолчанию, это приводило к падению при запуске
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) {

        // гарантированное удаление БД
        Database.EnsureDeleted();

        // гарантированное создание БД
        Database.EnsureCreated();
    } // ApplicationContext

} // class ApplicationContext
