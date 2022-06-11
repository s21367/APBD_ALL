using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efDataBase.Models
{
    public class s21367Context : DbContext
    {

        protected s21367Context()
        {

        }
            

        public s21367Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Prescription_Medicament> prescription_Medicaments { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Birthdate).IsRequired();

                p.HasData(
                    new Patient
                    {
                       IdPatient = 1, 
                       FirstName = "Tomasz", 
                       LastName = "Koło", 
                       Birthdate = DateTime.Parse("1995-04-18")
                    },
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Jan",
                        LastName = "Dyzma",
                        Birthdate = DateTime.Parse("1999-07-12")
                    }
                    );
            });

            modelBuilder.Entity<Doctor>(d =>
            {
                d.HasKey(e => e.IdDoctor);
                d.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                d.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                d.Property(e => e.Email).IsRequired().HasMaxLength(100);

                d.HasData(
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Arkadiusz",
                        LastName = "Nowak",
                        Email = "a.nowak@wp.pl"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Dariusz",
                        LastName = "Kowalski",
                        Email = "d.kowalski@wp.pl"
                    }
                    );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();

                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

                p.HasData(
                    new Prescription
                    {
                        IdPrescription = 1,
                        Date = DateTime.Parse("2022-05-21"),
                        DueDate = DateTime.Parse("2022-06-21"),
                        IdPatient = 1,
                        IdDoctor = 2
                    },
                    new Prescription
                    {
                        IdPrescription = 2,
                        Date = DateTime.Parse("2022-04-18"),
                        DueDate = DateTime.Parse("2022-05-18"),
                        IdPatient = 2,
                        IdDoctor = 1
                    }
                    );
            });

            modelBuilder.Entity<Medicament>(m =>
            {
                m.HasKey(e => e.IdMedicament);
                m.Property(e => e.Name).IsRequired().HasMaxLength(100);
                m.Property(e => e.Description).IsRequired().HasMaxLength(100);
                m.Property(e => e.Type).IsRequired().HasMaxLength(100);

                m.HasData(
                    new Medicament
                    {
                        IdMedicament = 1,
                        Name = "Nerwosol",
                        Description = "Bez recepty",
                        Type = "krople"
                    },
                    new Medicament
                    {
                        IdMedicament = 2,
                        Name = "LekNaWszystko",
                        Description = "Wymagana zgoda kierownika",
                        Type = "tabletki"
                    }
                    );
            });

            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.HasOne(e => e.Prescription).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdPrescription);
                p.HasKey(e => e.IdMedicament);
                p.HasOne(e => e.Medicament).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdMedicament);
                p.Property(e => e.Dose);
                p.Property(e => e.Details).IsRequired().HasMaxLength(100);

                p.HasData(
                    new Prescription_Medicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Dose = 1,
                        Details = "Przed śniadaniem"
                    },
                    new Prescription_Medicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 2,
                        Dose = 2,
                        Details = "Przed śniadaniem i kolacją"
                    },
                    new Prescription_Medicament
                    {
                        IdMedicament = 2,
                        IdPrescription = 2,
                        Dose = 1,
                        Details = "Na dobry start"
                    }

                    );
            });
        }

    }
}
