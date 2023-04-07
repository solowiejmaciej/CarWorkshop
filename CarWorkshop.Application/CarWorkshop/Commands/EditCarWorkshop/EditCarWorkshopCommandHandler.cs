using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    internal class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _repository;

        public EditCarWorkshopCommandHandler(ICarWorkshopRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByEncodedName(request.EncodedName!);

            carWorkshop.About = request.About;
            carWorkshop.Description = request.Description;
            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.EmailAddress = request.EmailAddress;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;

            await _repository.Commit();

            return Unit.Value;
        }
    }
}