﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagingToolkit.Service.Common.Models;

namespace MessagingToolkit.Service.Provider.Commands
{
    public sealed class DeleteIncomingMessageCommand : ICommand<Incoming>
    {
        public string Id { get; set; }
    }
}
