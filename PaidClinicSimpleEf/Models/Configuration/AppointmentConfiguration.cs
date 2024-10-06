using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaidClinicSimpleEf.Models.Configuration;

// класс конфигурации сущности Author для демонстрации задания конфигуратора
// атрибутиом в классе сущности 
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    void IEntityTypeConfiguration<Appointment>.Configure(EntityTypeBuilder<Appointment> builder) {

        #region Настройка полей таблицы, ограничения таблицы

        builder
            .Property(p => p.Doctor)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(150);

        builder
            .Property(p => p.Speciality)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);
        builder
            .Property(p => p.Price)
            .IsRequired();

        builder
            .Property(p => p.Patient)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(150);

        builder
            .Property(p => p.Age)
            .IsRequired();

        // SQL-ограничения значений, check constraints
        // https://metanit.com/sharp/efcore/2.9.php
        builder
            .ToTable(t => t.HasCheckConstraint("Price", "Price > 0"))
            .ToTable(t => t.HasCheckConstraint("Age", "Age > 18"));
        #endregion

        #region Инициализация таблицы авторов
        var appoinmtments = new List<Appointment>{
            new() {Id = 1, Date = new DateTime(2024, 4, 2), Doctor = "Романова А.В.", Speciality = "терапевт",    Patient = "Иванова А.Р.",    Age=23, Price = 500},
            new() {Id = 2, Date = new DateTime(2024, 4, 2), Doctor = "Романова А.В.", Speciality = "терапевт",    Patient = "Павловская Т.А.", Age=26, Price = 500},
            new() {Id = 3, Date = new DateTime(2024, 4, 3), Doctor = "Тарасов Р.П.",  Speciality = "хирург",      Patient = "Землякова В.В.",  Age=84, Price = 800},
            new() {Id = 4, Date = new DateTime(2024, 4, 3), Doctor = "Якубенко В.Я.", Speciality = "офтальмолог", Patient = "Иванов Ю.В.",     Age=56, Price = 600},
            new() {Id = 5, Date = new DateTime(2024, 4, 3), Doctor = "Тарасов Р.П.",  Speciality = "хирург",      Patient = "Городов Е.Е.",    Age=42, Price = 800},
        };

        // инициализация таблицы Appointments
        builder.HasData(appoinmtments);
        #endregion
    } // IEntityTypeConfiguration<Appointment>.Configure
} // class AppointmentConfiguration
