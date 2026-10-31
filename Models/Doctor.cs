using System.ComponentModel.DataAnnotations;

namespace SmartClinic.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Specialization { get; set; } = string.Empty;

        [Range(0, 10000, ErrorMessage = "Fee must be a valid amount.")]
        public decimal ConsultationFee { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
