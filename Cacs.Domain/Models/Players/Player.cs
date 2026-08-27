using System;
using System.Collections.Generic;
using System.Text;
using Cacs.Domain.Models.SeedWork;

namespace Cacs.Domain.Models.Players
{
    public class Player: Entidade, IAggregateRoot
    {
        private string _email;

        private string _name;
    }
}
