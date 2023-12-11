using RapidBlazor.Application.Common.Services.Data;
using RapidBlazor.Domain.Enums;
using RapidBlazor.WebUi.Shared.Common;
using RapidBlazor.WebUi.Shared.TodoLists;

namespace RapidBlazor.Application.TodoLists.Queries;

public sealed record GetTodoListQuery : IRequest<TodosVm>;

public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, TodosVm>
{
    private readonly IApplicationDbContext _context;

    public GetTodoListQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TodosVm> Handle(GetTodoListQuery request, 
        CancellationToken cancellationToken)
    {
        return new TodosVm
        {
            PriorityLevels = PriorityLevelExtensions.GetValues()
                .Select(p => new LookupDto { Id = (int)p, Title = p.ToStringFast() })
                .ToList(),
            Lists = await _context.TodoLists
                .ProjectToDto()
                .ToListAsync(cancellationToken)
        };
    }
}
