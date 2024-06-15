using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using ClinicHistoryPro.Infraestructure.Ports;

namespace ClinicHistoryPro.Application.Services
{
    public class FormAppService : IFormAppService
    {
        private readonly IUnitOfWork unitOfWork;
        public FormAppService(IUnitOfWork unitOfWork) => (this.unitOfWork) = (unitOfWork);
        public async Task<List<Form>> GetManyForm()
        {
            try
            {
                return await unitOfWork.Repository<Form>().GetManyAsync(
                    selector: form => new Form
                    {
                        Id = form.Id,
                        Name = form.Name,
                        //Inputs = (ICollection<Input>)form.Inputs.OrderBy(o => o.Id)
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<Form> GetOneForms(string url)
        {
            try
            {
                return await unitOfWork.Repository<Form>().GetOneAsync(
                    selector: form => new Form
                    {
                        Id = form.Id,
                        Name = form.Name,
                        //Inputs = (ICollection<Input>)form.Inputs.OrderBy(o => o.Id)
                    },
                    predicate: form => form.Url.Equals(url)
                );
            }
            catch
            {
                throw;
            }
        }
    }
}
