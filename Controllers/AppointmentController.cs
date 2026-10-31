using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartClinic.Data;
using SmartClinic.Models;

namespace SmartClinic.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
            
            ViewBag.LastBookedId = HttpContext.Session.GetInt32("LastBookedAppointmentId");
            return View(appointments);
        }

        public IActionResult Create()
        {
            ViewBag.Doctors = new SelectList(_context.Doctors, "DoctorId", "FullName");
            ViewBag.Patients = new SelectList(_context.Patients, "PatientId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (appointment.AppointmentDate < DateTime.Now)
            {
                ModelState.AddModelError("AppointmentDate", "Appointment date cannot be in the past.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("LastBookedAppointmentId", appointment.AppointmentId);
                TempData["SuccessMessage"] = "Appointment scheduled successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Doctors = new SelectList(_context.Doctors, "DoctorId", "FullName", appointment.DoctorId);
            ViewBag.Patients = new SelectList(_context.Patients, "PatientId", "FullName", appointment.PatientId);
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                appointment.Status = "Cancelled";
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Appointment cancelled.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
