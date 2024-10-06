using Microsoft.EntityFrameworkCore;
using PaidClinicSimpleEf.Models.Configuration;

namespace PaidClinicSimpleEf.Models;

// сущность для хранения в таблице БД - сведения о врачебном приеме
// Атрибут задания класса конфигурирования сущности 
[EntityTypeConfiguration(typeof(AppointmentConfiguration))]
public class Appointment
{
    public int Id { get; set; }

    // Дата приема
    public DateTime Date {
        get;
        set;
        // set
    } // Date


    // Фамилия и инициалы доктора, проводящего прием
    public string Doctor { get; set; } = null!; // Doctor

    // Фамилия и инициалы пациента
    public string Patient { get; set; } = null!; // Patient

    // Возраст пациента, полных лет
    public int Age { get; set; } // Age


    // Врачебная специальность доктора
    public string Speciality { get; set; } = null!; // Patient

    // Стоимость приема
    public int Price { get; set; } // Price

} // class Appointment
