﻿using Microsoft.AspNetCore.Mvc.Rendering;
using TripPortal.Models.Entities;

namespace TripPortal.Models
{
    public class AddReservationViewModel
    {
        public Guid TripID { get; set; }
        public Trip Trip { get; set; }
        public List<Trip> Trips { get; set; }
        public List<Student> Students { get; set; } // Lista studentów do wyboru
        public Guid SelectedStudentID { get; set; } // ID wybranego studenta
        public DateTime ReservationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PriceForAll { get; set; }
        //public Guid TripID { get; set; }
        //public string PaymentStatus { get; set; }
        //public List<int> SelectedStudents { get; set; }
        //public List<SelectListItem> Trips { get; set; }
        //public List<SelectListItem> StudentList { get; set; }

        //public AddReservationViewModel(List<Student> students, List<Trip> trips, List<int> lista)
        //{
        //    Trips = trips.Select(t => new SelectListItem { Value = t.TripID.ToString(), Text = t.Nazwa }).ToList();
        //    StudentList = students.Select(s => new SelectListItem { Value = s.StudentID.ToString(), Text = $"{s.Name} {s.Surname}" }).ToList();
        //    SelectedStudents = lista;
        //}
        //public AddReservationViewModel()
        //{
        //    Trips = new List<SelectListItem>();
        //    StudentList = new List<SelectListItem>();
        //    SelectedStudents = new List<int>();
        //}
    }
}