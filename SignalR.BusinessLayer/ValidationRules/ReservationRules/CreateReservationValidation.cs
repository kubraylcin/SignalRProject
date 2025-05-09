using FluentValidation;
using SignalR.DtoLayer.ReservationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.ReservationRules
{
    public class CreateReservationValidation:AbstractValidator<CreateReservationDto>
    {
        public CreateReservationValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim Alanı Boş Geçilemez!");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez!")
                .Must(phone => phone.StartsWith("5") && phone.Length == 10)
                .WithMessage("Telefon numarası 5 ile başlamalı ve 10 karakterli olmalıdır!");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail Alanı Boş Geçilemez!")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz!");

            RuleFor(x => x.PersonCount)
                .NotEmpty().WithMessage("Kişi Alanı Boş Geçilemez!");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez!");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir");
        }
    }
}
