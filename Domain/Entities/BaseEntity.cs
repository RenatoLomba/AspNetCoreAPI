using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    //ENTIDADE BASE ONDE TODAS AS ENTIDADES HERDARÃO SEUS ATRIBUTOS
    public abstract class BaseEntity
    {
        [Key] //DATA ANNOTATION
        public Guid Id { get; set; } //IDENTIFICADOR GLOBAL UNICO PRIMARY KEY
        private DateTime? _createAt;

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpdateAt { get; set; }

    }
}
