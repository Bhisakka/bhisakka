using Bhisakka.DataAccess;
using Bhisakka.Models;
using System.Collections.Generic;

namespace Bhisakka.Services
{
    internal class QueueManager
    {
        private readonly ConsultationRepository consultationRepository;

        public QueueManager()
        {
            consultationRepository = new ConsultationRepository();
        }

        public List<CheckInEntry> GetScheduledForToday()
        {
            return consultationRepository.GetScheduledForToday();
        }

        public List<QueueEntry> GetLiveQueue()
        {
            return consultationRepository.GetLiveQueue();
        }

        public void CheckIn(int appointmentId)
        {
            consultationRepository.CheckIn(appointmentId);
        }

        public int CallNext(int appointmentId, int patientId, int doctorId, decimal defaultFee)
        {
            return consultationRepository.CallNext(appointmentId, patientId, doctorId, defaultFee);
        }

        public void CompleteConsultation(int consultationId, int appointmentId, string diagnosis, string notes, decimal fee)
        {
            consultationRepository.CompleteConsultation(consultationId, appointmentId, diagnosis, notes, fee);
        }

        public List<MedicineOption> GetActiveMedicines()
        {
            return consultationRepository.GetActiveMedicines();
        }

        public int CreatePrescription(int consultationId)
        {
            return consultationRepository.CreatePrescription(consultationId);
        }

        public void AddPrescriptionItem(int prescriptionId, int medicineId, int quantity, string dosageInstructions)
        {
            consultationRepository.AddPrescriptionItem(prescriptionId, medicineId, quantity, dosageInstructions);
        }
    }
}
