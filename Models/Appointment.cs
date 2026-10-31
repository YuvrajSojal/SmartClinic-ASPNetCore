using System.ComponentModel.DataAnnotations;

namespace SmartClinic.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Please select a patient.")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [Required(ErrorMessage = "Please select a doctor.")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [Required(ErrorMessage = "Appointment Date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string? Notes { get; set; }
    }
}
