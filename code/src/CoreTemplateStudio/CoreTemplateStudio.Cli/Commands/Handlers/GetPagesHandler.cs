﻿using System.Threading.Tasks;
using Microsoft.Templates.Cli.Commands.Contracts;
using Microsoft.Templates.Cli.Services.Contracts;

namespace Microsoft.Templates.Cli.Commands.Handlers
{
    public class GetPagesHandler : ICommandHandler<GetPagesCommand>
    {
        private readonly IMessageService _messageService;
        private readonly ITemplatesService _templatesService;

        public GetPagesHandler(IMessageService messageService, ITemplatesService templatesService)
        {
            _messageService = messageService;
            _templatesService = templatesService;
        }

        public async Task<int> ExecuteAsync(GetPagesCommand command)
        {
            var pages = _templatesService.GetPages(command.ProjectType, command.FrontendFramework, command.BackendFramework);
            _messageService.Send(pages);

            return await Task.FromResult(0);
        }
    }
}
