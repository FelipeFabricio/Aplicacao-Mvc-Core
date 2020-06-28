using FluentValidation;
using FluentValidation.Results;
using MvcCore.Business.Interfaces;
using MvcCore.Business.Models;
using MvcCore.Business.Notificacoes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MvcCore.Business.Services
{
    public abstract class BaseService 
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }

    }
}
