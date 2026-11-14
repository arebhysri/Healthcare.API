using Healthcare.Interface.IRepository;
using Healthcare.model;
using Healthcare.Services;

namespace Healthcare.UnitTest
{
    public class AppointmentServiceTests
    {
        [Fact]
        public async Task CreateAppointment_saves_and_returns_the_new_id()
        {
            var service = new AppointmentService(new FakeRepo());

            var result = await service.CreateAppointmentAsync(NewAppointment(patientId: 42));

            Assert.Equal(100, result.Id);
            Assert.Equal(42, result.PatientId);
        }

        [Fact]
        public async Task CreateAppointment_in_the_past_is_rejected()
        {
            var service = new AppointmentService(new FakeRepo());
            var appointment = NewAppointment(patientId: 42);
            appointment.AppoinmentDate = DateTime.Now.AddDays(-1);

            await Assert.ThrowsAsync<Exception>(() => service.CreateAppointmentAsync(appointment));
        }

        private static Appointment NewAppointment(int patientId) => new()
        {
            PatientId = patientId,
            DoctorId = 7,
            AppoinmentDate = DateTime.Now.AddDays(3),
            Status = 0,
            Type = 0,
        };

        private class FakeRepo : IAppointmentRepository
        {
            public Task AddAppointmentAsync(Appointment appointment)
            {
                appointment.Id = 100; // what the DB identity column would assign
                return Task.CompletedTask;
            }

            public Task<IEnumerable<Appointment>> GetAllByPatient(int patientId) => throw new NotImplementedException();
            public Task<Appointment> GetAppointmentById(int id) => throw new NotImplementedException();
            public Task UpdateAppointmentAsync(Appointment appointment) => throw new NotImplementedException();
        }
    }
}
